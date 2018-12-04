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

        public const string InvState = "STATE_INV";
        public const string MainState = "STATE_MAIN";
        public const string OpenCaseState = "STATE_OPEN_CASE";

        public static List<Item> ItemsInGame = new List<Item>();

        #region loot boxes

        public static LootBox BasicBox, IntermediateBox, AdvancedBox;

        #endregion

        public static Color BorderColor = new Color(32, 32, 32, 175);

        public static void Init()
        {

            #region items

            #region custom items

            AddItem(new Item("verts_item", "Verts OP item", 1000, Rarity.Mystical, "Dirk of Cronus"));
            AddItem(new Item("test_item", "Test item", 10, Rarity.Common, "Gold Medal"));
            AddItem(new Item("mindless_item", "Mindless's item", 100, Rarity.Legendary, "Shield of Ogmur"));

            #endregion

            #region swords

            AddItem(new Item("t0_sword", "Short Sword", 5, Rarity.Common));
            AddItem(new Item("t1_sword", "Broad Sword", 7, Rarity.Common));
            AddItem(new Item("t2_sword", "Saber", 10, Rarity.Common));
            AddItem(new Item("t3_sword", "Long Sword", 15, Rarity.Common));
            AddItem(new Item("t4_sword", "Falchion", 22, Rarity.Common));
            AddItem(new Item("t5_sword", "Fire Sword", 32, Rarity.Common));
            AddItem(new Item("t6_sword", "Glass Sword", 47, Rarity.Common));
            AddItem(new Item("t7_sword", "Golden Sword", 70, Rarity.Common));
            AddItem(new Item("t8_sword", "Ravenheart Sword", 100, Rarity.Common));
            AddItem(new Item("t9_sword", "Dragonsoul Sword", 145, Rarity.Common));
            AddItem(new Item("t10_sword", "Archon Sword", 212, Rarity.Uncommon));
            AddItem(new Item("t11_sword", "Skysplitter Sword", 310, Rarity.Uncommon));
            AddItem(new Item("t12_sword", "Sword of Acclaim", 450, Rarity.Rare));
            AddItem(new Item("t13_sword", "Sword of Splendor", 650, Rarity.Legendary));

            #endregion

            #region daggers

            AddItem(new Item("t0_dagger", "Steel Dagger", 5, Rarity.Common));
            AddItem(new Item("t1_dagger", "Dirk", 7, Rarity.Common));
            AddItem(new Item("t2_dagger", "Blue Steel Dagger", 10, Rarity.Common));
            AddItem(new Item("t3_dagger", "Dusky Rose Dagger", 15, Rarity.Common));
            AddItem(new Item("t4_dagger", "Silver Dagger", 22, Rarity.Common));
            AddItem(new Item("t5_dagger", "Golden Dagger", 32, Rarity.Common));
            AddItem(new Item("t6_dagger", "Obsidian Dagger", 47, Rarity.Common));
            AddItem(new Item("t7_dagger", "Mithril Dagger", 70, Rarity.Common));
            AddItem(new Item("t8_dagger", "Fire Dagger", 100, Rarity.Common));
            AddItem(new Item("t9_dagger", "Ragetalon Dagger", 145, Rarity.Common));
            AddItem(new Item("t10_dagger", "Emeraldshard Dagger", 212, Rarity.Uncommon));
            AddItem(new Item("t11_dagger", "Agateclaw Dagger", 310, Rarity.Uncommon));
            AddItem(new Item("t12_dagger", "Dagger of Foul Malevolence", 450, Rarity.Rare));
            AddItem(new Item("t13_dagger", "Dagger of Sinister Deeds", 650, Rarity.Legendary));

            #endregion

            #region katanas

            AddItem(new Item("t0_katana", "Rusty Katana", 5, Rarity.Common));
            AddItem(new Item("t1_katana", "Kendo Stick", 7, Rarity.Common));
            AddItem(new Item("t2_katana", "Plain Katana", 10, Rarity.Common));
            AddItem(new Item("t3_katana", "Thunder Katana", 15, Rarity.Common));
            AddItem(new Item("t4_katana", "Line Kutter Katana", 22, Rarity.Common));
            AddItem(new Item("t5_katana", "Night Edge", 32, Rarity.Common));
            AddItem(new Item("t6_katana", "Sky Edge", 47, Rarity.Common));
            AddItem(new Item("t7_katana", "Buster Katana", 70, Rarity.Common));
            AddItem(new Item("t8_katana", "Demon Edge", 100, Rarity.Common));
            AddItem(new Item("t9_katana", "Jewel Eye Katana", 145, Rarity.Common));
            AddItem(new Item("t10_katana", "Ichimonji", 212, Rarity.Uncommon));
            AddItem(new Item("t11_katana", "Muramasa", 310, Rarity.Uncommon));
            AddItem(new Item("t12_katana", "Masamune", 450, Rarity.Rare));
            AddItem(new Item("t13_katana", "Sadamune", 650, Rarity.Legendary));

            #endregion

            #region wands

            AddItem(new Item("t0_wand", "Fire Wand", 5, Rarity.Common));
            AddItem(new Item("t1_wand", "Force Wand", 7, Rarity.Common));
            AddItem(new Item("t2_wand", "Power Wand", 10, Rarity.Common));
            AddItem(new Item("t3_wand", "Missile Wand", 15, Rarity.Common));
            AddItem(new Item("t4_wand", "Eldritch Wand", 22, Rarity.Common));
            AddItem(new Item("t5_wand", "Hell’s Fire Wand", 32, Rarity.Common));
            AddItem(new Item("t6_wand", "Wand of Dark Magic", 47, Rarity.Common));
            AddItem(new Item("t7_wand", "Wand of Arcane Flame", 70, Rarity.Common));
            AddItem(new Item("t8_wand", "Wand of Death", 100, Rarity.Common));
            AddItem(new Item("t9_wand", "Wand of Deep Sorcery", 145, Rarity.Common));
            AddItem(new Item("t10_wand", "Wand of Shadow", 212, Rarity.Uncommon));
            AddItem(new Item("t11_wand", "Wand of Ancient Warning", 310, Rarity.Uncommon));
            AddItem(new Item("t12_wand", "Wand of Recompense", 450, Rarity.Rare));
            AddItem(new Item("t13_wand", "Wand of Evocation", 650, Rarity.Legendary));

            #endregion

            #region bow

            AddItem(new Item("t0_bow", "Short Bow", 5, Rarity.Common));
            AddItem(new Item("t1_bow", "Reinforced Bow", 7, Rarity.Common));
            AddItem(new Item("t2_bow", "Crossbow", 10, Rarity.Common));
            AddItem(new Item("t3_bow", "Greywood Bow", 15, Rarity.Common));
            AddItem(new Item("t4_bow", "Iron Wood Bow", 22, Rarity.Common));
            AddItem(new Item("t5_bow", "Fire Bow", 32, Rarity.Common));
            AddItem(new Item("t6_bow", "Double Bow", 47, Rarity.Common));
            AddItem(new Item("t7_bow", "Heavy Crossbow", 70, Rarity.Common));
            AddItem(new Item("t8_bow", "Golden Bow", 100, Rarity.Common));
            AddItem(new Item("t9_bow", "Verdant Bow", 145, Rarity.Common));
            AddItem(new Item("t10_bow", "Bow of Fey Magic", 212, Rarity.Uncommon));
            AddItem(new Item("t11_bow", "Bow of Innocent Blood", 310, Rarity.Uncommon));
            AddItem(new Item("t12_bow", "Bow of Covert Havens", 450, Rarity.Rare));
            AddItem(new Item("t13_bow", "Bow of Mystical Energy", 650, Rarity.Legendary));


            #endregion

            #region staff

            AddItem(new Item("t0_staff", "Energy Staff", 5, Rarity.Common));
            AddItem(new Item("t1_staff", "Firebrand Staff", 7, Rarity.Common));
            AddItem(new Item("t2_staff", "Comet Staff", 10, Rarity.Common));
            AddItem(new Item("t3_staff", "Serpentine Staff", 15, Rarity.Common));
            AddItem(new Item("t4_staff", "Meteor Staff", 22, Rarity.Common));
            AddItem(new Item("t5_staff", "Slayer Staff", 32, Rarity.Common));
            AddItem(new Item("t6_staff", "Avenger Staff", 47, Rarity.Common));
            AddItem(new Item("t7_staff", "Staff of Desctruction", 70, Rarity.Common));
            AddItem(new Item("t8_staff", "Staff of Horror", 100, Rarity.Common));
            AddItem(new Item("t9_staff", "Staff of Necrotic Arcana", 145, Rarity.Common));
            AddItem(new Item("t10_staff", "Staff of Diabolic Secrets", 212, Rarity.Uncommon));
            AddItem(new Item("t11_staff", "Staff of Astral Knowledge", 310, Rarity.Uncommon));
            AddItem(new Item("t12_staff", "Staff of the Cosmic Whole", 450, Rarity.Rare));
            AddItem(new Item("t13_staff", "Staff of the Vital Unity", 650, Rarity.Legendary));

            #endregion
            #endregion

            #region loot boxes

            BasicBox = new LootBox("Basic Box", 10,
                new List<LootboxItem>()
                {
                    new LootboxItem("t0_dagger",0,50000)
                });

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
