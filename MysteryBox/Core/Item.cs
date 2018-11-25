using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteryBox.Core
{

    public enum Rarity
    {
        Common,
        Uncommon,
        Rare,
        Legendary,
        Mystical
    }

    public class Item
    {
        /// <summary>
        /// The name of the item
        /// </summary>
        public string Name;

        /// <summary>
        /// The item id. The players will never see this
        /// </summary>
        public string ID;
        
        /// <summary>
        /// The price it will have on the market
        /// </summary>
        public int Price;
        
        /// <summary>
        /// The rarity of the items. From common -> Mystical
        /// </summary>
        public Rarity Rarity;

        /// <summary>
        /// The ID for the texture assigned to the item
        /// </summary>
        private string texture_id;

        /// <summary>
        /// Constructor that sets all the members to parameter value
        /// </summary>
        /// <param name="id">The item id of the item.</param>
        /// <param name="name">The item name. This is what players will see when they unbox an item</param>
        /// <param name="price">The price of the item</param>
        /// <param name="rarity">The rarity of the item</param>
        public Item(string id, string name, int price, Rarity rarity, string textureId)
        {
            ID = id;
            Name = name;
            Price = price;
            Rarity = rarity;
            texture_id = textureId;
        }


        /// <summary>
        /// Empty constructor. Dont know why this exists, it just does
        /// </summary>
        public Item()
        {

        }

        public Texture2D GetTexture()
        {
            return Sprites.GetTexture(texture_id);
        }

    }
}
