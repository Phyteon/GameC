using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.ItemFactories
{
    [Serializable]
    class AxeFactory : ItemFactory
    {
        
        public Item CreateItem()
        {
            List<Item> basicAxe = new List<Item>()
            {
                new BasicAxe(),
                new IronAxe(),
                new GymirAxe(),
                new DiamondAxe()
            };
            return basicAxe[Index.RNG(0, basicAxe.Count)];
        }
        public Item CreateNonMagicItem()
        {
            List<Item> basicAxe = new List<Item>()
            {
                new BasicAxe(),
                new IronAxe(),
                new GymirAxe(),
                new DiamondAxe()
            };
            return basicAxe[Index.RNG(0, basicAxe.Count)];
        }
        public Item CreateNonWeaponItem()
        {
            return null;
        }
    }
}
