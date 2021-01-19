using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Items.AnnItems;

namespace Game.Engine.Items.ItemFactories
{
    [Serializable]
    class AnnItemsFactory : ItemFactory
    {

        public Item CreateItem()
        {
            List<Item> AnnItems = new List<Item>()
            {
                new AnnMagicBook(),
                new AnnPoison(),
                new AnnShuriken(),
            };
            return AnnItems[Index.RNG(0, AnnItems.Count)];
        }
        public Item CreateNonMagicItem()
        {
            List<Item> AnnItems = new List<Item>()
            {
                new AnnPoison(),
                new AnnShuriken(),
            };
            return AnnItems[Index.RNG(0, AnnItems.Count)];
        }
        public Item CreateNonWeaponItem()
        {
            List<Item> AnnItems = new List<Item>()
            {
                new AnnMagicBook(),
                new AnnPoison(),
            };
            return AnnItems[Index.RNG(0, AnnItems.Count)];
        }
    }
}
