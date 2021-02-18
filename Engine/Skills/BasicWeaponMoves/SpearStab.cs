using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicWeaponMoves
{
    [Serializable]
    class SpearStab : Skill
    {
        // simple stab with spear
        public SpearStab() : base("Spear Stab", 20, 1) 
        { 
            PublicName = "Pchniecie wlocznia [wymagana wlocznia]: 0.2*Sila + 0.3*Precyzja obrazen [fizyczne]";
            RequiredItem = RequiredItem.Spear;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Physical);
            response.HealthDmg = (int)(0.2 * player.Strength) + (int)(0.3 * player.Precision);
            response.CustomText = "Uzywasz pchniecia wlocznia! " + ((int)(0.2 * player.Strength) + (int)(0.3 * player.Precision)) + " obrazen [fizyczne]";
            return new List<StatPackage>() { response };
        }
    }
}
