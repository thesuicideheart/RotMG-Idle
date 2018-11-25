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
            OkButton = new Button(Option.Width / 2 - 80, Option.Height / 2 + 60, 160, 64, Color.CornflowerBlue, false);
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
                    var rect = new RectangleF(80, 80, Option.Width - (80 * 2), Option.Height - (80 * 2));
                    batch.FillRectangle(rect, Color.CadetBlue);

                    batch.DrawString(Game1.Instance.font, "Youre opening a box D:", new Vector2(rect.Width / 2, rect.Height / 2), Color.White);
                    if (!ShouldHideTimer)
                        batch.DrawString(Game1.Instance.TimerFont, $"{TimerNumber}", new Vector2(rect.Width / 2, rect.Height / 2 + 50), Color.White);
                    if (ItemToReturn != null)
                    {
                        //draw the item here
                        var item = GameData.GetItemFromId(ItemToReturn.ItemID);
                        batch.Draw(item.GetTexture(), new Rectangle((int)(rect.Width / 2), (int)(rect.Height / 2) + 50, 40, 40), Color.White);
                        batch.DrawString(Game1.Instance.font, $"{item.Name}", new Vector2(rect.Width / 2, (int)(rect.Height / 2) + 90), Color.White);

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
