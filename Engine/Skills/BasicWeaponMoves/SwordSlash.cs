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
            PublicName = "Uderzenie mieczem [wymagany miecz]: 0.2*Sila + 0.2*Precyzja obrazen [fizyczne]";
            RequiredItem = RequiredItem.Sword;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response1 = new StatPackage(DmgType.Physical);
            response1.HealthDmg = (int)(0.2 * player.Strength) + (int)(0.2 * player.Precision);
            // applying CustomText only once is sufficient
            response1.CustomText = "Uderzasz mieczem! " + ((int)(0.2 * player.Strength) + (int)(0.2 * player.Precision)) + " obrazen [fizyczne]";
            return new List<StatPackage>() { response1 };
        }
    }
}
