using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.SimpleSkills
{
    [Serializable]
    class StoneThrow:Skill
    {
        public StoneThrow() : base("Stone Throw", 20, 2)
        {
            MinimumLevel = 2;
            PublicName = "Stone Throw: you pick up a stone which appears to be magic and throw it(50% + Precision stat chance) 0.5*Str";
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Earth);
            Random rnd = new Random();
            if (rnd.Next(0, 100) < player.Precision+50)
            {
                response.HealthDmg = (int)(0.5 * player.Strength);
                response.CustomText = "You use Stone Throw! (" + (int)(0.5 * player.Strength) + " earth damage)";
            }
            else
            {
                response.HealthDmg = 0;
                response.CustomText = "You try to throw a stone, but it misses!";
            }
            return new List<StatPackage>() { response };
        }
    }
}
