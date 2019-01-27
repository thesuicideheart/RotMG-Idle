using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteryBox.Core
{
    public class Weapon
    {
        public Item Parent;
        public int MinDmg;
        public int MaxDmg;
        public int FameBonus;
        public WeaponType WeaponType;

        public Weapon(Item parent, int mindmg, int maxdmg, int famebonus , WeaponType type)
        {
            Parent = parent;
            MinDmg = mindmg;
            MaxDmg = maxdmg;
            FameBonus = famebonus;
            WeaponType = type;
        }
    }
}
