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
        public int ItemCount;
        
        public LootBox(List<LootboxItem> items)
        {
            Items = items;
            ItemCount = Items.Count-1;
        }
        
        public LootboxItem GetItem()
        {
            //Vi skal generere et tilfældigt nummer mellem 0 og 100.000
            int randomNumber = Utils.GenerateRandomNumber(0, 100000);

            Console.WriteLine(randomNumber);
            foreach(var item in Items)
            {
                
                if(randomNumber <= item.MaxNum && randomNumber >= item.MinNum)
                {
                    return item;
                }

            }
            
            return null;
        }
    }
}
