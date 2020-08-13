using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.SkillWeaponMoves
{
    [Serializable]
    class DoubleAxeCut : Skill
    {
        public DoubleAxeCut() : base("Double Axe Cut", 30, 3)
        {
            PublicName = "Double Axe Cut: a chance equal to your Precission stat to make two times bigger damage";
            RequiredItem = Skill.MainItem.axe;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.cut);
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
            return new List<StatPackage>() { response };
        }
    }
}
