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
        private List<Item> items = new List<Item>();

        public Storage(int capacity, float maxCombinedWeight)
        {
            Capacity = capacity;
            MaxCombinedWeight = maxCombinedWeight;
        }

        public void ListAll()
        {
            Console.WriteLine("Lista przedmiotów w magazynie:");

            foreach (var item in items)
            {
                Console.WriteLine(item.description());
            }
        }

        public float GetContentWeight()
        {
            float totalWeight = 0;
            foreach (var item in items)
            {
                totalWeight += item.GetWeight();
            }
            return totalWeight;
        }

        public void AddItem(Item item)
        {
            if (CurrentItemCount < Capacity)
            {
                if (GetContentWeight() + item.GetWeight() <= MaxCombinedWeight)
                {
                    CurrentItemCount++;
                    Console.WriteLine($"Dodano przedmiot: {item.GetName()}");
                }
                else
                {
                    Console.WriteLine("Przedmiot jest zbyt ciężki");
                }
            }
            else
            {
                Console.WriteLine("Magazyn jest pełny.");
            }
        }


    }
}
