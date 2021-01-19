using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Engine.Items.Chains;

namespace Game.Engine.Items.ItemFactories
{
    [Serializable]

    class ChainFactory : ItemFactory 
    {
        public Item CreateItem()
        {
            List<Item> jewelry = new List<Item>()
            {
                new ArmorChain(),
                new StaminaChain(),
                new MagicChain(),
                new PrecisionChain(),
            };
            return jewelry[Index.RNG(0, jewelry.Count)];
        }
        public Item CreateNonMagicItem()
        {
            List<Item> jewelry = new List<Item>()
            {
                new ArmorChain(),
                new StaminaChain(),
                new PrecisionChain(),
            };
            return jewelry[Index.RNG(0, jewelry.Count)];
        }
        
        public Item CreateNonWeaponItem()
        {
            List<Item> jewelry = new List<Item>()
            {
                new ArmorChain(),
                new StaminaChain(),
                new MagicChain(),
                new PrecisionChain(),
            };
            return jewelry[Index.RNG(0, jewelry.Count)];
        }
    }
}
