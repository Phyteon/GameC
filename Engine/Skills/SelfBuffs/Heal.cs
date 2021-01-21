using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class Heal : Skill
    {
        // heal: heals for 20 HP
        public Heal() : base("Self Heal", 10, 2)
        {
            PublicName = "Self Heal: 20 HP heal";
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Other);
            player.BattleBuffHealth += 20;
            response.CustomText = "You use Self Heal! (20 HP healed)";
            return new List<StatPackage>() { response };
        }
    }
}