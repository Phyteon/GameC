using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills
{
    [Serializable]
    class RageDecorator : SkillDecorator
    {
        public RageDecorator(Skill skill) : base("Heal", 1, 2, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = "COMBO - Rage: damages you for 10 and converts it to strength AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = Skill.MainItem.Staff;
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Other);
            player.Health -= 10;
            player.Strength += 10;
            response.CustomText = "You used Rage! (health decreased to " + player.Health + " strength increased to " + player.Strength + ")";
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}