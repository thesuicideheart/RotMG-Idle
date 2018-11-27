using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteryBox.Core
{
    public class InventoryItem
    {

        public int Count;
        public string ItemID;

        public InventoryItem()
        {

        }

        public InventoryItem(string id, int count)
        {
            ItemID = id;
            Count = count;
        }

        public static InventoryItem CreateInventoryItemFromLootboxItem(LootboxItem lootboxItem)
        {
            Console.WriteLine(lootboxItem.ItemId);
            return new InventoryItem(lootboxItem.ItemId, 1);
        }

    }
}
