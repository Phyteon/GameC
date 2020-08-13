using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.OsirisMoves
{
    [Serializable]
    class OsirisCurse : Skill
    {
        public OsirisCurse() : base("Osiris Curse", 20, 2)
        {
            PublicName = "Osiris Curse [requires staff]: 0.2*Str + 0.2*MagPwr damage [poison] + random god`s help [fire + armor damage, water + precision damage, earth + strength damage, air + magic power damage]";
            RequiredItem = Skill.MainItem.staff;
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response1 = new StatPackage(DmgType.poison);
            response1.HealthDmg = (int)(0.2 * player.Strength) + (int)(0.2 * player.MagicPower) + 20;

            int godHelp = Index.RNG(1, 5);
            StatPackage response2;

            if (godHelp == 1)
            {
                response2 = new StatPackage(DmgType.fire);
                response2.ArmorDmg = 15;
                response2.CustomText = "You use Osiris Curse! (" + ((int)(0.2 * player.Strength) + (int)(0.2 * player.MagicPower)) + " poison damage, " + "\n" + " God Raa helped you! [enemy armor decreased by 15] " ;
                return new List<StatPackage>() { response1, response2 };
            }
            else if (godHelp == 2)
            {
                response2 = new StatPackage(DmgType.water);
                response2.PrecisionDmg = 15;
                response2.CustomText = "You use Osiris Curse (" + ((int)(0.2 * player.Strength) + (int)(0.2 * player.MagicPower)) + " poison damage, " + "\n" + " God Sobek helped you! [enemy precision decreased by 15] ";
                return new List<StatPackage>() { response1, response2 };
            }
            else if (godHelp == 3)
            {
                response2 = new StatPackage(DmgType.earth);
                response2.StrengthDmg = 15;
                response2.CustomText = "You use Osiris Curse (" + ((int)(0.2 * player.Strength) + (int)(0.2 * player.MagicPower)) + " poison damage, " + "\n" + " God Geb helped you! [enemy strength decreased by 15] ";
                return new List<StatPackage>() { response1, response2 };
            }
            else
            {
                response2 = new StatPackage(DmgType.air);
                response2.MagicPowerDmg = 15;
                response2.CustomText = "You use Osiris Curse (" + ((int)(0.2 * player.Strength) + (int)(0.2 * player.MagicPower)) + " poison damage, " + "\n" + " God Amon helped you! [enemy magic power decreased by 15] ";
                return new List<StatPackage>() { response1, response2 };
            }
            
        }
    }
}
