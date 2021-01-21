using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class AquaSparkDecorator : SkillDecorator
    {
        // decorator for Aqua Spark class
        public AquaSparkDecorator(Skill skill) : base("Aqua Spark", 15, 1, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = "COMBO - Aqua Spark: 15 damage[water] AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Water);
            response.HealthDmg = 15 ;
            response.CustomText = "You use Aqua Spark! (15 water damage)";
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
