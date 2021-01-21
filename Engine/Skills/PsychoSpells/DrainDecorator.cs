using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class DrainDecorator : SkillDecorator
    {
        // decorator for Drain class
        public DrainDecorator(Skill skill) : base("Drain", 40, 3, skill)
        {
            MinimumLevel = Math.Max(3, skill.MinimumLevel) + 1;
            PublicName = "COMBO - Drain: a chance equal to your Precision stat to land 30+0.4*MP damage [psycho] with heal AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Psycho);
            if (Index.RNG(0, 100) < player.Precision)
            {
                response.HealthDmg = 30+(int)(0.4 * player.MagicPower);
                player.BattleBuffHealth += (int)(0.8 * response.HealthDmg);
                response.CustomText = "You use Drain! (" + (int)(0.4 * player.MagicPower) + " psycho damage and restoration of " + (int)(0.8 * response.HealthDmg) + " HP)";
            }
            else
            {
                response.HealthDmg = 0;
                response.CustomText = "You try to Drain but it misses!";
            }
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
