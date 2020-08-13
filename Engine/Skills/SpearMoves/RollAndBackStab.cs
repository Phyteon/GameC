using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.AdvancedWeaponTechniques
{
    [Serializable]
    class RollAndBackStab : Skill
    {
        public RollAndBackStab() : base("RollAndBackStab", 40, 5)
        {
            PublicName = "Roll and stab in the back [requires spear]: 0.2*Pr damage [incised] and then 0.3*Str + 0.3*Pr damage [stab]";
            RequiredItem = Skill.MainItem.spear;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response1 = new StatPackage("incised");
            response1.HealthDmg = (int)(0.2 * player.Precision);
            StatPackage response2 = new StatPackage("stab");
            response2.HealthDmg = (int)(0.3 * player.Strength) + (int)(0.3 * player.Precision);
            response2.CustomText = "You use roll&stab in the back technique! (" + ((int)(0.2 * player.Precision)) + " incised damage, " + ((int)(0.3 * player.Strength) + (int)(0.3 * player.Precision)) + " stab damage)";
            return new List<StatPackage>() { response1, response2 };
        }
    }
}
