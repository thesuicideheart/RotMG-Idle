using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MysteryBox
{
    public static class Sprites
    {

        public static Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();

        static string tierRegex = @"([T][0-9]+)";

        public static void Load(ContentManager content)
        {
            var bows = Directory.GetFiles("Content\\Weapons\\Bows");
            var katanas = Directory.GetFiles("Content\\Weapons\\Katanas");
            var wands = Directory.GetFiles("Content\\Weapons\\Wand");
            var staves = Directory.GetFiles("Content\\Weapons\\Staves");
            var swords = Directory.GetFiles("Content\\Weapons\\Sword");
            var daggers = Directory.GetFiles("Content\\Weapons\\Dagger");
            var heavyArmors = Directory.GetFiles("Content\\Armors\\Heavy");
            var leahterArmors = Directory.GetFiles("Content\\Armors\\Leather");
            var robes = Directory.GetFiles("Content\\Armors\\Robe");
            var untiered = Directory.GetFiles("Content\\UTs");
            var GUI = Directory.GetFiles("Content\\GUI");

            #region Load in weapon textures

            foreach (var item in bows)
            {
                var fileName = Path.GetFileNameWithoutExtension(item);
                var actualFileName = Regex.Replace(fileName, tierRegex, "");
                actualFileName = actualFileName.Remove(0, 1);
                textures.Add(actualFileName,content.Load<Texture2D>("Weapons\\Bows\\" + Path.GetFileNameWithoutExtension(item)));
            }

            foreach (var item in katanas)
            {
                var fileName = Path.GetFileNameWithoutExtension(item);
                var actualFileName = Regex.Replace(fileName, tierRegex, "");
                actualFileName = actualFileName.Remove(0, 1);
                textures.Add(actualFileName, content.Load<Texture2D>("Weapons\\Katanas\\" + Path.GetFileNameWithoutExtension(item)));
            }

            foreach (var item in wands)
            {
                var fileName = Path.GetFileNameWithoutExtension(item);
                var actualFileName = Regex.Replace(fileName, tierRegex, "");
                actualFileName = actualFileName.Remove(0, 1);
                textures.Add(actualFileName, content.Load<Texture2D>("Weapons\\Wand\\" + Path.GetFileNameWithoutExtension(item)));
            }

            foreach (var item in staves)
            {
                var fileName = Path.GetFileNameWithoutExtension(item);
                var actualFileName = Regex.Replace(fileName, tierRegex, "");
                actualFileName = actualFileName.Remove(0, 1);
                textures.Add(actualFileName, content.Load<Texture2D>("Weapons\\Staves\\" + Path.GetFileNameWithoutExtension(item)));
            }

            foreach (var item in swords)
            {
                var fileName = Path.GetFileNameWithoutExtension(item);
                var actualFileName = Regex.Replace(fileName, tierRegex, "");
                actualFileName = actualFileName.Remove(0, 1);
                textures.Add(actualFileName, content.Load<Texture2D>("Weapons\\Sword\\" + Path.GetFileNameWithoutExtension(item)));
            }

            foreach (var item in daggers)
            {
                var fileName = Path.GetFileNameWithoutExtension(item);
                var actualFileName = Regex.Replace(fileName, tierRegex, "");
                actualFileName = actualFileName.Remove(0, 1);
                textures.Add(actualFileName, content.Load<Texture2D>("Weapons\\Dagger\\" + Path.GetFileNameWithoutExtension(item)));
            }

            #endregion

            #region load in armors

            foreach (var item in heavyArmors)
            {
                var fileName = Path.GetFileNameWithoutExtension(item);
                var actualFileName = Regex.Replace(fileName, tierRegex, "");
                actualFileName = actualFileName.Remove(0, 1);
                textures.Add(actualFileName, content.Load<Texture2D>("Armors\\Heavy\\" + Path.GetFileNameWithoutExtension(item)));
            }

            foreach (var item in leahterArmors)
            {
                var fileName = Path.GetFileNameWithoutExtension(item);
                var actualFileName = Regex.Replace(fileName, tierRegex, "");
                actualFileName = actualFileName.Remove(0, 1);
                textures.Add(actualFileName, content.Load<Texture2D>("Armors\\Leather\\" + Path.GetFileNameWithoutExtension(item)));
            }

            foreach (var item in robes)
            {
                var fileName = Path.GetFileNameWithoutExtension(item);
                var actualFileName = Regex.Replace(fileName, tierRegex, "");
                actualFileName = actualFileName.Remove(0, 1);
                textures.Add(actualFileName, content.Load<Texture2D>("Armors\\Robe\\" + Path.GetFileNameWithoutExtension(item)));
            }

            #endregion
            
            #region Untiered items

            foreach (var item in untiered)
            {
                var fileName = Path.GetFileNameWithoutExtension(item);
                textures.Add(fileName, content.Load<Texture2D>("UTs\\" + Path.GetFileNameWithoutExtension(item)));
            }

            #endregion

            #region GUI

            foreach(var file in GUI)
            {
                var fileName = Path.GetFileNameWithoutExtension(file);
                textures.Add(fileName, content.Load<Texture2D>("GUI\\"+Path.GetFileNameWithoutExtension(file)));
            }

            #endregion

        }

        public static Texture2D GetTexture(string filename)
        {

            return textures[filename];
        }

    }
}
