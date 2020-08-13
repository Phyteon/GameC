using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.OsirisMoves
{
    [Serializable]
    class MummySpell : Skill
    {
        public MummySpell() : base("Mummy Spell", 20, 1)
        {
            PublicName = " MummySpell [requires staff]: decrease enemy strength, precision, health stats by 10 [poison] ";
            RequiredItem = Skill.MainItem.staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("poison");
            response.StrengthDmg = 10;
            response.PrecisionDmg = 10;
            response.HealthDmg = 20;
            response.CustomText = "You use MummySpell! (enemy strength, precision and health decreased by 10)";
            return new List<StatPackage>() { response };
        }
    }
}
