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
    public class InventoryState : State
    {

        public Player Player;

        private int invX = 60;
        private int invY = Option.Height / 2 - 40;
        private int invWidth = 512;
        private int invHeight = 38;
        private int invListCenterX = 0;//invX + 171;
        private int invListCenterY = 0;//invY + invHeight / 2 + 5;
        private int invListSpacing = 60;

        private int SelectedItem = 0;

        private Texture2D invBackground, itemSlot;

        private Rectangle itemSlotRect,
            itemNameRect,
            itemRarityRect,
            itemPriceRect;

        public InventoryState(Player player) : base(GameData.InvState)
        {
            Player = player;
            Player.AddItem(new InventoryItem("t10_dagger", 1));
            Player.AddItem(new InventoryItem("t11_dagger", 1));
            Player.AddItem(new InventoryItem("t12_dagger", 1));

            Player.AddItem(new InventoryItem("t10_staff", 1));
            Player.AddItem(new InventoryItem("t11_staff", 1));
            Player.AddItem(new InventoryItem("t12_staff", 1));

            Player.AddItem(new InventoryItem("t10_sword", 1));
            Player.AddItem(new InventoryItem("t11_sword", 1));
            Player.AddItem(new InventoryItem("t12_sword", 1));

            Player.AddItem(new InventoryItem("t10_katana", 1));
            Player.AddItem(new InventoryItem("t11_katana", 1));
            Player.AddItem(new InventoryItem("t12_katana", 1));

            Player.AddItem(new InventoryItem("t10_bow", 1));
            Player.AddItem(new InventoryItem("t11_bow", 1));
            Player.AddItem(new InventoryItem("t12_bow", 1));

            Player.AddItem(new InventoryItem("t10_wand", 1));
            Player.AddItem(new InventoryItem("t11_wand", 1));
            Player.AddItem(new InventoryItem("t12_wand", 1));

            invListCenterY = invY + invHeight / 2 + 5;
            invListCenterX = invX + 44;

            invBackground = Sprites.GetTexture("inventory");
            itemSlot = Sprites.GetTexture("item_slot");
            itemSlotRect = new Rectangle(Option.Width / 2 - (itemSlot.Width / 2), Option.Height / 2 - 200, itemSlot.Width, itemSlot.Height);

            itemNameRect = new Rectangle(itemSlotRect.X - 96, itemSlotRect.Y + itemSlotRect.Height + 10, 256, 48);
            itemRarityRect = new Rectangle(itemNameRect.X, itemNameRect.Y + itemNameRect.Height + 10, 256, 24);
            itemPriceRect = new Rectangle(itemRarityRect.X, itemRarityRect.Y + itemRarityRect.Height + 10, 256, 24);


        }

        public override void Draw(SpriteBatch batch)
        {

            batch.Draw(invBackground, new Rectangle(0, 0, Option.Width, Option.Height), Color.White);
            batch.Draw(itemSlot, itemSlotRect, Color.White);


            for (int i = -3; i < 4; i++)
            {
                if (SelectedItem + i < 0 || SelectedItem + i >= Player.Inventory.Count) continue;
                var iItem = Player.Inventory[SelectedItem + i];
                var item = GameData.GetItemFromId(iItem.ItemID);

                if (i == 0)
                {
                    Game1.Instance.draw(item.GetTexture(), new Rectangle(invX - item.GetTexture().Width - 10, (invY + i * invListSpacing) - 15, item.GetTexture().Width * 2, item.GetTexture().Height * 2));
                    Game1.Instance.draw(item.GetTexture(), new Rectangle(itemSlotRect.X + 7, itemSlotRect.Y + 7, item.GetTexture().Width, item.GetTexture().Height));
                    Utils.DrawSmallString(item.Name, itemNameRect, Color.White);
                    Utils.DrawRarityString(item, itemRarityRect);
                    Utils.DrawSmallString($"Price: {item.Price} fame", itemPriceRect, Color.White);
                    //Game1.Instance.drawString($">{item.Name} x{iItem.Count}<", invListCenterX, invListCenterY + i * invListSpacing);
                }
                else
                {
                    Game1.Instance.draw(item.GetTexture(), new Rectangle(invX - item.GetTexture().Width, (invY + i * invListSpacing) + 10, item.GetTexture().Width, item.GetTexture().Height));
                }
            }

            base.Draw(batch);
        }

        public override void Update()
        {
            if (SelectedItem < 0)
                SelectedItem = Player.Inventory.Count - 1;
            else if (SelectedItem >= Player.Inventory.Count)
                SelectedItem = 0;

            var iItem = Player.Inventory[SelectedItem];
            var item = GameData.GetItemFromId(iItem.ItemID);

            if (Game1.Instance.input.JustPressed(Keys.W) || Game1.Instance.input.JustPressed(Keys.Up))
            {
                SelectedItem--;
            }
            if (Game1.Instance.input.JustPressed(Keys.S) || Game1.Instance.input.JustPressed(Keys.Down))
            {
                SelectedItem++;

            }

            if (Game1.Instance.input.JustPressed(Keys.Escape))
            {
                Game1.Instance.SwitchState(GameData.MainState);
            }

            if (Game1.Instance.input.JustPressed(Keys.F))
            {
                Player.AddItem(new InventoryItem("t10_staff", 10));
            }

            RPC.SetPresence("Browsing Inventory", $"Looking at {item.Name}", "inventory", "Browsing the inventory");

            base.Update();
        }
    }
}
