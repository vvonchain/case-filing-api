using System.Data;
using System.IO;
using System.Xml;
using ClosedXML.Excel;

namespace EvictionCaseFilingAPI
{
    public static class ExcelToXmlConverter
    {
        public static string ConvertExcelToXml(string excelFilePath)
        {
            using (var workbook = new XLWorkbook(excelFilePath))
            {
                var worksheet = workbook.Worksheets.First();
                var dataTable = new DataTable();

                // Add columns to the DataTable based on the Excel header row
                var headerRow = worksheet.FirstRow();
                foreach (var cell in headerRow.Cells())
                {
                    dataTable.Columns.Add(cell.Value.ToString());
                }

                // Add rows to the DataTable based on the Excel data rows
                foreach (var row in worksheet.RowsUsed().Skip(1))
                {
                    var dataRow = dataTable.NewRow();
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        dataRow[i] = row.Cell(i + 1).Value.ToString();
                    }
                    dataTable.Rows.Add(dataRow);
                }

                // Convert the DataTable to XML format
                using (var stringWriter = new StringWriter())
                {
                    using (var xmlWriter = XmlWriter.Create(stringWriter))
                    {
                        dataTable.WriteXml(xmlWriter, XmlWriteMode.WriteSchema);
                        return stringWriter.ToString();
                    }
                }
            }
        }
    }
}