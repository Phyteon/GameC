using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.SkillWeaponMoves
{
    [Serializable]
    class JumpAxeCutDecorator : SkillDecorator
    {
        public JumpAxeCutDecorator(Skill skill) : base("Jump Axe Cut", 20, 2, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = "COMBO - Jump Axe Cut: a chance equal to your Precission stat to make 1,5 times bigger damage AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = Skill.MainItem.axe;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.cut);
            Random rnd = new Random();
            if (rnd.Next(0, 100) < player.Precision)
            {
                response.HealthDmg = (int)(1.5 * player.Strength);
                response.CustomText = "You use Jump Axe Cut! (" + (int)(1.5 * player.Strength) + " stab damage)";
            }
            else
            {
                response.HealthDmg = 0;
                response.CustomText = "You try to use Jump Axe Cut but you miss!";
            }
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
