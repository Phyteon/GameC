using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class FireproofAmulet:Item
    {
        
        public FireproofAmulet() : base("item0863")
        {
            HpMod = 25;
            StaMod = 15;
            GoldValue = 60;
            PublicName = "Fireproof Amulet";
            PublicTip = "gives you extra stamina and health points, reduces health damage by 80% in case of a fight with a fire creature, but increases health damage by 20% if the creature uses any other magic power";
        }

        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.HealthBuff += HpMod;
            currentPlayer.StaminaBuff += StaMod;
        }
               
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == DmgType.fire)
            {
                pack.HealthDmg = 20 * pack.HealthDmg / 100;
            }
            else if (pack.DamageType == DmgType.water || pack.DamageType == DmgType.air || pack.DamageType == DmgType.earth)
            {
                pack.HealthDmg = 120 * pack.HealthDmg / 100;
            }
            return pack;
        }

    }
}
