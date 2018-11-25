using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteryBox.Core
{
    public class LootboxItem
    {
        public int MinNum;
        public int MaxNum;
        public string ItemId;

        public int Range {
            get
            {
                return MaxNum - MinNum;
            }
        }

        public LootboxItem(string id, int min,int max)
        {
            ItemId = id;
            MinNum = min;
            MaxNum = max;
        }
        
    }
}
