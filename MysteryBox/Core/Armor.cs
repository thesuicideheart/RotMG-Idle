using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteryBox.Core
{
    public class Armor
    {
        public Item Parent;
        public int Defence;
        public int FameBonus;
        public ArmorType ArmorType;

        public Armor(Item parent, int def, int bonus , ArmorType type)
        {
            Parent = parent;
            Defence = def;
            FameBonus = bonus;
            ArmorType = type;
        }
    }
}
