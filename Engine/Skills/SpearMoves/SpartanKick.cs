using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills
{
	[Serializable]
	public class SpartanKick : Skill
	{
		public SpartanKick() : base("Spartan Kick", 80, 7)
		{
			PublicName = "Spartan Kick [requires spear]: deal 2*Str + random(1-199) crush damage";
			RequiredItem = RequiredItem.Spear;
		}
		public override List<StatPackage> BattleMove(Player player)
		{
			int r;
			r = Index.RNG(0, 200);
			StatPackage response = new StatPackage(DmgType.Crush);
			response.HealthDmg = (int)(2 * player.Strength) + r;
			response.CustomText = "THIS IS SPARTA! (" + ((int)(2 * player.Strength) + r) + " crush damage)";
			return new List<StatPackage>() { response };
		}
	}
}
