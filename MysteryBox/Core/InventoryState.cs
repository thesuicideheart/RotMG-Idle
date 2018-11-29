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
        private int invY = Option.Height / 2;
        private int invWidth = 512;
        private int invHeight = 38;
        private int invListCenterX = 0;//invX + 171;
        private int invListCenterY = 0;//invY + invHeight / 2 + 5;
        private int invListSpacing = 60;

        private int SelectedItem = 0;

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

        }

        public override void Draw(SpriteBatch batch)
        {

            for (int i = -10; i < 11; i++)
            {
                if (SelectedItem + i < 0 || SelectedItem + i >= Player.Inventory.Count) continue;
                var iItem = Player.Inventory[SelectedItem + i];
                var item = GameData.GetItemFromId(iItem.ItemID);

                if (i == 0)
                {
                    Game1.Instance.draw(item.GetTexture(), new Rectangle(invX - item.GetTexture().Width, (invY + i * invListSpacing) + 10, item.GetTexture().Width, item.GetTexture().Height));
                    Game1.Instance.drawString($">{item.Name} x{iItem.Count}<", invListCenterX, invListCenterY + i * invListSpacing);
                }
                else
                {
                    Game1.Instance.drawString($"{item.Name} x{iItem.Count}", invListCenterX, invListCenterY + i * invListSpacing);
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
