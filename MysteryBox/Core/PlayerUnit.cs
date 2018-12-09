using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteryBox.Core
{
    public class PlayerUnit
    {
        public string UnitID;
        public int Count;

        public PlayerUnit()
        {

        }

        public PlayerUnit(string id, int count = 1)
        {
            UnitID = id;
            Count = count;
        }

    }
}
