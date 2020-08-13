using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.OldManMysticQuest
{
    class RagedOldManMonster : Monsters.Monster
    {
        public RagedOldManMonster(int oldManLevel)
        {
            Health = 220 + 5 * oldManLevel;
            Strength = 220 + 2 * oldManLevel;
            Armor = 35;
            Precision = 60;
            MagicPower = 200;
            Stamina = 200;
            XPValue = 200 + oldManLevel;
            Name = "monster0346";
            BattleGreetings = null;
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Random random = new Random();
                if (random.NextDouble() <= 0.4)
                {
                    Stamina -= 10;
                    return new List<StatPackage>()
                    {
                        new StatPackage(DmgType.air, Strength - 20, "Raged Old Man uses Forced Wind Gust! (" + (Strength - 20) + " air damage)"),

                    };
                }
                else if (random.NextDouble() > 0.4 && random.NextDouble() <= 0.8)
                {
                    Stamina -= 10;
                    return new List<StatPackage>() { new StatPackage(DmgType.stab, Strength - 35, "Raged Old Man stab you with his staff! (" + (Strength - 35) + " stab damage)") };
                }
                else
                {
                    Stamina -= 20;
                    return new List<StatPackage>()
                    {
                        new StatPackage(DmgType.fire, Strength + 10 , "Raged Old Man uses Fire Strike! (" + (Strength + 10) + " fire damage)"),

                    };
                }
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.none, 0, "Raged Old Man has no energy to attack anymore!") };
            }
        }
    }
}
