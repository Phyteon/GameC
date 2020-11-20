using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.WaterSpells
{
    [Serializable]
    class HeavyRainDecorator : SkillDecorator
    {
        // decorator for HeavyRain class
        public HeavyRainDecorator(Skill skill) : base("Heavy Rain", 10, 2, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1; 
            PublicName = "COMBO - Heavy Rain: decreases enemy precision and strength stat by 0.2*MP [water] AND " + decoratedSkill.PublicName.Replace("COMBO: ", ""); 
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Water);
            response.PrecisionDmg = (int)(0.2 * player.MagicPower);
            response.StrengthDmg = (int)(0.2 * player.MagicPower);
            response.CustomText = "You use Heavy Rain! (enemy precision desreased by " + ((int)(0.2 * player.MagicPower)) + " )"; 
            List<StatPackage> combo = decoratedSkill.BattleMove(player); 
            combo.Add(response); 
            return combo;
        }
    }
}
