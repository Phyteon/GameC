using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills
{
	[Serializable]
	public class SpartanAid : Skill
	{
		public SpartanAid() : base("Spartan Aid", 40, 5)
		{
			PublicName = "Spartan Aid - Feel the power of Sparta and heal yourself [requires spear]: 10-100 heal";
			RequiredItem = RequiredItem.Spear;
		}
		public override List<StatPackage> BattleMove(Player player)
		{
			StatPackage response = new StatPackage(DmgType.Fire);
			int heal = Index.RNG(10, 100);
			player.BattleBuffHealth += heal;
			response.CustomText = "You heal yourself with: " + heal + " health";
			return new List<StatPackage>() { response };
		}
	}
}

