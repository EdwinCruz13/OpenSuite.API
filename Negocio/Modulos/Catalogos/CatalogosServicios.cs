using AutoMapper;
using Datos.ADO;
using Datos.EF;
using Datos.EF.Context;
using Datos.EF.Modelos;
using Microsoft.EntityFrameworkCore;


namespace Negocio.Modulos.Catalogos
{
    public class CatalogosServicios
    {
        private readonly DatosSQL<Pais> _repositorioPais;
        private readonly DatosSQL<Ciudad> _repositorioCiudad;
        private readonly DatosSQL<Concepto> _repositorioConcepto;
        private readonly DatosSQL<ConceptoTipo> _repositorioConceptoTipo;
        private readonly DatosSQL<Moneda> _repositorioMoneda;
        private readonly DatosSQL<MonedaDenominacion> _repositorioDenominacion;
        private readonly DatosSQL<TasaCambio> _repositorioTasaCambio;
        private readonly DatosSQL<Impuestos> _repositorioImpuesto;
        private readonly DatosSQL<DocumentoMadre> _repositorioDocumento;
        private readonly DatosSQL<Estado> _repositorioEstado;


        private readonly IMapper _mapper;



        /// <summary>
        /// Constructor de la clase CatalogosServicios
        /// </summary>
        /// <param name="repositorio"></param>
        /// <param name="respositorioPais"></param>
        /// <param name="respositorioCiudad"></param>
        /// <param name="respositorioConcepto"></param>
        /// <param name="respositorioConceptoTipo"></param>
        /// <param name="respositorioMoneda"></param>
        /// <param name="respositorioDenominacion"></param>
        /// <param name="respositorioTasaCambio"></param>
        /// <param name="respositorioImpuesto"></param>
        /// <param name="respositorioDocumento"></param>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public CatalogosServicios(
            DatosSQL<Pais> respositorioPais,
            DatosSQL<Ciudad> respositorioCiudad,
            DatosSQL<Concepto> respositorioConcepto,
            DatosSQL<ConceptoTipo> respositorioConceptoTipo,
            DatosSQL<Moneda> respositorioMoneda,
            DatosSQL<MonedaDenominacion> respositorioDenominacion,
            DatosSQL<TasaCambio> respositorioTasaCambio,
            DatosSQL<Impuestos> respositorioImpuesto,
            DatosSQL<DocumentoMadre> respositorioDocumento,
            DatosSQL<Estado> respositorioEstado,
            IMapper mapper)
        {
            _repositorioPais = respositorioPais;
            _repositorioCiudad = respositorioCiudad;
            _repositorioConcepto = respositorioConcepto;
            _repositorioConceptoTipo = respositorioConceptoTipo;
            _repositorioMoneda = respositorioMoneda;
            _repositorioDenominacion = respositorioDenominacion;
            _repositorioTasaCambio = respositorioTasaCambio;
            _repositorioImpuesto = respositorioImpuesto;
            _repositorioDocumento = respositorioDocumento;
            _repositorioEstado = respositorioEstado;
            _mapper = mapper;
        }

        #region "estados"
        /// <summary>
        /// obtener todos los estados
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Entidades.Catalogos.Estado>> ListarEstados()
        {
            try
            {
                /// llama al repositorio para obtener todos los paises
                var listado = await _repositorioEstado.GetAllAsync(asNoTracking: true);
                /// mapea la lista de paises a la entidad correspondiente
                var resultado = _mapper.Map<List<Entidades.Catalogos.Estado>>(listado);
                ///
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// obtener listado de estados dentro de una empresa
        /// </summary>
        /// <param name="empresa"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Entidades.Catalogos.Estado>> ListarEstadosPorEmpresa(int empresa)
        {
            try
            {
                /// llama al repositorio para obtener un pais por ID
                var listado = await _repositorioEstado.GetAllAsync(
                    filter: e=> e.EmpresaID == empresa,
                    asNoTracking: true
                 );
                /// mapea la lista de paises a la entidad correspondiente
                var resultado = _mapper.Map<List<Entidades.Catalogos.Estado>>(listado);
                ///     
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// obtener un estado por su codigo dentro de un modulo y submodulo
        /// </summary>
        /// <param name="modulo"></param>
        /// <param name="submodulo"></param>
        /// <param name="empresa"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Entidades.Catalogos.Estado>> ListarEstadosPorModulo(int empresa, int modulo, int submodulo )
        {
            try
            {
                /// llama al repositorio para obtener un pais por ID
                var listado = await _repositorioEstado.GetAllAsync(
                    filter: e => e.ModuloID == modulo && e.SubModuloID == submodulo && e.EmpresaID == empresa,
                    asNoTracking: true
                 );
                /// mapea la lista de paises a la entidad correspondiente
                var resultado = _mapper.Map<List<Entidades.Catalogos.Estado>>(listado);
                ///     
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// obtener un estado por ID
        /// </summary>
        /// <param name="EstadoID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Entidades.Catalogos.Estado> ObtenerEstado(int EstadoID, int empresa, int modulo, int submodulo )
        {
            try
            {
                /// llama al repositorio para obtener un pais por ID
                var listado = await _repositorioEstado.GetAsync(
                    predicate: e => e.ModuloID == modulo && e.SubModuloID == submodulo && e.EmpresaID == empresa && e.EmpresaID == empresa,
                    asNoTracking: true
                 );
                /// mapea la lista de paises a la entidad correspondiente
                var resultado = _mapper.Map<Entidades.Catalogos.Estado>(listado);
                ///     
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       

        

        #endregion

        #region "Paises y ciudades"

        /// <summary>
        /// obtener todos los paises
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Entidades.Catalogos.Pais>> ListarPaises()
        {
            try
            {
                /// llama al repositorio para obtener todos los paises
                var listado = await _repositorioPais.GetAllAsync();

                /// mapea la lista de paises a la entidad correspondiente
                var resultado = _mapper.Map<List<Entidades.Catalogos.Pais>>(listado);

                ///
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// obtener un pais por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Entidades.Catalogos.Pais> ObtenerPais(int? id)
        {
            try
            {
                /// llama al repositorio para obtener un pais por ID
                var listado = await _repositorioPais.GetByIdAsync(id);

                /// mapea la lista de paises a la entidad correspondiente
                var resultado = _mapper.Map<Entidades.Catalogos.Pais>(listado);

                ///     
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }



        /// <summary>
        /// obtener todas las ciudades
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Entidades.Catalogos.Ciudad>> ListarCiudades(int PaisID)
        {
            try
            {
                /// llama al repositorio para obtener todos los paises
                var listado = await _repositorioCiudad.GetAllAsync(
                    filter: e => e.PaisID == PaisID,
                    orderBy: q => q.OrderBy(c => c.PaisID),
                    include: q => q
                        .Include(c => c.Pais),
                    asNoTracking: true
                 );

                /// mapea la lista de paises a la entidad correspondiente
                var resultado = _mapper.Map<List<Entidades.Catalogos.Ciudad>>(listado);

                ///
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// obtener una ciudad por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Entidades.Catalogos.Ciudad> ObtenerCiudad(int PaisID, int CiudadID)
        {
            try
            {
                /// llama al repositorio para obtener un pais por ID
                var listado = await _repositorioCiudad.GetAsync(
                    predicate: e => e.CiudadID == CiudadID && e.PaisID == PaisID,
                    include: q => q.Include(c => c.Pais),
                    asNoTracking: true
                 );

                /// mapea la lista de paises a la entidad correspondiente
                var resultado = _mapper.Map<Entidades.Catalogos.Ciudad>(listado);

                ///     
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion


        #region "conceptos"

        /// <summary>
        /// obtener todos los conceptos
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Entidades.Catalogos.Concepto>> ListarConcepto()
        {
            try
            {
                /// llama al repositorio para obtener todos los paises
                var listado = await _repositorioConcepto.GetAllAsync(
                       include: q => q
                           .Include(c => c.ConceptoTipo),
                       asNoTracking: true
                );

                /// mapea la lista de paises a la entidad correspondiente
                var resultado = _mapper.Map<List<Entidades.Catalogos.Concepto>>(listado);

                ///
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// obtener un concepto por ID
        /// </summary>
        /// <param name="ConceptoID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Entidades.Catalogos.Concepto> ObtenerConcepto(int ConceptoID)
        {
            try
            {
                /// llama al repositorio para obtener un pais por ID
                var data = await _repositorioConcepto.GetByIdAsync(
                    keyValue: ConceptoID,
                    keySelector: c => c.ConceptoID,
                    include: q => q
                        .Include(c => c.ConceptoTipo),
                    asNoTracking: true
                );

                /// mapea la lista de paises a la entidad correspondiente
                var resultado = _mapper.Map<Entidades.Catalogos.Concepto>(data);

                ///     
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// obtener un concepto por su tipo
        /// </summary>
        /// <param name="TipoID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Entidades.Catalogos.Concepto>> ObtenerConceptoPorTipo(int TipoID)
        {
            try
            {
                /// llama al repositorio para obtener un pais por ID
                var data = await _repositorioConcepto.GetAllAsync(
                        filter: e => e.ConceptoTipo.ConceptoTipoID == TipoID,                              // filtro
                        include: q => q                                            // include + thenInclude
                            .Include(c => c.ConceptoTipo),
                        asNoTracking: true                                          // sin tracking 
                );

                /// mapea la lista de paises a la entidad correspondiente
                var resultado = _mapper.Map<List<Entidades.Catalogos.Concepto>>(data);

                ///     
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }



        /// <summary>
        /// obtener todos los tipos de conceptos
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Entidades.Catalogos.ConceptoTipo>> ListarConceptoTipos()
        {
            try
            {
                /// llama al repositorio para obtener todos los paises
                var listado = await _repositorioConceptoTipo.GetAllAsync(
                    asNoTracking: true
                );

                /// mapea la lista de paises a la entidad correspondiente
                var resultado = _mapper.Map<List<Entidades.Catalogos.ConceptoTipo>>(listado);

                ///
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// obtener un tipo de concepto por ID
        /// </summary>
        /// <param name="ConceptoID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Entidades.Catalogos.ConceptoTipo> ObtenerConceptoTipo(int TipoID)
        {
            try
            {
                /// llama al repositorio para obtener un pais por ID
                var data = await _repositorioConceptoTipo.GetByIdAsync(
                        keySelector: c => c.ConceptoTipoID,
                        keyValue: TipoID,
                        asNoTracking: true
                );

                /// mapea la lista de paises a la entidad correspondiente
                var resultado = _mapper.Map<Entidades.Catalogos.ConceptoTipo>(data);

                ///     
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion



        #region "monedas"

        /// <summary>
        /// obtener todas las monedas
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Entidades.Catalogos.Moneda>> ListarMonedas()
        {
            try
            {
                /// llama al repositorio para obtener todos los paises
                var listado = await _repositorioMoneda.GetAllAsync(
                       include: q => q
                           .Include(c => c.Pais)
                           .Include(c => c.MonedaDenominacion),
                       asNoTracking: true
                 );

                /// mapea la lista de paises a la entidad correspondiente
                var resultado = _mapper.Map<List<Entidades.Catalogos.Moneda>>(listado);

                ///
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// obtener una moneda por ID
        /// </summary>
        /// <param name="ConceptoID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Entidades.Catalogos.Moneda> ObtenerMoneda(int monedaID)
        {
            try
            {
                /// llama al repositorio para obtener un pais por ID
                var listado = await _repositorioMoneda.GetByIdAsync(
                    keyValue: monedaID,
                    keySelector: c => c.MonedaID,
                    include: q => q
                        .Include(c => c.Pais)
                        .Include(c => c.MonedaDenominacion),
                    asNoTracking: true
                );

                /// mapea la lista de paises a la entidad correspondiente
                var resultado = _mapper.Map<Entidades.Catalogos.Moneda>(listado);

                ///     
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// obtener todas las denominaciones
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Entidades.Catalogos.MonedaDenominacion>> ListarDenominaciones()
        {
            try
            {
                /// llama al repositorio para obtener todos los paises
                var listado = await _repositorioDenominacion.GetAllAsync(
                       include: q => q
                           .Include(c => c.Moneda)
                               .ThenInclude(m => m.Pais),
                       asNoTracking: true
                 );

                /// mapea la lista de paises a la entidad correspondiente
                var resultado = _mapper.Map<List<Entidades.Catalogos.MonedaDenominacion>>(listado);

                ///
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// obtener una denominacion por ID
        /// </summary>
        /// <param name="ConceptoID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Entidades.Catalogos.MonedaDenominacion> ObtenerDenominacion(int id)
        {
            try
            {
                /// llama al repositorio para obtener una denominacion
                var listado = await _repositorioDenominacion.GetByIdAsync(
                    keyValue: id,
                    keySelector: c => c.DenominacionID,
                    include: q => q
                        .Include(c => c.Moneda)
                            .ThenInclude(m => m.Pais),
                    asNoTracking: true
                );

                /// mapea la lista de paises a la entidad correspondiente
                var resultado = _mapper.Map<Entidades.Catalogos.MonedaDenominacion>(listado);

                ///     
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }



        /// <summary>
        /// obtener la tasa de cambio actual entre dos monedas
        /// </summary>
        /// <param name="monedaOrigenId"></param>
        /// <param name="monedaDestinoId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Entidades.Catalogos.TasaCambio?> ObtenerTasaActual(int monedaOrigenId, int monedaDestinoId)
        {
            try
            {
                /// llama al repositorio para obtener una denominacion
                var listado = await _repositorioTasaCambio.GetAsync(
                    predicate: e => e.MonedaOrigenID == monedaOrigenId && e.MonedaDestinoID == monedaDestinoId,
                    include: q => q
                        .Include(c => c.MonedaOrigen)
                            .ThenInclude(m => m.Pais)
                        .Include(c => c.MonedaDestino)
                            .ThenInclude(m => m.Pais),
                    asNoTracking: true
                 );

                /// mapea la lista de paises a la entidad correspondiente
                var resultado = _mapper.Map<Entidades.Catalogos.TasaCambio>(listado);

                ///     
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// obtener la tasa de cambio entre dos monedas para una fecha especifica
        /// </summary>
        /// <param name="monedaOrigenId"></param>
        /// <param name="monedaDestinoId"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Entidades.Catalogos.TasaCambio?> ObtenerTasaPorFecha(int monedaOrigenId, int monedaDestinoId, DateTime fecha)
        {
            try
            {
                var fechaOnly = DateOnly.FromDateTime(fecha);
                /// llama al repositorio para obtener una denominacion
                var listado = await _repositorioTasaCambio.GetAsync(
                    predicate: e => e.MonedaOrigenID == monedaOrigenId && e.MonedaDestinoID == monedaDestinoId && e.Fecha == fechaOnly,
                    include: q => q
                        .Include(c => c.MonedaOrigen)
                        .Include(c => c.MonedaDestino),
                    asNoTracking: true
                 );

                /// mapea la lista de paises a la entidad correspondiente
                var resultado = _mapper.Map<Entidades.Catalogos.TasaCambio>(listado);

                ///     
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// obtener el historial de tasas de cambio entre dos monedas en un rango de fechas
        /// </summary>
        /// <param name="monedaOrigenId"></param>
        /// <param name="monedaDestinoId"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Entidades.Catalogos.TasaCambio>?> ListarHistorial(int monedaOrigenId, int monedaDestinoId, DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            try
            {
                var fechaIniciaOnly = DateOnly.FromDateTime(fechaInicio.Value);
                var fechaFinOnly = DateOnly.FromDateTime(fechaFin.Value);

                /// llama al repositorio para obtener una denominacion
                var listado = await _repositorioTasaCambio.GetAllAsync(
                    filter: e => e.MonedaOrigenID == monedaOrigenId
                                && e.MonedaDestinoID == monedaDestinoId
                                && (fechaInicio == null || e.Fecha >= fechaIniciaOnly)
                                && (fechaFin == null || e.Fecha <= fechaFinOnly),
                    orderBy: q => q.OrderBy(e => e.Fecha),
                    include: q => q
                        .Include(c => c.MonedaOrigen)
                        .Include(c => c.MonedaDestino),
                    asNoTracking: true
                 );

                /// mapea la lista de paises a la entidad correspondiente
                var resultado = _mapper.Map<List<Entidades.Catalogos.TasaCambio>>(listado);

                ///     
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        #endregion


        #region "impuestos"
        /// <summary>
        /// obtener todos los impuestos
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Entidades.Catalogos.Impuesto>> ListarImpuestos()
        {
            try
            {
                /// llama al repositorio para obtener todos los paises
                var listado = await _repositorioImpuesto.GetAllAsync(asNoTracking: true);

                /// mapea la lista de paises a la entidad correspondiente
                var resultado = _mapper.Map<List<Entidades.Catalogos.Impuesto>>(listado);

                ///
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// obtener un impuesto por ID
        /// </summary>
        /// <param name="ImpuestoID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Entidades.Catalogos.Impuesto> ObtenerImpuestos(int ImpuestoID)
        {
            try
            {
                /// llama al repositorio para obtener un pais por ID
                var listado = await _repositorioImpuesto.GetByIdAsync(ImpuestoID);

                /// mapea la lista de paises a la entidad correspondiente
                var resultado = _mapper.Map<Entidades.Catalogos.Impuesto>(listado);

                ///     
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion



        #region "Documentos"
        /// <summary>
        /// obtener todos los documentos
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Entidades.Catalogos.DocumentoMadre>> ListarDocumentos()
        {
            try
            {
                /// llama al repositorio para obtener todos los paises
                var listado = await _repositorioDocumento.GetAllAsync(asNoTracking: true);

                /// mapea la lista de paises a la entidad correspondiente
                var resultado = _mapper.Map<List<Entidades.Catalogos.DocumentoMadre>>(listado);

                ///
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// obtener documento en especifico
        /// </summary>
        /// <param name="ImpuestoID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Entidades.Catalogos.DocumentoMadre> ObtenerDocumento(int DocumentoID)
        {
            try
            {
                /// llama al repositorio para obtener un pais por ID
                var listado = await _repositorioDocumento.GetByIdAsync(DocumentoID);

                /// mapea la lista de paises a la entidad correspondiente
                var resultado = _mapper.Map<Entidades.Catalogos.DocumentoMadre>(listado);

                ///     
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
