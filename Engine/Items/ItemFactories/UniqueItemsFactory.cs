using System;
using System.Collections.Generic;
using Game.Engine.Items.MyItems;

namespace Game.Engine.Items.ItemFactories
{
    class UniqueItemsFactory : ItemFactory
    {
        // produce items from MyItems directory
        public Item CreateItem()
        {
            List<Item> myItems = new List<Item>()
            {
                new BloodyArmor(),
                new BigBertha(),
                new MjolnirAxe(),
                new LongBow(),
                new CrystalBall(),
                new GoldenApple(),
                new Lightsaber(),
            };
            return myItems[Index.RNG(0, myItems.Count)];
        }
        public Item CreateNonMagicItem()
        {
            List<Item> myItems = new List<Item>()
            {
                new BloodyArmor(),
                new BigBertha(),
                new MjolnirAxe(),
                new LongBow(),
                new Lightsaber(),
            };
            return myItems[Index.RNG(0, myItems.Count)];
        }
        public Item CreateNonWeaponItem()
        {
            List<Item> myItems = new List<Item>()
            {
                new BloodyArmor(),
                new CrystalBall(),
                new LongBow(),
                new GoldenApple(),
                new Lightsaber(),
            };
            return myItems[Index.RNG(0, myItems.Count)];
        }
    }
}
