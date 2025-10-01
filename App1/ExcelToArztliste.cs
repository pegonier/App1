using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Globalization;
using System.Threading.Tasks;

namespace Pooltriage2._0
{
    internal class ExcelToArztliste
    {
        public List<BuildArzt> BuildArztliste()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            var result = ReadExcel.ExcelReader();

            if (result is not DataSet ds)
            {
                System.Diagnostics.Debug.WriteLine("Keine Daten gefunden oder Datei konnte nicht gelesen werden.");
                return null;
            }

            var table = ds.Tables[0];
            DateTime heute = DateTime.Today;
            DataRow zeileHeute = null;

            // 🔍 Zeile mit heutigem Datum finden
            foreach (DataRow row in table.Rows)
            {
                if (DateTime.TryParse(row[0]?.ToString(), out DateTime datum) && datum.Date == heute)
                {
                    zeileHeute = row;
                    break;
                }
            }

            if (zeileHeute == null)
            {
                System.Diagnostics.Debug.WriteLine("Keine Zeile mit heutigem Datum gefunden.");
                return null;
            }

            // 🧠 Attribute aus den oberen Zeilen extrahieren
            Dictionary<string, List<string>> attributMap = new();
            foreach (DataRow row in table.Rows)
            {
                string attributName = row[0]?.ToString()?.Trim();
                if (DateTime.TryParse(attributName, out _)) break; // Stop bei Datum

                attributMap[attributName] = new List<string>();
                for (int i = 1; i < table.Columns.Count; i++)
                {
                    attributMap[attributName].Add(row[i]?.ToString()?.Trim());
                }
            }

            // 🏗 Objekte für jeden Arzt erstellen
            List<BuildArzt> aerzte = new();
            for (int i = 1; i < table.Columns.Count; i++) // Spalte 0 ist die Beschriftung
            {
                string name = attributMap["Name"][i - 1];
                int befundung = int.TryParse(attributMap["Befundung"][i - 1], out int b) ? b : 0;
                bool externe = attributMap["Extern"][i - 1] == "j";
                bool mr = attributMap["MR"][i - 1] == "j";
                bool ct = attributMap["CT"][i - 1] == "j";
                bool dl = attributMap["DL"][i - 1] == "j";
                bool us = attributMap["US"][i - 1] == "j";
                bool dexa = attributMap["DEXA"][i - 1] == "j";
                int rx100 = 0;
                int rxIndex = 0;
                int nonrx100 = 0;
                int nonrxIndex = 0;
                string abwesenheit = zeileHeute[i]?.ToString()?.Trim();

                List<string> abwesenheitenListe = new List<string>();
                if (!string.IsNullOrEmpty(abwesenheit))
                {
                    abwesenheitenListe.Add(abwesenheit);
                }
                // Default-Daten anhängen
                abwesenheitenListe.Add("12:00-13:15");
                abwesenheitenListe.Add("18:30-23:59");

                // Optional: zurück in Array konvertieren
                string[] abwesenheiten = abwesenheitenListe.ToArray();


                BuildArzt arzt = new BuildArzt(name, befundung, externe, mr, ct, dl, us, dexa, true, abwesenheiten, rx100, rxIndex, nonrx100, nonrxIndex);
                aerzte.Add(arzt);

                Console.WriteLine("\n" + arzt);
                //TextErstellen.TextErstellenMethode(arzt.ToString(), arzt.arztName);
            }
            // CS0161: Immer ein Wert zurückgeben
            return aerzte;
        }
    }
}
