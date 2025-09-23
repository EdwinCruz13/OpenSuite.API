using OfficeOpenXml;
using System.Data;

namespace Shared.ExcelReader
{
    public static class ExcelReader
    {
        /// <summary>
        /// Lee un archivo Excel y convierte su contenido en una lista de objetos PlanCuentaInsertar.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static DataTable LeerExcel(Stream file)
        {
            ExcelPackage.License.SetNonCommercialPersonal("OpenSuite");

            // Crear DataTable
            var dt = new DataTable();

            // Leer archivo Excel
            //using var stream = new MemoryStream();
            //file.CopyTo(stream);


            using var package = new ExcelPackage(file);
            var worksheet = package.Workbook.Worksheets.FirstOrDefault();
            if (worksheet == null)
                throw new Exception("El Excel no contiene hojas.");

            int colCount = worksheet.Dimension.Columns;
            int rowCount = worksheet.Dimension.Rows;

            // Crear columnas en el DataTable
            for (int col = 1; col <= colCount; col++)
            {
                string columnName = worksheet.Cells[1, col].Text.Trim();
                if (string.IsNullOrWhiteSpace(columnName))
                    columnName = $"Columna{col}";
                dt.Columns.Add(columnName);
            }

            // Leer filas
            for (int row = 2; row <= rowCount; row++)
            {
                var dr = dt.NewRow();
                for (int col = 1; col <= colCount; col++)
                {
                    dr[col - 1] = worksheet.Cells[row, col].Text.Trim();
                }
                dt.Rows.Add(dr);
            }

            return dt;

        }
    }
}
