using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class AquaSpark : Skill
    {
        // aqua spark: deal 20 damage
        public AquaSpark() : base("Aqua Spark", 15, 1)
        {
            PublicName = "Aqua Spark: 15 damage [water]";
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Water);
            response.HealthDmg = 15;
            response.CustomText = "You use Aqua Spark! (15 water damage)";
            return new List<StatPackage>() { response };
        }
    }
}
