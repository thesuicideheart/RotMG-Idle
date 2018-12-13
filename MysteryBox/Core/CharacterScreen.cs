using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteryBox.Core
{
    public class CharacterScreen : State
    {

        public Player Player;

        public CharacterScreen(Player player) : base( GameData.CharacterScreen )
        {
            Player = player;
        }
    }
}
