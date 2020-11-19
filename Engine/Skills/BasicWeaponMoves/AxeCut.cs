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
            PublicName = "Basic axe cut [requires axe]: 0.4*Str + 0.1*Pr damage [incised]";
            RequiredItem = Skill.MainItem.Axe;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Cut);
            response.HealthDmg = (int)(0.4 * player.Strength) + (int)(0.1 * player.Precision);
            response.CustomText = "You use Axe Cut! (" + ((int)(0.4 * player.Strength) + (int)(0.1 * player.Precision)) + " incised damage)";
            return new List<StatPackage>() { response };
        }
    }
}
