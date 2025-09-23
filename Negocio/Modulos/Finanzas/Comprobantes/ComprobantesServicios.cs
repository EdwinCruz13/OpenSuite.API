using AutoMapper;
using Datos.ADO;
using Datos.EF;
using Datos.EF.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Modulos.Finanzas.Comprobantes
{
    /// <summary>
    /// Clase de servicios para la gestión de comprobantes financieros.
    /// </summary>
    public class ComprobantesServicios
    {
        private readonly DatosSQL<ComprobanteTipo> _repositorioTipo;
        private readonly DatosSQL<ComprobanteNaturaleza> _repositorioNaturaleza;
        private readonly DatosSQL<ComprobanteEstado> _repositorioEstado;
        private readonly DatosSQL<Comprobante> _repositorioComprobante;
        private readonly DatosSQL<ComprobanteDetalle> _repositorioComprobanteDetalle;
        private readonly DatosSQL<ComprobanteDocumento> _repositorioComprobanteDocumento;
        private readonly DatosSQL<ComprobanteSecuencia> _repositorioSecuencia;

        private readonly IMapper _mapper;
        private readonly DatosSQL _datosSQL;    //por si ocupamos algo mas complejo

        /// <summary>
        /// Constructor de la clase ComprobantesServicios
        /// </summary>
        /// <param name="repositorioTipo"></param>
        /// <param name="repositorioNaturaleza"></param>
        /// <param name="repositorioEstado"></param>
        /// <param name="repositorioComprobante"></param>
        /// <param name="repositorioComprobanteDetalle"></param>
        /// <param name="repositorioComprobanteDocumento"></param>
        /// <param name="repositorioSecuencia"></param>
        /// <param name="mapper"></param>
        /// <param name="datosSQL"></param>
        public ComprobantesServicios(
            DatosSQL<ComprobanteTipo> repositorioTipo,
            DatosSQL<ComprobanteNaturaleza> repositorioNaturaleza,
            DatosSQL<ComprobanteEstado> repositorioEstado,
            DatosSQL<Comprobante> repositorioComprobante,
            DatosSQL<ComprobanteDetalle> repositorioComprobanteDetalle,
            DatosSQL<ComprobanteDocumento> repositorioComprobanteDocumento,
            DatosSQL<ComprobanteSecuencia> repositorioSecuencia,
            IMapper mapper,
            DatosSQL datosSQL)
        {
            _repositorioTipo = repositorioTipo;
            _repositorioNaturaleza = repositorioNaturaleza;
            _repositorioEstado = repositorioEstado;
            _repositorioComprobante = repositorioComprobante;
            _repositorioComprobanteDetalle = repositorioComprobanteDetalle;
            _repositorioComprobanteDocumento = repositorioComprobanteDocumento;
            _repositorioSecuencia = repositorioSecuencia;
            _mapper = mapper;
            _datosSQL = datosSQL;
        }

        #region "ComprobanteTipo"

        /// <summary>
        /// Obtiene una lista de todos los tipos de comprobantes disponibles.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Entidades.Finanzas.Comprobantes.ComprobanteTipo>> ListarTipos()
        {
            var data = await _repositorioTipo.GetAllAsync(
                filter: null,
                include: q => q
                    .Include(e => e.ComprobanteNaturaleza)
                    .Include(e => e.CentroCosto),
                asNoTracking: true
            );

            return _mapper.Map<List<Entidades.Finanzas.Comprobantes.ComprobanteTipo>>(data);
        }

        /// <summary>
        /// Obtiene una lista de tipos de comprobantes filtrados por CentroCostoID y EmpresaID.
        /// </summary>
        /// <param name="centroCostoID"></param>
        /// <param name="EmpresaID"></param>
        /// <returns></returns>
        public async Task<List<Entidades.Finanzas.Comprobantes.ComprobanteTipo>> ListarTiposPorCentros(int centroCostoID, int EmpresaID)
        {
            var data = await _repositorioTipo.GetAsync(
                predicate: c => c.CentroCostoID == centroCostoID && c.EmpresaID == EmpresaID,
                include: q => q
                    .Include(e => e.ComprobanteNaturaleza)
                    .Include(e => e.CentroCosto),
                asNoTracking: true
            );

            return _mapper.Map<List<Entidades.Finanzas.Comprobantes.ComprobanteTipo>>(data);
        }


        /// <summary>
        /// Obtiene un tipo de comprobante por su ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Entidades.Finanzas.Comprobantes.ComprobanteTipo> ObtenerTipo(string id)
        {
            var data = await _repositorioTipo.GetByIdAsync(
                keyValue: id,
                keySelector: c => c.ComprobanteTipoID,
                include: q => q
                    .Include(e => e.ComprobanteNaturaleza)
                    .Include(e => e.CentroCosto),
                asNoTracking: true
            );

            return _mapper.Map<Entidades.Finanzas.Comprobantes.ComprobanteTipo>(data);
        }

        /// <summary>
        /// Obtiene un tipo de comprobante por su ID, EmpresaID y CentroCostoID.
        /// </summary>
        /// <param name="centroCostoID"></param>
        /// <param name="EmpresaID"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Entidades.Finanzas.Comprobantes.ComprobanteTipo> ObtenerTipo(int centroCostoID, int EmpresaID, string id)
        {
            var data = await _repositorioTipo.GetAsync(
               predicate: c => c.ComprobanteTipoID == id && c.CentroCostoID == centroCostoID && c.EmpresaID == EmpresaID,
                include: q => q
                    .Include(e => e.ComprobanteNaturaleza)
                    .Include(e => e.CentroCosto),
                asNoTracking: true
            );

            return _mapper.Map<Entidades.Finanzas.Comprobantes.ComprobanteTipo>(data);
        }
        #endregion


    }
}
