using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.UpgradedWeaponMoves
{
    [Serializable]
    class DoubleSlashDecorator:SkillDecorator
    { 
        public DoubleSlashDecorator(Skill skill) : base("Double Slash", 20, 2, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 2;
            PublicName = "double basic sword slash [requires sword]: 0.2*Str + 0.2*Pr damage [stab] and 0.2*Str + 0.2*Pr damage [incised]";
            RequiredItem = Skill.MainItem.sword;
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response1 = new StatPackage("stab");
            response1.HealthDmg = (int)(0.1 * player.Strength) + (int)(0.1 * player.Precision);
            StatPackage response2 = new StatPackage("incised");
            response2.HealthDmg = (int)(0.1 * player.Strength) + (int)(0.1 * player.Precision);

            StatPackage response3 = new StatPackage("stab");
            response3.HealthDmg = (int)(0.1 * player.Strength) + (int)(0.1 * player.Precision);
            StatPackage response4 = new StatPackage("incised");
            response4.HealthDmg = (int)(0.1 * player.Strength) + (int)(0.1 * player.Precision);

            response1.CustomText = "You use Double Sword Slash! (" + ((int)(0.2 * player.Strength) + (int)(0.2 * player.Precision)) + " stab damage, " + ((int)(0.2 * player.Strength) + (int)(0.2 * player.Precision)) + " incised damage)";
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response1);
            combo.Add(response2);
            combo.Add(response3);
            combo.Add(response4);
            return combo;
        }
    }
}
