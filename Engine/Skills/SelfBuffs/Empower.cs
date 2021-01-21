using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class Empower : Skill
    {
        // empower: adds 20 points to magic power
        public Empower() : base("Empower", 10, 2)
        {
            PublicName = "Empower: +20 magic power";
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Other);
            player.BattleBuffMagicPower += 20;
            response.CustomText = "You use Empower! (+20 magic power)";
            return new List<StatPackage>() { response };
        }
    }
}