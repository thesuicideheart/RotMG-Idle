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
    public class MessageBox
    {
        public int X;
        public int Y;
        public int Width;
        public int Height;

        public string text;


        public RectangleF bounds = new RectangleF(100, 100, Option.Width - 200, Option.Height - 200);
        public Button OkBtn;


        public MessageBox()
        {
            OkBtn = new Button("Okay", bounds.X + (bounds.Width/2)-50, bounds.Y+bounds.Width-100, 192, 24, Color.Blue);
        }

        public bool Active;

        public void Show(string text)
        {
            Active = true;
            this.text = text;
        }

        public void Update()
        {
            OkBtn.MouseClicked();
        }

        public void Draw(SpriteBatch batch)
        {
            if (Active)
            {
                batch.FillRectangle(bounds, GameData.LightBorderColor);
                batch.DrawRectangle(bounds, GameData.BorderColor, 3);
                OkBtn.Draw(batch);
            }
        }

    }
}
