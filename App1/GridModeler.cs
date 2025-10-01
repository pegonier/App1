using CommunityToolkit.Mvvm.ComponentModel;
using Pooltriage2._0;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Pooltriage2._0
{
    public class GridModeler : ObservableObject
    {
        public ObservableCollection<BuildArzt> MyItems { get; } = new ObservableCollection<BuildArzt>();

        public GridModeler()
        {
            var aerzteListe = LoadData();
            if (aerzteListe != null)
            {
                // MyItems mit Rückgabe Liste bestücken (optional, wenn nicht schon in LoadData)
                foreach (var arzt in aerzteListe)
                {
                    MyItems.Add(arzt);
                }
            }
        }

        private List<BuildArzt>  LoadData()
        {
            var excelLoader = new ExcelToArztliste();
            var aerzteListe = excelLoader.BuildArztliste();
            if (aerzteListe != null)
            {
                foreach (var arzt in aerzteListe)
                {
                    MyItems.Add(arzt);
                }
            }
            else 
            {
                MyItems.Add(new BuildArzt(
                    "Dr. Müller", 100, true, false, true, false, true, false, true, new string[] { "10:00-11:00", "14:00-16:30"},0,0,0,0
                ));
            }
            return aerzteListe;
        }
    }


    public class MyItem : ObservableObject
    {
        public required string Name { get; set; }
        public int Age { get; set; }
    }
}

