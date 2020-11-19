using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.AdvancedWeaponTechniques
{
    [Serializable]
    class Whirl : Skill
    {
        public Whirl() : base("Whirl", 50, 4)
        {
            PublicName = "Spear-whirl [requires spear]: 0.3*Str + 0.4*Pr damage [cut]";
            RequiredItem = Skill.MainItem.Spear;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Cut);
            response.HealthDmg = (int)(0.3 * player.Strength) + (int)(0.4 * player.Precision);
            response.CustomText = "You whirl your spear around! (" + ((int)(0.3 * player.Strength) +(int)(0.4 * player.Precision)) + " cut damage)";
            return new List<StatPackage>() { response };
        }
    }
}
