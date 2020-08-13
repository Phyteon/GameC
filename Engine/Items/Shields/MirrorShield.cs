using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Shield
{
    [Serializable]
    class MirrorShield : Item
    {
        public MirrorShield() : base("item1362")
        {
            PublicName = "Mirror Shield";
            PublicTip = "33% chance to bounce a magic spell";
            GoldValue = 70;
            ArMod = 30;
        }
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.ArmorBuff += ArMod;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == DmgType.fire || pack.DamageType == DmgType.water || pack.DamageType == DmgType.air || pack.DamageType == DmgType.earth)
            {
                int i = Index.RNG(0, 3);
                if(i == 0)
                    return null;
            }
            return pack;
        }
    }
}
