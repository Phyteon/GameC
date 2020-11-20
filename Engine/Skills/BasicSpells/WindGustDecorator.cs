using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class WindGustDecorator : SkillDecorator
    {
        // decorator for Wind Gust class
        public WindGustDecorator(Skill skill) : base("Wind Gust", 10, 1, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = "COMBO - Wind Gust: 5 + 0.3 * MP damage[air] AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Air);
            response.HealthDmg = 5 + (int)(0.3 * player.MagicPower);
            response.CustomText = "You use Wind Gust! (" + (5 + (int)(0.3 * player.MagicPower)) + " air damage)";
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
