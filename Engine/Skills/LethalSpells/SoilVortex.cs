using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class SoilVortex : Skill
    {
        // soil vortex: small chance to lethal hit and one-shot the enemy
        public SoilVortex() : base("Soil Vortex", 70, 7)
        {
            PublicName = "Soil Vortex: small [Pr] chance to immediately kill the enemy";
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Earth);
            if (Index.RNG(0, 500) < player.Precision)
            {
                response.HealthDmg = 10000000;
                response.CustomText = "Soil Vortex was successful!";
            }
            else
            {
                response.HealthDmg = 0;
                response.CustomText = "Soil Vortex was not successful!";
            }
            return new List<StatPackage>() { response };
        }
    }
}