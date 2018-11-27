using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteryBox.Core
{
    public class Player
    {
        public int Fame;
        public int Gold;

        public List<InventoryItem> Inventory = new List<InventoryItem>();

        public Player()
        {

        }

        public void AddItem(InventoryItem item)
        {
            if(Inventory.Exists(i => i.ItemID == item.ItemID))
            {
                Inventory.Find(i => i.ItemID == item.ItemID).Count += item.Count;
            }
            else
            {
                Inventory.Add(item);
            }
        }

    }
}
