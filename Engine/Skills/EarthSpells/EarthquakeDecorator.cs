using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class EarthquakeDecorator : SkillDecorator
    {
        // decorator for Earthquake class
        public EarthquakeDecorator(Skill skill) : base("Earthquake", 45, 3, skill)
        {
            MinimumLevel = Math.Max(3, skill.MinimumLevel) + 1;
            PublicName = "COMBO - Earthquake: a chance equal to your Precision stat to land 0.6*MP damage [earth], a two times lower chance to stun AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Earth);
            if (2 * Index.RNG(0, 100) < player.Precision)
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
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
