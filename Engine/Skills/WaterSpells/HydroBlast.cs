using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class HydroBlast : Skill
    {
        // hydro blast: skill that scales with user missing health
        public HydroBlast() : base("Hydro Blast", 20, 3)
        {
            PublicName = "Hydro Blast: less health equals more [water] damage";
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Water);
            if (player.Health<100)
            {
                response.HealthDmg = 2*(100-player.Health);
                response.CustomText = "You use Hydro Blast! (" + 2 * (100 - player.Health) + " water damage)";
            }
            else
            {
                response.HealthDmg = 0;
                response.CustomText = "Because you are full health this skill did zero damage!";
            }
            return new List<StatPackage>() { response };
        }
    }
}
