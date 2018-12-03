using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MysteryBox.Core
{
    public class Utils
    {

        
        public static void DrawSmallString(string text, int x, int y, Color color)
        {

        }

        public static void DrawBigString(string text, int x, int y, Color color)
        {

        }

        public static void DrawRarityString(Item item, Rectangle bounds)
        {
            if (item != null)
            {
                Color color = Color.White;
                if (item.Rarity == Rarity.Common)
                {
                    color = Color.White;
                }
                else if (item.Rarity == Rarity.Uncommon)
                {
                    color = Color.LightGray;
                }
                else if (item.Rarity == Rarity.Rare)
                {
                    color = Color.LightCyan;
                }
                else if (item.Rarity == Rarity.Legendary)
                {
                    color = Color.Gold;
                }
                else if (item.Rarity == Rarity.Mystical)
                {
                    color = new Color(255, 0, 255);
                }
                DrawSmallString($"Rarity: {item.Rarity}",bounds,color);
            }
        }


        public static void DrawSmallString(string strToDraw,Rectangle boundaries, Color color)
        {
            Vector2 size = Game1.Instance.font.MeasureString(strToDraw);

            float xScale = (boundaries.Width / size.X);
            float yScale = (boundaries.Height / size.Y);

            // Taking the smaller scaling value will result in the text always fitting in the boundaires.
            float scale = Math.Min(xScale, yScale);

            // Figure out the location to absolutely-center it in the boundaries rectangle.
            int strWidth = (int)Math.Round(size.X * scale);
            int strHeight = (int)Math.Round(size.Y * scale);
            Vector2 position = new Vector2();
            position.X = (((boundaries.Width - strWidth) / 2) + boundaries.X);
            position.Y = (((boundaries.Height - strHeight) / 2) + boundaries.Y);

            // A bunch of settings where we just want to use reasonable defaults.
            float rotation = 0.0f;
            Vector2 spriteOrigin = new Vector2(0, 0);
            float spriteLayer = 0.0f; // all the way in the front
            SpriteEffects spriteEffects = new SpriteEffects();

            // Draw the string to the sprite batch!
            Game1.Instance.spriteBatch.DrawString(Game1.Instance.font, strToDraw, position, color, rotation, spriteOrigin, scale, spriteEffects, spriteLayer);
        }

        public static void DrawBigString(string strToDraw, Rectangle boundaries, Color color)
        {
            Vector2 size = Game1.Instance.TimerFont.MeasureString(strToDraw);

            float xScale = (boundaries.Width / size.X);
            float yScale = (boundaries.Height / size.Y);

            // Taking the smaller scaling value will result in the text always fitting in the boundaires.
            float scale = Math.Min(xScale, yScale);

            // Figure out the location to absolutely-center it in the boundaries rectangle.
            int strWidth = (int)Math.Round(size.X * scale);
            int strHeight = (int)Math.Round(size.Y * scale);
            Vector2 position = new Vector2();
            position.X = (((boundaries.Width - strWidth) / 2) + boundaries.X);
            position.Y = (((boundaries.Height - strHeight) / 2) + boundaries.Y);

            // A bunch of settings where we just want to use reasonable defaults.
            float rotation = 0.0f;
            Vector2 spriteOrigin = new Vector2(0, 0);
            float spriteLayer = 0.0f; // all the way in the front
            SpriteEffects spriteEffects = new SpriteEffects();

            // Draw the string to the sprite batch!
            Game1.Instance.spriteBatch.DrawString(Game1.Instance.TimerFont, strToDraw, position, color, rotation, spriteOrigin, scale, spriteEffects, spriteLayer);
        }

        public static Rectangle RectFToRect(RectangleF rectf)
        {
            return new Rectangle((int)rectf.X, (int)rectf.Y, (int)rectf.Width, (int)rectf.Height);
        }

        private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();

        public static int GenerateRandomNumber(int min, int max)
        {

            byte[] randomNumber = new byte[1];

            _generator.GetBytes(randomNumber);

            double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);

            // We are using Math.Max, and substracting 0.00000000001,
            // to ensure "multiplier" will always be between 0.0 and .99999999999
            // Otherwise, it's possible for it to be "1", which causes problems in our rounding.
            double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);

            // We need to add one to the range, to allow for the rounding done with Math.Floor
            int range = max - min + 1;

            double randomValueInRange = Math.Floor(multiplier * range);

            return (int)(min + randomValueInRange);
        }
    }
}
