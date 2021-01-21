using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills
{
	[Serializable]
	public class AsteroidPunch : Skill
	{
		public AsteroidPunch() : base("Asteroid Punch", 80, 5)
		{
			PublicName = "Asteroid Punch [requires staff]: a chance equal to your Precision stat to land 3*MP damage [fire]";
			RequiredItem = RequiredItem.Staff;
		}

		public override List<StatPackage> BattleMove(Player player)
		{
			StatPackage response = new StatPackage(DmgType.Fire);
			if (Index.RNG(0, 100) < 3)
			{
				response.HealthDmg = (int)(5 * player.MagicPower);
				response.CustomText = "Ouch, critical hit from an Asteroid! (" + (int)(5 * player.MagicPower) + " fire damage";
			}
			else if (Index.RNG(0, 100) < player.Precision)
			{
				response.HealthDmg = (int)(3 * player.MagicPower);
				response.CustomText = "You use Asteroid Punch! (" + (int)(3 * player.MagicPower) + " fire damage)";
			}
			else
			{
				response.HealthDmg = 0;
				response.CustomText = "Your magic sucks, bro.";
			}
			return new List<StatPackage>() { response };
		}
	}
}



