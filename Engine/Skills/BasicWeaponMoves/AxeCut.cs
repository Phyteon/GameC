using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicWeaponMoves
{
    [Serializable]
    class AxeCut : Skill
    {
        // simple axe cut
        public AxeCut() : base("Axe Cut", 20, 1) 
        {
            PublicName = "Cios toporem [wymagany topor]: 0.4*Sila + 0.1*Precyzja obrazen [fizyczne]";
            RequiredItem = RequiredItem.Axe;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Physical);
            response.HealthDmg = (int)(0.4 * player.Strength) + (int)(0.1 * player.Precision);
            response.CustomText = "Uzywasz ciosu toporem! " + ((int)(0.4 * player.Strength) + (int)(0.1 * player.Precision)) + " obrazen [fizyczne]";
            return new List<StatPackage>() { response };
        }
    }
}
