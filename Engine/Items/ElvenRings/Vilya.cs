using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Items
{
    [Serializable]
    class Vilya : Item
    {
        public Vilya() : base("item0341")
        {
            PublicName = "Vilya";
            PublicTip = "increased air damage and resistance, precision increased by 0.2*MP";
            GoldValue = 100;

        }
        public override void ApplyBuffs(Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.PrecisionBuff = (int)(currentPlayer.MagicPower * 0.2);
        }
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == DmgType.Air)
            {
                pack.HealthDmg += pack.HealthDmg / 4;
            }
            return pack;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == DmgType.Air)
            {
                pack.HealthDmg -= pack.HealthDmg/2;
            }
            return pack;
        }
    }
}
