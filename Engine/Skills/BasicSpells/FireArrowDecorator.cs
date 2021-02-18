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
            PublicName = "COMBO - Ognista Strzala: procentowa szansa rowna twojej precyzji na zadanie 0.5*Moc obrazen [ogien] ORAZ " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Fire);
            if (Index.RNG(0, 100) < player.Precision)
            {
                response.HealthDmg = (int)(0.5 * player.MagicPower);
                response.CustomText = "Ognista Strzala trafia przeciwnika! " + (int)(0.5 * player.MagicPower) + "  obrazen [ogien]";
            }
            else
            {
                response.HealthDmg = 0;
                response.CustomText = "Ognista Strzala nie trafila w przeciwnika!";
            }
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
