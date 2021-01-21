using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class Earthquake : Skill
    {
        // earthquake: [Pr]% chance to land a skill that deals 0.6*[Mp] damage and additionaly can stun an enemy and hit twice
        // if your precision stat is higher than 200, you will always hit two times
        public Earthquake() : base("Earthquake", 45, 3)
        {
            PublicName = "Earthquake: a chance equal to your Precision stat to land 0.5*MP damage [earth] and a two times lower chance to stun";
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Earth);
            if (2*Index.RNG(0, 100) < player.Precision)
            {
                response.HealthDmg = (int)(1.2 * player.MagicPower);
                response.CustomText = "You use Earthquake! (" + (int)(0.6 * player.MagicPower) + " earth damage) and you stunned the enemy (additional " + (int)(0.6 * player.MagicPower) + " earth damage)";
            }
            else if (Index.RNG(0, 100) < player.Precision)
            {
                response.HealthDmg = (int)(0.6 * player.MagicPower);
                response.CustomText = "You use Earthquake! (" + (int)(0.5 * player.MagicPower) + " earth damage)";
            }
            else
            {
                response.HealthDmg = 0;
                response.CustomText = "You try to use Earthquake but it misses!";
            }
            return new List<StatPackage>() { response };
        }
    }
}
