using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.OsirisMoves
{
    [Serializable]
    class NileSplash : Skill
    {
        public NileSplash() : base("Nile Spash", 10, 1)
        {
            PublicName = "Nile Water Splash [requires staff]: 5 + 0.5*MP damage [water]";
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Water);
            response.HealthDmg = 10 + (int)(0.5 * player.MagicPower);
            response.CustomText = "Bless Osisris! You used Nile Water Splash! (" + (5 + (int)(0.5 * player.MagicPower)) + "water damage)";
            return new List<StatPackage>() { response };
        }
    }
}
