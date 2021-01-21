using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.AxeMoves
{
    [Serializable]
    class HorrifyingCharge : Skill
    {
        public HorrifyingCharge() : base("Horrifying Charge", 50, 2)
        {
            PublicName = "Horrifying Charge [requires axe]: 0.6*Str (+ bonus dmg under 40HP) damage [incised] and decrease enemy precision stat by 25";
            RequiredItem = RequiredItem.Axe;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response1 = new StatPackage(DmgType.Cut);
            StatPackage response2 = new StatPackage(DmgType.Cut);
            if (player.Health < 40)
            {
                response1.HealthDmg = (int)(0.6 * player.Strength) + (int)(3*(100-player.Health)*0.1);
                response2.PrecisionDmg = 25;
                response2.CustomText = "You use Horrifying Charge with bonus damage! (" + ((int)(0.6 * player.Strength) + (int)(3 * (100 - player.Health) * 0.1)) + " incised damage)";
            }
            else
            {
                response1.HealthDmg = (int)(0.6 * player.Strength);
                response2.PrecisionDmg = 25;
                response2.CustomText = "You use Horrifying Charge! (" + (int)(0.6 * player.Strength) + " incised damage)";
            }
            return new List<StatPackage>() { response1, response2 };
        }
    }
}
