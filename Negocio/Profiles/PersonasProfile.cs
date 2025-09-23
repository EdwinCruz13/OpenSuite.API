using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Profiles
{
    public class PersonasProfile: Profile
    {
        // Configuraciones de AutoMapper para la entidad Persona
        public PersonasProfile() {
            //de EF -> Entidad
            CreateMap<Datos.EF.Modelos.Persona, Entidades.Personas.Persona>();
            //de Entidad -> EF
            CreateMap<Entidades.Personas.Persona, Datos.EF.Modelos.Persona>();


            //de EF -> Entidad
            CreateMap<Datos.EF.Modelos.Persona, Entidades.Personas.PersonaDTO>();
            //de Entidad -> EF
            CreateMap<Entidades.Personas.PersonaDTO, Datos.EF.Modelos.Persona>();



        }
    }
}
