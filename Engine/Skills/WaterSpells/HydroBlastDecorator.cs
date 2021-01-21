using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class HydroBlastDecorator : SkillDecorator
    {
        // decorator for Hydro Blast class
        public HydroBlastDecorator(Skill skill) : base("Hydro Blast", 20, 3, skill)
        {
            MinimumLevel = Math.Max(3, skill.MinimumLevel) + 1;
            PublicName = "COMBO - Hydro Blast: less health equals more [water] damage " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Water);
            if (player.Health < 100)
            {
                response.HealthDmg = 2 * (100 - player.Health);
                response.CustomText = "You use Hydro Blast! (" + 2 * (100 - player.Health) + " water damage)";
            }
            else
            {
                response.HealthDmg = 0;
                response.CustomText = "Because you are full health this skill did zero damage!";
            }
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
