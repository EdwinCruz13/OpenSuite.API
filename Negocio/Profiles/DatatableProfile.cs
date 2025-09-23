using AutoMapper;
using Entidades.Finanzas.PlanCuentas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Profiles
{
    public class DatatableProfile : Profile
    {
        // Constructor
        public DatatableProfile()
        {
            // Mapeo de DataRow a PlanCuentaDTO
            CreateMap<DataRow, PlanCuentaDTO>()
            .ForMember(dest => dest.CuentaID, opt => opt.Ignore()) // se genera en BD
            .ForMember(dest => dest.Cuenta, opt => opt.MapFrom(src => src["Cuenta"].ToString()))
            .ForMember(dest => dest.EmpresaID, opt => opt.MapFrom(src => int.Parse(src["EmpresaID"].ToString())))
            .ForMember(dest => dest.Padre, opt => opt.MapFrom(src =>
                string.IsNullOrWhiteSpace(src["Padre"].ToString()) || src["Padre"].ToString().Trim().ToUpper() == "NULL"
                    ? null
                    : src["Padre"].ToString()))
            .ForMember(dest => dest.NivelID, opt => opt.MapFrom(src => int.Parse(src["NivelID"].ToString())))
            .ForMember(dest => dest.NaturalezaID, opt => opt.MapFrom(src => int.Parse(src["NaturalezaID"].ToString())))
            .ForMember(dest => dest.nCuentaContable, opt => opt.MapFrom(src => src["nCuentaContable"].ToString()))
            .ForMember(dest => dest.EstadoID, opt => opt.MapFrom(src => int.Parse(src["EstadoID"].ToString())))
            .ForMember(dest => dest.PadreID, opt => opt.Ignore()); // podrías resolverlo luego si necesitas relacionar por Cuenta
        }
    }

}
