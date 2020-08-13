using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSpells
{
	[Serializable]
    class ForcedLightning:Skill
    {
        public ForcedLightning() : base("spell0582", 60, 3)
        {
            PublicName = "Forced Lightning - UNLIMITED POWER (5-10*MP) 10% chance to hurt self";
            RequiredItem = Skill.MainItem.staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            Random rng = new Random();
            StatPackage response = new StatPackage("fire");
            int multiplier = rng.Next(5,10);
            response.HealthDmg = multiplier * player.MagicPower;
            response.CustomText = "Forceful lightning envelops the enemy.";

            multiplier = rng.Next(0, 9);

            if (multiplier == 0)
            {
                player.Health -= player.MagicPower;
            }
            response.CustomText += "The lightning ricoshets and strikes back at the caster";

            return new List<StatPackage>() { response };
        }
    }
}
