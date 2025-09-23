using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Profiles
{
    public class SeguridadProfile : Profile
    {
        public SeguridadProfile()
        {
            #region "Usuarios"
            //de EF -> Entidad
            CreateMap<Datos.EF.Modelos.Usuario, Entidades.Seguridad.Usuarios.Usuario>();
            //de Entidad -> EF
            CreateMap<Entidades.Seguridad.Usuarios.Usuario, Datos.EF.Modelos.Usuario>();

            //de EF -> Entidad
            CreateMap<Datos.EF.Modelos.Usuario, Entidades.Seguridad.Usuarios.UsuarioDTO>()
                .ForMember(dest => dest.Contrasena, opt => opt.MapFrom(src => src.Contrasena));
            //de Entidad -> EF
            CreateMap<Entidades.Seguridad.Usuarios.UsuarioDTO, Datos.EF.Modelos.Usuario>()
                .ForMember(dest => dest.Contrasena, opt => opt.MapFrom(src => src.Contrasena));
            #endregion


            #region "perfiles"
            //de EF -> Entidad
            CreateMap<Datos.EF.Modelos.Perfil, Entidades.Seguridad.Perfiles.Perfil>();
            //de Entidad -> EF
            CreateMap<Entidades.Seguridad.Perfiles.Perfil, Datos.EF.Modelos.Perfil>();

            //de EF -> Entidad
            CreateMap<Datos.EF.Modelos.UsuarioPerfil, Entidades.Seguridad.Perfiles.UsuarioPerfil>();
            //de Entidad -> EF
            CreateMap<Entidades.Seguridad.Perfiles.UsuarioPerfil, Datos.EF.Modelos.UsuarioPerfil>();
            #endregion

            #region "modulos y submodulos"
            //de EF -> Entidad
            CreateMap<Datos.EF.Modelos.Modulo, Entidades.Seguridad.Modulos.Modulo>();
            //de Entidad -> EF
            CreateMap<Entidades.Seguridad.Modulos.Modulo, Datos.EF.Modelos.Modulo>();

            //de eF -> Entidad
            CreateMap<Datos.EF.Modelos.SubModulo, Entidades.Seguridad.Modulos.SubModulo>();
            //de Entidad -> EF
            CreateMap<Entidades.Seguridad.Modulos.SubModulo, Datos.EF.Modelos.SubModulo>();

            //de EF -> Entidad
            CreateMap<Datos.EF.Modelos.Acciones, Entidades.Seguridad.Modulos.Accion>();
            //de Entidad -> EF
            CreateMap<Entidades.Seguridad.Modulos.Accion, Datos.EF.Modelos.Acciones>();
            #endregion

            #region "Permisos"
            //de EF -> Entidad
            CreateMap<Datos.EF.Modelos.Permiso, Entidades.Seguridad.Permisos.Permiso>();
            //de Entidad -> EF
            CreateMap<Entidades.Seguridad.Permisos.Permiso, Datos.EF.Modelos.Permiso>();

            //de EF -> Entidad
            CreateMap<Datos.EF.Modelos.UsuarioEmpresa, Entidades.Seguridad.Permisos.UsuarioEmpresa>();
            #endregion
        }
    }
}
