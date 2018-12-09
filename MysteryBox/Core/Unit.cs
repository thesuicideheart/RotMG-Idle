using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteryBox.Core
{
    public class Unit
    {
        public string Name;
        public string ID;
        // public string Description; //Will be used later for tooltips.
        public int Price;
        public int IncomePerTick;

        public Unit(string id,string name, int price, int incomePerTick)
        {
            ID = id;
            Name = name;
            Price = price;
            IncomePerTick = incomePerTick;
        }
    }
}
