using AutoMapper;
using Datos.EF.Modelos;
using System.Xml.Serialization;
using Datos.EF;
using Microsoft.EntityFrameworkCore;
using Datos.EF.Context;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Negocio.Modulos.Configuraciones.Empresas
{
    public class EmpresasServicios
    {
        private readonly DatosSQL<Empresa> _repository;
        private readonly IMapper _mapper;
        private readonly OpenSuiteDbContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public EmpresasServicios(DatosSQL<Empresa> repository, OpenSuiteDbContext context, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
        }


        /// <summary>
        /// Listar todas las empresas
        /// </summary>
        /// <returns></returns>
        public async Task<List<Entidades.Configuraciones.Empresa>> ListarEmpresas()
        {

            // Ejemplo con filtro, orden, include y asNoTracking
            var empresas = await _repository.GetAllAsync(
                                filter: e => e.Estado == true,
                                orderBy: q => q.OrderBy(e => e.EmpresaID),
                                include: q => q
                                    .Include(e => e.Pais)
                                    .Include(e => e.EmpresaGiroEconomico)
                                        .ThenInclude(g => g.TipoGiro)
                                    .Include(e => e.EmpresaContacto),
                                asNoTracking: true
            );



            // Mapeo de modelos a entidad Empresa
            return _mapper.Map<List<Entidades.Configuraciones.Empresa>>(empresas);


        }

        /// <summary>
        /// Detalle de una empresa por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Entidades.Configuraciones.Empresa?> ObtenerEmpresa(int id)
        {
            try
            {
                var empresa = await _repository.GetByIdAsync(
                                keyValue: 1,
                                keySelector: e => e.EmpresaID,
                                include: q => q
                                    .Include(e => e.Pais)
                                    .Include(e => e.EmpresaGiroEconomico)
                                        .ThenInclude(g => g.TipoGiro)
                                    .Include(e => e.EmpresaContacto),
                                asNoTracking: true
                );

                if (empresa == null) return null;


                return _mapper.Map<Entidades.Configuraciones.Empresa?>(empresa);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Crear una nueva empresa
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<Entidades.Configuraciones.Empresa> CrearEmpresas(Entidades.Configuraciones.Empresa dto)
        {
            try
            {
                var entity = _mapper.Map<Empresa>(dto);
                var creada = await _repository.InsertAsync(entity);
                return _mapper.Map<Entidades.Configuraciones.Empresa>(creada);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Crear una empresa con sus datos de contacto, giros economicos, monedas, dueños, etc.
        /// </summary>
        /// <param name="empresa"></param>
        /// <returns></returns>
        public async Task<bool> CrearEmpresaCompleta(Entidades.Configuraciones.Empresa dto)
        {
            var empresa = _mapper.Map<Empresa>(dto);

            // Iniciamos la transacción usando el método genérico
            return await _repository.ExecuteInTransactionAsync(async () =>
            {
                // Insertamos la empresa sin guardar aún
                await _repository.InsertWithoutSaveAsync(empresa);

                // acignar EmpresaID generado a las entidades hijas
                empresa.EmpresaDueno.ToList().ForEach(d => d.EmpresaID = empresa.EmpresaID);
                empresa.EmpresaContacto.ToList().ForEach(c => c.EmpresaID = empresa.EmpresaID);
                empresa.EmpresaGiroEconomico.ToList().ForEach(g => g.EmpresaID = empresa.EmpresaID);
                empresa.CentroCosto.ToList().ForEach(cc => cc.EmpresaID = empresa.EmpresaID);
                empresa.EmpresaMoneda.ToList().ForEach(m => m.EmpresaID = empresa.EmpresaID);

                // Insertar todas las colecciones hijas automáticamente
                await InsertColeccionesRelacionadasAsync(empresa);

            });
        }

        /// <summary>
        /// Obtener una empresa por ID usando un procedimiento almacenado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Entidades.Configuraciones.Empresa?> verEmpresa(int id)
        {
            try
            {

                var parametros = new[]{ 
                    new SqlParameter("@EmpresaID", id),
                    new SqlParameter("@Salida", SqlDbType.NVarChar, 100) { Direction = ParameterDirection.Output }
                };


                /// Ejecutar el procedimiento almacenado
                //var (empresa, salidas) = await _repository.EjecutarProcedimiento<Datos.EF.Modelos.Empresa>("sp_ObtenerEmpresa", parametros);
                var (_, salidas) = await _repository.EjecutarProcedimiento<object>("sp_ObtenerEmpresa", parametros);

                // 
                if (salidas == null) return null;

                // Mapeo de modelos a entidad Empresa
                return new Entidades.Configuraciones.Empresa();
            }
            catch (Exception x)
            {

                throw new Exception(x.Message);
            }
        }

        /// <summary>
        /// Inserta todas las colecciones relacionadas de una entidad Empresa
        /// </summary>
        /// <param name="empresa"></param>
        /// <returns></returns>
        private async Task InsertColeccionesRelacionadasAsync(Empresa empresa)
        {


            // Recorremos todas las propiedades ICollection<T>
            var propiedades = empresa.GetType().GetProperties()
                .Where(p => p.PropertyType.IsGenericType &&
                            typeof(IEnumerable<>).IsAssignableFrom(p.PropertyType.GetGenericTypeDefinition()))
                .ToList();

            foreach (var prop in propiedades)
            {
                // Tipo de entidad hija
                var tipoEntidad = prop.PropertyType.GetGenericArguments()[0];

                // Lista de objetos
                var lista = (IEnumerable<object>?)prop.GetValue(empresa);
                if (lista == null || !lista.Any()) continue;

                // Asignar EmpresaID si existe
                foreach (var item in lista)
                {
                    var empresaIDProp = item.GetType().GetProperty("EmpresaID");
                    if (empresaIDProp != null)
                        empresaIDProp.SetValue(item, empresa.EmpresaID);
                }

                // Agregar al DbSet correspondiente
                var method = typeof(DbContext).GetMethod("Set")?.MakeGenericMethod(tipoEntidad);
                var dbSet = method?.Invoke(_context, null);
            }
        }



    }
}
