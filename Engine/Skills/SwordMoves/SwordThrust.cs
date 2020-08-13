using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.UpgradedWeaponMoves
{
    [Serializable]
    class SwordThrust:Skill
    {
        public SwordThrust() : base("Sword Thrust", 25, 2)
        {
            PublicName = "Sword Thrust [requires sword]: 0.1*Str + 0.3*Pr damage [stab]";
            RequiredItem = Skill.MainItem.sword;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
        StatPackage response1 = new StatPackage(DmgType.stab);
        response1.HealthDmg = (int)(0.1 * player.Strength) + (int)(0.3 * player.Precision);
        response1.CustomText = "You use Sword Thrust! (" + ((int)(0.1 * player.Strength) + (int)(0.3 * player.Precision)) + ") stab damage";
        return new List<StatPackage>() { response1 };
        }
    }
}