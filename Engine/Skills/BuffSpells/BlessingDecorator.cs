using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.SomeSeriousSpells
{
    [Serializable]
    class BlessingDecorator: SkillDecorator
    {
        public BlessingDecorator(Skill skill): base("Blessing", 30, 3, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = "Blessing: increase your Strength and armor by 20, and decrease enemy armor by 10 [earth] AND"
            + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = Skill.MainItem.staff;
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage reaction = new StatPackage(DmgType.earth);
            player.Strength += 20;
            player.Armor += 20;
            reaction.ArmorDmg = 10;
            reaction.CustomText = "You use Blessing! (Your strenght and armor will be increased by 20 and enemies armor will be decreased by 10!)";
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(reaction);
            return combo;
        }
    }
}
