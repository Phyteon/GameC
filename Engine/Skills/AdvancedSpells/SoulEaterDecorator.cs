using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills
{   
    [Serializable]
    class SoulEaterDecorator :SkillDecorator
    {
        public SoulEaterDecorator(Skill skill) : base("Soul Eater", 30, 5, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = "COMBO - Soul Eater: 0.4*MP fire damage gives you 0.1*MP health points during battle AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = Skill.MainItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Fire);
            response.HealthDmg = (int)(0.4 * player.MagicPower);
            player.Health += (int)(0.1 * player.MagicPower);
            response.CustomText = "You use Soul Eater! (" + ((int)(0.4 * player.MagicPower)) + " fire damage)\nYou've gained " + ((int)(0.1 * player.MagicPower)) + " health points";
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
