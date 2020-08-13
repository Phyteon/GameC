using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.AdvancedWeaponTechniques
{
    [Serializable]
    class RollAndBackStabDecorator : SkillDecorator
    {
        public RollAndBackStabDecorator(Skill skill) : base("RollAndBackStab", 40, 5, skill)
        {
            MinimumLevel = Math.Max(5, skill.MinimumLevel) + 1;
            PublicName = "COMBO - Roll and stab in the back [requires spear]: 0.2*Pr damage [incised] and then 0.3*Str + 0.3*Pr damage [stab] AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = Skill.MainItem.spear;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response1 = new StatPackage(DmgType.cut);
            response1.HealthDmg = (int)(0.2 * player.Precision);
            StatPackage response2 = new StatPackage(DmgType.stab);
            response2.HealthDmg = (int)(0.3 * player.Strength) + (int)(0.3 * player.Precision);
            response2.CustomText = "You use roll&stab in the back technique! (" + ((int)(0.2 * player.Precision)) + " incised damage, " + ((int)(0.3 * player.Strength) + (int)(0.3 * player.Precision)) + " stab damage)";
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response1);
            combo.Add(response2);
            return combo;
        }
    }
}
