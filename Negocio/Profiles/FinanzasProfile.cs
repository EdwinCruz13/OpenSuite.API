using AutoMapper;
using Entidades.Finanzas.PlanCuentas;
using Microsoft.Extensions.DependencyInjection;
using System.Data;


namespace Negocio.Profiles
{
    public class FinanzasProfile : Profile
    {
        public FinanzasProfile()
        {

            #region "PlanCuentas"

            // De EF -> Entidad
            CreateMap<Datos.EF.Modelos.PlanCuentaNivel, Entidades.Finanzas.PlanCuentas.PlanCuentaNivel>();
            // De Entidad -> EF
            CreateMap<Entidades.Finanzas.PlanCuentas.PlanCuentaNivel, Datos.EF.Modelos.PlanCuentaNivel>();



            // De EF -> Entidad
            CreateMap<Datos.EF.Modelos.PlanCuentaNaturaleza, Entidades.Finanzas.PlanCuentas.PlanCuentaNaturaleza>();
            // De Entidad -> EF
            CreateMap<Entidades.Finanzas.PlanCuentas.PlanCuentaNaturaleza, Datos.EF.Modelos.PlanCuentaNaturaleza>();


            // DTO → EF
            CreateMap<Datos.EF.Modelos.PlanCuenta, PlanCuentaDTO>()
             .ForMember(dest => dest.Cuenta, opt => opt.Ignore())
             .ForMember(dest => dest.Cuenta, opt => opt.MapFrom(src => src.CodigoContable))
             .ForMember(dest => dest.Padre, opt => opt.MapFrom(src => src.Padre != null ? src.Padre.CodigoContable : null));


            // EF → DTO
            CreateMap<PlanCuentaDTO, Datos.EF.Modelos.PlanCuenta>()
                .ForMember(dest => dest.CodigoContable, opt => opt.MapFrom(src => src.Cuenta))
                .ForMember(dest => dest.Padre, opt => opt.Ignore()); // porque se resuelve en la lógica de negocio





            //// DE EF -> Entidad
            //CreateMap<Datos.EF.Modelos.PlanCuenta, Entidades.Finanzas.PlanCuentas.PlanCuentaDTO>()

            ////DE Etidad -> Modelo
            //CreateMap<Entidades.Finanzas.PlanCuentas.PlanCuentaDTO, Datos.EF.Modelos.PlanCuenta>();


            CreateMap<Datos.EF.Modelos.PlanCuenta, Entidades.Finanzas.PlanCuentas.PlanCuenta>()
                .ForMember(dest => dest.Hijas, opt => opt.MapFrom(src => src.InversePadre))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado))
                .ForMember(dest => dest.Padre, opt => opt.MapFrom(src => src.Padre));

            // Mapping from DataRow to PlanCuentaEstructurada
            CreateMap<DataRow, PlanCuentaEstructurada>()
            .ForMember(dest => dest.CuentaID, opt => opt.MapFrom(src => src["CuentaID"]))
            .ForMember(dest => dest.PadreID, opt => opt.MapFrom(src => src["PadreID"] == DBNull.Value ? null : (int?)Convert.ToInt32(src["PadreID"])))
            .ForMember(dest => dest.NivelID, opt => opt.MapFrom(src => src["NivelID"]))
            .ForMember(dest => dest.GrupoID, opt => opt.MapFrom(src => src["GrupoID"].ToString()))
            .ForMember(dest => dest.Grupo, opt => opt.MapFrom(src => src["Grupo"].ToString()))
            .ForMember(dest => dest.SubGrupoID, opt => opt.MapFrom(src => src["SubGrupoID"].ToString()))
            .ForMember(dest => dest.SubGrupo, opt => opt.MapFrom(src => src["SubGrupo"].ToString()))
            .ForMember(dest => dest.RubroID, opt => opt.MapFrom(src => src["RubroID"].ToString()))
            .ForMember(dest => dest.Rubro, opt => opt.MapFrom(src => src["Rubro"].ToString()))
            .ForMember(dest => dest.MayorID, opt => opt.MapFrom(src => src["MayorID"].ToString()))
            .ForMember(dest => dest.CuentaMayor, opt => opt.MapFrom(src => src["CuentaMayor"].ToString()))
            .ForMember(dest => dest.AuxiliarID, opt => opt.MapFrom(src => src["AuxiliarID"].ToString()))
            .ForMember(dest => dest.Auxiliar, opt => opt.MapFrom(src => src["Auxiliar"].ToString()));
            #endregion

            #region "Comprobantes"
            // De EF -> Entidad
            CreateMap<Datos.EF.Modelos.Comprobante, Entidades.Finanzas.Comprobantes.Comprobante>();
            // De Entidad -> EF
            CreateMap<Entidades.Finanzas.Comprobantes.Comprobante, Datos.EF.Modelos.Comprobante>();


            // De EF -> Entidad
            CreateMap<Datos.EF.Modelos.ComprobanteTipo, Entidades.Finanzas.Comprobantes.ComprobanteTipo>();
            // De Entidad -> EF
            CreateMap<Entidades.Finanzas.Comprobantes.ComprobanteTipo, Datos.EF.Modelos.ComprobanteTipo>();


            // De EF -> Entidad
            CreateMap<Datos.EF.Modelos.ComprobanteDetalle, Entidades.Finanzas.Comprobantes.ComprobanteDetalle>();
            // De Entidad -> EF
            CreateMap<Entidades.Finanzas.Comprobantes.ComprobanteDetalle, Datos.EF.Modelos.ComprobanteDetalle>();


            // De EF -> Entidad
            CreateMap<Datos.EF.Modelos.ComprobanteDocumento, Entidades.Finanzas.Comprobantes.ComprobanteDocumento>();
            // De Entidad -> EF
            CreateMap<Entidades.Finanzas.Comprobantes.ComprobanteDocumento, Datos.EF.Modelos.ComprobanteDocumento>();


            // De EF -> Entidad
            CreateMap<Datos.EF.Modelos.ComprobanteEstado, Entidades.Finanzas.Comprobantes.ComprobanteEstado>();
            // De Entidad -> EF
            CreateMap<Entidades.Finanzas.Comprobantes.ComprobanteEstado, Datos.EF.Modelos.ComprobanteEstado>();


            // De EF -> Entidad
            CreateMap<Datos.EF.Modelos.ComprobanteNaturaleza, Entidades.Finanzas.Comprobantes.ComprobanteNaturaleza>();
            // De Entidad -> EF
            CreateMap<Entidades.Finanzas.Comprobantes.ComprobanteNaturaleza, Datos.EF.Modelos.ComprobanteNaturaleza>();

            // De EF -> Entidad
            CreateMap<Datos.EF.Modelos.ComprobanteSecuencia, Entidades.Finanzas.Comprobantes.ComprobanteSecuencia>();
            // De Entidad -> EF
            CreateMap<Entidades.Finanzas.Comprobantes.ComprobanteSecuencia, Datos.EF.Modelos.ComprobanteSecuencia>();

            #endregion

        }
    }
}
