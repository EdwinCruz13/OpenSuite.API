using AutoMapper;
using Datos.EF.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Profiles
{
    public class ConfiguracionProfile : Profile
    {
        public ConfiguracionProfile()
        {

           


            /// de EF -> Entidad
            CreateMap<Entidades.Configuraciones.Empresa, Empresa>();

            // de Entidad -> EF
            CreateMap<Empresa, Entidades.Configuraciones.Empresa>();


            // de EF -> Entidad
            CreateMap<Entidades.Configuraciones.EmpresaContacto, EmpresaContacto>();

            // de Entidad -> EF
            CreateMap<EmpresaContacto, Entidades.Configuraciones.EmpresaContacto>();


            // de EF -> Entidad
            CreateMap<Entidades.Configuraciones.EmpresaGiroEconomico, EmpresaGiroEconomico>();

            // de Entidad -> EF
            CreateMap<EmpresaGiroEconomico, Entidades.Configuraciones.EmpresaGiroEconomico>();


            // de EF -> Entidad
            CreateMap<Entidades.Configuraciones.EmpresaDueno, EmpresaDueno>();

            // de Entidad -> EF
            CreateMap<EmpresaDueno, Entidades.Configuraciones.EmpresaDueno>();

        }
    }
}

