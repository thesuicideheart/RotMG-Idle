using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteryBox.Core
{
    public class Label
    {
        public int X, Y;
        public string Text;
        public Color TextColor;

        public Label(string text, int x, int y, Color color)
        {
            Text = text;
            X = x;
            Y = y;
            TextColor = color;
        }

        public void Draw(SpriteBatch batch)
        {
            
        }

    }
}
