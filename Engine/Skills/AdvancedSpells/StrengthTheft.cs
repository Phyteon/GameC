using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.MoreSpells
{
    [Serializable]
    class StrengthTheft : Skill
    {
        // substract 15 strenght points from enemy and add same amount to player's strenght
        public StrengthTheft() : base("Strength theft", 20, 2)
        {
            PublicName = "Steal 15 strength poins from monster [theft]";
            RequiredItem = Skill.MainItem.staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("magic");
            player.Strength += 15;
            response.StrengthDmg = 15;
            response.CustomText = "You steal 15 strength points for yourself";
            return new List<StatPackage>() { response };
        }
    }
}
