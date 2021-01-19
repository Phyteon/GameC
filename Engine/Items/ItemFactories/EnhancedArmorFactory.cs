using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Items.EnhancedArmor;

namespace Game.Engine.Items.ItemFactories
{
    class EnhancedArmorFactory : ItemFactory
    {
        // produce items from Armor directory
        public Item CreateItem()
        {
            List<Item> enhancedArmors = new List<Item>()
            {
                new AdaptiveArmor(),
                new AntiPoisonArmor(),
                new LeatherArmor(),
                new DiamondArmor()
            };
            return enhancedArmors[Index.RNG(0, enhancedArmors.Count)];
        }
        public Item CreateNonMagicItem()
        {
            List<Item> enhancedArmors = new List<Item>()
            {
                new AdaptiveArmor(),
                new AntiPoisonArmor(),
                new LeatherArmor(),
                new DiamondArmor()
            };
            return enhancedArmors[Index.RNG(0, enhancedArmors.Count)];
        }
        public Item CreateNonWeaponItem()
        {
            List<Item> enhancedArmors = new List<Item>()
            {
                new AdaptiveArmor(),
                new AntiPoisonArmor(),
                new LeatherArmor(),
                new DiamondArmor()
            };
            return enhancedArmors[Index.RNG(0, enhancedArmors.Count)];
        }
    }
}
