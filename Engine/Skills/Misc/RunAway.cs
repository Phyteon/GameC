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
        // this is a special skill and the way it works is handled inside the Battle class instead of here 
        // if you are looking for a clear example of how to write your own skill, this is probably NOT the right place
        // you can check BasicSpells and BasicWeaponMoves folders instead 
        public RunAway() : base("Run Away", 20, 1)
        {
            PublicName = "Run away (only half of your wounds will heal!)";
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Other);
            return new List<StatPackage>() { response };
        }
    }
}
