using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class MentalAttack : Skill
    {
        // mental attack: deal 7+0.6*[Mp] damage
        public MentalAttack() : base("Mental Attack", 10, 1)
        {
            PublicName = "Mental Attack: 5 + 0.6*MP damage [psycho]";
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Psycho);
            response.HealthDmg = 5 + (int)(0.6*player.MagicPower);
            response.CustomText = "You use Mental Attack! (" + (5 + (int)(0.6*player.MagicPower)) + " psycho damage)";
            return new List<StatPackage>() { response };
        }
    }
}
