using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteryBox.Core
{
    public static class Extensions
    {
        public static bool RectangleClicked(this Rectangle rect)
        {
            return rect.Contains(Game1.Instance.input.GetMousePosition()) && Game1.Instance.input.JustPressed(MouseInput.LeftButton);
        }
    }
}
