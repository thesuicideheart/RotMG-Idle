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

        public string Text;

        private Color Color;

        public bool Visible;
        private bool noColor, useTexture;

        public Texture2D Texture;

        public Button(float x, float y, float width, float height, Texture2D text, bool visible = true)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Texture = text;
            Visible = visible;
            Bounds = new RectangleF(X, Y, Width, Height);
            useTexture = true;
        }

        public Button(float x, float y, float width, float height, bool visible = true)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Visible = visible;
            Bounds = new RectangleF(X, Y, Width, Height);
            noColor = true;
        }

        public Button(string text, float x, float y, float width, float height, Color color, bool visible = true)
        {
            Text = text;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Bounds = new RectangleF(X, Y, Width, Height);
            Color = color;
            Visible = visible;
            noColor = false;
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
            {
                if (useTexture)
                {
                    if (MouseHovering())
                    {
                        batch.Draw(Texture, Utils.RectFToRect(Bounds), new Color((byte)Color.White.R, (byte)Color.White.G, (byte)Color.White.B, (byte)175));
                    }
                    else
                    {
                        batch.Draw(Texture, Utils.RectFToRect(Bounds), Color.White);
                    }
                }
                else
                {
                    if (!noColor)
                    {
                        if (Color != null)
                            batch.FillRectangle(new RectangleF(X, Y, Width, Height), Color);
                        if (Text != "" && Bounds != null)
                            Utils.DrawBigString(Text, Utils.RectFToRect(Bounds), Color.White);
                    }
                    else
                    {
                        //No drawing!
                    }
                }

            }
        }

    }
}
