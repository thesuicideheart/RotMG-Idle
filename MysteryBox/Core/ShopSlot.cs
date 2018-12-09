using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteryBox.Core
{
    public class ShopSlot
    {
        public Rectangle Bounds;

        public ShopItem item;

        public ShopSlot(int x, int y, int width, int height)
        {
            Bounds = new Rectangle(x, y, width, height);
        }

        public ShopSlot(Rectangle rect)
        {
            Bounds = rect;
        }

        public virtual void Draw(SpriteBatch batch)
        {
            batch.FillRectangle(Utils.RectToRectF(Bounds), GameData.LightBorderColor);
            batch.DrawRectangle(Utils.RectToRectF(Bounds), GameData.BorderColor, 3);
            
            if(item != null)
            {
                item.Draw(batch, Bounds);
            }
        }

        public virtual void Update()
        {

        }
    }
}
