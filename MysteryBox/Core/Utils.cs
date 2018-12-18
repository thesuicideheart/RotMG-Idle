using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MysteryBox.Core
{
    public class Utils
    {

        public static Class ParseClass ( string str )
        {
            str = str.ToLower( );
            if ( str == "wizard" )
                return Class.Wizard;

            else if ( str == "rogue" )
                return Class.Rogue;

            else if ( str == "priest" )
                return Class.Priest;

            else if ( str == "archer" )
                return Class.Archer;

            else if ( str == "warrior" )
                return Class.Warrior;

            else if ( str == "knight" )
                return Class.Knight;

            else if ( str == "paladin" )
                return Class.Paladin;

            else if ( str == "assassin" )
                return Class.Assassin;

            else if ( str == "necromancer" )
                return Class.Necromancer;

            else if ( str == "huntress" )
                return Class.Huntress;

            else if ( str == "mystic" )
                return Class.Mystic;

            else if ( str == "trickster" )
                return Class.Trickster;

            else if ( str == "sorcerer" )
                return Class.Sorcerer;

            else if ( str == "ninja" )
                return Class.Ninja;

            else if ( str == "samurai" )
                return Class.Samurai;

            else
                return Class.Wizard;
        }

        public static void DrawClassIcon ( Class chr, int x, int y )
        {
            switch ( chr )
            {
                case Class.Rogue:
                    Game1.Instance.draw( Sprites.GetTexture( "rogue" ), new Rectangle( x, y, Sprites.GetTexture( "rogue" ).Width, Sprites.GetTexture( "rogue" ).Height ) );
                    break;
                case Class.Archer:
                    Game1.Instance.draw( Sprites.GetTexture( "archer" ), new Rectangle( x, y, Sprites.GetTexture( "archer" ).Width, Sprites.GetTexture( "archer" ).Height ) );
                    break;
                case Class.Wizard:
                    Game1.Instance.draw( Sprites.GetTexture( "wizard" ), new Rectangle( x, y, Sprites.GetTexture( "wizard" ).Width, Sprites.GetTexture( "wizard" ).Height ) );
                    break;
                case Class.Priest:
                    Game1.Instance.draw( Sprites.GetTexture( "priest" ), new Rectangle( x, y, Sprites.GetTexture( "priest" ).Width, Sprites.GetTexture( "priest" ).Height ) );
                    break;
                case Class.Warrior:
                    Game1.Instance.draw( Sprites.GetTexture( "warrior" ), new Rectangle( x, y, Sprites.GetTexture( "warrior" ).Width, Sprites.GetTexture( "warrior" ).Height ) );
                    break;
                case Class.Knight:
                    Game1.Instance.draw( Sprites.GetTexture( "knight" ), new Rectangle( x, y, Sprites.GetTexture( "knight" ).Width, Sprites.GetTexture( "knight" ).Height ) );
                    break;
                case Class.Paladin:
                    Game1.Instance.draw( Sprites.GetTexture( "paladin" ), new Rectangle( x, y, Sprites.GetTexture( "paladin" ).Width, Sprites.GetTexture( "paladin" ).Height ) );
                    break;
                case Class.Assassin:
                    Game1.Instance.draw( Sprites.GetTexture( "assassin" ), new Rectangle( x, y, Sprites.GetTexture( "assassin" ).Width, Sprites.GetTexture( "assassin" ).Height ) );
                    break;
                case Class.Necromancer:
                    Game1.Instance.draw( Sprites.GetTexture( "necromancer" ), new Rectangle( x, y, Sprites.GetTexture( "necromancer" ).Width, Sprites.GetTexture( "necromancer" ).Height ) );
                    break;
                case Class.Huntress:
                    Game1.Instance.draw( Sprites.GetTexture( "huntress" ), new Rectangle( x, y, Sprites.GetTexture( "huntress" ).Width, Sprites.GetTexture( "huntress" ).Height ) );
                    break;
                case Class.Mystic:
                    Game1.Instance.draw( Sprites.GetTexture( "mystic" ), new Rectangle( x, y, Sprites.GetTexture( "mystic" ).Width, Sprites.GetTexture( "mystic" ).Height ) );
                    break;
                case Class.Trickster:
                    Game1.Instance.draw( Sprites.GetTexture( "trickster" ), new Rectangle( x, y, Sprites.GetTexture( "trickster" ).Width, Sprites.GetTexture( "trickster" ).Height ) );
                    break;
                case Class.Sorcerer:
                    Game1.Instance.draw( Sprites.GetTexture( "sorcerer" ), new Rectangle( x, y, Sprites.GetTexture( "sorcerer" ).Width, Sprites.GetTexture( "sorcerer" ).Height ) );
                    break;
                case Class.Ninja:
                    Game1.Instance.draw( Sprites.GetTexture( "ninja" ), new Rectangle( x, y, Sprites.GetTexture( "ninja" ).Width, Sprites.GetTexture( "ninja" ).Height ) );
                    break;
                case Class.Samurai:
                    Game1.Instance.draw( Sprites.GetTexture( "samurai" ), new Rectangle( x, y, Sprites.GetTexture( "samurai" ).Width, Sprites.GetTexture( "samurai" ).Height ) );
                    break;
                default:
                    break;
            }
        }
        public static void DrawClassIcon ( Class chr, int x, int y, int w, int h )
        {
            switch ( chr )
            {
                case Class.Rogue:
                    Game1.Instance.draw( Sprites.GetTexture( "rogue" ), new Rectangle( x, y, w, h ) );
                    break;
                case Class.Archer:
                    Game1.Instance.draw( Sprites.GetTexture( "archer" ), new Rectangle( x, y, w, h ) );
                    break;
                case Class.Wizard:
                    Game1.Instance.draw( Sprites.GetTexture( "wizard" ), new Rectangle( x, y, w, h ) );
                    break;
                case Class.Priest:
                    Game1.Instance.draw( Sprites.GetTexture( "priest" ), new Rectangle( x, y, w, h ) );
                    break;
                case Class.Warrior:
                    Game1.Instance.draw( Sprites.GetTexture( "warrior" ), new Rectangle( x, y, w, h ) );
                    break;
                case Class.Knight:
                    Game1.Instance.draw( Sprites.GetTexture( "knight" ), new Rectangle( x, y, w, h ) );
                    break;
                case Class.Paladin:
                    Game1.Instance.draw( Sprites.GetTexture( "paladin" ), new Rectangle( x, y, w, h ) );
                    break;
                case Class.Assassin:
                    Game1.Instance.draw( Sprites.GetTexture( "assassin" ), new Rectangle( x, y, w, h ) );
                    break;
                case Class.Necromancer:
                    Game1.Instance.draw( Sprites.GetTexture( "necromancer" ), new Rectangle( x, y, w, h ) );
                    break;
                case Class.Huntress:
                    Game1.Instance.draw( Sprites.GetTexture( "huntress" ), new Rectangle( x, y, w, h ) );
                    break;
                case Class.Mystic:
                    Game1.Instance.draw( Sprites.GetTexture( "mystic" ), new Rectangle( x, y, w, h ) );
                    break;
                case Class.Trickster:
                    Game1.Instance.draw( Sprites.GetTexture( "trickster" ), new Rectangle( x, y, w, h ) );
                    break;
                case Class.Sorcerer:
                    Game1.Instance.draw( Sprites.GetTexture( "sorcerer" ), new Rectangle( x, y, w, h ) );
                    break;
                case Class.Ninja:
                    Game1.Instance.draw( Sprites.GetTexture( "ninja" ), new Rectangle( x, y, w, h ) );
                    break;
                case Class.Samurai:
                    Game1.Instance.draw( Sprites.GetTexture( "samurai" ), new Rectangle( x, y, w, h ) );
                    break;
                default:
                    break;
            }
        }

        public static void DrawSmallString ( string text, int x, int y, Color color )
        {
            Game1.Instance.spriteBatch.DrawString( Game1.Instance.font, text, new Vector2( x, y ), color );
        }

        public static void DrawBigString ( string text, int x, int y, Color color )
        {
            Game1.Instance.spriteBatch.DrawString( Game1.Instance.TimerFont, text, new Vector2( x, y ), color );
        }

        public static RectangleF RectToRectF ( Rectangle rect )
        {
            return new RectangleF( rect.X, rect.Y, rect.Width, rect.Height );
        }

        public static void DrawRarityString ( Item item, Rectangle bounds )
        {
            if ( item != null )
            {
                Color color = Color.White;
                if ( item.Rarity == Rarity.Common )
                {
                    color = Color.White;
                }
                else if ( item.Rarity == Rarity.Uncommon )
                {
                    color = Color.LightGray;
                }
                else if ( item.Rarity == Rarity.Rare )
                {
                    color = Color.LightCyan;
                }
                else if ( item.Rarity == Rarity.Legendary )
                {
                    color = Color.Gold;
                }
                else if ( item.Rarity == Rarity.Mystical )
                {
                    color = new Color( 255, 0, 255 );
                }
                DrawSmallString( $"Rarity: {item.Rarity}", bounds, color );
            }
        }


        public static void DrawSmallString ( string strToDraw, Rectangle boundaries, Color color )
        {
            Vector2 size = Game1.Instance.font.MeasureString( strToDraw );

            float xScale = ( boundaries.Width / size.X );
            float yScale = ( boundaries.Height / size.Y );

            // Taking the smaller scaling value will result in the text always fitting in the boundaires.
            float scale = Math.Min( xScale, yScale );

            // Figure out the location to absolutely-center it in the boundaries rectangle.
            int strWidth = ( int ) Math.Round( size.X * scale );
            int strHeight = ( int ) Math.Round( size.Y * scale );
            Vector2 position = new Vector2( );
            position.X = ( ( ( boundaries.Width - strWidth ) / 2 ) + boundaries.X );
            position.Y = ( ( ( boundaries.Height - strHeight ) / 2 ) + boundaries.Y );

            // A bunch of settings where we just want to use reasonable defaults.
            float rotation = 0.0f;
            Vector2 spriteOrigin = new Vector2( 0, 0 );
            float spriteLayer = 0.0f; // all the way in the front
            SpriteEffects spriteEffects = new SpriteEffects( );

            // Draw the string to the sprite batch!
            Game1.Instance.spriteBatch.DrawString( Game1.Instance.font, strToDraw, position, color, rotation, spriteOrigin, scale, spriteEffects, spriteLayer );
        }

        public static void DrawBigString ( string strToDraw, Rectangle boundaries, Color color )
        {
            Vector2 size = Game1.Instance.TimerFont.MeasureString( strToDraw );

            float xScale = ( boundaries.Width / size.X );
            float yScale = ( boundaries.Height / size.Y );

            // Taking the smaller scaling value will result in the text always fitting in the boundaires.
            float scale = Math.Min( xScale, yScale );

            // Figure out the location to absolutely-center it in the boundaries rectangle.
            int strWidth = ( int ) Math.Round( size.X * scale );
            int strHeight = ( int ) Math.Round( size.Y * scale );
            Vector2 position = new Vector2( );
            position.X = ( ( ( boundaries.Width - strWidth ) / 2 ) + boundaries.X );
            position.Y = ( ( ( boundaries.Height - strHeight ) / 2 ) + boundaries.Y );

            // A bunch of settings where we just want to use reasonable defaults.
            float rotation = 0.0f;
            Vector2 spriteOrigin = new Vector2( 0, 0 );
            float spriteLayer = 0.0f; // all the way in the front
            SpriteEffects spriteEffects = new SpriteEffects( );

            // Draw the string to the sprite batch!
            Game1.Instance.spriteBatch.DrawString( Game1.Instance.TimerFont, strToDraw, position, color, rotation, spriteOrigin, scale, spriteEffects, spriteLayer );
        }

        public static Rectangle RectFToRect ( RectangleF rectf )
        {
            return new Rectangle( ( int ) rectf.X, ( int ) rectf.Y, ( int ) rectf.Width, ( int ) rectf.Height );
        }

        private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider( );

        public static int GenerateRandomNumber ( int min, int max )
        {

            byte [ ] randomNumber = new byte [ 1 ];

            _generator.GetBytes( randomNumber );

            double asciiValueOfRandomCharacter = Convert.ToDouble( randomNumber [ 0 ] );

            // We are using Math.Max, and substracting 0.00000000001,
            // to ensure "multiplier" will always be between 0.0 and .99999999999
            // Otherwise, it's possible for it to be "1", which causes problems in our rounding.
            double multiplier = Math.Max( 0, ( asciiValueOfRandomCharacter / 255d ) - 0.00000000001d );

            // We need to add one to the range, to allow for the rounding done with Math.Floor
            int range = max - min + 1;

            double randomValueInRange = Math.Floor( multiplier * range );

            return ( int ) ( min + randomValueInRange );
        }
    }
}
