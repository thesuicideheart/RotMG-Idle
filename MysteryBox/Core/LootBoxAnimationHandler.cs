using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteryBox.Core
{
    public class LootBoxAnimationHandler
    {

        public bool Active;

        public bool ShouldOpenBox;
        public bool ShouldUpdateTimer;
        public bool ShouldHideTimer;
        public bool ShouldGenerateItem;

        public List<InventoryItem> Inventory;
        public LootBox BoxToOpen;
        public InventoryItem ItemToReturn;
        public Button OkButton;

        public int Timer;
        public int TimerNumber; //Number thats gonna be rendered;

        private Texture2D LeftSide, RightSide, Middle, BoxLabel, itemSlot;
        private Rectangle labelRect, labelTextRect;
        private Rectangle itemSlotRect, itemNameRect, itemRarityRect, itemPriceRect;
        private RectangleF borderRect;


        public LootBoxAnimationHandler()
        {
            LeftSide = Sprites.GetTexture("LeftSide");
            RightSide = Sprites.GetTexture("RightSide");
            Middle = Sprites.GetTexture("middle");
            BoxLabel = Sprites.GetTexture("label");
            itemSlot = Sprites.GetTexture("item_slot");

            borderRect = new RectangleF(80, 80, Option.Width - (80 * 2), Option.Height - (80 * 2));
            labelRect = new Rectangle(
                (int)borderRect.X + 80,
                (int)borderRect.Y + 60,
                (int)borderRect.Width - 132,
                BoxLabel.Height - 10
            );

            labelTextRect = new Rectangle(
                (int)labelRect.X + 10,
                (int)labelRect.Y + 10,
                (int)labelRect.Width - 10,
                (int)labelRect.Height - 10
            );

            itemSlotRect = new Rectangle(
                (int)(Option.Width / 2 - 40),
                (int)(Option.Height / 2 - 40),
                itemSlot.Width,
                itemSlot.Height
            );

            itemNameRect = new Rectangle(
                (int)itemSlotRect.X - 30,
                (int)itemSlotRect.Y + itemSlot.Height,
                128,
                itemSlot.Height
            );

            itemRarityRect = new Rectangle(
                itemNameRect.X,
                itemNameRect.Y+itemNameRect.Height-20,
                itemNameRect.Width,
                itemNameRect.Height
            );

            itemPriceRect = new Rectangle(
                itemRarityRect.X,
                itemRarityRect.Y + itemRarityRect.Height-10,
                itemRarityRect.Width,
                itemRarityRect.Height/2
                );

        }

        public void OpenBox(LootBox lootBox, List<InventoryItem> inventory)
        {
            if (Active) return;

            Active = true;

            BoxToOpen = lootBox;
            Inventory = inventory;

            ShouldOpenBox = true;
            ShouldUpdateTimer = true;

            Timer = 3 * Option.FPS; // in seconds
            TimerNumber = 3;


            //640 440
            OkButton = new Button("Sweet!", Option.Width / 2 - 80, Option.Height / 2 + 204, 160, 32, Color.CornflowerBlue, false);
        }

        public void Update()
        {
            if (Active)
            {
                if (ShouldOpenBox)
                {
                    //Open the box here.
                    //you are opening the box D:
                    if (ShouldUpdateTimer)
                    {
                        Timer--;
                        if (Timer % 60 == 0)
                        {
                            //This means it hits either 120, 60, or 180.
                            TimerNumber--;
                        }
                    }

                    if (Timer <= 0)
                    {
                        //do soemthing here
                        ShouldUpdateTimer = false;
                        ShouldHideTimer = true;

                        //Show what item we got.
                        ShouldGenerateItem = true;

                    }

                    if (ShouldGenerateItem && ItemToReturn == null && TimerNumber <= 0)
                    {
                        OkButton.Visible = true;
                        ItemToReturn = InventoryItem.CreateInventoryItemFromLootboxItem(BoxToOpen.GetItem());
                        Inventory.Add(ItemToReturn);
                        ShouldGenerateItem = false;

                    }

                    if (OkButton.MouseClicked())
                    {
                        Close();
                        Reset();
                    }
                }
            }
        }

        public void Draw(SpriteBatch batch)
        {
            if (Active)
            {
                if (ShouldOpenBox)
                {

                    batch.DrawRectangle(borderRect, GameData.BorderColor, 5);

                    Utils.DrawBigString($"Youre opening {BoxToOpen.Name}", labelTextRect, Color.White);

                    #region top and bottom bars

                    batch.Draw(
                        BoxLabel,
                        labelRect,
                        Color.White
                        );

                    batch.Draw(
                        Middle,
                        new Rectangle((int)(borderRect.X + LeftSide.Width),
                        (int)borderRect.Y - (LeftSide.Height / 2),
                        432,
                        Middle.Height),
                        Color.White);

                    batch.Draw(
                        Middle,
                        new Rectangle((int)(borderRect.X + LeftSide.Width),
                        (int)(borderRect.Y + borderRect.Height) - (LeftSide.Height / 2) + 1,
                        432,
                        Middle.Height),
                        Color.White);

                    batch.Draw(
                        LeftSide,
                        new Rectangle((int)(borderRect.X),
                        (int)borderRect.Y - (LeftSide.Height / 2) - 1,
                        LeftSide.Width,
                        LeftSide.Height),
                        Color.White);

                    batch.Draw(
                        LeftSide,
                        new Rectangle((int)(borderRect.X),
                        (int)(borderRect.Y + borderRect.Height) - (LeftSide.Height / 2),
                        LeftSide.Width,
                        LeftSide.Height),
                        Color.White);


                    batch.Draw(
                        RightSide,
                        new Rectangle((int)(borderRect.X + borderRect.Width - RightSide.Width),
                        (int)borderRect.Y - (RightSide.Height / 2) - 1,
                        RightSide.Width,
                        RightSide.Height),
                        Color.White);

                    batch.Draw(
                        RightSide,
                        new Rectangle((int)(borderRect.X + borderRect.Width - RightSide.Width),
                        (int)(borderRect.Y + borderRect.Height) - (RightSide.Height / 2),
                        RightSide.Width,
                        RightSide.Height),
                        Color.White);
                    #endregion


                    batch.Draw(
                        itemSlot,
                        itemSlotRect,
                        Color.White
                        );

                    if (!ShouldHideTimer)
                        batch.DrawString(Game1.Instance.TimerFont, $"{TimerNumber}", new Vector2(itemSlotRect.X + 16, itemSlotRect.Y - 40), Color.White);

                    if (ItemToReturn != null)
                    {
                        //draw the item here
                        var item = GameData.GetItemFromId(ItemToReturn.ItemID);
                        batch.Draw(item.GetTexture(), new Rectangle(itemSlotRect.X + 6, itemSlotRect.Y + 7, 40, 40), Color.White);
                        Utils.DrawBigString($"{item.Name}", itemNameRect, Color.White);
                        Utils.DrawRarityString(item, itemRarityRect);
                        Utils.DrawSmallString($"Price: {item.Price}", itemPriceRect, Color.White);
                        OkButton.Draw(batch);
                    }

                }
            }
        }

        public void Close()
        {
            Active = false;
        }

        public void Reset()
        {

            BoxToOpen = null;
            Inventory = null;
            ItemToReturn = null;

            ShouldOpenBox = false;
            ShouldUpdateTimer = false;
            ShouldHideTimer = false;
            ShouldGenerateItem = false;

            Timer = 0;
            TimerNumber = 0;
        }

    }
}
