using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.EnhancedArmor
{
    [Serializable]
    class AdaptiveArmor : Item
    {
        private Dictionary<DmgType, int> ReducedDamage = new Dictionary<DmgType, int>();
        public AdaptiveArmor() : base("item1249")
        {
            PublicName = "AdaptiveArmor";
            PublicTip = "when wearer take damage of specific DamageType, next attack of this DamageType will deal 33% less damage";
            GoldValue = 80;
            ArMod = 30;
        }

        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            pack.HealthDmg = ReducedDamage.ContainsKey(pack.DamageType) ?
                ReducedDamage[pack.DamageType] * pack.HealthDmg / 100 : pack.HealthDmg;

            if (!ReducedDamage.ContainsKey(pack.DamageType))
            {
                ReducedDamage.Add(pack.DamageType, 67);
            }
            else
            {
                ReducedDamage[pack.DamageType] -= 33 * ReducedDamage[pack.DamageType] / 100;
            }

            return pack;
        }
    }
}
