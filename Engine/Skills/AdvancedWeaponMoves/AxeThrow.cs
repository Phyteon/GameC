using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.AdvancedWeaponMoves
{
    [Serializable]
    class AxeThrow : Skill
    {
        public AxeThrow() : base("Axe Throw", 30, 5)
        {
            PublicName = "Axe Throw [requires axe]: a chance equal to your Stamina stat to land 0.5*Str + 0.2*Pr damage [incised]";
            RequiredItem = Skill.MainItem.Axe;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Cut);
            Random rnd = new Random();
            if (rnd.Next(0, 100) < player.Stamina)
            {
                response.HealthDmg = (int)(0.4 * player.Strength) + (int)(0.1 * player.Precision);
                response.CustomText = "You use Axe Throw! (" + ((int)(0.4 * player.Strength) + (int)(0.1 * player.Precision)) + " incised damage)";
            }
            else
            {
                response.HealthDmg = 0;
                response.CustomText = "You try to use Axe Throw but it misses!";
            }
            return new List<StatPackage>() { response };
        }
    }
}
