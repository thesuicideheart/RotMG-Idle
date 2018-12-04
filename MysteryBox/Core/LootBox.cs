using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteryBox.Core
{
    public class LootBox
    {

        public List<LootboxItem> Items = new List<LootboxItem>();
        public string Name;
        public int Cost;

        public LootBox(string name, int cost, List<LootboxItem> items)
        {
            Name = name;
            Cost = cost;
            Items = items;
        }

        public LootboxItem GetItem()
        {
            int randomNumber = 0;
            //Vi skal generere et tilfældigt nummer mellem 0 og 100.000
            if (Items.Count() > 0)
            {
                 randomNumber = Utils.GenerateRandomNumber(0, Items.Last().MaxNum);
            }
            else
            {
                return null;
            }

            Console.WriteLine(randomNumber);

            //var item = Items.SingleOrDefault(i => randomNumber < i.MaxNum && randomNumber > i.MinNum);

            foreach (var item in Items)
            {

                if (randomNumber <= item.MaxNum && randomNumber >= item.MinNum)
                {
                    return item;
                }

            }

            return null;
        }
    }
}
