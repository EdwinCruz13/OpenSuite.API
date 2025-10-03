using Datos.EF.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Modulos.Seguridad.Permisos
{
    public class PermisosServicios
    {
        private readonly Datos.EF.DatosSQL<Permiso> _repo;
        private readonly AutoMapper.IMapper _mapper;

        public PermisosServicios(Datos.EF.DatosSQL<Permiso> repo, AutoMapper.IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene la lista de permisos basados en el nombre del permiso proporcionado.
        /// </summary>
        /// <param name="Permisos"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Entidades.Seguridad.Modulos.Accion?> VerificarPermiso(string urlRouteApi, string method)
        {
            try
            {
                // Obtener permisos desde el repositorio con los filtros y orden especificados
                var permisos = await _repo.GetAllAsync(
                                filter: e => e.Acciones.urlApi == urlRouteApi && e.Acciones.MethodType == method,
                                orderBy: q => q.OrderBy(m => m.ModuloID).OrderBy(m => m.SubModuloID),
                                include: q => q
                                    .Include(e => e.Acciones),
                                asNoTracking: true
                );
                if(permisos == null)
                    return null;


                return _mapper.Map<Entidades.Seguridad.Modulos.Accion>(permisos.FirstOrDefault()?.Acciones);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }


}
