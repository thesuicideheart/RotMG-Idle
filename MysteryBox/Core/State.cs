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

        public MessageBox MessageBox = new MessageBox( );

        public State(string id)
        {
            ID = id;
        }

        public virtual void Draw(SpriteBatch batch)
        {
            MessageBox.Draw( batch );
        }

        public virtual void Update()
        {
            MessageBox.Update( );
        }

        public void SwitchState(string stateId)
        {
            Game1.Instance.SwitchState(stateId);
        }

    }
}
