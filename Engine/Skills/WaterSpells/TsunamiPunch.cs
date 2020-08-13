using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.WaterSpells
{
    [Serializable]
    class TsunamiPunch : Skill
    {

        public TsunamiPunch() : base("Tsunami Punch", 20, 5)
        {
            PublicName = "Tsunami Punch: decrease enemy strength stat by 10 and land 0.3*MP damage [water]"; 
            RequiredItem = Skill.MainItem.staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("water");
            response.StrengthDmg = 10 ;
            response.HealthDmg = (int)(0.4*player.MagicPower);
            response.CustomText = "You use Tsunami Punch! ( " + ((int)(0.4 * player.MagicPower)) + " water damage and enemy strength decreased by 10)"; 
            return new List<StatPackage>() { response };
        }
    }
}
