using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.SomeSeriousSpells
{
    [Serializable]
    class MagicArrow: Skill
    {
        public MagicArrow(): base("Magic Arrow",30,2)
        {
            PublicName = "Magic Arrow: deal 0.6*MP damage [air], but if your precision skill is high enough you can deal 1*MP damage [air]";
            RequiredItem = Skill.MainItem.staff;
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage reaction = new StatPackage(DmgType.air);
            if (player.Precision > 70)
            {
                reaction.HealthDmg = (int)(player.MagicPower);
                reaction.CustomText = ("You use a POWERFUL Magic Arrow! ( " + player.MagicPower + " air damage! )");
            }
            else
            {
                reaction.HealthDmg = (int)(0.6 * player.MagicPower);
                reaction.CustomText = ("You use Magic Arrow! ( " + 0.6 * player.MagicPower + " air damage! )");
            }
            return new List<StatPackage>() { reaction };
        }
    }
}
