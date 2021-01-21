using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.AxeMoves
{
    [Serializable]
    class BloodyCutDecorator : SkillDecorator
    {
        public BloodyCutDecorator(Skill skill) : base("Bloody Cut", 30, 5, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = "COMBO - Bloody cut [requires axe]: 0.5*Str damage [incised] and if your health is under 65, restores 50%*damage as a health points AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = RequiredItem.Axe;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Cut);
            response.HealthDmg = (int)(0.5 * player.Strength);
            if (player.Health < 65)
            {
                player.Health += (int)(0.25 * player.Strength);
                response.CustomText = "You use Bloody Cut! (" + (int)(0.5 * player.Strength) + " incised damage)\n" + (int)(0.25 * player.Strength) + " health points restored";
            }
            response.CustomText = "You use Bloody Cut! (" + (int)(0.5 * player.Strength) + " incised damage)";
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
