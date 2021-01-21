using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class MentalAttackDecorator : SkillDecorator
    {
        // decorator for Mental Attack class
        public MentalAttackDecorator(Skill skill) : base("Mental Attack", 10, 1, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = "COMBO - Mental Attack: 5 + 0.6 * MP damage[psycho] AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Psycho);
            response.HealthDmg = 5 + (int)(0.6*player.MagicPower);
            response.CustomText = "You use Mental Attack! (" + (5 + (int)(0.6*player.MagicPower)) + " psycho damage)";
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
