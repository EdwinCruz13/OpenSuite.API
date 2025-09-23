using AutoMapper;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;

using Datos.ADO;
using Datos.EF;
using Datos.EF.Modelos;
using Datos.EF.Context;
using Microsoft.AspNetCore.Http;
using Shared.ExcelReader;

namespace Negocio.Modulos.Finanzas.PlanCuentas
{
    /// <summary>
    /// Servicio para gestionar el plan de cuentas, incluyendo niveles y naturalezas y plan de cuentas
    /// </summary>
    public class PlanCuentasServicios 
    {
        
       
       

        private readonly DatosSQL<PlanCuentaNaturaleza> _repositorioNatraleza;
        private readonly DatosSQL<PlanCuentaNivel> _repositorioNivel;
        private readonly DatosSQL<PlanCuenta> _repositorioPlan;

        private readonly IMapper _mapper;
        private readonly OpenSuiteDbContext _context;
        private readonly DatosSQL _datosADO;


        /// <summary>
        /// servicios de plan de cuentas
        /// </summary>
        /// <param name="repositorioNatraleza"></param>
        /// <param name="repositorioNivel"></param>
        /// <param name="repositorioPlan"></param>
        /// <param name="context"></param>
        /// <param name="datosSQL"></param>
        /// <param name="mapper"></param>
        public PlanCuentasServicios(
            DatosSQL<PlanCuentaNaturaleza> repositorioNatraleza,
            DatosSQL<PlanCuentaNivel> repositorioNivel,
            DatosSQL<PlanCuenta> repositorioPlan,
            OpenSuiteDbContext context,
            Datos.ADO.DatosSQL datosSQL,
            IMapper mapper)
        {
            _repositorioNatraleza = repositorioNatraleza;
            _repositorioNivel = repositorioNivel;
            _repositorioPlan = repositorioPlan;
            _context = context;
            _datosADO = datosSQL;
            _mapper = mapper;
        }

        #region "PlanCuentas"


        /// <summary>
        /// Obtiene todos los planes de cuentas de una empresa específica.
        /// </summary>
        /// <param name="empresaID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Entidades.Finanzas.PlanCuentas.PlanCuenta>> ListarPlanCuentas(int empresaID)
        {
            try
            {
                /// obtener todas las cuentas de una empresa
                var listado = await _repositorioPlan.GetAllAsync(
                    filter: f => f.EmpresaID == empresaID,
                    include: q => q
                        .Include(c => c.Nivel)
                        .Include(c => c.Naturaleza)
                        .Include(c => c.Estado),
                    asNoTracking: true,
                    orderBy: q => q.OrderBy(c => c.CuentaID)
                    );

                ///  Retornar la lista mapeada
                var listadoEntidad = _mapper.Map<List<Entidades.Finanzas.PlanCuentas.PlanCuenta>>(listado);

                return listadoEntidad;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Obtiene todos los planes de cuentas de una empresa específica en formato jerárquico.
        /// </summary>
        /// <param name="empresaID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Entidades.Finanzas.PlanCuentas.PlanCuentaEstructurada>> ListarPlanCuenta_Estructurada(int empresaID)
        {
            try
            {
                ///  crear la lista vacia
                List<Entidades.Finanzas.PlanCuentas.PlanCuentaEstructurada> listado = new List<Entidades.Finanzas.PlanCuentas.PlanCuentaEstructurada>();

                /// crear el string de consulta
                string str = "exec spr_Finanzas_PlanCuenta_CuentaEstructurada " + empresaID.ToString() + "";
                /// obtener todas las cuentas de una empresa
                var dt = _datosADO.ObtenerDatos(str).Tables[0];

                // Mapear el DataTable a la lista usando AutoMapper
                if (dt.Rows.Count > 0)
                    listado = dt.AsEnumerable().Select(row => _mapper.Map<Entidades.Finanzas.PlanCuentas.PlanCuentaEstructurada>(row)).ToList();
                

                ///  Retornar la lista mapeada
                return listado;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }






        /// <summary>
        /// Obtiene todos los planes de cuentas de una empresa específica.
        /// </summary>
        /// <param name="empresaID"></param>
        /// <param name="cuentaID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Entidades.Finanzas.PlanCuentas.PlanCuenta> ObtenerPlanCuenta(int empresaID, string cuentaID, bool incluyeHijos = false)
        {
            try
            {
                /// obtener todas las cuentas de una empresa
                var listado = await _repositorioPlan.GetAsync(
                    predicate: f => f.EmpresaID == empresaID && f.CuentaID.ToString() == cuentaID,
                    include: q => q
                        // ==== CUENTA PRINCIPAL ====
                        .Include(c => c.Nivel)
                        .Include(c => c.Naturaleza)
                        .Include(c => c.Estado)

                        //shit
                        // ==== PADRES (hasta 3 niveles) ====
                        .Include(c => c.Padre)
                            .ThenInclude(p => p.Naturaleza)
                        .Include(c => c.Padre)
                            .ThenInclude(p => p.Estado)
                        .Include(c => c.Padre)
                            .ThenInclude(p => p.Nivel)

                        .Include(c => c.Padre)
                            .ThenInclude(p => p.Padre)
                                .ThenInclude(pp => pp.Naturaleza)
                        .Include(c => c.Padre)
                            .ThenInclude(p => p.Padre)
                                .ThenInclude(pp => pp.Estado)
                        .Include(c => c.Padre)
                            .ThenInclude(p => p.Padre)
                                .ThenInclude(pp => pp.Nivel)

                        .Include(c => c.Padre)
                            .ThenInclude(p => p.Padre)
                                .ThenInclude(pp => pp.Padre)
                                    .ThenInclude(ppp => ppp.Naturaleza)
                        .Include(c => c.Padre)
                            .ThenInclude(p => p.Padre)
                                .ThenInclude(pp => pp.Padre)
                                    .ThenInclude(ppp => ppp.Estado)
                        .Include(c => c.Padre)
                            .ThenInclude(p => p.Padre)
                                .ThenInclude(pp => pp.Padre)
                                    .ThenInclude(ppp => ppp.Nivel)

                        // ==== HIJOS mejor uno, para esa gracia mejor devuelvo el arbolito en otro metodo ====
                        // solo las hijas directa
                        .Include(c => c.InversePadre)
                            .ThenInclude(h => h.Naturaleza)
                        .Include(c => c.InversePadre)
                            .ThenInclude(h => h.Estado)
                        .Include(c => c.InversePadre)
                            .ThenInclude(h => h.Nivel),

                        //.Include(c => c.InversePadre)
                        //    .ThenInclude(h => h.InversePadre)
                        //        .ThenInclude(h2 => h2.Naturaleza)
                        //.Include(c => c.InversePadre)
                        //    .ThenInclude(h => h.InversePadre)
                        //        .ThenInclude(h2 => h2.Estado)
                        //.Include(c => c.InversePadre)
                        //    .ThenInclude(h => h.InversePadre)
                        //        .ThenInclude(h2 => h2.Nivel)

                        //.Include(c => c.InversePadre)
                        //    .ThenInclude(h => h.InversePadre)
                        //        .ThenInclude(h2 => h2.InversePadre)
                        //            .ThenInclude(h3 => h3.Naturaleza)
                        //.Include(c => c.InversePadre)
                        //    .ThenInclude(h => h.InversePadre)
                        //        .ThenInclude(h2 => h2.InversePadre)
                        //            .ThenInclude(h3 => h3.Estado)
                        //.Include(c => c.InversePadre)
                        //    .ThenInclude(h => h.InversePadre)
                        //        .ThenInclude(h2 => h2.InversePadre)
                        //            .ThenInclude(h3 => h3.Nivel),
                    asNoTracking: true
                 );

                ///  Retornar la lista mapeada
                var listadoEntidad = _mapper.Map<Entidades.Finanzas.PlanCuentas.PlanCuenta>(listado);

                return listadoEntidad;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Inserta un nuevo nodo (cuenta) en el plan de cuentas.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Entidades.Finanzas.PlanCuentas.PlanCuenta> InsertarNodo(Entidades.Finanzas.PlanCuentas.PlanCuentaDTO dto)
        {
            try
            {
                //obtener el codigo contable
                var ExisteCodigo = await _repositorioPlan.GetAsync(
                    predicate: f => f.EmpresaID == dto.EmpresaID && f.CodigoContable == dto.Cuenta,
                    asNoTracking: true
                 );

                // validar que no exista el codigo contable
                if (ExisteCodigo != null)
                    throw new Exception($"El codigo contable {dto.Cuenta} ya existe en la empresa");


                //buscar al padre en caso que sea hijo de otro
                var padre = await _repositorioPlan.GetAsync(
                    predicate: f => f.EmpresaID == dto.EmpresaID && f.CodigoContable == dto.Padre,
                    asNoTracking: true
                 );

                // obtener el maxID para el modelo
                var maxID = await _repositorioPlan.GetMaxIdAsync(keySelector: e => e.CuentaID);


                /// Mapear a modelo y asignar los valores restantes
                var modelo = _mapper.Map<Datos.EF.Modelos.PlanCuenta>(dto);
                modelo.CuentaID = maxID + 1; //asignar manualmente CuentaID
                modelo.PadreID = padre.CuentaID; //asignar manualmente PadreID, que weba


                // Guardar en la base de datos
                var insertarModelo = await _repositorioPlan.InsertAsync(modelo);


                // Mapear a la capa de entidades y retornar
                return _mapper.Map<Entidades.Finanzas.PlanCuentas.PlanCuenta>(insertarModelo);


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Inserta la lista de PlanCuenta recibida desde Excel
        /// </summary>
        /// <param name="lista">Lista de PlanCuentaInsertar (DTO del Excel)</param>
        /// <returns>Lista de PlanCuenta guardadas</returns>
        public async Task<List<Entidades.Finanzas.PlanCuentas.PlanCuentaDTO>> InsertarDesdeExcelAsync(IFormFile file)
        {

            // para leer el excel y convertirlo en un DataTable
            DataTable dt = new DataTable();


            // Valida la extensión del archivo
            if (!ExcelValidator.ValidarExtension(file.FileName))
                throw new Exception("El archivo no es un Excel válido (.xls o .xlsx)");


            try
            {
                // convierte el IFormFile en stream
                using var stream = new MemoryStream();
                await file.CopyToAsync(stream);
                stream.Position = 0;

                // lee el excel y lo convierte en un DataTable
                dt = ExcelReader.LeerExcel(stream);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



           




            //mapear excel a dto usando automapper
            List<Entidades.Finanzas.PlanCuentas.PlanCuentaDTO> cuentasExcel = new List<Entidades.Finanzas.PlanCuentas.PlanCuentaDTO>();
            cuentasExcel = dt.AsEnumerable().Select(row => _mapper.Map<Entidades.Finanzas.PlanCuentas.PlanCuentaDTO>(row)).ToList();

            try
            {
                // Validar que la lista no esté vacía
                foreach (var item in cuentasExcel)
                {
                    if (string.IsNullOrWhiteSpace(item.Cuenta))
                        throw new Exception($"El Código Contable no puede estar vacío (CuentaID: {item.Cuenta})");

                    // validar que nCuentaContable no este vacio
                    if (string.IsNullOrWhiteSpace(item.nCuentaContable))
                        throw new Exception($"El nombre de la cuenta no puede estar vacío (CuentaID: {item.Cuenta})");



                    var ExisteCodigo = await _repositorioPlan.GetAsync(
                        predicate: f => f.EmpresaID == item.EmpresaID && f.CodigoContable == item.Cuenta,
                        asNoTracking: true
                    );

                    if (ExisteCodigo != null)
                        throw new Exception($"El codigo contable '{item.Cuenta}' ya existe en la empresa");
                }



                //obtener el maxID
                var maxID = await _repositorioPlan.GetMaxIdAsync(keySelector: e => e.CuentaID);
                // si no hay registros, iniciar en 1
                var nextID = maxID;

                // mapear a modelo
                //no lo pude hacer con automaper, la shit revienta
                var modelo = cuentasExcel.Select(row => new PlanCuenta
                {
                    CuentaID = nextID++, // aumentar a 1 cada vez que inserta
                    EmpresaID = row.EmpresaID,
                    PadreID = null, // despues buscamos el padre
                    NivelID = row.NivelID,
                    NaturalezaID = row.NaturalezaID,
                    CodigoContable = row.Cuenta,
                    nCuentaContable = row.nCuentaContable,
                    EstadoID = row.EstadoID,

                }).ToList();

                // eejcutar transacciones, las operaciones son:
                // primera inserta sin padre
                // al ejecutar la inserccion, buscar el CuentaID del codigocontable
                // recorrer el dto (que vino del excel)
                //          buscar la PadreID usando la cuenta contable (dto)
                //
                await _repositorioPlan.ExecuteInTransactionAsync(async () => {
                   
                    // insertar la lista
                    await _repositorioPlan.InsertRangeAsync(modelo);


                    // crear el puto diccionario para obtener codigo contable referenciando a cuentaID
                    var mapCodigoCuenta = modelo.ToDictionary(e => e.CodigoContable, e => e.CuentaID);

                    // recorrer el dto (que vino del excel)
                    foreach (var dto in cuentasExcel.Where(e => e.Padre != null)) {
                        var hijo = modelo.FirstOrDefault(e => e.CodigoContable == dto.Cuenta);

                        if (hijo != null && mapCodigoCuenta.ContainsKey(dto.Padre.ToString())) { 
                            hijo.PadreID = mapCodigoCuenta[dto.Padre.ToString()];
                        }
                    }

                    await _repositorioPlan.UpdateRangeAsync(modelo);

                });

                // Mapear a la capa de entidades y retornar
                return _mapper.Map<List<Entidades.Finanzas.PlanCuentas.PlanCuentaDTO>>(modelo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        /// <summary>
        /// Editar un plan de cuenta existente.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Entidades.Finanzas.PlanCuentas.PlanCuenta> ActualizarPlanCuenta(Entidades.Finanzas.PlanCuentas.PlanCuentaDTO dto)
        {
            try
            {

                // traer sin tracking para luego actualizar
                var cuentaExistente = await _repositorioPlan.GetAsync(
                    predicate: f => f.EmpresaID == dto.EmpresaID && f.CuentaID == dto.CuentaID,
                    include: q => q.Include(c => c.InversePadre).ThenInclude(f => f.InversePadre).ThenInclude(f => f.InversePadre).ThenInclude(f => f.InversePadre),
                    asNoTracking: false
                 );


                var existePadre = await _repositorioPlan.GetAsync(
                    predicate: f => f.EmpresaID == dto.EmpresaID && f.CuentaID == dto.PadreID,
                    include: q => q.Include(c => c.InversePadre).ThenInclude(f => f.InversePadre).ThenInclude(f => f.InversePadre).ThenInclude(f => f.InversePadre),
                    asNoTracking: false
                 );



                // validar si existe
                if (cuentaExistente == null)
                    throw new Exception("La cuenta contable no existe.");


                if (existePadre == null)
                    throw new Exception("La cuenta contable padre no existe.");

                // guardar el nivel anterior, para validar
                int nivelAnterior = cuentaExistente.NivelID;

                // actualizar los campos editables
                cuentaExistente.nCuentaContable = dto.nCuentaContable;
                cuentaExistente.CodigoContable = dto.Cuenta;
                cuentaExistente.NaturalezaID = dto.NaturalezaID;
                cuentaExistente.NivelID = dto.NivelID;
                cuentaExistente.EstadoID = dto.EstadoID;
                cuentaExistente.PadreID = dto.PadreID;

                // Si cambió el nivel, actualizar hijos
                if (nivelAnterior != dto.NivelID)
                {
                    //obtener el maxNivelID y el MinNivelID
                    var niveles = await _repositorioNivel.GetAllAsync(asNoTracking: true); // traer todos los niveles
                    int MaxID = niveles.Max(f => f.NivelID); // traer el maximo nivel
                    int MinID = niveles.Where(f => f.NivelID != null).Min(f => f.NivelID); // traer el minimo nivel

                    // ver diferencia, para deectar si sube o baja los niveles
                    int diferencia = dto.NivelID - nivelAnterior;


                    await ActualizarNivelHijosRecursivo(cuentaExistente.InversePadre, diferencia, MaxID, MinID);
                }

                // Guardar en la base de datos
                var resultado = await _repositorioPlan.UpdateAsync(cuentaExistente);



                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // Mapear a la capa de entidades y retornar
                if(resultado == true)
                    // retornar la entidad mapeada
                    return await this.ObtenerPlanCuenta(dto.EmpresaID, dto.CuentaID.ToString());

                else
                    throw new Exception("No se pudo actualizar la cuenta contable.");

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }




        /// <summary>
        ///  
        /// </summary>
        /// <param name="hijos"></param>
        /// <param name="nivelPadre"></param>
        private async Task ActualizarNivelHijosRecursivo(ICollection<Datos.EF.Modelos.PlanCuenta> hijos, int diferencia, int maxNivel, int minNivel)
        {

            

            foreach (var hijo in hijos)
            {
                // El nivel del hijo siempre es el nivel del padre + 1
                hijo.NivelID += diferencia;

                /// Asegurarse de que el nivel esté dentro de los límites permitidos
                if (hijo.NivelID > maxNivel)
                    hijo.NivelID = maxNivel;
                if (hijo.NivelID < minNivel)
                    hijo.NivelID = minNivel;

                // Llamada recursiva para los hijos del hijo
                if (hijo.InversePadre?.Any() == true)
                    await ActualizarNivelHijosRecursivo(hijo.InversePadre, diferencia, maxNivel, minNivel);
            }
        }


       

        #endregion






        #region "niveles"
        /// <summary>
        /// Obtiene todos los niveles de cuentas del plan de cuentas.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Entidades.Finanzas.PlanCuentas.PlanCuentaNivel>> ListarNiveles()
        {
            try
            {
                /// 
                var lsitado = await _repositorioNivel.GetAllAsync(asNoTracking: true);

                // Mapear a la capa de entidades
                var listadoEntidad = _mapper.Map<List<Entidades.Finanzas.PlanCuentas.PlanCuentaNivel>>(lsitado);

                ///  Retornar la lista mapeada
                return listadoEntidad;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Obtiene un nivel de cuenta por su ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Entidades.Finanzas.PlanCuentas.PlanCuentaNivel> ObtenerNivel(int id)
        {
            try
            {
                var lsitado = await _repositorioNivel.GetByIdAsync(id);

                // Mapear a la capa de entidades
                var listadoEntidad = _mapper.Map<Entidades.Finanzas.PlanCuentas.PlanCuentaNivel>(lsitado);

                ///  Retornar la lista mapeada
                return listadoEntidad;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion


        #region "naturaleza"

        /// <summary>
        /// Obtiene todos las naturalezas de cuentas del plan de cuentas.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Entidades.Finanzas.PlanCuentas.PlanCuentaNaturaleza>> ListarNaturaleza()
        {
            try
            {
                var lsitado = await _repositorioNatraleza.GetAllAsync(asNoTracking: true);

                // Mapear a la capa de entidades
                var listadoEntidad = _mapper.Map<List<Entidades.Finanzas.PlanCuentas.PlanCuentaNaturaleza>>(lsitado);

                ///  Retornar la lista mapeada
                return listadoEntidad;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Obtiene una naturaleza de cuenta por su ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Entidades.Finanzas.PlanCuentas.PlanCuentaNaturaleza> ObtenerNaturaleza(int id)
        {
            try
            {
                var lsitado = await _repositorioNatraleza.GetByIdAsync(id);

                // Mapear a la capa de entidades
                var listadoEntidad = _mapper.Map<Entidades.Finanzas.PlanCuentas.PlanCuentaNaturaleza>(lsitado);

                ///  Retornar la lista mapeada
                return listadoEntidad;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion





    }
}