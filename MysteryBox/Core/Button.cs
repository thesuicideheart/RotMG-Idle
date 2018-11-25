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
    public class Button
    {
        public float X;
        public float Y;
        public float Width;
        public float Height;

        public RectangleF Bounds;

        private Color Color;

        public bool Visible;

        public Button(float x, float y, float width, float height, Color color, bool visible = true)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Bounds = new RectangleF(X, Y, Width, Height);
            Color = color;
            Visible = visible;
        }

        public bool MouseHovering()
        {
            return Visible && Bounds.Contains(Game1.Instance.input.GetMousePosition());
        }

        public bool MouseClicked()
        {
            return MouseHovering() && Game1.Instance.input.JustPressed(MouseInput.LeftButton);
        }

        public void Draw(SpriteBatch batch)
        {
            if (Visible)
                batch.FillRectangle(new RectangleF(X, Y, Width, Height), Color);
        }

    }
}
