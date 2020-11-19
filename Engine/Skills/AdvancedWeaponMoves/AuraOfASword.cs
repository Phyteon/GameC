using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.AdvancedWeaponMoves
{
    [Serializable]
    class AuraOfASword : Skill
    {
        public AuraOfASword() : base("Aura Of The Sword", 30, 5)
        {
            PublicName = "Aura Of The Sword [requires sword]: deal 0.1*Str + 0.1*Pr incised damage and then create an aura that increase your strength and precision by 10";
            RequiredItem = Skill.MainItem.Sword;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Cut);
            response.HealthDmg = (int)(0.1 * player.Strength + 0.1 * player.Precision);
            player.StrengthBuff = 20;
            player.PrecisionBuff = 20;
            response.CustomText = "You use Aura Of The Sword! ("+ (int)(0.1 * player.Strength + 0.1 * player.Precision) +" incised damage, +10 Strength, +10 Precision)";
            return new List<StatPackage>() { response };
        }
    }
}
