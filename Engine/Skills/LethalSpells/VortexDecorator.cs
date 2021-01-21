using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class VortexDecorator : SkillDecorator
    {
        // decorator for any Vortex class
        public VortexDecorator(Skill skill) : base("Vortex", 70, 7, skill)
        {
            MinimumLevel = Math.Max(7, skill.MinimumLevel) + 1;
            PublicName = "COMBO - Vortex AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Other);
            if (Index.RNG(0, 500) < player.Precision)
            {
                response.HealthDmg = 10000000;
                response.CustomText = "Typhoon Vortex was successful!";
            }
            else
            {
                response.HealthDmg = 0;
                response.CustomText = "Typhoon Vortex was not successful!";
            }
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
