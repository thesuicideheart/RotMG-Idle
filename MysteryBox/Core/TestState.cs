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

        private int Size = 64;

        public TestState ( Player player ) : base( GameData.TestState )
        {

            Player = player;
            charSlot = Sprites.GetTexture( "big_slot" );
            charSlotRect = new Rectangle( Option.Width / 2 - charSlot.Width / 2, Option.Height / 2 - charSlot.Height / 2 - 150, charSlot.Width, charSlot.Height );
            charNameRect = new Rectangle( charSlotRect.X, charSlotRect.Y + charSlotRect.Height, charSlot.Width, 24 );
            charClassRect = new Rectangle( charNameRect.X, charNameRect.Y + charNameRect.Height, charSlot.Width, 24 );

            HealthRect = new Rectangle( charClassRect.X - Size, charClassRect.Y + charClassRect.Height, Size * 3, 24 );
            ManaRect = new Rectangle( HealthRect.X, HealthRect.Y + HealthRect.Height, HealthRect.Width, 24 );
            AtkRect = new Rectangle( HealthRect.X, ManaRect.Y + ManaRect.Height, Size * 3, HealthRect.Height );
            DefRect = new Rectangle( AtkRect.X, AtkRect.Y + AtkRect.Height, Size * 3, HealthRect.Height );
            SpdRect = new Rectangle( DefRect.X, DefRect.Y + DefRect.Height, Size * 3, HealthRect.Height );
            DexRect = new Rectangle( SpdRect.X, SpdRect.Y + SpdRect.Height, Size * 3, HealthRect.Height );
            VitRect = new Rectangle( DexRect.X, DexRect.Y + DexRect.Height, Size * 3, HealthRect.Height );
            WisRect = new Rectangle( VitRect.X, VitRect.Y + VitRect.Height, Size * 3, HealthRect.Height );
        }

        public override void Draw ( SpriteBatch batch )
        {
            Game1.Instance.draw( charSlot, charSlotRect );
            if ( Player.ActiveCharacter != null )
            {
                Utils.DrawClassIcon( Player.ActiveCharacter.Class, charSlotRect.X + 8, charSlotRect.Y + 8, charSlotRect.Width - 16, charSlotRect.Height - 16 );
                Utils.DrawBigString( Player.ActiveCharacter.Name, charNameRect, Color.White );
                Utils.DrawBigString( Player.ActiveCharacter.Class.ToString( ), charClassRect, Color.White );


                #region fillament


                //Health
                batch.FillRectangle( Utils.RectToRectF( HealthRect ), GameData.BorderColor );
                batch.FillRectangle( new RectangleF( HealthRect.X, HealthRect.Y, Player.ActiveCharacter.Stats.HP / Player.ActiveCharacter.Stats.MaxHP * HealthRect.Width, HealthRect.Height ), GameData.LifeColor );

                //Mana
                batch.FillRectangle( Utils.RectToRectF( ManaRect ), GameData.BorderColor );
                batch.FillRectangle( new RectangleF( ManaRect.X, ManaRect.Y, Player.ActiveCharacter.Stats.MP / Player.ActiveCharacter.Stats.MaxMP * ManaRect.Width, ManaRect.Height ), GameData.ManaColor );

                //Attack
                batch.FillRectangle( Utils.RectToRectF( AtkRect ), GameData.BorderColor );
                batch.FillRectangle( new RectangleF( AtkRect.X, AtkRect.Y, Player.ActiveCharacter.Stats.Atk / Player.ActiveCharacter.Stats.MaxAtk * AtkRect.Width, AtkRect.Height ), GameData.AttackColor );

                //Defence
                batch.FillRectangle( Utils.RectToRectF( DefRect ), GameData.BorderColor );
                batch.FillRectangle( new RectangleF( DefRect.X, DefRect.Y, Player.ActiveCharacter.Stats.Def / Player.ActiveCharacter.Stats.MaxDef * DefRect.Width, DefRect.Height ), GameData.DefenceColor );

                //Speed
                batch.FillRectangle( Utils.RectToRectF( SpdRect ), GameData.BorderColor );
                batch.FillRectangle( new RectangleF( SpdRect.X, SpdRect.Y, Player.ActiveCharacter.Stats.Spd / Player.ActiveCharacter.Stats.MaxSpd * SpdRect.Width, SpdRect.Height ), GameData.SpeedColor );

                //Dexterity
                batch.FillRectangle( Utils.RectToRectF( DexRect ), GameData.BorderColor );
                batch.FillRectangle( new RectangleF( DexRect.X, DexRect.Y, Player.ActiveCharacter.Stats.Dex / Player.ActiveCharacter.Stats.MaxDex * DexRect.Width, DexRect.Height ), GameData.DexterityColor );

                //Vitality
                batch.FillRectangle( Utils.RectToRectF( VitRect ), GameData.BorderColor );
                batch.FillRectangle( new RectangleF( VitRect.X, VitRect.Y, Player.ActiveCharacter.Stats.Vit / Player.ActiveCharacter.Stats.MaxVit * VitRect.Width, VitRect.Height ), GameData.VitalityColor );

                //Wisdom
                batch.FillRectangle( Utils.RectToRectF( WisRect ), GameData.BorderColor );
                batch.FillRectangle( new RectangleF( WisRect.X, WisRect.Y, Player.ActiveCharacter.Stats.Wis / Player.ActiveCharacter.Stats.MaxWis * WisRect.Width, WisRect.Height ), GameData.WisdomColor );


                #endregion

                #region text
                if ( Player.ActiveCharacter.IsHealthMaxed )
                    Utils.DrawBigString( $"HP: {Player.ActiveCharacter.Stats.HP}/{Player.ActiveCharacter.Stats.MaxHP}", HealthRect, Color.Gold );
                else
                    Utils.DrawBigString( $"HP: {Player.ActiveCharacter.Stats.HP}/{Player.ActiveCharacter.Stats.MaxHP}", HealthRect, Color.White );

                if ( Player.ActiveCharacter.IsManaMaxed )
                    Utils.DrawBigString( $"MP: {Player.ActiveCharacter.Stats.MP}/{Player.ActiveCharacter.Stats.MaxMP}", ManaRect, Color.Gold );
                else
                    Utils.DrawBigString( $"MP: {Player.ActiveCharacter.Stats.MP}/{Player.ActiveCharacter.Stats.MaxMP}", ManaRect, Color.White );

                if ( Player.ActiveCharacter.IsAttackMaxed )
                    Utils.DrawBigString( $"Atk: {Player.ActiveCharacter.Stats.Atk}/{Player.ActiveCharacter.Stats.MaxAtk}", AtkRect, Color.Gold );
                else
                    Utils.DrawBigString( $"Atk: {Player.ActiveCharacter.Stats.Atk}/{Player.ActiveCharacter.Stats.MaxAtk}", AtkRect, Color.White );

                if ( Player.ActiveCharacter.IsDefenceMaxed )
                    Utils.DrawBigString( $"Def: {Player.ActiveCharacter.Stats.Def}/{Player.ActiveCharacter.Stats.MaxDef}", DefRect, Color.Gold );
                else
                    Utils.DrawBigString( $"Def: {Player.ActiveCharacter.Stats.Def}/{Player.ActiveCharacter.Stats.MaxDef}", DefRect, Color.White );

                if ( Player.ActiveCharacter.IsSpeedMaxed )
                    Utils.DrawBigString( $"Spd: {Player.ActiveCharacter.Stats.Spd}/{Player.ActiveCharacter.Stats.MaxSpd}", SpdRect, Color.Gold );
                else
                    Utils.DrawBigString( $"Spd: {Player.ActiveCharacter.Stats.Spd}/{Player.ActiveCharacter.Stats.MaxSpd}", SpdRect, Color.White );

                if ( Player.ActiveCharacter.IsDexterityMaxed )
                    Utils.DrawBigString( $"Dex: {Player.ActiveCharacter.Stats.Dex}/{Player.ActiveCharacter.Stats.MaxDex}", DexRect, Color.Gold );
                else
                    Utils.DrawBigString( $"Dex: {Player.ActiveCharacter.Stats.Dex}/{Player.ActiveCharacter.Stats.MaxDex}", DexRect, Color.White );

                if ( Player.ActiveCharacter.IsVitalityMaxed )
                    Utils.DrawBigString( $"Vit: {Player.ActiveCharacter.Stats.Vit}/{Player.ActiveCharacter.Stats.MaxVit}", VitRect, Color.Gold );
                else
                    Utils.DrawBigString( $"Vit: {Player.ActiveCharacter.Stats.Vit}/{Player.ActiveCharacter.Stats.MaxVit}", VitRect, Color.White );

                if ( Player.ActiveCharacter.IsWisdomMaxed )
                    Utils.DrawBigString( $"Wis: {Player.ActiveCharacter.Stats.Wis}/{Player.ActiveCharacter.Stats.MaxWis}", WisRect, Color.Gold );
                else
                    Utils.DrawBigString( $"Wis: {Player.ActiveCharacter.Stats.Wis}/{Player.ActiveCharacter.Stats.MaxWis}", WisRect, Color.White );

                #endregion

                #region borders
                batch.DrawRectangle( Utils.RectToRectF( HealthRect ), Color.Black, 1 );
                batch.DrawRectangle( Utils.RectToRectF( ManaRect ), Color.Black, 1 );
                batch.DrawRectangle( Utils.RectToRectF( AtkRect ), Color.Black, 1 );
                batch.DrawRectangle( Utils.RectToRectF( DefRect ), Color.Black, 1 );
                batch.DrawRectangle( Utils.RectToRectF( SpdRect ), Color.Black, 1 );
                batch.DrawRectangle( Utils.RectToRectF( DexRect ), Color.Black, 1 );
                batch.DrawRectangle( Utils.RectToRectF( VitRect ), Color.Black, 1 );
                batch.DrawRectangle( Utils.RectToRectF( WisRect ), Color.Black, 1 );

                #endregion
            }

            base.Draw( batch );
        }

        public override void Update ( )
        {

            if ( iStuff < 0 ) iStuff = Player.Characters.Count( ) - 1;
            else if ( iStuff >= Player.Characters.Count ) iStuff = 0;

            if ( Player.Characters.Count( ) > 0 )
                Player.SetActiveCharacter( Player.Characters [ iStuff ] );

            if ( Game1.Instance.input.JustPressed( Keys.F ) )
            {
                if ( Player.ActiveCharacter != null )
                {
                    //Max Health
                    Player.ActiveCharacter.Stats.HP = Player.ActiveCharacter.Stats.MaxHP;
                    Player.ActiveCharacter.Stats.MP = Player.ActiveCharacter.Stats.MaxMP;
                    Player.ActiveCharacter.Stats.Atk = Player.ActiveCharacter.Stats.MaxAtk;
                    Player.ActiveCharacter.Stats.Def = Player.ActiveCharacter.Stats.MaxDef;
                    Player.ActiveCharacter.Stats.Spd = Player.ActiveCharacter.Stats.MaxSpd;
                    Player.ActiveCharacter.Stats.Dex = Player.ActiveCharacter.Stats.MaxDex;
                    Player.ActiveCharacter.Stats.Vit = Player.ActiveCharacter.Stats.MaxVit;
                    Player.ActiveCharacter.Stats.Wis = Player.ActiveCharacter.Stats.MaxWis;
                }
            }

            if ( Game1.Instance.input.JustPressed( Keys.H ) )
            {
                if ( Player.ActiveCharacter != null )
                    Player.ActiveCharacter.Stats.Def -= 1;
            }

            if ( Game1.Instance.input.JustPressed( Keys.G ) )
            {
                if ( Player.ActiveCharacter != null )
                {
                    //Unmax health
                    Player.ActiveCharacter.Stats.HP = 150;
                    Player.ActiveCharacter.Stats.MP = 100;
                    Player.ActiveCharacter.Stats.Atk = 10;
                    Player.ActiveCharacter.Stats.Def = 0;
                    Player.ActiveCharacter.Stats.Spd = 15;
                    Player.ActiveCharacter.Stats.Dex = 15;
                    Player.ActiveCharacter.Stats.Vit = 10;
                    Player.ActiveCharacter.Stats.Wis = 12;
                }
            }

            //Todo: Do GUI for character select.
            //Figure out how to do GUI elements like textbox, scrollbar
            if ( Game1.Instance.input.JustPressed( Keys.A ) )
            {
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
