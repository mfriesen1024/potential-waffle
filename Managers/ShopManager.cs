using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using untitled.Map;

namespace untitled.Managers
{
    /// <summary>
    /// Manages shops for inventory purposes.
    /// </summary>
    internal class ShopManager
    {
        public Shop[] shops;

        /// <summary>
        /// Checks if there is a valid shop at the given location.
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        /// <param name="shop">The shop that was found. Is null if no shop is found.</param>
        /// <returns>True if a shop is found at the location, otherwise false.</returns>
        public bool ShopCheck(int x, int y, out Shop shop)
        {
            shop = null;

            foreach (Shop sh in shops)
            {
                if (sh.x == x && sh.y == y) { shop = sh; return true; }
            }
            return false;
        }

        /// <summary>
        /// Fetch stuff from settings class.
        /// </summary>
        public void Init()
        {
            // Create items. This would probably belong in an ItemManager or something if I bothered to make one,
            // but this is too small scope to require it.
            var allWeapons = new List<Item>();
            foreach (var weapon in Settings.weaponData)
            {
                allWeapons.Add(new(weapon[0], weapon[1]));
            }

            // Now we create shops from our data.
            var shops = new List<Shop>();
            for (int i = 0; i<Settings.shopLocations.Length; i++)
            {
                var location = Settings.shopLocations[i];
                var inventoryData = Settings.shopInventories[i];

                var inventory = new List<Item>();
                foreach (var weaponIndex in inventoryData)
                {
                    inventory.Add(allWeapons[weaponIndex]);
                }

                shops.Add(new(location[0], location[1], inventory.ToArray()));
            }
            this.shops = shops.ToArray();
        }

        public void Draw(CBuffer buffer)
        {
            foreach(Shop shop in shops)
            {
                buffer.secondBuffer[shop.x, shop.y] = Settings.ShopTile;
            }
        }
    }
}
