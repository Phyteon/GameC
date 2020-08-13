using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills
{
    [Serializable]
    class SoulEater : Skill
    {
        //receive health points after giving damage
        public SoulEater() : base("Soul Eater", 30, 5)//zmien lvl
        {
            PublicName = "Soul Eater: 0.4*Mp fire damage, gives you 0.1*MP health points during battle.";
            RequiredItem = Skill.MainItem.staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("fire");
            response.HealthDmg = (int)(0.4 * player.MagicPower);
            player.Health += (int)(0.1 * player.MagicPower);
            // applying CustomText only once is sufficient
            response.CustomText = "You use Soul Eater! (" + ((int)(0.4 * player.MagicPower)) + " fire damage)\nYou've gained " + ((int)(0.1 * player.MagicPower)) + " health points";
            return new List<StatPackage>() { response };
        }
    }
}
