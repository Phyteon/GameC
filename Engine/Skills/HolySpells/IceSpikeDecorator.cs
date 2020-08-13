using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.HolySpells
{
    [Serializable]
    class IceSpikeDecorator : SkillDecorator
    {
        public IceSpikeDecorator(Skill skill) : base("Prayer", 35, 2, skill)
        {
            MinimumLevel = 4;
            PublicName = "COMBO - Ice Spike: 33% chance of attacking for 200% value of your magic power (water damage) AND" + decoratedSkill.PublicName.Replace("COMBO: ", ""); 
        }
        public override List<StatPackage> BattleMove(Engine.CharacterClasses.Player player)
        {
            int randomNumber = Index.RNG(0, 3);
            StatPackage response = new StatPackage(DmgType.water);
            if (randomNumber == 0)
            {
                response.HealthDmg = 2 * player.MagicPower;
                response.CustomText = "You use Ice Spike! (" + 2 * player.MagicPower + ") water  damage. "; 
            }
            else
            {
                response.DamageType = DmgType.none;
                response.CustomText = "You use Ice Spike, but you miss!";
            }
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
