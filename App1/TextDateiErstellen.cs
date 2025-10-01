using System;
using System.IO;

namespace Pooltriage2._0
{
    internal class TextDateiErstellen
    {
        public static void TextErstellenMethode(string text, string arztName, string pfad)
        {
            string filePath = @pfad + arztName + ".txt";
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    writer.WriteLine("Dies ist eine Beispieltextdatei.");
                    writer.WriteLine("Sie wurde von der TextErstellen-Klasse erstellt.");
                    writer.WriteLine(text);
                }
                Console.WriteLine($"Textdatei wurde erfolgreich erstellt unter: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Erstellen der Textdatei: {ex.Message}");
            }
        }

    }
}