using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.HolySpells
{
    [Serializable]
    class PrayerDecorator : SkillDecorator
    {
        public PrayerDecorator(Skill skill) : base("Prayer", 20, 1, skill)
        {
            MinimumLevel = 4;
            PublicName = "COMBO - Prayer: One attribute chosen randomly from : Strenght, Precision and Magic power and you attack for 150% of its value AND" + decoratedSkill.PublicName.Replace("COMBO: ", "");
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
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
