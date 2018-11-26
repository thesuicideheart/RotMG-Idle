using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteryBox.Core
{
    public static class GameData
    {

        public static string InvState = "STATE_INV";

        public static List<Item> ItemsInGame = new List<Item>();

        public static Color BorderColor = new Color(32, 32, 32);

        public static void Init()
        {
            AddItem(new Item("verts_item","Verts OP item",1000,Rarity.Mystical, "Dirk of Cronus"));
            AddItem(new Item("test_item", "Test item", 10, Rarity.Common, "Gold Medal"));
            AddItem(new Item("mindless_item", "Mindless's custom item", 100, Rarity.Legendary, "Shield of Ogmur"));
        }

        public static void AddItem(Item item)
        {
            ItemsInGame.Add(item);
        }

        public static Item GetItemFromId(string id)
        {
            return ItemsInGame.SingleOrDefault(item => item.ID == id);
        }
    }
}
