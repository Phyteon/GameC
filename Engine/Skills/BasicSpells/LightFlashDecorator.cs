using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class LightFlashDecorator : SkillDecorator
    {
        // decorator for Light Flash class
        public LightFlashDecorator(Skill skill) : base("Light Flash", 10, 1, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = "COMBO - Light Flash: decrease enemy precision stat by 15 [fire] AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = Skill.MainItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Fire);
            response.PrecisionDmg = 15;
            response.CustomText = "You use Light Flash! (enemy precision decreased by 15)";
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
