using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class HurricaneDecorator : SkillDecorator
    {
        // decorator for Hurricane class
        public HurricaneDecorator(Skill skill) : base("Hurricane", 50, 3, skill)
        {
            MinimumLevel = Math.Max(3, skill.MinimumLevel) + 1;
            PublicName = "COMBO - Hurricane: a chance equal to your Precision stat to land 1*MP damage [air] AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Air);
            if (Index.RNG(0, 100) < player.Precision)
            {
                response.HealthDmg = player.MagicPower;
                response.CustomText = "You use Hurricane! (" + player.MagicPower + " air damage)";
            }
            else
            {
                response.HealthDmg = 0;
                response.CustomText = "You try to Hurricane but it misses!";
            }
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
