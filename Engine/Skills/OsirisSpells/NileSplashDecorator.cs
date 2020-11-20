using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.OsirisMoves
{
    [Serializable]
    class NileSplashDecorator : SkillDecorator
    {
        public NileSplashDecorator(Skill skill) : base("Nile Splash", 10, 1, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = " COMBO - Nile Splash: 5 + 0.5*MP damage [water] AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Water);
            response.HealthDmg = 5 + (int)(0.5 * player.MagicPower);
            response.CustomText = "Bless Osisris! You used Nile Water Splash! (" + (5 + (int)(0.5 * player.MagicPower)) + "water damage)";
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
