using AutoMapper;
using Datos.EF;
using Datos.EF.Modelos;
using Entidades.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Linq.Expressions;
using System.Xml;

namespace Negocio.Modulos.Personas
{
    /// <summary>
    /// Servicios para la gestión de personas
    /// </summary>
    public class PersonasServicios
    {
        private readonly DatosSQL<Persona> _repository;
        private readonly IMapper _mapper;


        /// <summary>
        /// Constructor de la clase PersonasServicios
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public PersonasServicios(DatosSQL<Persona> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Listar todas las personas
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Entidades.Personas.Persona>> ListarPersonas()
        {
            try
            {
                /// Obtener todas las personas con PersonaID mayor a 0, ordenadas por PrimerNombre
                var personas = await _repository.GetAllAsync(
                                orderBy: q => q.OrderBy(p => p.PrimerNombre),
                                include: q => q
                                    .Include(e => e.PersonaTipo)
                                    .Include(e => e.EntidadTipo),
                                asNoTracking: true
                );
                return _mapper.Map<List<Entidades.Personas.Persona>>(personas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtener una persona por ID
        /// </summary>
        /// <param name="PersonaID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Entidades.Personas.Persona> ObternerPersona(int PersonaID)
        {
            try
            {
                // Obtener la persona por su ID
                var persona = await _repository.GetByIdAsync(
                    keySelector: c => c.PersonaID,
                    keyValue: PersonaID,    
                    include: q => q
                        .Include(e => e.PersonaTipo)
                        .Include(e => e.EntidadTipo),
                    asNoTracking: true
                );

                // Mapear y retornar la persona
                return _mapper.Map<Entidades.Personas.Persona>(persona);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Guardar persona
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Entidades.Personas.Persona> CrearPersona(Entidades.Personas.PersonaDTO dto)
        {
            try
            {
                // buscar si la persona ya existe
                var personaExiste = await _repository.GetAsync(
                    predicate: e => e.Identificacion == dto.Identificacion || e.Email == dto.Email,
                    asNoTracking: true
                );


                // si la persona existe, lanzar una excepción
                if (personaExiste != null)
                {
                    throw new Exception("La persona ya existe");
                }

                // obtener el maxId De persona
                var maxId = await _repository.GetMaxIdAsync(p => p.PersonaID);
                // asignar el nuevo ID
                dto.PersonaID = maxId + 1; 
                dto.Identificacion = dto.Identificacion.ToUpper().Trim();
                dto.PrimerNombre = dto.PrimerNombre.Capitalize();
                dto.SegundoNombre = dto.SegundoNombre?.Capitalize();
                dto.PrimerApellido = dto.PrimerApellido.Capitalize();
                dto.SegundoApellido = dto.SegundoApellido?.Capitalize();

                // mapear el dto a modelo
                var nuevaPersona = _mapper.Map<Persona>(dto);

                // guardar la nueva persona
                var personaCreada = await _repository.InsertAsync(nuevaPersona);


                // retornar la persona creada mapeada a dto
                return _mapper.Map<Entidades.Personas.Persona>(personaCreada);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Actualizar persona
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Boolean> ActualizarPersona(Entidades.Personas.PersonaDTO dto) 
        {
            try
            {
                // verificar si la persona existe
                var personaExste = await _repository.GetByIdAsync(
                    keySelector: c => c.PersonaID,
                    keyValue: dto.PersonaID,
                    asNoTracking: true
                );

                if(personaExste == null)
                    throw new Exception("La persona no existe");

                dto.Identificacion = dto.Identificacion.ToUpper().Trim();
                dto.PrimerNombre = dto.PrimerNombre.Capitalize();
                dto.SegundoNombre = dto.SegundoNombre?.Capitalize();
                dto.PrimerApellido = dto.PrimerApellido.Capitalize();
                dto.SegundoApellido = dto.SegundoApellido?.Capitalize();
                dto.Email = dto.Email.Trim().ToLower();
                dto.FechaGrabado = personaExste.FechaGrabado; // mantener la fecha de grabado original


                // mapear el dto a modelo
                var personaActualizar = _mapper.Map<Persona>(dto);

                // actualizar la persona
                var personaActualizada = await _repository.UpdateAsync(personaActualizar);

                // retornar la persona actualizada mapeada a dto
                return personaActualizada;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
