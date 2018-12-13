using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MysteryBox.Core
{
    public class Player
    {
        public int Fame;
        public int Gold;

        public List<InventoryItem> Inventory = new List<InventoryItem>( );
        public List<PlayerUnit> Units = new List<PlayerUnit>( );
        public List<Character> Characters = new List<Character>( );

        public PotionStorage PotionStorage = new PotionStorage( );

        public Player ( )
        {

        }

        public bool BuyUnit ( PlayerUnit unit )
        {
            if ( Fame >= GameData.UnitsInGame.Find( r => r.ID == unit.UnitID ).Price )
            {
                AddUnit( unit );
                Fame -= GameData.UnitsInGame.Find( r => r.ID == unit.UnitID ).Price;
                return true;
            }
            else
            {
                //Cant afford unit
                return false;
            }
        }

        public void AddCharacter ( Character character )
        {
            Characters.Add( character );
        }

        public void GiveFameFromUnits ( )
        {
            var amtToGive = 0;
            foreach ( var unit in Units )
            {
                var units = unit.Count;
                var aUnit = GameData.GetUnit( unit.UnitID );
                amtToGive += ( units * aUnit.IncomePerTick );
            }

            Fame += amtToGive;
        }

        public void AddUnit ( PlayerUnit unit )
        {
            if ( Units.Exists( u => u.UnitID == unit.UnitID ) )
            {
                Units.Find( u => u.UnitID == unit.UnitID ).Count += unit.Count;
            }
            else
            {
                Units.Add( unit );
            }
        }

        public void AddItem ( InventoryItem item )
        {
            if ( Inventory.Exists( i => i.ItemID == item.ItemID ) )
            {
                Inventory.Find( i => i.ItemID == item.ItemID ).Count += item.Count;
            }
            else
            {
                Inventory.Add( item );
            }
        }

        public void SellItem ( int index )
        {
            if ( index < 0 ) index = 0;
            if ( index >= Inventory.Count( ) ) index = Inventory.Count - 1;
            var iItem = Inventory [ index ];

            if ( iItem.Count > 0 )
            {
                var item = GameData.GetItemFromId( iItem.ItemID );

                if ( item != null )
                {
                    iItem.Count--;
                    Fame += item.Price;
                    if ( iItem.Count <= 0 )
                    {
                        //Todo: Remove item from inventroy
                        Inventory.RemoveAt( index );
                    }
                }
            }



        }

        public void Save ( )
        {
            var xDoc = new XDocument( );

            var saveElem = new XElement( "Save" );

            var fameElem = new XElement( "Fame" );
            var goldElem = new XElement( "Gold" );
            var invElem = new XElement( "Inventory" );
            var UnitInv = new XElement( "Units" );
            var potionStorage = new XElement( "PotionStorage" );

            fameElem.Value = Fame.ToString( );
            goldElem.Value = Gold.ToString( );


            foreach ( var item in Inventory )
            {
                var itemElem = new XElement( "Item" );
                itemElem.SetAttributeValue( "id", $"{item.ItemID}" );
                itemElem.Value = item.Count.ToString( );
                invElem.Add( itemElem );
            }

            foreach ( var unit in Units )
            {
                var unitElem = new XElement( "Unit" );
                unitElem.SetAttributeValue( "id", $"{unit.UnitID}" );
                unitElem.Value = unit.Count.ToString( );
                UnitInv.Add( unitElem );
            }

            var hpElem = new XElement( "Health" );
            hpElem.Value = PotionStorage.HealthPotions.ToString( );

            var mpElem = new XElement( "Mana" );
            mpElem.Value = PotionStorage.ManaPotions.ToString( );

            var defElem = new XElement( "Defense" );
            defElem.Value = PotionStorage.DefensePotions.ToString( );

            var atkElem = new XElement( "Attack" );
            atkElem.Value = PotionStorage.AttackPotions.ToString( );

            var dexElem = new XElement( "Dexterity" );
            dexElem.Value = PotionStorage.DexterityPotions.ToString( );

            var spdElem = new XElement( "Speed" );
            spdElem.Value = PotionStorage.SpeedPotions.ToString( );

            var vitElem = new XElement( "Vitality" );
            vitElem.Value = PotionStorage.VitalityPotions.ToString( );

            var wisElem = new XElement( "Wisdom" );
            wisElem.Value = PotionStorage.WisdomPotions.ToString( );

            potionStorage.Add( hpElem );
            potionStorage.Add( mpElem );
            potionStorage.Add( defElem );
            potionStorage.Add( atkElem );
            potionStorage.Add( dexElem );
            potionStorage.Add( spdElem );
            potionStorage.Add( vitElem );
            potionStorage.Add( wisElem );

            saveElem.Add( fameElem );
            saveElem.Add( goldElem );
            saveElem.Add( invElem );
            saveElem.Add( UnitInv );
            saveElem.Add( potionStorage );

            xDoc.Add( saveElem );

            using ( var writer = new StreamWriter( Environment.GetFolderPath( Environment.SpecialFolder.ApplicationData ) + $"\\{Option.SaveFolderName}\\{Option.SaveFileName}" ) )
            {
                writer.WriteLine( xDoc.ToString( SaveOptions.None ) );
            }

        }

        public static Player Load ( string file )
        {
            var player = new Player( );
            var xDoc = XDocument.Load( file );

            if ( xDoc.Element( "Save" ) != null )
            {
                var saveElem = xDoc.Element( "Save" );

                if ( saveElem.Element( "Fame" ) != null )
                    if ( !int.TryParse( saveElem.Element( "Fame" ).Value, out player.Fame ) )
                        player.Fame = 0;

                if ( saveElem.Element( "Gold" ) != null )
                    if ( !int.TryParse( saveElem.Element( "Gold" ).Value, out player.Gold ) )
                        player.Gold = 0;

                var invElem = saveElem.Element( "Inventory" );

                var itemsInInv = invElem.Elements( "Item" );

                foreach ( var itemElem in itemsInInv )
                {
                    int count = 0;
                    if ( !int.TryParse( itemElem.Value, out count ) )
                    {
                        Console.WriteLine( "Error in loading item. Item Count Error" );
                        continue;
                    }

                    var item = new InventoryItem( itemElem.Attribute( "id" ).Value, count );
                    player.AddItem( item );
                }

                var unitsElem = saveElem.Element( "Units" );
                var unitsInInv = unitsElem.Elements( "Unit" );

                foreach ( var unitElem in unitsInInv )
                {
                    int count = 0;
                    if ( !int.TryParse( unitElem.Value, out count ) )
                    {
                        Console.WriteLine( "Error loading unit count" );
                        continue;
                    }

                    var unit = new PlayerUnit( unitElem.Attribute( "id" ).Value, count );
                    player.AddUnit( unit );
                }

                var potionStorageElem = saveElem.Element( "PotionStorage" );

                #region Potion Storage

                if ( !int.TryParse( potionStorageElem.Element( "Health" ).Value, out player.PotionStorage.HealthPotions ) )
                {

                }

                if ( !int.TryParse( potionStorageElem.Element( "Mana" ).Value, out player.PotionStorage.ManaPotions ) )
                {

                }

                if ( !int.TryParse( potionStorageElem.Element( "Defense" ).Value, out player.PotionStorage.DefensePotions ) )
                {

                }

                if ( !int.TryParse( potionStorageElem.Element( "Attack" ).Value, out player.PotionStorage.AttackPotions ) )
                {

                }

                if ( !int.TryParse( potionStorageElem.Element( "Dexterity" ).Value, out player.PotionStorage.DexterityPotions ) )
                {

                }

                if ( !int.TryParse( potionStorageElem.Element( "Speed" ).Value, out player.PotionStorage.SpeedPotions ) )
                {

                }

                if ( !int.TryParse( potionStorageElem.Element( "Wisdom" ).Value, out player.PotionStorage.WisdomPotions ) )
                {

                }

                if ( !int.TryParse( potionStorageElem.Element( "Vitality" ).Value, out player.PotionStorage.VitalityPotions ) )
                {

                }
                #endregion

            }
            return player;
        }
    }
}
