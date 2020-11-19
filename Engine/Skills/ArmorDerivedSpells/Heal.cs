using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills
{
    [Serializable]
    public class Heal : Skill
    {
        public Heal() : base("Heal", 1, 2)
        {
            PublicName = "Heal: restores 10 health";
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Other);
            player.Health += 10;
            response.CustomText = "You used Heal! (" + 10 + " health restored)";
            return new List<StatPackage>() { response };
        }
    }
}
