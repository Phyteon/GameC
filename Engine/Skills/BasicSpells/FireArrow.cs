using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class FireArrow : Skill
    {
        // fire arrow: [Pr]% chance to land an arrow that deals 0.5*[Mp] damage
        // if your precision stat is higher than 100, you will always land the arrow
        public FireArrow() : base("Fire Arrow", 20, 1)
        { 
            PublicName = "Fire Arrow: a chance equal to your Precision stat to land 0.5*MP damage [fire]";
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Fire);
            if (Index.RNG(0, 100) < player.Precision)
            {
                response.HealthDmg = (int)(0.5 * player.MagicPower);
                response.CustomText = "You use Fire Arrow! (" + (int)(0.5 * player.MagicPower) + " fire damage)";
            }
            else
            {
                response.HealthDmg = 0;
                response.CustomText = "You try to use Fire Arrow but it misses!";
            }
            return new List<StatPackage>() { response };
        }
    }
}
