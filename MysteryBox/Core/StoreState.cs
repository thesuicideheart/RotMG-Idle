using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace MysteryBox.Core
{
    public class StoreState : State
    {

        private int selectedItem = 0;

        public StoreState() : base(GameData.StoreState)
        {

        }

        public override void Update()
        {

            base.Update();
        }

        public override void Draw(SpriteBatch batch)
        {

            if ( !MessageBox.Active )
            {

            }

            base.Draw(batch);
        }
    }
}
