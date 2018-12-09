using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteryBox.Core
{
    public class UnitShopItem : ShopItem
    {

        public string UnitID;
        
        public UnitShopItem(string id)
        {
            UnitID = id;
        }

    }
}
