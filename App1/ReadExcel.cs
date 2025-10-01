using ExcelDataReader;
using System;
using System.Data;
using System.IO;
using Windows.System;

namespace Pooltriage2._0
{
    internal class ReadExcel
    {
        public static object ExcelReader()
        {
            string path = @"C:\Users\Public\Documents\Abwesenheiten.xlsx";
            if (!File.Exists(path))
            {
                System.Diagnostics.Debug.WriteLine("Datei existiert nicht!");
                return null;
            }
            try
            {
                FileStream fStream = File.Open(path, FileMode.Open, FileAccess.Read);
                IExcelDataReader excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(fStream);
                DataSet resultDataSet = excelDataReader.AsDataSet();
                excelDataReader.Close();
                return resultDataSet;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("keine Datei gefunden");
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                return null;
            }

        }
    }
}