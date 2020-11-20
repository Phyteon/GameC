using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.UpgradedWeaponMoves
{
    [Serializable]
    class SwordThrustDecorator:SkillDecorator
    {
        public SwordThrustDecorator(Skill skill) : base("Enchanted Slash", 25, 2, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 2;
            PublicName = "Sword Thrust [requires sword]: 0.1*Str + 0.3*Pr damage [cut]";
            RequiredItem = RequiredItem.Sword;
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response1 = new StatPackage(DmgType.Cut);
            response1.HealthDmg = (int)(0.1 * player.Strength) + (int)(0.3 * player.Precision);
            response1.CustomText = "You use Sword Thrust! (" + ((int)(0.1 * player.Strength) + (int)(0.3 * player.Precision)) + ") cut damage";
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response1);
            return combo;
        }
    }
}