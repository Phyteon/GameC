using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicWeaponMoves
{
    [Serializable]
    class AxeCut : Skill
    {
        public AxeCut() : base("Axe Cut", 20, 1) 
        {
            PublicName = "Atak toporem: (0.5 * Sila) dmg [fizyczne]";
            RequiredItem = RequiredItem.Axe;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Physical);
            response.HealthDmg = (int)(0.5 * player.Strength);
            response.CustomText = "Atakujesz toporem! " + (int)(0.5 * player.Strength) + " dmg [fizyczne]";
            return new List<StatPackage>() { response };
        }
    }
}
