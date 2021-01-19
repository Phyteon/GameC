using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Engine.Items.Spears;

namespace Game.Engine.Items.ItemFactories
{
    [Serializable]
    class SpearFactory : ItemFactory
    {
        public Item CreateItem()
        {
            List<Item> S = new List<Item>()
            {
                new EmeraldSpear(),
                new SharpSpear(),
            };
            return S[Index.RNG(0, S.Count)];
        }
        public Item CreateNonMagicItem()
        {
            List<Item> S = new List<Item>()
            {
                new EmeraldSpear(),
                new SharpSpear(),
            };
            return S[Index.RNG(0, S.Count)];
        }
        public Item CreateNonWeaponItem()
        {
            return null;
        }
    }
}
