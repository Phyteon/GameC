using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class WindGust : Skill
    {
        // wind gust: deal 15+0.1*[Mp] damage
        public WindGust() : base("Wind Gust", 10, 1)
        {
            PublicName = "Wind Gust: 15 + 0.1*MP damage [air]";
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Air);
            response.HealthDmg = 15 + (int)(0.1 * player.MagicPower);
            response.CustomText = "You use Wind Gust! (" + (15 + (int)(0.1 * player.MagicPower)) + " air damage)";
            return new List<StatPackage>() { response };
        }
    }
}
