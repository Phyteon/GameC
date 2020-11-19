using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.SimpleSkills
{
    [Serializable]
    class VerbalAbuse:Skill
    {
        public VerbalAbuse() : base("Verbal Abuse", 30, 2)
        {
            MinimumLevel = 2;
            PublicName = "Verbal Abuse: You use very bad language to abuse your oponent[air] 5*level damage for Strength, Precision, Magic Power";
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Air);
            response.StrengthDmg = player.Level * 5;
            response.PrecisionDmg = player.Level * 5;
            response.MagicPowerDmg = player.Level * 5;
            response.CustomText = "You use Verbal Abuse! (enemy Strenght, Precision and Magic Power decreased by " + player.Level * 5 ;
            return new List<StatPackage>() { response };
        }
    }
}
