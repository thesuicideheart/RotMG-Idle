using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MysteryBox.Core
{
    public class TestState : State
    {

        Player Player;

        int iStuff = 0;

        private Texture2D charSlot;

        private Rectangle charSlotRect;

        public TestState ( Player player ) : base( GameData.TestState )
        {

            Player = player;
            charSlot = Sprites.GetTexture( "big_slot" );
            charSlotRect = new Rectangle( Option.Width / 2 - charSlot.Width / 2, Option.Height / 2 - charSlot.Height / 2 - 150, charSlot.Width, charSlot.Height );
        }

        public override void Draw ( SpriteBatch batch )
        {
            Game1.Instance.draw( charSlot, charSlotRect );
            if ( Player.ActiveCharacter != null )
            {
                Utils.DrawClassIcon( Player.ActiveCharacter.Class, charSlotRect.X + 8, charSlotRect.Y + 8, charSlotRect.Width - 16, charSlotRect.Height - 16 );
            }

            base.Draw( batch );
        }

        public override void Update ( )
        {

            if ( iStuff < 0 ) iStuff = Player.Characters.Count( ) - 1;
            else if ( iStuff >= Player.Characters.Count ) iStuff = 0;

            Player.SetActiveCharacter( Player.Characters [ iStuff ] );
            //Todo: Do GUI for character select.
            //Figure out how to do GUI elements like textbox, scrollbar
            if ( Game1.Instance.input.JustPressed( Keys.A ) )
            {
                //TODO: Select char
                iStuff--;
            }

            if ( Game1.Instance.input.JustReleased( Keys.D ) )
            {
                iStuff++;
            }

            base.Update( );
        }

    }
}
