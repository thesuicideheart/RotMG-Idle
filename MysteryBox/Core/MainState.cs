using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MysteryBox.Core
{
    public class MainState : State
    {
        public Player Player;

        public MainState(Player player) : base(GameData.MainState)
        {
            Player = player;
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
        }

        int timer;

        public override void Update()
        {
            timer++;

            if (timer % 20 == 0)
            {
                //Update RPC 3 times a second
                RPC.SetPresence("Farming fame", $"Current fame: {Player.Fame}", "fame", $"Currently at {Player.Fame} fame!");
            }

            if (Game1.Instance.input.JustPressed(Keys.E))
            {
                Game1.Instance.SwitchState(GameData.InvState);
            }

            if (Game1.Instance.input.JustPressed(Keys.F))
            {
                //increment
                Player.Fame += 10;
            }

            base.Update();
        }
    }
}
