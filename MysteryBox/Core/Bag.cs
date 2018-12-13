using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteryBox.Core
{
    public class Bag
    {
        public InventoryItem [ ] items;

        public Bag ( List<InventoryItem> items )
        {
            this.items = items.ToArray( );
        }
    }
}
