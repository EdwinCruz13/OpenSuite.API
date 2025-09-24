using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.EF.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Negocio.Modulos.Seguridad.Modulos
{
    /// <summary>
    /// Servicios para gestionar módulos y submódulos del sistema.
    /// </summary>
    public class ModulosServicios
    {
        private readonly Datos.EF.DatosSQL<Modulo> _repoModulo;
        private readonly Datos.EF.DatosSQL<SubModulo> _repoSubModulo;
        private readonly AutoMapper.IMapper _mapper;

        /// <summary>
        /// Constructor de servicios de módulos.
        /// </summary>
        /// <param name="repoModulo"></param>
        /// <param name="repoSubModulo"></param>
        /// <param name="mapper"></param>
        public ModulosServicios(Datos.EF.DatosSQL<Modulo> repoModulo, Datos.EF.DatosSQL<SubModulo> repoSubModulo, AutoMapper.IMapper mapper)
        {
            _repoModulo = repoModulo;
            _repoSubModulo = repoSubModulo;
            _mapper = mapper;
        }

        /// <summary>
        /// Listar todos los módulos activos con sus submódulos activos.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Entidades.Seguridad.Modulos.Modulo>> ListarModulos()
        {
            try
            {
                /// Obtiene todos los módulos incluyendo sus submódulos.
                var modulos = await _repoModulo.GetAllAsync(
                                orderBy: q => q.OrderBy(m => m.ModuloID),
                                include: q => q
                                    .Include(e => e.SubModulo),
                                asNoTracking: true
                );
                return _mapper.Map<List<Entidades.Seguridad.Modulos.Modulo>>(modulos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtener un módulo por su ID, incluyendo sus submódulos.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Entidades.Seguridad.Modulos.Modulo?> ObtenerModulo(int id)
        {
            try
            {
                var modulo = await _repoModulo.GetByIdAsync(
                                keyValue: id,
                                 keySelector: e => e.ModuloID,
                                include: q => q
                                    .Include(e => e.SubModulo),
                                asNoTracking: true
                );
                return _mapper.Map<Entidades.Seguridad.Modulos.Modulo>(modulo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
