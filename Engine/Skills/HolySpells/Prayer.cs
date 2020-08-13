using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.HolySpells
{
    [Serializable]
    class Prayer : Skill
    {
        // One statisticis chosen randomly from : Strenght, precision and magic power and you attack for 150% of its value 
        public Prayer() : base("Prayer", 25, 5)
        {
            PublicName = "Prayer: One attribute chosen randomly from : Strength, Precision and Magic power and you attack for 150% of its value ";
            
        }
        public override List<StatPackage> BattleMove(Engine.CharacterClasses.Player player)
        {
            StatPackage response = new StatPackage(DmgType.none);
            int randomNumber = Index.RNG(0, 3);
            if (randomNumber == 0)//Base Magic
            {
                response.DamageType = DmgType.fire;
                response.HealthDmg = (int)(player.MagicPower * 1.5);
                response.CustomText = "You use Prayer. Base attribute: Magic Power. You attack for (" + (int)(1.5 * player.MagicPower) + " fire damage)";
            }
            else if (randomNumber == 1)//base Precision
            {
                response.DamageType = DmgType.stab;
                response.HealthDmg = (int)(player.Precision * 1.5);
                response.CustomText = "You use Prayer. Base attribute: Precision. You attack for (" + (int)(1.5 * player.Precision) + " stab damage)";
            }
            else//base Strength
            {
                response.DamageType = DmgType.cut;
                response.HealthDmg = (int)(player.Strength * 1.5);
                response.CustomText = "You use Prayer. Base attribute: Strength. You attack for (" + (int)(1.5 * player.Strength) + " incised damage)";
            }
            return new List<StatPackage>() { response };
        }
    }
}

