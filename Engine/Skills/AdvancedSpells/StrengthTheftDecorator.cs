using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.MoreSpells
{
    [Serializable]
    class StrengthTheftDecorator : SkillDecorator
    {
        public StrengthTheftDecorator(Skill skill) : base("Strength theft", 20, 2, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 2;
            PublicName = "COMBO - Steal 15 strength poins from monster [theft] AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = Skill.MainItem.staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("magic");
            player.Strength += 15;
            response.StrengthDmg = 15;
            response.CustomText = "You steal 15 strength points for yourself";

            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
