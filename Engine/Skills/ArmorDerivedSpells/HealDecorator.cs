using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills
{
    [Serializable]
    class HealDecorator : SkillDecorator
    {
        public HealDecorator(Skill skill) : base("Heal", 1, 2, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = "COMBO - Heal: restores 10 health AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = Skill.MainItem.staff;
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.none);
            player.Health += 10;
            response.CustomText = "You used Heal! (" + 10 + " health restored)";
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
