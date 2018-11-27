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
            AddItem(new Item("mindless_item", "Mindless's item", 100, Rarity.Legendary, "Shield of Ogmur"));

            #region swords

            AddItem(new Item("t0_sword", "Short Sword", 5, Rarity.Common, "Short Sword"));
            AddItem(new Item("t1_sword", "Broad Sword", 7, Rarity.Common, "Broad Sword"));
            AddItem(new Item("t2_sword", "Saber", 10, Rarity.Common, "Saber"));
            AddItem(new Item("t3_sword", "Long Sword", 15, Rarity.Common, "Long Sword"));
            AddItem(new Item("t4_sword", "Falchion", 22, Rarity.Common, "Falchion"));
            AddItem(new Item("t5_sword", "Fire Sword", 32, Rarity.Common, "Fire Sword"));
            AddItem(new Item("t6_sword", "Glass Sword", 47, Rarity.Common, "Glass Sword"));
            AddItem(new Item("t7_sword", "Golden Sword", 70, Rarity.Common, "Golden Sword"));
            AddItem(new Item("t8_sword", "Ravenheart Sword", 100, Rarity.Common, "Ravenheart Sword"));
            AddItem(new Item("t9_sword", "Dragonsoul Sword", 145, Rarity.Common, "Dragonsoul Sword"));
            AddItem(new Item("t10_sword", "Archon Sword", 212, Rarity.Uncommon, "Archon Sword"));
            AddItem(new Item("t11_sword", "Skysplitter Sword", 310, Rarity.Uncommon, "Skysplitter Sword"));
            AddItem(new Item("t12_sword", "Sword of Acclaim", 450, Rarity.Rare, "Sword of Acclaim"));
            AddItem(new Item("t13_sword", "Sword of Splendor", 650, Rarity.Legendary, "Sword of Splendor"));

            #endregion

            #region daggers

            AddItem(new Item("t0_dagger", "Steel Dagger", 5, Rarity.Common, "Steel Dagger"));
            AddItem(new Item("t1_dagger", "Dirk", 7, Rarity.Common, "Dirk"));
            AddItem(new Item("t2_dagger", "Blue Steel Dagger", 10, Rarity.Common, "Blue Steel Dagger"));
            AddItem(new Item("t3_dagger", "Dusky Rose Dagger", 15, Rarity.Common, "Dusky Rose Dagger"));
            AddItem(new Item("t4_dagger", "Silver Dagger", 22, Rarity.Common, "Silver Dagger"));
            AddItem(new Item("t5_dagger", "Golden Dagger", 32, Rarity.Common, "Golden Dagger"));
            AddItem(new Item("t6_dagger", "Obsidian Dagger", 47, Rarity.Common, "Obsidian Dagger"));
            AddItem(new Item("t7_dagger", "Mithril Dagger", 70, Rarity.Common, "Mithril Dagger"));
            AddItem(new Item("t8_dagger", "Fire Dagger", 100, Rarity.Common, "Fire Dagger"));
            AddItem(new Item("t9_dagger", "Ragetalon Dagger", 145, Rarity.Common, "Ragetalon Dagger"));
            AddItem(new Item("t10_dagger", "Emeraldshard Dagger", 212, Rarity.Uncommon, "Emeraldshard Dagger"));
            AddItem(new Item("t11_dagger", "Agateclaw Dagger", 310, Rarity.Uncommon, "Agateclaw Dagger"));
            AddItem(new Item("t12_dagger", "Dagger of Foul Malevolence", 450, Rarity.Rare, "Dagger of Foul Malevolence"));
            AddItem(new Item("t13_dagger", "Dagger of Sinister Deeds", 650, Rarity.Legendary, "Dagger of Sinister Deeds"));

            #endregion
            
            #region katanas

            AddItem(new Item("t0_katana", "Rusty Katana", 5, Rarity.Common, "Rusty Katana"));
            AddItem(new Item("t1_katana", "kendo Stick", 7, Rarity.Common, "kendo Stick"));
            AddItem(new Item("t2_katana", "Plain Katana", 10, Rarity.Common, "Plain Katana"));
            AddItem(new Item("t3_katana", "Thunder Katana", 15, Rarity.Common, "Thunder Katana"));
            AddItem(new Item("t4_katana", "Line Kutter Katana", 22, Rarity.Common, "Line Kutter Katana"));
            AddItem(new Item("t5_katana", "Night Edge", 32, Rarity.Common, "Night Edge"));
            AddItem(new Item("t6_katana", "Sky Edge", 47, Rarity.Common, "Sky Edge"));
            AddItem(new Item("t7_katana", "Buster Katana", 70, Rarity.Common, "Buster Katana"));
            AddItem(new Item("t8_katana", "Demon Edge", 100, Rarity.Common, "Demon Edge"));
            AddItem(new Item("t9_katana", "Jewel Eye Katana", 145, Rarity.Common, "Jewel Eye Katana"));
            AddItem(new Item("t10_katana", "Ichimonji", 212, Rarity.Uncommon, "Ichimonji"));
            AddItem(new Item("t11_katana", "Muramasa", 310, Rarity.Uncommon, "Muramasa"));
            AddItem(new Item("t12_katana", "Masamune", 450, Rarity.Rare, "Masamune"));
            AddItem(new Item("t13_katana", "Sadamune", 650, Rarity.Legendary, "Sadamune"));

            #endregion

            #region wands

            AddItem(new Item("t0_wand", "Fire Wand", 5, Rarity.Common, "Fire Wand"));
            AddItem(new Item("t1_wand", "Force Wand", 7, Rarity.Common, "Force Wand"));
            AddItem(new Item("t2_wand", "Power Wand", 10, Rarity.Common, "Power Wand"));
            AddItem(new Item("t3_wand", "Missile Wand", 15, Rarity.Common, "Missile Wand"));
            AddItem(new Item("t4_wand", "Eldritch Wand", 22, Rarity.Common, "Eldritch Wand"));
            AddItem(new Item("t5_wand", "Hell’s Fire Wand", 32, Rarity.Common, "Hell’s Fire Wand"));
            AddItem(new Item("t6_wand", "Wand of Dark Magic", 47, Rarity.Common, "Wand of Dark Magic"));
            AddItem(new Item("t7_wand", "Wand of Arcane Flame", 70, Rarity.Common, "Wand of Arcane Flame"));
            AddItem(new Item("t8_wand", "Wand of Death", 100, Rarity.Common, "Wand of Death"));
            AddItem(new Item("t9_wand", "Wand of Deep Sorcery", 145, Rarity.Common, "Wand of Deep Sorcery"));
            AddItem(new Item("t10_wand", "Wand of Shadow", 212, Rarity.Uncommon, "Wand of Shadow"));
            AddItem(new Item("t11_wand", "Wand of Ancient Warning", 310, Rarity.Uncommon, "Wand of Ancient Warning"));
            AddItem(new Item("t12_wand", "Wand of Recompense", 450, Rarity.Rare, "Wand of Recompense"));
            AddItem(new Item("t13_wand", "Wand of Evocation", 650, Rarity.Legendary, "Wand of Evocation"));

            #endregion



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
