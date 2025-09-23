using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ExcelReader
{
    public static class ExcelValidator
    {
        private static readonly string[] AllowedExtensions = { ".xls", ".xlsx" };

        public static bool ValidarExtension(string fileName)
        {
            var extension = Path.GetExtension(fileName).ToLower();
            return AllowedExtensions.Contains(extension);
        }
    }
}
