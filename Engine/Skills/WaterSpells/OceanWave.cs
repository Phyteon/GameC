using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.WaterSpells
{
    [Serializable]
    class OceanWave : Skill
    {

        public OceanWave() : base("Ocean Wave", 15, 3)
        {
            PublicName = "Ocean Wave: 0.4*MP + 0.1*STR damage [water]"; 
            RequiredItem = Skill.MainItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Water);
            response.HealthDmg =  (int)(0.4 * player.MagicPower) + (int)(0.1*player.Strength); 
            response.CustomText = "You use Ocean Wave! (" + ((int)(0.4 * player.MagicPower) + (int)(0.1*player.Strength)) + " water damage)"; 
            return new List<StatPackage>() { response };
        }
    }
}
