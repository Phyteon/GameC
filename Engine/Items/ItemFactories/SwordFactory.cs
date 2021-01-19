using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Items.Swords;

namespace Game.Engine.Items.ItemFactories
{
    [Serializable]
    class SwordFactory : ItemFactory
    {
        public Item CreateItem()
        {
            List<Item> Swords = new List<Item>()
            {
                new FierySword(),
                new DiaxSword(),
                new SilverSword(),
            };
            return Swords[Index.RNG(0, Swords.Count)];
        }
        public Item CreateNonMagicItem()
        {
            List<Item> Swords = new List<Item>()
            {
                new FierySword(),
                new DiaxSword(),
                new SilverSword(),
            };
            return Swords[Index.RNG(0, Swords.Count)];
        }
        public Item CreateNonWeaponItem()
        {
            return null;
        }
    }
}
