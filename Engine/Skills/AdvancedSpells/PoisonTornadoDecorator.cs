using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills
{
    [Serializable]
    class PoisonTornadoDecorator : SkillDecorator
    {
        public PoisonTornadoDecorator(Skill skill) : base("Poison Tornado", 20, 2, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = "COMBO - PoisonTornado: 0.1*MP + 0.1*PR damage [poison] AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = Skill.MainItem.staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            int damage = (int)(0.1 * player.MagicPower) + (int)(0.1 * player.Precision);
            StatPackage response = new StatPackage("poison");
            response.HealthDmg = damage;
            response.CustomText = "You use Poison Tornado! (" + damage + " poison damage)";
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
