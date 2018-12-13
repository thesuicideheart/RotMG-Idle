using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteryBox.Core
{
    public class Weapon
    {
        public string ItemID;
        public int MinDmg;
        public int MaxDmg;
        public int FameBonus;
        public WeaponType WeaponType;

        public Weapon(string id, int mindmg, int maxdmg, int famebonus , WeaponType type)
        {
            ItemID = id;
            MinDmg = mindmg;
            MaxDmg = maxdmg;
            FameBonus = famebonus;
            WeaponType = type;
        }
    }
}
