using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class Narya : Item
    {
        public Narya() : base("item0343")
        {
            PublicName = "Narya";
            PublicTip = "increased fire damage and resistance, stamina increased by 20%";
            GoldValue = 100;

        }
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.StaminaBuff = currentPlayer.Stamina / 5;
        }
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == DmgType.Fire)
            {
                pack.HealthDmg += pack.HealthDmg / 4;
            }
            return pack;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == DmgType.Fire)
            {
                pack.HealthDmg -= pack.HealthDmg/2;
            }
            return pack;
        }
    }
}
