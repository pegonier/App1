using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    internal class ExaminationGetter
    {
        public object GetExaminations()
        {
            int nummer = Random.Shared.Next(100000, 999900);
            TimeOnly zeit = TimeOnly.FromDateTime(DateTime.Now);
            string untersuch = Random.Shared.Next(0, 5) switch {0 => "RX", 1 => "CT", 2 => "MR", 3 => "DL", 4 => "US", 5 => "RX" };
            bool is_rx = untersuch == Random.Shared.Next(0, 2) switch { 0 => "Ja", 1 => "Nein" };
            string patient_name = Random.Shared.Next(0, 11) switch { 0 => "Müller", 1 => "Schmidt", 2 => "Schneider", 3 => "Fischer", 4 => "Weber", 5 => "Meyer" , 6 => "Peter", 7 => "Bleiker", 8 => "Steiner", 9 => "Roggenmoser", 10 => "Blocher"};
            return new { nummer, zeit, untersuch, is_rx, patient_name };
        }
    }
}
