using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteryBox.Core
{
    public class ShopItem
    {

        public Texture2D TextureToDraw;

        public virtual void Draw(SpriteBatch batch, Rectangle rect)
        {
            if (TextureToDraw != null)
                batch.Draw(TextureToDraw, rect, Color.White);
        }

        public virtual void Update()
        {

        }

    }
}
