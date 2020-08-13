using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class FireArrowDecorator : SkillDecorator
    {
        // decorator for Fire Arrow class
        public FireArrowDecorator(Skill skill) : base("Fire Arrow", 20, 1, skill) 
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = "COMBO - Fire Arrow: a chance equal to your Precision stat to land 0.5*MP damage [fire] AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = Skill.MainItem.staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("fire");
            Random rnd = new Random();
            if (rnd.Next(0, 100) < player.Precision)
            {
                response.HealthDmg = (int)(0.5 * player.MagicPower);
                response.CustomText = "You use Fire Arrow! (" + (int)(0.5 * player.MagicPower) + " fire damage)";
            }
            else
            {
                response.HealthDmg = 0;
                response.CustomText = "You try to Fire Arrow but it misses!";
            }
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
