using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class Hurricane : Skill
    {
        // hurricane: [Pr]% chance to land a skill that deals 1*[Mp] damage
        // if your precision stat is higher than 100, you will always land the skill
        public Hurricane() : base("Hurricane", 50, 3)
        {
            PublicName = "Hurricane: a chance equal to your Precision stat to land 1*MP damage [air]";
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Air);
            if (Index.RNG(0, 100) < player.Precision)
            {
                response.HealthDmg = player.MagicPower;
                response.CustomText = "You use Hurricane! (" + player.MagicPower + " air damage)";
            }
            else
            {
                response.HealthDmg = 0;
                response.CustomText = "You try to use Hurricane but it misses!";
            }
            return new List<StatPackage>() { response };
        }
    }
}
