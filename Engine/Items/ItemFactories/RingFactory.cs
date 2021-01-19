using System;
using System.Collections.Generic;
using Game.Engine.Items.Ring;

namespace Game.Engine.Items.ItemFactories
{
    [Serializable]
    class RingFactory : ItemFactory
    {
        public Item CreateItem()
        {
            List<Item> extraRing = new List<Item>()
            {
                new AntiMagicDmgRing(),
                new AntiPhysicalDmgRing(),
                new MagicRing(),
                new HealthRing(),
                new EnhancementRing(),
            };
            return extraRing[Index.RNG(0, extraRing.Count)];
        }
        public Item CreateNonMagicItem()
        {
            List<Item> extraRing = new List<Item>()
            {
                // MagicRing works only for magic users
                new AntiMagicDmgRing(),
                new AntiPhysicalDmgRing(),
                new HealthRing(),
                new EnhancementRing(),
            };
            return extraRing[Index.RNG(0, extraRing.Count)];
        }
        public Item CreateNonWeaponItem()
        {
            List<Item> extraRing = new List<Item>()
            {
                new AntiMagicDmgRing(),
                new AntiPhysicalDmgRing(),
                new MagicRing(),
                new HealthRing(),
                new EnhancementRing(),
            };
            return extraRing[Index.RNG(0, extraRing.Count)];
        }
    }
}
