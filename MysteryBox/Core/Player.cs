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

        public List<InventoryItem> Inventory = new List<InventoryItem>();
        public List<PlayerUnit> Units = new List<PlayerUnit>();

        public Player()
        {

        }

        public void GiveFameFromUnits()
        {
            var amtToGive = 0;
            foreach(var unit in Units)
            {
                var units = unit.Count;
                var aUnit = GameData.GetUnit(unit.UnitID);
                amtToGive += (units * aUnit.IncomePerTick);
            }

            Fame += amtToGive;
        }

        public void AddUnit(PlayerUnit unit)
        {
            if(Units.Exists(u => u.UnitID == unit.UnitID))
            {
                Inventory.Find(u => u.ItemID == unit.UnitID).Count += unit.Count;
            }
            else
            {
                Units.Add(unit);
            }
        }

        public void AddItem(InventoryItem item)
        {
            if (Inventory.Exists(i => i.ItemID == item.ItemID))
            {
                Inventory.Find(i => i.ItemID == item.ItemID).Count += item.Count;
            }
            else
            {
                Inventory.Add(item);
            }
        }

        public void SellItem(int index)
        {
            if (index < 0) index = 0;
            if (index >= Inventory.Count()) index = Inventory.Count - 1;
            var iItem = Inventory[index];

            if (iItem.Count > 0)
            {
                var item = GameData.GetItemFromId(iItem.ItemID);

                if (item != null)
                {
                    iItem.Count--;
                    Fame += item.Price;
                    if(iItem.Count <= 0)
                    {
                        //Todo: Remove item from inventroy
                        Inventory.RemoveAt(index);
                    }
                }
            }



        }

        public void Save()
        {
            var xDoc = new XDocument();

            var saveElem = new XElement("Save");

            var fameElem = new XElement("Fame");
            var goldElem = new XElement("Gold");
            var invElem = new XElement("Inventory");

            fameElem.Value = Fame.ToString();
            goldElem.Value = Gold.ToString();


            foreach (var item in Inventory)
            {
                var itemElem = new XElement("Item");
                itemElem.SetAttributeValue("id", $"{item.ItemID}");
                itemElem.Value = item.Count.ToString();
                invElem.Add(itemElem);
            }

            saveElem.Add(fameElem);
            saveElem.Add(goldElem);
            saveElem.Add(invElem);

            xDoc.Add(saveElem);

            using (var writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $"\\{Option.SaveFolderName}\\{Option.SaveFileName}"))
            {
                writer.WriteLine(xDoc.ToString(SaveOptions.None));
            }

        }

        public static Player Load(string file)
        {
            var player = new Player();
            var xDoc = XDocument.Load(file);

            if (xDoc.Element("Save") != null)
            {
                var saveElem = xDoc.Element("Save");

                if (saveElem.Element("Fame") != null)
                    if (!int.TryParse(saveElem.Element("Fame").Value, out player.Fame))
                        player.Fame = 0;

                if (saveElem.Element("Gold") != null)
                    if (!int.TryParse(saveElem.Element("Gold").Value, out player.Gold))
                        player.Gold = 0;

                var invElem = saveElem.Element("Inventory");

                var itemsInInv = invElem.Elements("Item");

                foreach (var itemElem in itemsInInv)
                {
                    int count = 0;
                    if (!int.TryParse(itemElem.Value, out count))
                    {
                        Console.WriteLine("Error in loading item. Item Count Error");
                        continue;
                    }

                    var item = new InventoryItem(itemElem.Attribute("id").Value, count);
                    player.AddItem(item);
                }

            }
            return player;
        }

    }
}
