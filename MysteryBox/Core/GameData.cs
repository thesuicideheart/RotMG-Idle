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
        public const string StoreState = "STATE_STORE";
        public const string TestState = "STATE_TEST";
        public const string CharacterScreen = "STATE_CHARACTER_SCREEN";

        public static List<Item> ItemsInGame = new List<Item>( );
        public static List<LootBox> LootBoxesInGame = new List<LootBox>( );
        public static List<Unit> UnitsInGame = new List<Unit>( );

        public static List<Weapon> Weapons = new List<Weapon>( );
        public static List<Armor> Armors = new List<Armor>( );

        #region loot boxes

        public static LootBox BasicBox, IntermediateBox, AdvancedBox;

        #endregion

        public static Color TransparentBorderColor = new Color( 32, 32, 32, 175 );
        public static Color BorderColor = new Color( 32, 32, 32 );
        public static Color LightBorderColor = new Color( 82, 82, 82 );

        public static Color LifeColor = new Color( 224, 52, 52 );
        public static Color ManaColor = new Color( 96, 132, 224 );
        public static Color AttackColor = new Color( 211, 80, 230 );
        public static Color DefenceColor = new Color( 82, 82, 82 );
        public static Color SpeedColor = new Color( 8, 141, 60 );
        public static Color DexterityColor = new Color( 225, 127, 39 );
        public static Color VitalityColor = new Color( 196, 0, 21 );
        public static Color WisdomColor = new Color( 64, 137, 244 );

        public static void Init ( )
        {

            #region items

            #region custom items

            AddItem( new Item( "verts_item", "Verts OP item", 1000, Rarity.Mystical, "Dirk of Cronus" ) );
            AddItem( new Item( "test_item", "Test item", 10, Rarity.Common, "Gold Medal" ) );
            AddItem( new Item( "mindless_item", "Mindless's item", 100, Rarity.Legendary, "Shield of Ogmur" ) );

            #endregion

            #region swords

            AddItem( new Item( "t0_sword", "Short Sword", 5, Rarity.Common ) );
            AddWeapon( new Weapon( GetItemFromId( "t0_sword" ), 45, 90, 0, WeaponType.Sword ) );

            AddItem( new Item( "t1_sword", "Broad Sword", 7, Rarity.Common ) );
            AddWeapon( new Weapon( GetItemFromId( "t1_sword" ), 60, 105, 0, WeaponType.Sword ) );

            AddItem( new Item( "t2_sword", "Saber", 10, Rarity.Common ) );
            AddWeapon( new Weapon( GetItemFromId( "t2_sword" ), 75, 105, 0, WeaponType.Sword ) );

            AddItem( new Item( "t3_sword", "Long Sword", 15, Rarity.Common ) );
            AddWeapon( new Weapon( GetItemFromId( "t3_sword" ), 75, 125, 0, WeaponType.Sword ) );

            AddItem( new Item( "t4_sword", "Falchion", 22, Rarity.Common ) );
            AddWeapon( new Weapon( GetItemFromId( "t4_sword" ), 75, 135, 0, WeaponType.Sword ) );

            AddItem( new Item( "t5_sword", "Fire Sword", 32, Rarity.Common ) );
            AddWeapon( new Weapon( GetItemFromId( "t5_sword" ), 90, 135, 0, WeaponType.Sword ) );

            AddItem( new Item( "t6_sword", "Glass Sword", 47, Rarity.Common ) );
            AddWeapon( new Weapon( GetItemFromId( "t6_sword" ), 30, 210, 0, WeaponType.Sword ) );

            AddItem( new Item( "t7_sword", "Golden Sword", 70, Rarity.Common ) );
            AddWeapon( new Weapon( GetItemFromId( "t7_sword" ), 150, 180, 0, WeaponType.Sword ) );

            AddItem( new Item( "t8_sword", "Ravenheart Sword", 100, Rarity.Common ) );
            AddWeapon( new Weapon( GetItemFromId( "t8_sword" ), 180, 255, 1, WeaponType.Sword ) );

            AddItem( new Item( "t9_sword", "Dragonsoul Sword", 145, Rarity.Common ) );
            AddWeapon( new Weapon( GetItemFromId( "t9_sword" ), 195, 255, 1, WeaponType.Sword ) );

            AddItem( new Item( "t10_sword", "Archon Sword", 212, Rarity.Uncommon ) );
            AddWeapon( new Weapon( GetItemFromId( "t10_sword" ), 195, 255, 1, WeaponType.Sword ) );

            AddItem( new Item( "t11_sword", "Skysplitter Sword", 310, Rarity.Uncommon ) );
            AddWeapon( new Weapon( GetItemFromId( "t11_sword" ), 195, 255, 1, WeaponType.Sword ) );

            AddItem( new Item( "t12_sword", "Sword of Acclaim", 450, Rarity.Rare ) );
            AddWeapon( new Weapon( GetItemFromId( "t12_sword" ), 195, 255, 1, WeaponType.Sword ) );

            AddItem( new Item( "t13_sword", "Sword of Splendor", 900, Rarity.Legendary ) );
            AddWeapon( new Weapon( GetItemFromId( "t13_sword" ), 195, 255, 1, WeaponType.Sword ) );

            #endregion

            #region daggers

            AddItem( new Item( "t0_dagger", "Steel Dagger", 5, Rarity.Common ) );
            AddItem( new Item( "t1_dagger", "Dirk", 7, Rarity.Common ) );
            AddItem( new Item( "t2_dagger", "Blue Steel Dagger", 10, Rarity.Common ) );
            AddItem( new Item( "t3_dagger", "Dusky Rose Dagger", 15, Rarity.Common ) );
            AddItem( new Item( "t4_dagger", "Silver Dagger", 22, Rarity.Common ) );
            AddItem( new Item( "t5_dagger", "Golden Dagger", 32, Rarity.Common ) );
            AddItem( new Item( "t6_dagger", "Obsidian Dagger", 47, Rarity.Common ) );
            AddItem( new Item( "t7_dagger", "Mithril Dagger", 70, Rarity.Common ) );
            AddItem( new Item( "t8_dagger", "Fire Dagger", 100, Rarity.Common ) );
            AddItem( new Item( "t9_dagger", "Ragetalon Dagger", 145, Rarity.Common ) );
            AddItem( new Item( "t10_dagger", "Emeraldshard Dagger", 212, Rarity.Uncommon ) );
            AddItem( new Item( "t11_dagger", "Agateclaw Dagger", 310, Rarity.Uncommon ) );
            AddItem( new Item( "t12_dagger", "Dagger of Foul Malevolence", 450, Rarity.Rare ) );
            AddItem( new Item( "t13_dagger", "Dagger of Sinister Deeds", 550, Rarity.Legendary ) );

            #endregion

            #region katanas

            AddItem( new Item( "t0_katana", "Rusty Katana", 5, Rarity.Common ) );
            AddItem( new Item( "t1_katana", "Kendo Stick", 7, Rarity.Common ) );
            AddItem( new Item( "t2_katana", "Plain Katana", 10, Rarity.Common ) );
            AddItem( new Item( "t3_katana", "Thunder Katana", 15, Rarity.Common ) );
            AddItem( new Item( "t4_katana", "Line Kutter Katana", 22, Rarity.Common ) );
            AddItem( new Item( "t5_katana", "Night Edge", 32, Rarity.Common ) );
            AddItem( new Item( "t6_katana", "Sky Edge", 47, Rarity.Common ) );
            AddItem( new Item( "t7_katana", "Buster Katana", 70, Rarity.Common ) );
            AddItem( new Item( "t8_katana", "Demon Edge", 100, Rarity.Common ) );
            AddItem( new Item( "t9_katana", "Jewel Eye Katana", 145, Rarity.Common ) );
            AddItem( new Item( "t10_katana", "Ichimonji", 212, Rarity.Uncommon ) );
            AddItem( new Item( "t11_katana", "Muramasa", 310, Rarity.Uncommon ) );
            AddItem( new Item( "t12_katana", "Masamune", 450, Rarity.Rare ) );
            AddItem( new Item( "t13_katana", "Sadamune", 550, Rarity.Legendary ) );

            #endregion

            #region wands

            AddItem( new Item( "t0_wand", "Fire Wand", 5, Rarity.Common ) );
            AddItem( new Item( "t1_wand", "Force Wand", 7, Rarity.Common ) );
            AddItem( new Item( "t2_wand", "Power Wand", 10, Rarity.Common ) );
            AddItem( new Item( "t3_wand", "Missile Wand", 15, Rarity.Common ) );
            AddItem( new Item( "t4_wand", "Eldritch Wand", 22, Rarity.Common ) );
            AddItem( new Item( "t5_wand", "Hell’s Fire Wand", 32, Rarity.Common ) );
            AddItem( new Item( "t6_wand", "Wand of Dark Magic", 47, Rarity.Common ) );
            AddItem( new Item( "t7_wand", "Wand of Arcane Flame", 70, Rarity.Common ) );
            AddItem( new Item( "t8_wand", "Wand of Death", 100, Rarity.Common ) );
            AddItem( new Item( "t9_wand", "Wand of Deep Sorcery", 145, Rarity.Common ) );
            AddItem( new Item( "t10_wand", "Wand of Shadow", 212, Rarity.Uncommon ) );
            AddItem( new Item( "t11_wand", "Wand of Ancient Warning", 310, Rarity.Uncommon ) );
            AddItem( new Item( "t12_wand", "Wand of Recompense", 450, Rarity.Rare ) );
            AddItem( new Item( "t13_wand", "Wand of Evocation", 900, Rarity.Legendary ) );

            #endregion

            #region bow

            AddItem( new Item( "t0_bow", "Short Bow", 5, Rarity.Common ) );
            AddItem( new Item( "t1_bow", "Reinforced Bow", 7, Rarity.Common ) );
            AddItem( new Item( "t2_bow", "Crossbow", 10, Rarity.Common ) );
            AddItem( new Item( "t3_bow", "Greywood Bow", 15, Rarity.Common ) );
            AddItem( new Item( "t4_bow", "Iron Wood Bow", 22, Rarity.Common ) );
            AddItem( new Item( "t5_bow", "Fire Bow", 32, Rarity.Common ) );
            AddItem( new Item( "t6_bow", "Double Bow", 47, Rarity.Common ) );
            AddItem( new Item( "t7_bow", "Heavy Crossbow", 70, Rarity.Common ) );
            AddItem( new Item( "t8_bow", "Golden Bow", 100, Rarity.Common ) );
            AddItem( new Item( "t9_bow", "Verdant Bow", 145, Rarity.Common ) );
            AddItem( new Item( "t10_bow", "Bow of Fey Magic", 212, Rarity.Uncommon ) );
            AddItem( new Item( "t11_bow", "Bow of Innocent Blood", 310, Rarity.Uncommon ) );
            AddItem( new Item( "t12_bow", "Bow of Covert Havens", 450, Rarity.Rare ) );
            AddItem( new Item( "t13_bow", "Bow of Mystical Energy", 550, Rarity.Legendary ) );


            #endregion

            #region staff

            AddItem( new Item( "t0_staff", "Energy Staff", 5, Rarity.Common ) );
            AddItem( new Item( "t1_staff", "Firebrand Staff", 7, Rarity.Common ) );
            AddItem( new Item( "t2_staff", "Comet Staff", 10, Rarity.Common ) );
            AddItem( new Item( "t3_staff", "Serpentine Staff", 15, Rarity.Common ) );
            AddItem( new Item( "t4_staff", "Meteor Staff", 22, Rarity.Common ) );
            AddItem( new Item( "t5_staff", "Slayer Staff", 32, Rarity.Common ) );
            AddItem( new Item( "t6_staff", "Avenger Staff", 47, Rarity.Common ) );
            AddItem( new Item( "t7_staff", "Staff of Desctruction", 70, Rarity.Common ) );
            AddItem( new Item( "t8_staff", "Staff of Horror", 100, Rarity.Common ) );
            AddItem( new Item( "t9_staff", "Staff of Necrotic Arcana", 145, Rarity.Common ) );
            AddItem( new Item( "t10_staff", "Staff of Diabolic Secrets", 212, Rarity.Uncommon ) );
            AddItem( new Item( "t11_staff", "Staff of Astral Knowledge", 310, Rarity.Uncommon ) );
            AddItem( new Item( "t12_staff", "Staff of the Cosmic Whole", 450, Rarity.Rare ) );
            AddItem( new Item( "t13_staff", "Staff of the Vital Unity", 900, Rarity.Legendary ) );

            #endregion
            #endregion

            #region loot boxes

            BasicBox = new LootBox( "Basic Box", "Shield of Ogmur", 10,
                new List<LootboxItem>( )
                {
                    new LootboxItem("t1_dagger",0,10000),
                    new LootboxItem("t2_dagger",10000,15000),
                    new LootboxItem("t3_dagger",15000,17500),
                    new LootboxItem("t4_dagger",17500,19500),
                    new LootboxItem("t5_dagger",19500,20000),
                    new LootboxItem("t6_dagger",20000,20250),

                    new LootboxItem("t1_sword",20250,30250),
                    new LootboxItem("t2_sword",30250,37750),
                    new LootboxItem("t3_sword",37750,40250),
                    new LootboxItem("t4_sword",40250,42250),
                    new LootboxItem("t5_sword",42250,42750),
                    new LootboxItem("t6_sword",42750,43000),

                    new LootboxItem("t1_bow",43000,53000),
                    new LootboxItem("t2_bow",53000,58000),
                    new LootboxItem("t3_bow",58000,60500),
                    new LootboxItem("t4_bow",60500,62500),
                    new LootboxItem("t5_bow",62500,63000),
                    new LootboxItem("t6_bow",63000,63200),

                    new LootboxItem("t1_wand",63200,73200),
                    new LootboxItem("t2_wand",73200,78200),
                    new LootboxItem("t3_wand",78200,80700),
                    new LootboxItem("t4_wand",80700,82700),
                    new LootboxItem("t5_wand",82700,83200),
                    new LootboxItem("t6_wand",83200,83400),

                    new LootboxItem("t1_katana",83400,93400),
                    new LootboxItem("t2_katana",93400,98400),
                    new LootboxItem("t3_katana",98400,100900),
                    new LootboxItem("t4_katana",100900,102900),
                    new LootboxItem("t5_katana",102900,103400),
                    new LootboxItem("t6_katana",103400,103650),

                    new LootboxItem("t1_staff",103650,113650),
                    new LootboxItem("t2_staff",113650,118650),
                    new LootboxItem("t3_staff",118650,121150),
                    new LootboxItem("t4_staff",121150,123150),
                    new LootboxItem("t5_staff",123150,123650),
                    new LootboxItem("t6_staff",123650,123900)
                } );

            IntermediateBox = new LootBox( "Intermediate Box", "Dirk of Cronus", 300,
                new List<LootboxItem>( )
                {
                    new LootboxItem("t11_bow",0,15500),
                    new LootboxItem("t11_katana",15500,31000),
                    new LootboxItem("t11_dagger",31000,46500),
                    new LootboxItem("t11_staff",46500,62000),
                    new LootboxItem("t11_wand",62000,77500),
                    new LootboxItem("t11_sword",77500,93000),

                    new LootboxItem("t12_bow",93000,94111),
                    new LootboxItem("t12_katana",94111,95222),
                    new LootboxItem("t12_dagger",95222,96333),
                    new LootboxItem("t12_staff",96333,97555),
                    new LootboxItem("t12_wand",97555,98000),
                    new LootboxItem("t12_sword",98000,100000)
                } );

            AdvancedBox = new LootBox( "Advanced Box", "Staff of the Vital Unity", 750,
                new List<LootboxItem>( )
                {
                    new LootboxItem("t13_bow",0,30000),
                    new LootboxItem("t13_katana",30000,60000),
                    new LootboxItem("t13_dagger",60000,90000),

                    new LootboxItem("t13_staff",90000,93333),
                    new LootboxItem("t13_wand",93333,96666),
                    new LootboxItem("t13_sword",96666,100000)
                } );

            LootBoxesInGame.Add( BasicBox );
            LootBoxesInGame.Add( IntermediateBox );
            LootBoxesInGame.Add( AdvancedBox );

            #endregion

            #region units

            UnitsInGame.Add( new Unit( "UNIT_TEST", "test unit 1", 100, 5 ) );
            UnitsInGame.Add( new Unit( "UNIT_TEST_2", "test unit 2", 250, 10 ) );
            UnitsInGame.Add( new Unit( "UNIT_TEST_3", "test unit 3", 500, 25 ) );

            #endregion

        }

        /**
         
          TODO: Implement this. Add all items to the game via hand. Shouldnt be too hard.
            
          */

        public static Weapon GetWeapon ( string id )
        {
            return null;
        }

        public static Armor GetArmor ( string id )
        {
            return null;
        }

        public static void AddItem ( Item item )
        {
            ItemsInGame.Add( item );
        }

        public static void AddWeapon ( Weapon weapon )
        {
            Weapons.Add( weapon );
        }

        public static Unit GetUnit ( string id )
        {
            return UnitsInGame.SingleOrDefault( unit => unit.ID == id );
        }

        public static Item GetItemFromId ( string id )
        {
            return ItemsInGame.SingleOrDefault( item => item.ID == id );
        }
    }
}
