using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills
{
    [Serializable]
    public class Bloodlust : Skill
    {
        public Bloodlust() : base ("Bloodlust", 3, 3)
        {
            PublicName = "Bloodlust: dameges a target for 10% of their health and restores that amount to you";
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("health");
            response.HealthDmg = 90 * response.HealthDmg / 10;
            player.Health += response.HealthDmg;
            response.CustomText = "You use Bloodlust! (" + 90 * response.HealthDmg / 10 + " health damage)";
            return new List<StatPackage>() { response };
        }
    }
}
