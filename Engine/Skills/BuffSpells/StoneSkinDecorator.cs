using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.SomeSeriousSpells
{
    [Serializable]
    class StoneSkinDecorator: SkillDecorator
    {
        public StoneSkinDecorator(Skill skill): base("Stone Skin",15, 1, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = "Stone Skin: increase your armor stats by 30 + your current armor stat/4! [earth] AND"
            + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage reaction = new StatPackage(DmgType.Earth);
            player.Armor = player.Armor + (30 + player.Armor / 4);
            reaction.HealthDmg = 0;
            reaction.CustomText = "You use Stone Skin! You will get ( " + (30 + player.Armor / 4) + " ) armor buff!";
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(reaction);
            return combo;
        }
    }
}
