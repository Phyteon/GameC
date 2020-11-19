using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.AdvancedWeaponTechniques
{
    [Serializable]
    class SpearThrow : Skill
    {
        public SpearThrow() : base("Spear Throw", 15, 1)
        {
            PublicName = "Spear throw [requires spear]: 0.5*Pr damage [cut]";
            RequiredItem = Skill.MainItem.Spear;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Cut);
            response.HealthDmg = (int)(0.5 * player.Precision);
            response.CustomText = "You use Spear Throw! (" + (int)(0.5 * player.Precision) + " cut damage)";
            return new List<StatPackage>() { response };
        }
    }
}
