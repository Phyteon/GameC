using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.SimpleSkills
{
    [Serializable]
    class HealingFactor:Skill
    {
        public HealingFactor():base("Healing Factor", 20, 2)
        {
            MinimumLevel = 2;
            PublicName = "Healing factor: adds 30 health";
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.none);
            player.Health += 30;
            response.CustomText = "You use Healing Factor! (30 health added)";
            return new List<StatPackage>() { response };
        }
    }
}
