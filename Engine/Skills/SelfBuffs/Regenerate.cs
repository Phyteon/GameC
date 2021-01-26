using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class Regenerate : Skill
    {
        // regenerate: regenerates 50 stamina
        public Regenerate() : base("Regenerate", 0, 2)
        {
            PublicName = "Regenerates: +50 stamina";
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Other);
            player.BattleBuffStamina += 50;
            player.BattleBuffHealth -= 5;
            response.CustomText = "You use Regenerate! (50 stamina added, 5 HP taken)";
            return new List<StatPackage>() { response };
        }
    }
}