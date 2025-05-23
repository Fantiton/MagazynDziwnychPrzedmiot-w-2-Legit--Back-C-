﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

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

        public string description()
        {
            var descriptionObject = new
            {
                Name,
                Weight,
                StrangenessLevel,
                IsFragile = IsFragile ? "TAK" : "NIE",
            };
            string descriptionJSON = JsonSerializer.Serialize(descriptionObject);
            return descriptionJSON;
        }

        public string GetName()
        {
            return Name;
        }

        public float GetWeight()
        {
            return Weight;
        }

        public int GetStrangenessLevel()
        {
            return StrangenessLevel;
        }

        public bool GetIsFragile()
        {
            return IsFragile;
        }
    }
}
