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
    public class OpenCaseState : State
    {

        public Player player;

        LootBoxAnimationHandler lootBoxAnimationHandler;

        private Button btnCloseInvSmall;

        private Texture2D overlay;

        public OpenCaseState(Player player) : base(GameData.OpenCaseState)
        {
            this.player = player;
            lootBoxAnimationHandler = new LootBoxAnimationHandler();
            overlay = Sprites.GetTexture("inventory");
            btnCloseInvSmall = new Button(740, 18, 34, 33, Sprites.GetTexture("exitbtn"));
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(overlay, new Rectangle(0, 0, 800, 600), Color.White);
            btnCloseInvSmall.Draw(batch);

            lootBoxAnimationHandler.Draw(batch);
            base.Draw(batch);
        }

        public override void Update()
        {
            lootBoxAnimationHandler.Update();
            if (Game1.Instance.input.JustPressed(Keys.F))
            {
                lootBoxAnimationHandler.OpenBox(GameData.BasicBox, player);
            }

            if (btnCloseInvSmall.MouseClicked())
            {
                if (lootBoxAnimationHandler.Active)
                {
                    return;
                }
                else
                {
                    SwitchState(GameData.MainState);
                }
            }

            base.Update();
        }
    }
}
