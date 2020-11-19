using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.OsirisArmor
{
    [Serializable]
    class OsirisSabre : Sword
    {
        public OsirisSabre() : base("item0823") 
        {
            StrMod = 40;
            ArMod = 30;
            StaMod = 10;
            GoldValue = 100;
            PublicTip = "reduce physical damage by 20% + if you have an Osiris Eye, your Strength will be increased. ";
            PublicName = "OsirisSabre";
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == DmgType.Cut || pack.DamageType == DmgType.Cut)
            {
                pack.HealthDmg = 80 * pack.HealthDmg / 100;
            }
            return pack;
        }

        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            foreach (string i in otherItems)
            {
				currentPlayer.HealthBuff += HpMod;
				currentPlayer.StrengthBuff += StrMod;
				currentPlayer.ArmorBuff += ArMod;
				currentPlayer.PrecisionBuff += PrMod;
				currentPlayer.MagicPowerBuff += MgcMod;
				currentPlayer.StaminaBuff += StaMod;
                if (i == "OsirisEye")
                {
                    currentPlayer.StrengthBuff = currentPlayer.Strength + StrMod * 150 / 100;
                }
            }
        }

    }
}
