using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills
{
	[Serializable]
	public class FireBreath : Skill
	{

		public FireBreath() : base("Fire Breath", 50, 5)
		{
			PublicName = "Fire Breath [requires staff]: deal 1*MP fire damage";
			RequiredItem = RequiredItem.Staff;
		}
		public override List<StatPackage> BattleMove(Player player)
		{
			StatPackage response = new StatPackage(DmgType.Fire);
			DateTime moment = DateTime.Now;
			if (moment.Second > 6)
			{
				response.HealthDmg = (int)(moment.Second / 6 * player.MagicPower);
				response.CustomText = "A mysterious condition is fullfiled - critical hit! (" + (int)(moment.Second / 6 * player.MagicPower) + " fire damage)";
			}
			else
			{
				response.HealthDmg = (int)(2 * player.Strength);
				response.CustomText = "You use Fire Breath and deal (" + (int)(1 * player.MagicPower) + " fire damage)";
			}
			return new List<StatPackage>() { response };
		}
	}
}


