using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class GroundSwirl : Skill
    {
        // ground swirl: deal 10+0.2*[Mp] damage
        public GroundSwirl() : base("Ground Swirl", 15, 1)
        {
            PublicName = "Ground Swirl: 10 + 0.2*MP damage [earth]";
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Earth);
            response.HealthDmg = 10 + (int)(0.2 * player.MagicPower);
            response.CustomText = "You use Ground Swirl! (" + (10 + (int)(0.2 * player.MagicPower)) + " earth damage)";
            return new List<StatPackage>() { response };
        }
    }
}
