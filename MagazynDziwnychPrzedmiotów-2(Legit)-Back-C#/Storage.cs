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

        public List<Item> GetItems()
        {
            return items;
        }

        public int GetCapacity()
        {
            return Capacity;
        }

        public int GetCurrentItemCount()
        {
            return CurrentItemCount;
        }

        public float GetMaxCombinedWeight()
        {
            return MaxCombinedWeight;
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

        public bool AddItem(Item item)
        {
            if (CurrentItemCount < Capacity)
            {
                if (GetContentWeight() + item.GetWeight() <= MaxCombinedWeight)
                {
                    if (item.GetStrangenessLevel() == 7 && item.GetIsFragile())
                    {
                        if (CurrentItemCount < (Capacity * 0.5))
                        {
                            CurrentItemCount++;
                            items.Add(item);
                            Console.WriteLine($"Dodano przedmiot: {item.GetName()}");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Zbyt ryzykowny przedmiot przy obecnym zapełnieniu");
                            return false;
                        }
                    }
                    else
                    {
                        CurrentItemCount++;
                        items.Add(item);
                        Console.WriteLine($"Dodano przedmiot: {item.GetName()}");
                        return true;
                    }  
                }
                else
                {
                    Console.WriteLine("Przedmiot jest zbyt ciężki");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Magazyn jest pełny.");
                return false;
            }
        }

        public bool DeleteItem(string itemName)
        {
            foreach (var item in items)
            {
                if (item.GetName() == itemName)
                {
                    items.Remove(item);
                    CurrentItemCount--;
                    Console.WriteLine($"Usunięto przedmiot: {itemName}");
                    return true;
                }
            }
            return false;
        }

        public float AverageWeirdness()
        {
            if (CurrentItemCount == 0)
            {
                Console.WriteLine("Brak przedmiotów w magazynie.");
                return 0;
            }
            float totalWeirdness = 0;
            int itemCount = CurrentItemCount;
            foreach (var item in items)
            {
                totalWeirdness += item.GetStrangenessLevel();
            }
            float averageWeirdness = totalWeirdness / itemCount;
            return averageWeirdness;
        }

        public List<Item> ListFragileOrheavy(float weight)
        {

            List<Item> filteredItems = items.Where(item => item.GetWeight() > weight || item.GetStrangenessLevel() > 0).ToList();
            return filteredItems;
        }
    }
}
