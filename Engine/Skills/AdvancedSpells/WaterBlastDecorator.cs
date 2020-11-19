using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills
{
    [Serializable]
    class WaterBlastDecorator : SkillDecorator
    {
        public WaterBlastDecorator(Skill skill) : base("Water Blast", 25, 3, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = "COMBO - Water blast: a 70% chance to land 0.5*MP damage [water] AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = Skill.MainItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            int damage = (int)(0.5 * player.MagicPower);
            StatPackage response = new StatPackage(DmgType.Water);
            Random rnd = new Random();
            if (rnd.Next(0, 100) < 70)
            {
                response.HealthDmg = damage;
                response.CustomText = "You use Water Blast! (" + damage + " water damage)";
            }
            else
            {
                response.HealthDmg = 0;
                response.CustomText = "You try to use Water Blast but it misses!";
            }
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
