using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Items
{
	[Serializable]
	class CrystalBall : Item
	{
		public CrystalBall() : base("item1286")
		{
			PublicName = "Crystal Ball";
			GoldValue = 100;
			PublicTip = "converts 30% of your gold to magic power and occasionally applies random debuff";
		}
		public override void ApplyBuffs(Player currentPlayer, List<string> otherItems)
		{
			currentPlayer.MagicPowerBuff += (currentPlayer.Gold / 10) * 3; // 10 gold is converted to 3 points of magic power 
		}
		public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
		{
            if (Index.RNG(0, 30) < 10)
            {
				pack.StrengthDmg += pack.HealthDmg / 4;
            }
            else if (Index.RNG(0, 30) < 20)
            {
				pack.MagicPowerDmg += pack.HealthDmg / 4;
            }
            else
            {
				pack.ArmorDmg += pack.HealthDmg / 4;
            }
			return pack;
		}

	}
}