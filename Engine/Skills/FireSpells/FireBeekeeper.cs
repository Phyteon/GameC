using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills
{
	[Serializable]
	public class FireBeekeeper : Skill
	{
		
		public FireBeekeeper() : base("Fire Beekeeper", 80, 7)
		{
			PublicName = "Fire Beekeeper - spawn fire bees that deal dmg and die instantly. Number of bees is random [requires staff]: bees*MP";
			RequiredItem = RequiredItem.Staff;
		}
		public override List<StatPackage> BattleMove(Player player)
		{
			StatPackage response = new StatPackage(DmgType.Fire);
			int bees = (int)Index.RNG(1, 5);
			response.HealthDmg = bees * player.MagicPower;
			response.CustomText = "You spawn " + bees + " bees and deal " + response.HealthDmg + " dmg";
			return new List<StatPackage>() { response };
		}
	}
}


