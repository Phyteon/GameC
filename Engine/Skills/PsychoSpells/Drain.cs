using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class Drain : Skill
    {
        // drain: [Pr]% chance to land a skill that deals 30+0.4*[Mp] damage and heals for 80% damage dealt
        // if your precision stat is higher than 100, you will always land the arrow
        public Drain() : base("Drain", 40, 3)
        {
            PublicName = "Drain: a chance equal to your Precision stat to land 0.4*MP damage [psycho] and heal for 80% damage dealt";
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Psycho);
            if (Index.RNG(0, 100) < player.Precision)
            {
                response.HealthDmg = 30+(int)(0.4 * player.MagicPower);
                player.BattleBuffHealth += (int)(0.8*response.HealthDmg);
                response.CustomText = "You use Drain! (" + (int)(0.4 * player.MagicPower) + " psycho damage and restoration of " + (int)(0.8 * response.HealthDmg) + " HP)";
            }
            else
            {
                response.HealthDmg = 0;
                response.CustomText = "You try to use Drain but it misses!";
            }
            return new List<StatPackage>() { response };
        }
    }
}
