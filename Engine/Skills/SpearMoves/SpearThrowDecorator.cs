using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.AdvancedWeaponTechniques
{
    [Serializable]
    class SpearThrowDecorator : SkillDecorator
    {
        public SpearThrowDecorator(Skill skill) : base("Spear Throw", 15, 3, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = "COMBO - Spear throw [requires spear]: 0.5*Pr damage [stab] AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = Skill.MainItem.spear;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.stab);
            response.HealthDmg = (int)(0.5 * player.Precision);
            response.CustomText = "You use Spear Throw! (" + (int)(0.5 * player.Precision) + " stab damage)";
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
