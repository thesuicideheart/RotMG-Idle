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

        public Button btnGetFame, btnInv, btnMysteryBox;

        private Rectangle rectInvText, rectMysteryBoxText;

        private Vector2 labelPos = new Vector2(162, 62);

        public Texture2D getFameSprite, backgroundSprite, fameLabel, invIcon, mysteryBoxIcon;



        public MainState(Player player) : base(GameData.MainState)
        {
            Player = player;
            backgroundSprite = Sprites.GetTexture("inventory");
            getFameSprite = Sprites.GetTexture("get_fame");
            fameLabel = Sprites.GetTexture("fame_label");
            invIcon = Sprites.GetTexture("inv_icon");
            mysteryBoxIcon = Sprites.GetTexture("mystery_box");
            btnGetFame = new Button(315, 533, getFameSprite.Width, getFameSprite.Height, getFameSprite);
            btnInv = new Button(113, 20, invIcon.Width, invIcon.Height, invIcon);
            btnMysteryBox = new Button(218, 22, mysteryBoxIcon.Width, mysteryBoxIcon.Height, mysteryBoxIcon);
            rectInvText = new Rectangle((int)(btnInv.X + btnInv.Width), (int)(btnInv.Y + 4), 64, 24);
            rectMysteryBoxText = new Rectangle((int)(btnMysteryBox.X + btnMysteryBox.Width), (int)(btnMysteryBox.Y + 4), 96, 24);
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(backgroundSprite, new Rectangle(0, 0, Option.Width, Option.Height), Color.White);
            btnGetFame.Draw(batch);
            batch.Draw(fameLabel, new Rectangle((int)labelPos.X, (int)labelPos.Y, fameLabel.Width, fameLabel.Height), Color.White);
            btnInv.Draw(batch);
            btnMysteryBox.Draw(batch);

            Utils.DrawBigString($"Fame: {Player.Fame}", (int)Option.Width / 2 - 60, (int)labelPos.Y, Color.White);
            Utils.DrawBigString("Inventory", rectInvText, Color.White);
            Utils.DrawBigString("Mystery Boxes", rectMysteryBoxText, Color.White);
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

            if (btnInv.MouseClicked() || rectInvText.RectangleClicked())
            {
                Game1.Instance.SwitchState(GameData.InvState);
            }

            if (btnMysteryBox.MouseClicked() || rectMysteryBoxText.RectangleClicked())
            {
                Game1.Instance.SwitchState(GameData.OpenCaseState);
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
