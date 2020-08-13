using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class WindGust : Skill
    {
        // wind gust: deal 5+0.3*[Mp] damage
        public WindGust() : base("Wind Gust", 10, 1)
        {
            PublicName = "Wind Gust: 5 + 0.3*MP damage [air]";
            RequiredItem = Skill.MainItem.staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("air");
            response.HealthDmg = 5 + (int)(0.3 * player.MagicPower);
            response.CustomText = "You use Wind Gust! (" + (5 + (int)(0.3 * player.MagicPower)) + " air damage)";
            return new List<StatPackage>() { response };
        }
    }
}
