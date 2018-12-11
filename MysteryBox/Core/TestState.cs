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

        private int invX = 60;
        private int invY = Option.Height / 2 - 40;
        private int invListSpacing = 60;

        private int newInvX = 260;

        private int SelectedItem = 0;

        private Button testbtn;


        public TestState ( Player player ) : base( GameData.TestState )
        {

            Player = player;
            testbtn = new Button( "Xd", 100, 100, 100, 100, Color.Blue );
        }

        public override void Draw ( SpriteBatch batch )
        {

            testbtn.Draw( batch );
            for ( int i = -3 ; i < 4 ; i++ )
            {
                if ( SelectedItem + i < 0 || SelectedItem + i >= GameData.UnitsInGame.Count ) continue;
                var unit = GameData.UnitsInGame [ SelectedItem + i ];
                if ( i == 0 )
                {
                    Utils.DrawSmallString( $"  >{unit.Name}<", invX, ( invY + i * invListSpacing ) + 10, Color.White );
                }
                else
                {
                    Utils.DrawSmallString( $"{unit.Name}", invX, ( invY + i * invListSpacing ) + 10, Color.White );
                }

            }

            Utils.DrawBigString( $"Fame: {Player.Fame}", 500, 40, Color.White );

            for ( var i = 0 ; i < Player.Units.Count( ) ; i++ )
            {
                Utils.DrawSmallString( $"Unit: {GameData.GetUnit( Player.Units [ i ].UnitID ).Name} x{Player.Units [ i ].Count}", newInvX, ( invY + i * invListSpacing ) + 10, Color.White );
            }
            base.Draw( batch );
        }

        public override void Update ( )
        {
            if ( !MessageBox.Active )
            {
                if ( SelectedItem < 0 )
                    SelectedItem = GameData.UnitsInGame.Count - 1;
                else if ( SelectedItem >= GameData.UnitsInGame.Count )
                    SelectedItem = 0;

                if ( testbtn.MouseClicked( ) )
                {

                    var pUnit = new PlayerUnit( GameData.UnitsInGame [ SelectedItem ].ID );
                    Player.BuyUnit( pUnit );
                    MessageBox.Show( $"Bought unit \"{GameData.UnitsInGame [ SelectedItem ].Name}\" for {GameData.UnitsInGame [ SelectedItem ].Price} Fame!" );
                }

                if ( Game1.Instance.input.JustPressed( Keys.W ) || Game1.Instance.input.JustPressed( Keys.Up ) )
                {
                    SelectedItem--;
                }
                if ( Game1.Instance.input.JustPressed( Keys.S ) || Game1.Instance.input.JustPressed( Keys.Down ) )
                {
                    SelectedItem++;
                }
            }

            //TODO: Prettify this at some point in time.
            //TODO: Implement a "buy" feature. Probs gonna do that today(10-12-2018)

            base.Update( );
        }

    }
}
