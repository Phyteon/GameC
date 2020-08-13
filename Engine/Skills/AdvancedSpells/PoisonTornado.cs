using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills
{
    [Serializable]
    class PoisonTornado : Skill
    {
        public PoisonTornado() : base("Poison Tornado", 20, 2)
        {
            PublicName = "Poison tornado: 0.1*MP + 0.1*PR damage [poison]";
            RequiredItem = Skill.MainItem.staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            int damage = (int)(0.1 * player.MagicPower) + (int)(0.1 * player.Precision);
            StatPackage response = new StatPackage(DmgType.poison);
            response.HealthDmg = damage;
            response.CustomText = "You use Poison Tornado! (" + damage + " poison damage)";
            return new List<StatPackage>() { response };
        }
    }
}
