using Entidades.Catalogos;
using Entidades.Configuraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entidades.Finanzas.PlanCuentas
{
    /// <summary>
    /// Clase que representa una cuenta en el plan de cuentas.
    /// </summary>
    public class PlanCuenta
    {
        public int CuentaID { get; set; }
        public Empresa Empresa { get; set; } = null!;
        public int? PadreID { get; set; } = null!;
        public PlanCuenta? Padre { get; set; }
        public PlanCuentaNaturaleza Naturaleza { get; set; } = null!;
        public PlanCuentaNivel Nivel { get; set; } = null!;
        public Estado? Estado { get; set; }
        public string CodigoContable { get; set; } = null!;
        public string nCuentaContable { get; set; } = null!;
        public DateTime FechaGrabado { get; set; }
        public ICollection<PlanCuenta> Hijas { get; set; } = new List<PlanCuenta>();
        
    }


    public class PlanCuentaEstructurada
    {
        public int CuentaID { get; set; }
        public int? PadreID { get; set; }
        public int NivelID { get; set; }
        public string? GrupoID { get; set; }
        public string? Grupo { get; set; }
        public string? SubGrupoID { get; set; }
        public string? SubGrupo { get; set; }
        public string? RubroID { get; set; }
        public string? Rubro { get; set; }
        public string? MayorID { get; set; }
        public string? CuentaMayor { get; set; }
        public string? AuxiliarID { get; set; }
        public string? Auxiliar { get; set; }
    }



    public class PlanCuentaDTO
    {
        public int CuentaID { get; set; }
        public int? PadreID { get; set; }

        public string Cuenta { get; set; } = null!;
        public int EmpresaID { get; set; }
        public string? Padre { get; set; } = null!;
        
        public int NaturalezaID { get; set; } 
        public int NivelID { get; set; }
        public int EstadoID { get; set; }
        public string nCuentaContable { get; set; } = null!;
    }


    

}
