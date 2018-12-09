using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteryBox.Core
{
    public class ShopPanel
    {
        public int X;
        public int Y;

        public List<ShopSlot> ShopSlots = new List<ShopSlot>();

        public ShopSlot this[int i] {
            get { return ShopSlots[i]; }
        }

        public void Draw(SpriteBatch batch)
        {
            foreach(var slot in ShopSlots)
            {
                slot.Draw(batch);
            }
        }
        
        public void AddSlot(ShopSlot slot)
        {
            ShopSlots.Add(slot);
        }
    }
}
