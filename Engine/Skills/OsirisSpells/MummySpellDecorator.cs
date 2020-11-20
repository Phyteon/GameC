using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.OsirisMoves
{
    [Serializable]
    class MummySpellDecorator : SkillDecorator
    {
        public MummySpellDecorator(Skill skill) : base("Mummy Spell", 20, 1, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = " COMBO - MummySpell: decrease enemy strenght, precision, health stats by 10 AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Poison);
            response.StrengthDmg = 10;
            response.PrecisionDmg = 10;
            response.HealthDmg = 10;
            response.CustomText = "You use MummySpell! (enemy strenght, precision and health decreased by 10)";
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
