using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills
{
    [Serializable]
    class RunAway : Skill
    {
        public RunAway() : base("Run Away", 20, 1)
        {
            PublicName = "Run away (only half of your wounds will heal!)";
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("none");
            return new List<StatPackage>() { response };
        }
    }
}
