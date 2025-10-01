using Pooltriage2._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    internal class ExaminationTriage
    {
        public string ExaminationToDoctor(List<BuildArzt>Liste)
        {
            System.Diagnostics.Debug.WriteLine(Liste.Count);
            for (int i = 0; i < Liste.Count; i++)
            {
                BuildArzt arzt = Liste[i];
                System.Diagnostics.Debug.WriteLine($"Name: {arzt.arztName}, Befundung: {arzt.befundung}, Rx100: {arzt.rx100}, RxIndex: {arzt.rxIndex}, NonRx100: {arzt.nonrx100}, NonRxIndex: {arzt.nonrxIndex}");
               
                // Alle Abwesenheiten ausgeben
                // Weitere Eigenschaften ausgeben...
            }
            ExaminationGetter NewNumber = new ExaminationGetter();
            object number = NewNumber.GetExaminations();
            
            //System.Diagnostics.Debug.WriteLine(Liste.ToString());
            System.Diagnostics.Debug.WriteLine(number.ToString());

            return "ExaminationToDoctor method called.";
        }
    }
}
