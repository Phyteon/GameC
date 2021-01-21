using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class HealDecorator : SkillDecorator
    {
        // decorator for Heal class
        public HealDecorator(Skill skill) : base("Self Heal", 10, 2, skill)
        {
            MinimumLevel = Math.Max(2, skill.MinimumLevel) + 1;
            PublicName = "COMBO - Self Heal: 20 HP AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Other);
            player.BattleBuffHealth += 20;
            response.CustomText = "You use Self Heal (20 HP healed)";
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
