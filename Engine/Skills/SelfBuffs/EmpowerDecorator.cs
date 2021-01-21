using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class EmpowerDecorator : SkillDecorator
    {
        // decorator for Empower class
        public EmpowerDecorator(Skill skill) : base("Empower", 10, 2, skill)
        {
            MinimumLevel = Math.Max(2, skill.MinimumLevel) + 1;
            PublicName = "COMBO - Empower: +20 magic power AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Other);
            player.BattleBuffMagicPower += 20;
            response.CustomText = "You use Empower! (+20 magic power)";
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
