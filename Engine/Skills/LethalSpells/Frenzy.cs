using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class Frenzy : Skill
    {
        // frenzy: entering rage mode
        public Frenzy() : base("Frenzy", 30, 8)
        {
            PublicName = "Frenzy: [Pr] chance to enter rage mode with +30 magic power, +50 precision, +40 strength, +20 HP, but u can lose something as well!";
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Other);
            if (Index.RNG(0, 100) < player.Precision)
            {
                player.MagicPowerBuff += 30;
                player.PrecisionBuff += 50;
                player.StrengthBuff += 40;
                player.HealthBuff += 20;
                response.CustomText = "You use Frenzy! (+30 magic power, +50 precision, +40 strength, +20 HP)";
            }
            else
            {
                player.MagicPowerBuff -= 10;
                response.CustomText = "You failed using Frenzy! (-10 magic power)";
            }
            return new List<StatPackage>() { response };
        }
    }
}