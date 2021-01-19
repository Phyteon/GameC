using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Items.Shields;

namespace Game.Engine.Items.ItemFactories
{
    [Serializable]
    class ShieldFactory : ItemFactory
    {
        public Item CreateItem()
        {
            List<Item> shield = new List<Item>()
            {
                new BasicShield(),
                new WoodenShield(),
                new VikingShield(),
                new SteelShield()
            };
            return shield[Index.RNG(0, shield.Count)];
        }
        public Item CreateNonMagicItem()
        {
            
            List<Item> shield = new List<Item>()
            {
                new BasicShield(),
                new WoodenShield(),
                new VikingShield(),
                new SteelShield()
            };
            return shield[Index.RNG(0, shield.Count)];
        }
        public Item CreateNonWeaponItem()
        {
            
            List<Item> shield = new List<Item>()
            {
                new BasicShield(),
                new WoodenShield(),
                new VikingShield(),
            };
            return shield[Index.RNG(0, shield.Count)];
        }
    }
}
