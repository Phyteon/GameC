using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Items.Axes;

namespace Game.Engine.Items.ItemFactories
{
    [Serializable]
    class AxeFactory : ItemFactory
    {
        public Item CreateItem()
        {
            List<Item> axe = new List<Item>()
            {
                new BlueAxe(),
                new OrangeAxe(),
                new DiamondAxe(),
                new IronAxe(),
                new BlazingAxe(),
            };
            return axe[Index.RNG(0, axe.Count)];
        }

        public Item CreateNonMagicItem()
        {
            List<Item> axe = new List<Item>()
            {
                new BlueAxe(),
                new OrangeAxe(),
                new DiamondAxe(),
                new IronAxe(),
                new BlazingAxe(),
            };
            return axe[Index.RNG(0, axe.Count)];
        }

        public Item CreateNonWeaponItem()
        {
            return null;
        }
    }
}
