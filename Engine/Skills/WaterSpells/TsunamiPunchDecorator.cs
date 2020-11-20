using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.WaterSpells
{
    [Serializable]
    class TsunamiPunchDecorator : SkillDecorator
    {
        // decorator for TsunamiPunch class
        public TsunamiPunchDecorator(Skill skill) : base("Tsunami Punch", 20, 5, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1; 
            PublicName = "COMBO - Tsunami Punch: desrease enemy strength stat by 10 and land 0.3*MP damage [water] AND " + decoratedSkill.PublicName.Replace("COMBO: ", ""); 
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Water);
            response.HealthDmg = (int)(0.4 * player.MagicPower);
            response.CustomText = "You use Tsunami Punch! ( " + ((int)(0.4 * player.MagicPower)) + " water damage and enemy strength decreased by 10)";
            List<StatPackage> combo = decoratedSkill.BattleMove(player); 
            combo.Add(response); 
            return combo;
        }
    }
}
