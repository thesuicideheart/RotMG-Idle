using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace MysteryBox.Core
{
    public class InventoryState : State
    {
        public InventoryState() : base(GameData.InvState)
        {

        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
