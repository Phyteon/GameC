using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills
{
    [Serializable]
    class BloodlustDecorator : SkillDecorator
    {
        public BloodlustDecorator(Skill skill) : base("Bloodlust", 3, 3, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = "COMBO - Bloodlust: dameges a target for 10% of their health and restores that amount to you AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = Skill.MainItem.Staff;
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Other);
            response.HealthDmg = 90 * response.HealthDmg / 10;
            player.Health += response.HealthDmg;
            response.CustomText = "You use Bloodlust! (" + 90 * response.HealthDmg / 10 + " health damage)";
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
