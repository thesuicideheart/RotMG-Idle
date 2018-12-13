using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteryBox.Core
{
    public class Armor
    {
        public string ItemID;
        public int Defence;
        public int FameBonus;
        public ArmorType ArmorType;

        public Armor(string id, int def, int bonus , ArmorType type)
        {
            ItemID = id;
            Defence = def;
            FameBonus = bonus;
            ArmorType = type;
        }
    }
}
