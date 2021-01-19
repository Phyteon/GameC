using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Ring
{
    [Serializable]
    class EnhancementRing : Item
    {
        public EnhancementRing() : base("item1246")
        {
            PublicName = "EnhancementRing";
            PublicTip = "enhance Health, Strength and Armor of all active items by 25%";
            GoldValue = 70;
        }

        public override void ApplyBuffs(Player currentPlayer, List<string> otherItems)
        {
            int buffPercent = 25;

            if (otherItems.Count > 0)
            {
                foreach (var itemName in otherItems)
                {
                    Item item = Index.ProduceSpecificItem(itemName);
                    currentPlayer.HealthBuff += buffPercent * item.HpMod / 100;
                    currentPlayer.StrengthBuff += buffPercent * item.StrMod / 100;
                    currentPlayer.ArmorBuff += buffPercent * item.ArMod / 100;
                }
            }
        }
    }
}
