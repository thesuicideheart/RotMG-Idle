using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteryBox.Core
{
    public class State
    {
        public string ID;
        

        public State(string id)
        {
            ID = id;
        }

        public virtual void Draw(SpriteBatch batch)
        {

        }

        public virtual void Update()
        {

        }

    }
}
