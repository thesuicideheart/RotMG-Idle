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

        public RectangleF bounds = new RectangleF( 100, 100, Option.Width - 200, Option.Height - 200 );
        public Button OkBtn;


        public MessageBox ( )
        {
            OkBtn = new Button( "Okay", bounds.X + ( bounds.Width / 2 ) - 50, bounds.Y + bounds.Height - 100, 192, 24, Color.Blue );
        }

        public bool Active = false;

        public void Show ( string text )
        {
            Active = true;
            this.text = text;
        }

        public void Close ( )
        {
            Active = false;
            this.text = "";
        }

        public void Update ( )
        {
            if ( OkBtn.MouseClicked( ) )
            {
                Close( );
            }
        }

        public void Draw ( SpriteBatch batch )
        {
            if ( Active )
            {
                batch.FillRectangle( bounds, GameData.LightBorderColor );
                batch.DrawRectangle( bounds, GameData.BorderColor, 3 );
                Utils.DrawBigString( text, ( int ) bounds.X + 10, ( int ) bounds.Y + 10, Color.White );
                OkBtn.Draw( batch );
            }
        }

    }
}
