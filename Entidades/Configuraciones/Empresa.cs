using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades.Catalogos;

namespace Entidades.Configuraciones
{
    public class Empresa
    {
        public int EmpresaID { get; set; }

        public Pais Pais { get; set; } = null!;

        public string nEmpresa { get; set; } = null!;

        public string? Abreviacion { get; set; }

        public string CodigoEmpresa { get; set; } = null!;

        public string CodigoFiscal { get; set; } = null!;

        public string? RLogo { get; set; }

        public string? LLogo { get; set; }

        public string? PrimaryHeader { get; set; }

        public string? SecondaryHeader { get; set; }

        public string? PrimaryFooter { get; set; }

        public string? SecondaryFooter { get; set; }

        public string? Correo { get; set; }

        public string? Telefono { get; set; }

        public string? Direccion { get; set; }

        public Boolean Estado { get; set; }

        public ICollection<CentroCosto> CentroCosto { get; set; } = new List<CentroCosto>();

        public ICollection<EmpresaDueno> EmpresaDueno { get; set; } = new List<EmpresaDueno>();

        public ICollection<EmpresaGiroEconomico> EmpresaGiroEconomico { get; set; } = new List<EmpresaGiroEconomico>();

        public ICollection<EmpresaMoneda> EmpresaMoneda { get; set; } = new List<EmpresaMoneda>();
    }

}
