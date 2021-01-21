using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class IceVortex : Skill
    {
        // ice vortex: small chance to lethal hit and one-shot the enemy
        public IceVortex() : base("Ice Vortex", 70, 7)
        {
            PublicName = "Ice Vortex: small [Pr] chance to immediately kill the enemy";
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Water);
            if (Index.RNG(0, 500) < player.Precision)
            {
                response.HealthDmg = 10000000;
                response.CustomText = "Ice Vortex was successful!";
            }
            else
            {
                response.HealthDmg = 0;
                response.CustomText = "Ice Vortex was not successful!";
            }
            return new List<StatPackage>() { response };
        }
    }
}