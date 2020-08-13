using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.SomeSeriousSpells
{
    [Serializable]
    class AuraOfTheSwordDecorator: SkillDecorator
    {
        public AuraOfTheSwordDecorator(Skill skill): base("Aura of the sword!", 30,3,skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = "Aura of the sword: If you have more than 120HP increse your strength stats by 50, otherwise increase your strength by 20 [air] AND"
            + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = Skill.MainItem.sword;
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage reaction = new StatPackage(DmgType.air);
            if (player.Health > 120)
            {
                player.Strength += 50;
                reaction.CustomText = "You use STRONG Aura of the sword! (Your Strength stat will be increased by 50!)";
            }
            else
            {
                player.Strength += 20;
                reaction.CustomText = "You use Aura of the sword! (Your Strength stat will be increased by 20!)";
            }
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(reaction);
            return combo;
        }
    }
}
