using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynDziwnychPrzedmiotów_2_Legit__Back_C_
{
    internal class Item
    {
        private string Name;
        private float Weight;
        private int StrangenessLevel;
        private bool IsFragile;

        public Item(string name, float weight, int strangenessLevel, bool isFragile)
        {
            Name = name;
            Weight = weight;
            StrangenessLevel = strangenessLevel;
            IsFragile = isFragile;
        }
    }
}
