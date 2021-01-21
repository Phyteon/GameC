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
            PublicName = "Basic spear stab [requires spear]: 0.2*Str + 0.3*Pr damage [cut]";
            RequiredItem = RequiredItem.Spear;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Cut);
            response.HealthDmg = (int)(0.2 * player.Strength) + (int)(0.3 * player.Precision);
            response.CustomText = "You use Spear Stab! (" + ((int)(0.2 * player.Strength) + (int)(0.3 * player.Precision)) + " cut damage)";
            return new List<StatPackage>() { response };
        }
    }
}
