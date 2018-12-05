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
    public class OpenCaseState : State
    {

        public Player player;

        LootBoxAnimationHandler lootBoxAnimationHandler;

        private Button btnCloseInvSmall;

        private Texture2D overlay;

        private Rectangle middleRect, leftRect, rightRect;

        public int rectsize = 80;

        private int selectedCrate;

        public OpenCaseState(Player player) : base(GameData.OpenCaseState)
        {
            this.player = player;
            lootBoxAnimationHandler = new LootBoxAnimationHandler();
            overlay = Sprites.GetTexture("inventory");
            btnCloseInvSmall = new Button(740, 18, 34, 33, Sprites.GetTexture("exitbtn"));

            middleRect = new Rectangle(Option.Width / 2 - 40, Option.Height / 2 - 200, rectsize, rectsize);
            leftRect = new Rectangle(Option.Width / 2 - 180, Option.Height / 2 - 40, rectsize, rectsize);
            rightRect = new Rectangle(Option.Width / 2 + 100, Option.Height / 2 - 40, rectsize, rectsize);

        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(overlay, new Rectangle(0, 0, 800, 600), Color.White);
            btnCloseInvSmall.Draw(batch);

            batch.FillRectangle(Utils.RectToRectF(middleRect), GameData.BorderColor);
            batch.FillRectangle(Utils.RectToRectF(leftRect), GameData.BorderColor);
            batch.FillRectangle(Utils.RectToRectF(rightRect), GameData.BorderColor);

            batch.DrawRectangle(Utils.RectToRectF(middleRect), GameData.LightBorderColor, 5);
            batch.DrawRectangle(Utils.RectToRectF(leftRect), GameData.LightBorderColor, 5);
            batch.DrawRectangle(Utils.RectToRectF(rightRect), GameData.LightBorderColor, 5);

            //TODO: Implement case rendering method

            for (int i = -1; i < 2; i++)
            {
                if (selectedCrate + i < 0 || selectedCrate + i >= GameData.LootBoxesInGame.Count) continue;
                var crate = GameData.LootBoxesInGame[selectedCrate + i];
                //Todo: Implement a much better drawing code here
                if (i == 0)
                {
                    Game1.Instance.draw(crate.Texture, middleRect);
                }
                else
                {
                    if(i == -1)
                    {
                        Game1.Instance.draw(crate.Texture, leftRect);
                    }
                    else if(i == 1)
                    {
                        Game1.Instance.draw(crate.Texture, rightRect);
                    }
                }
            }


            lootBoxAnimationHandler.Draw(batch);
            base.Draw(batch);
        }

        public override void Update()
        {
            lootBoxAnimationHandler.Update();

            if (selectedCrate < 0)
                selectedCrate = GameData.LootBoxesInGame.Count - 1;
            else if (selectedCrate >= GameData.LootBoxesInGame.Count)
                selectedCrate = 0;

            

            if (!lootBoxAnimationHandler.Active)
            {
                if (Game1.Instance.input.JustPressed(Keys.W) || Game1.Instance.input.JustPressed(Keys.Up))
                {
                    selectedCrate--;
                }
                if (Game1.Instance.input.JustPressed(Keys.S) || Game1.Instance.input.JustPressed(Keys.Down))
                {
                    selectedCrate++;
                }

                if (middleRect.RectangleClicked())
                {
                    Console.WriteLine($"Current index: {selectedCrate}");
                }

                if (rightRect.RectangleClicked())
                {
                    Console.WriteLine("xd 2");
                }

                if (leftRect.RectangleClicked())
                {
                    Console.WriteLine("xd 3");
                }

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

            RPC.SetPresence("Browsing the boxes", "Browsing", "mystery_box", "Looking at boxes");

            base.Update();
        }
    }
}
