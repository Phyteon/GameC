using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.AdvancedWeaponTechniques
{
    [Serializable]
    class WhirlDecorator : SkillDecorator
    {
        public WhirlDecorator(Skill skill) : base("Whirl", 50, 4, skill)
        {
            MinimumLevel = Math.Max(4, skill.MinimumLevel) + 1;
            PublicName = "COMBO - Spear-whirl [requires spear]: 0.3*Str + 0.4*Pr damage [stab] AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = Skill.MainItem.spear;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("stab");
            response.HealthDmg = (int)(0.3 * player.Strength) + (int)(0.4 * player.Precision);
            response.CustomText = "You whirl your spear around! (" + ((int)(0.3 * player.Strength) +(int)(0.4 * player.Precision)) + " stab damage)";
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
