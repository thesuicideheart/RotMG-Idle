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
    public class MainState : State
    {
        public Player Player;

        public Button btnGetFame;

        private Vector2 labelPos = new Vector2(162, 62);

        public Texture2D getFameSprite, backgroundSprite, fameLabel;

        public MainState(Player player) : base(GameData.MainState)
        {
            Player = player;
            backgroundSprite = Sprites.GetTexture("inventory");
            getFameSprite = Sprites.GetTexture("get_fame");
            fameLabel = Sprites.GetTexture("fame_label");
            btnGetFame = new Button(315, 533, getFameSprite.Width, getFameSprite.Height, getFameSprite);

        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(backgroundSprite, new Rectangle(0, 0, Option.Width, Option.Height), Color.White);
            btnGetFame.Draw(batch);
            batch.Draw(fameLabel, new Rectangle((int)labelPos.X, (int)labelPos.Y, fameLabel.Width, fameLabel.Height), Color.White);

            Utils.DrawBigString($"Fame: {Player.Fame}", (int)labelPos.X, (int)labelPos.Y, Color.White);

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

            if (btnGetFame.MouseClicked())
            {
                Player.Fame += 1;
            }

            if (Game1.Instance.input.JustPressed(Keys.E))
            {
                Game1.Instance.SwitchState(GameData.InvState);
            }

#if DEBUG
            if (Game1.Instance.input.JustPressed(Keys.F))
            {
                //increment
                Player.Fame += 10;
            }
#endif
            base.Update();
        }
    }
}
