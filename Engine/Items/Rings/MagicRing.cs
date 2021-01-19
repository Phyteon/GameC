using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Ring
{
    // this Ring works only for Mages

    [Serializable]
    class MagicRing : Item
    {
        public MagicRing() : base("item1247")
        {
            PublicName = "MagicRing";
            PublicTip = "increase magic power and elemental attacks damage by 40%";
            GoldValue = 100;
            MgcMod = 20;
        }

        public override void ApplyBuffs(Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.MagicPowerBuff += MgcMod;
            currentPlayer.MagicPowerBuff += 40 * currentPlayer.MagicPowerBuff / 100;
        }
        
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if(DmgTest.Magic(pack.DamageType) && pack.DamageType != DmgType.Psycho)
            {
                pack.HealthDmg = 140 * pack.HealthDmg / 100;
            }
            return pack;
        }
    }
}
