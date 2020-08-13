using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Shield
{
    [Serializable]
    class GoldenShield : Item
    {
        public GoldenShield() : base("item1361")
        {
            PublicName = "Hero's Ancient Golden Shield";
            PublicTip = "30% reduction of physical damage & with Basic Sword: 15% increase of physical damage you deal";
            GoldValue = 110;
            ArMod = 50;
        }
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.ArmorBuff += ArMod;
        }
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == DmgType.stab || pack.DamageType == DmgType.cut)
            {
                if (otherItems.Contains("Basic Sword") == true)
                {
                    pack.HealthDmg += pack.HealthDmg * 15 / 100;
                    return pack;
                }
            }
            return pack;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == DmgType.stab || pack.DamageType == DmgType.cut )
            {
                pack.HealthDmg = pack.HealthDmg * 70 / 100;
                return pack;
            }
            else return pack;
        }
    }
}
