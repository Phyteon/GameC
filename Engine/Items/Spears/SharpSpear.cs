using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Items.Spears
{
	[Serializable]
	class SharpSpear : Spear
	{
		public SharpSpear() : base("item1287")
		{
			PublicName = "Sharp Spear";
			GoldValue = 70;
			PublicTip = "you get 10% of your enemy's last attack as bonus damage";
			PrMod = 15;
		}
		private int damage;
		public override void ApplyBuffs(Player currentPlayer, List<string> otherItems)
		{
			currentPlayer.PrecisionBuff += PrMod;
		}
		public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
		{
			if(damage > pack.HealthDmg)
            {
				pack.HealthDmg += damage / 10; 
            }
			return pack;
		}
		public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
		{
			damage = pack.HealthDmg;
			return pack;
		}
	}
}
