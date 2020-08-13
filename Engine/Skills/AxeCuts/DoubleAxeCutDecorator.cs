using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.SkillWeaponMoves
{
    [Serializable]
    class DoubleAxeCutDecorator : SkillDecorator
    {
        public DoubleAxeCutDecorator(Skill skill) : base("Double Axe Cut", 30, 3, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = "COMBO - Double Axe Cut: a chance equal to your Precission stat to make two times bigger damage AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = Skill.MainItem.axe;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("cut");
            Random rnd = new Random();
            if (rnd.Next(0, 100) < player.Precision)
            {
                response.HealthDmg = (int)(2 * player.Strength);
                response.CustomText = "You use Double Axe Cut! (" + (int)(2 * player.Strength) + " stab damage)";
            }
            else
            {
                response.HealthDmg = 0;
                response.CustomText = "You try to use Double Axe Cut but you miss!";
            }
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
