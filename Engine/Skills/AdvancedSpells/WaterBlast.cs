using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills
{
    [Serializable]
    class WaterBlast :Skill
    {
        public WaterBlast() : base("Water Blast", 25, 3)
        {
            PublicName = "Water Blast: a 70% chance to land 0.5*MP damage [water]";
            RequiredItem = Skill.MainItem.staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            int damage = (int)(0.5 * player.MagicPower);
            StatPackage response = new StatPackage("water");
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
            return new List<StatPackage>() { response };
        }
    }
}
