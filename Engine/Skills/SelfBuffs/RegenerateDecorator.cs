using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class RegenerateDecorator : SkillDecorator
    {
        // decorator for Regenerate class
        public RegenerateDecorator(Skill skill) : base("Regenerate", 0, 2, skill)
        {
            MinimumLevel = Math.Max(4, skill.MinimumLevel) + 1;
            PublicName = "Regenerates: +50 stamina";
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Other);
            player.BattleBuffStamina += 50;
            player.BattleBuffHealth -= 5;
            response.CustomText = "You use Regenarate! (50 stamina added, 5 HP taken)";
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
