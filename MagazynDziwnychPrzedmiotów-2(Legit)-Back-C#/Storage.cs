using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynDziwnychPrzedmiotów_2_Legit__Back_C_
{
    internal class Storage
    {
        private int Capacity;
        private int CurrentItemCount;
        private float MaxCombinedWeight;

        public Storage(int capacity, float maxCombinedWeight)
        {
            Capacity = capacity;
            MaxCombinedWeight = maxCombinedWeight;
        }
    }
}
