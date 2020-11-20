using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.SomeSeriousSpells
{
    [Serializable]
    class MagicArrowDecorator: SkillDecorator
    {
        public MagicArrowDecorator(Skill skill): base("Magic Arrow",30,2,skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 2;
            PublicName = "Magic Arrow: deal 0.6*MP damage [air], but if your precision skill is high enough you can deal 1*MP damage [air] :O AND " 
                + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = RequiredItem.Staff;
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage reaction = new StatPackage(DmgType.Air);
            if (player.Precision > 70)
            {
                reaction.HealthDmg = (int)(player.MagicPower);
                reaction.CustomText = ("You  use a POWERFUL Magic Arrow! ( " + player.MagicPower + " air damage! )");
            }
            else
            {
                reaction.HealthDmg = (int)(0.6 * player.MagicPower);
                reaction.CustomText = ("You use Magic Arrow! ( " + 0.6 * player.MagicPower + " air damage! )");
            }
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(reaction);
            return combo;
        }
    }
}
