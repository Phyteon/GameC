using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class GroundSwirlDecorator : SkillDecorator
    {
        // decorator for Ground Swirl class
        public GroundSwirlDecorator(Skill skill) : base("Ground Swirl", 15, 1, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = "COMBO - Ground Swirl: 10 + 0.2 * MP damage[air] AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Earth);
            response.HealthDmg = 10 + (int)(0.2 * player.MagicPower);
            response.CustomText = "You use Ground Swirl! (" + (10 + (int)(0.2 * player.MagicPower)) + " earth damage)";
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
