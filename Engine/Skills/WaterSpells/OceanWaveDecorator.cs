using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.WaterSpells
{
    [Serializable]
    class OceanWaveDecorator : SkillDecorator
    {
        // decorator for Ocean Wave class
        public OceanWaveDecorator(Skill skill) : base("Ocean Wave", 15, 3, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1; 
            PublicName = "COMBO - Ocean Wave: 0.4*MP + 0.1*STR damage [water] AND " + decoratedSkill.PublicName.Replace("COMBO: ", ""); 
            RequiredItem = Skill.MainItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Water);
            response.HealthDmg = (int)(0.4 * player.MagicPower) + (int)(0.1 * player.Strength);
            response.CustomText = "You use Ocean Wave! (" + ((int)(0.4 * player.MagicPower) + (int)(0.1 * player.Strength)) + " water damage)";
            List<StatPackage> combo = decoratedSkill.BattleMove(player); 
            combo.Add(response); 
            return combo;
        }
    }
}
