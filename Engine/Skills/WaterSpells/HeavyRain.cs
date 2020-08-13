using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.WaterSpells
{
    [Serializable]
    class HeavyRain : Skill
    {
        
        public HeavyRain() : base("Heavy Rain", 10, 2)
        {
            PublicName = "Heavy Rain: decrease enemy precision and strength stat by 0.2*MP [water]"; 
            RequiredItem = Skill.MainItem.staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("water");
            response.PrecisionDmg = (int)(0.2 * player.MagicPower);
            response.StrengthDmg = (int)(0.2 * player.MagicPower);
            response.CustomText = "You use Heavy Rain! (enemy precision desreased by " +((int)(0.2 * player.MagicPower)) + " )"; 
            return new List<StatPackage>() { response };
        }
    }
}
