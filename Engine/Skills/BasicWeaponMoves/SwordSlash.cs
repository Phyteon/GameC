using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicWeaponMoves
{
    [Serializable]
    class SwordSlash : Skill
    {
        // simple slash with sword
        public SwordSlash() : base("Sword Slash", 20, 1)
        {
            PublicName = "Basic sword slash [requires sword]: 0.1*Str + 0.1*Pr damage [cut] and then 0.1*Str + 0.1*Pr damage [incised]";
            RequiredItem = RequiredItem.Sword;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response1 = new StatPackage(DmgType.Cut);
            response1.HealthDmg = (int)(0.1 * player.Strength) + (int)(0.1 * player.Precision);
            StatPackage response2 = new StatPackage(DmgType.Cut);
            response2.HealthDmg = (int)(0.1 * player.Strength) + (int)(0.1 * player.Precision);
            // applying CustomText only once is sufficient
            response2.CustomText = "You use Sword Slash! (" + ((int)(0.1 * player.Strength) + (int)(0.1 * player.Precision)) + " cut damage, " + ((int)(0.1 * player.Strength) + (int)(0.1 * player.Precision)) + " incised damage)";
            return new List<StatPackage>() { response1, response2 };
        }
    }
}
