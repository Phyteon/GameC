using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.HolySpells
{
    [Serializable]
    class IceSpike : Skill
    {
        // Shooting an ice spike - 1/3 chance for critical hit
        public IceSpike() : base("IceSpike", 35, 2)
        {
            PublicName = "Ice Spike: 33% chance of attacking for 200% value of your magic power (water damage)";
  
        }
        public override List<StatPackage> BattleMove(Engine.CharacterClasses.Player player)
        {
            int randomNumber = Index.RNG(0, 3);
            StatPackage response = new StatPackage(DmgType.Water);
            if (randomNumber == 0)
            {
                response.HealthDmg = 2 * player.MagicPower;
                response.CustomText = "You use Ice Spike! (" + 2 * player.MagicPower + ") water  damage. ";
            }
            else
            {
                response.DamageType = DmgType.Other;
                response.CustomText = "You use Ice Spike, but you miss!";
            }
        return new List<StatPackage> { response };
        }
    }
}
