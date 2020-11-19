using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class Nenya : Item
    {
        public Nenya() : base("item0342")
        {
            PublicName = "Nenya";
            PublicTip = "increased water damage and resistance, ability to increase health by 20% of current health";
            GoldValue = 100;
            
        }
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.HealthBuff = currentPlayer.Health / 5;
        }
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == DmgType.Water)
            {
                pack.HealthDmg += pack.HealthDmg/4;
            }
            return pack;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if(pack.DamageType == DmgType.Water)
            {
                pack.HealthDmg -= pack.HealthDmg/2;

            }
            return pack;
        }
    }
}
