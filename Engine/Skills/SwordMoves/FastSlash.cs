using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.SwordMoves
{
    [Serializable]
    class FastSlash : Skill
    {
        public FastSlash() : base("Fast Slash", 30, 2)
        {
            PublicName = "Fast Slash [requires sword]: deals 0.5*Str damage [cut] and decreases enemy precision stat by 10";
            RequiredItem = RequiredItem.Sword;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response1 = new StatPackage(DmgType.Cut);
            StatPackage response2 = new StatPackage(DmgType.Cut);
            response1.HealthDmg = (int)(0.5 * player.Strength);
            response2.PrecisionDmg = 10;
            response2.CustomText = "You use Fast Slash! (" + (int)(0.5 * player.Strength) + " cut damage)";
            return new List<StatPackage>() { response1, response2 };
        }
    }
}
