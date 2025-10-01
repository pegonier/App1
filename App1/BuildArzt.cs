using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pooltriage2._0
{
    public class BuildArzt
    {
        public string arztName { get; set; }
        public int befundung { get; set; }
        public bool externe { get; set; }
        public bool mr { get; set; }
        public bool ct { get; set; }
        public bool dl { get; set; }
        public bool us { get; set; }
        public bool dexa { get; set; }
        public bool istAnwesend { get; set; }
        public Array abwesenheiten { get; set; }
        public int rx100 { get; set; }
        public int rxIndex { get; set; }
        public int nonrx100 { get; set; }
        public int nonrxIndex { get; set; }


        public BuildArzt(string arztName, int befundung, bool externe, bool mr, bool ct, bool dl, bool us, bool dexa, bool istAnwesend, Array abwesenheiten, int rx100, int rxIndex, int nonrx100, int nonrxIndex)
        {
            this.arztName = arztName;
            this.befundung = befundung;
            this.externe = externe;
            this.mr = mr;
            this.ct = ct;
            this.dl = dl;
            this.us = us;
            this.dexa = dexa;
            this.istAnwesend = istAnwesend;
            this.abwesenheiten = abwesenheiten;
            this.rx100 = rx100;
            this.rxIndex = rxIndex;
            this.nonrx100 = nonrx100;
            this.nonrxIndex = nonrxIndex;
        }
        public static void BuildArztMethode()
        {
            Console.WriteLine("BuildArzt Methode wurde aufgerufen.");
        }
        public override string ToString()
        {
            try
            {
                return $"ArztName: {arztName}, Befundung: {befundung}, Externe: {externe}, MR: {mr}, CT: {ct}, DL: {dl}, US: {us}, Dexa: {dexa}, IstAnwesend: {istAnwesend}, Abwesenheiten: {string.Join(", ", abwesenheiten.Cast<object>())}, Rx100: {rx100}, RxIndex: {rxIndex}, Nonrx100: {nonrx100}, NonrxIndex: {nonrxIndex}";
            }
            catch
            {
                Console.WriteLine("Nullpointer Exception");
                return "Fehler beim Anzeigen der Arztinformationen.";
            }
        }
    }
}