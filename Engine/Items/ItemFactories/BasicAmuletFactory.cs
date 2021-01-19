using System;
using System.Collections.Generic;
using Game.Engine.Items.BasicAmulet;

namespace Game.Engine.Items.ItemFactories
{
    [Serializable]
    class BasicAmuletFactory : ItemFactory
    {
        public Item CreateItem()
        {
            List<Item> basicAmulet = new List<Item>()
            {
                new HpAmulet(),
                new MgcAmulet(),
                new StrAmulet()
            };
            return basicAmulet[Index.RNG(0, basicAmulet.Count)];
        }
        public Item CreateNonMagicItem()
        {
            // MgcAmulet only works for magic users
            List<Item> basicAmulet = new List<Item>()
            {
                new HpAmulet(),
                new StrAmulet()
            };
            return basicAmulet[Index.RNG(0, basicAmulet.Count)];
        }
        public Item CreateNonWeaponItem()
        {
            List<Item> basicAmulet = new List<Item>()
            {
                new HpAmulet(),
                new MgcAmulet(),
                new StrAmulet()
            };
            return basicAmulet[Index.RNG(0, basicAmulet.Count)];
        }
    }
}
