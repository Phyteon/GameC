using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.OsirisArmor
{
    [Serializable]
    class OsirisStaff : Staff
    {
        
        public OsirisStaff() : base("item0824") 
        {
            MgcMod = 40;
            GoldValue = 100;
            StaMod = 10;
            StrMod = 20;
            PublicTip = "reduce magic damage by 20% + if you have an Osiris Eye, your MagicPower will be increased. ";
            PublicName = "Osiris Staff";
        }

        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == DmgType.Fire || pack.DamageType == DmgType.Water || pack.DamageType == DmgType.Air || pack.DamageType == DmgType.Earth)
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
                    currentPlayer.MagicPowerBuff = currentPlayer.MagicPower + MgcMod * 150 / 100;
                }
            }
        }
    }
}
