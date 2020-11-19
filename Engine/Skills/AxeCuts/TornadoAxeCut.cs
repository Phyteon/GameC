using System;
using Game.Engine.CharacterClasses;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.SkillWeaponMoves
{
    [Serializable]
    class TornadoAxeCut : Skill
    {
        public TornadoAxeCut() : base("Tornado Axe Cut", 50, 4)
        {
            PublicName = "Tornado Axe Cut: a chance equal to your Precission stat to make 3 times bigger damage";
            RequiredItem = Skill.MainItem.Axe;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Cut);
            Random rnd = new Random();
            if (rnd.Next(0, 100) < player.Precision)
            {
                response.HealthDmg = (int)(3 * player.Strength);
                response.CustomText = "You use Tornado Axe Cut! (" + (int)(3 * player.Strength) + " cut damage)";
            }
            else
            {
                response.HealthDmg = 0;
                response.CustomText = "You try to use Tornado Axe Cut but you miss!";
            }
            return new List<StatPackage>() { response };
        }
    }
}
