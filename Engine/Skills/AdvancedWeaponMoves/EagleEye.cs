using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.AdvancedWeaponMoves
{
    [Serializable]
    class EagleEye : Skill
    {
        public EagleEye() : base("Eagle Eye", 30, 5)
        {
            PublicName = "Eagle Eye: + 30 Pr, + 10 Str, + 10 Armor";
            RequiredItem = Skill.MainItem.spear;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("incised");
            player.ArmorBuff = 10;
            player.StrengthBuff = 10;
            player.PrecisionBuff = 30;
            response.CustomText = "You use Eagle Eye! (+10 Armor, +10 Strength, +30 Preccision)";
            return new List<StatPackage>() { response };
        }
    }
}
