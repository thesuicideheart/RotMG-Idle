using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;

namespace MysteryBox.Core
{
    public class TestState : State
    {

        Player Player;

        int iStuff = 0;

        private Texture2D charSlot;

        private Rectangle charSlotRect;
        private Rectangle charNameRect;
        private Rectangle charClassRect;
        private Rectangle HealthRect, ManaRect;
        private Rectangle DefRect, AtkRect;
        private Rectangle DexRect, SpdRect;
        private Rectangle WisRect, VitRect;

        public TestState ( Player player ) : base( GameData.TestState )
        {

            Player = player;
            charSlot = Sprites.GetTexture( "big_slot" );
            charSlotRect = new Rectangle( Option.Width / 2 - charSlot.Width / 2, Option.Height / 2 - charSlot.Height / 2 - 150, charSlot.Width, charSlot.Height );
            charNameRect = new Rectangle( charSlotRect.X, charSlotRect.Y + charSlotRect.Height, charSlot.Width, 24 );
            charClassRect = new Rectangle( charNameRect.X, charNameRect.Y + charNameRect.Height, charSlot.Width, 24 );

            HealthRect = new Rectangle( charClassRect.X - 48, charClassRect.Y + charClassRect.Height, 48, 48 );
            ManaRect = new Rectangle( charClassRect.X + charClassRect.Width, HealthRect.Y, 48, 48 );

            AtkRect = new Rectangle( HealthRect.X, HealthRect.Y + HealthRect.Height, 48, 48 );
            DefRect = new Rectangle( ManaRect.X, ManaRect.Y + ManaRect.Width, 48, 48 );

            SpdRect = new Rectangle( AtkRect.X, AtkRect.Y + AtkRect.Height, 48, 48 );
            DexRect = new Rectangle( DefRect.X, DefRect.Y + DefRect.Height, 48, 48 );

            VitRect = new Rectangle( SpdRect.X, SpdRect.Y + SpdRect.Width, 48, 48 );
            WisRect = new Rectangle( DexRect.X, DexRect.Y + DexRect.Width, 48, 48 );
        }

        public override void Draw ( SpriteBatch batch )
        {
            Game1.Instance.draw( charSlot, charSlotRect );
            if ( Player.ActiveCharacter != null )
            {
                Utils.DrawClassIcon( Player.ActiveCharacter.Class, charSlotRect.X + 8, charSlotRect.Y + 8, charSlotRect.Width - 16, charSlotRect.Height - 16 );
                Utils.DrawBigString( Player.ActiveCharacter.Name, charNameRect, Color.White );
                Utils.DrawBigString( Player.ActiveCharacter.Class.ToString( ), charClassRect, Color.White );
                Utils.DrawBigString( $"HP\n{Player.ActiveCharacter.Stats.HP}/{Player.ActiveCharacter.Stats.MaxHP}", HealthRect, Color.Red );
                Utils.DrawBigString( $"MP\n{Player.ActiveCharacter.Stats.MP}/{Player.ActiveCharacter.Stats.MaxMP}", ManaRect, Color.Blue );
                Utils.DrawBigString( $"Atk\n{Player.ActiveCharacter.Stats.Atk}/{Player.ActiveCharacter.Stats.MaxAtk}", AtkRect, Color.Purple );
                Utils.DrawBigString( $"Def\n{Player.ActiveCharacter.Stats.Def}/{Player.ActiveCharacter.Stats.MaxDef}", DefRect, Color.DarkGray );
                Utils.DrawBigString( $"Spd\n{Player.ActiveCharacter.Stats.Spd}/{Player.ActiveCharacter.Stats.MaxSpd}", SpdRect, Color.Green );
                Utils.DrawBigString( $"Dex\n{Player.ActiveCharacter.Stats.Dex}/{Player.ActiveCharacter.Stats.MaxDex}", DexRect, Color.Orange );
                Utils.DrawBigString( $"Spd\n{Player.ActiveCharacter.Stats.Spd}/{Player.ActiveCharacter.Stats.MaxSpd}", SpdRect, Color.Green );
                Utils.DrawBigString( $"Dex\n{Player.ActiveCharacter.Stats.Dex}/{Player.ActiveCharacter.Stats.MaxDex}", DexRect, Color.Orange );
                //TODO: Set vit and wis to its assigned rectangle. Do this when i get home

#if DEBUG
                batch.DrawRectangle( Utils.RectToRectF( HealthRect ), Color.Black, 1 );
                batch.DrawRectangle( Utils.RectToRectF( ManaRect ), Color.Black, 1 );
                batch.DrawRectangle( Utils.RectToRectF( AtkRect ), Color.Black, 1 );
                batch.DrawRectangle( Utils.RectToRectF( DefRect ), Color.Black, 1 );
                batch.DrawRectangle( Utils.RectToRectF( SpdRect ), Color.Black, 1 );
                batch.DrawRectangle( Utils.RectToRectF( DexRect ), Color.Black, 1 );
#endif
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
