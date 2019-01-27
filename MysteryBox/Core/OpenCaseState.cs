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

        private Texture2D overlay, fameIcon;

        private Rectangle middleRect, leftRect, rightRect;
        private Rectangle middleNameRect, middlePriceRect;
        private Rectangle leftNameRect, leftPriceRect;
        private Rectangle rightNameRect, rightPriceRect;
        private Rectangle FameRect;

        public int rectsize = 80;

        private int selectedCrate;

        public OpenCaseState(Player player) : base(GameData.OpenCaseState)
        {
            this.player = player;
            lootBoxAnimationHandler = new LootBoxAnimationHandler();
            overlay = Sprites.GetTexture("inventory");
            fameIcon = Sprites.GetTexture("fame_small");
            btnCloseInvSmall = new Button(740, 18, 34, 33, Sprites.GetTexture("exitbtn"));

            middleRect = new Rectangle(Option.Width / 2 - 40, Option.Height / 2 - 200, rectsize, rectsize);
            leftRect = new Rectangle(Option.Width / 2 - 180, Option.Height / 2 - 40, rectsize, rectsize);
            rightRect = new Rectangle(Option.Width / 2 + 100, Option.Height / 2 - 40, rectsize, rectsize);

            middleNameRect = new Rectangle(middleRect.X - 28, middleRect.Y + middleRect.Height, 128, 24);
            middlePriceRect = new Rectangle(middleRect.X - 28, middleNameRect.Y + middleNameRect.Height, 128, 20);

            leftNameRect = new Rectangle(leftRect.X - 28, leftRect.Y + leftRect.Height, 128, 24);
            leftPriceRect = new Rectangle(leftRect.X - 28, leftNameRect.Y + leftNameRect.Height, 128, 20);

            rightNameRect = new Rectangle(rightRect.X - 28, rightRect.Y + rightRect.Height, 128, 24);
            rightPriceRect = new Rectangle(rightRect.X - 28, rightNameRect.Y + rightNameRect.Height, 128, 20);

            FameRect = new Rectangle(102 + fameIcon.Width, 14, 64, 36);

        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(overlay, new Rectangle(0, 0, 800, 600), Color.White);
            batch.Draw(fameIcon, new Rectangle(102, 14, fameIcon.Width, fameIcon.Height), Color.White);
            btnCloseInvSmall.Draw(batch);
            Utils.DrawSmallString($"{player.Fame}", FameRect, Color.White);


            batch.FillRectangle(Utils.RectToRectF(middleRect), GameData.BorderColor);
            batch.FillRectangle(Utils.RectToRectF(leftRect), GameData.BorderColor);
            batch.FillRectangle(Utils.RectToRectF(rightRect), GameData.BorderColor);

            batch.DrawRectangle(Utils.RectToRectF(middleRect), GameData.LightBorderColor, 5);
            batch.DrawRectangle(Utils.RectToRectF(leftRect), GameData.LightBorderColor, 5);
            batch.DrawRectangle(Utils.RectToRectF(rightRect), GameData.LightBorderColor, 5);
            

            for (int i = -1; i < 2; i++)
            {
                if (selectedCrate + i < 0 || selectedCrate + i >= GameData.LootBoxesInGame.Count) continue;
                var crate = GameData.LootBoxesInGame[selectedCrate + i];
                //Todo: Implement a much better drawing code here
                if (i == 0)
                {
                    Game1.Instance.draw(crate.Texture, middleRect);
                    Utils.DrawBigString(crate.Name, middleNameRect, Color.White);
                    Utils.DrawBigString($"Price: {crate.Cost}", middlePriceRect, Color.White);
                }
                else
                {
                    if (i == -1)
                    {
                        Game1.Instance.draw(crate.Texture, leftRect);
                        Utils.DrawBigString(crate.Name, leftNameRect, Color.White);
                        Utils.DrawBigString($"Price: {crate.Cost}", leftPriceRect, Color.White);

                    }
                    else if (i == 1)
                    {
                        Game1.Instance.draw(crate.Texture, rightRect);
                        Utils.DrawBigString(crate.Name, rightNameRect, Color.White);
                        Utils.DrawBigString($"Price: {crate.Cost}", rightPriceRect, Color.White);

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
                    Console.WriteLine($"{selectedCrate}");
                    var crate = GameData.LootBoxesInGame[selectedCrate];
                    if (player.Fame >= crate.Cost)
                    {
                        lootBoxAnimationHandler.OpenBox(crate, player);
                        player.Fame -= crate.Cost;
                    }
                }

                if (rightRect.RectangleClicked())
                {
                    if (selectedCrate + 1 >= GameData.LootBoxesInGame.Count()) return;
                    var crate = GameData.LootBoxesInGame[selectedCrate + 1];
                    if (player.Fame >= crate.Cost)
                    {
                        lootBoxAnimationHandler.OpenBox(crate, player);
                        player.Fame -= crate.Cost;
                    }
                }

                if (leftRect.RectangleClicked())
                {
                    if (selectedCrate - 1 < 0) return;
                    var crate = GameData.LootBoxesInGame[selectedCrate - 1];
                    if (player.Fame >= crate.Cost)
                    {
                        lootBoxAnimationHandler.OpenBox(crate, player);
                        player.Fame -= crate.Cost;
                    }
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
