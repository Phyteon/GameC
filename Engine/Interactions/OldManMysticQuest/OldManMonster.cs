using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.OldManMysticQuest
{
    class OldManMonster : Monsters.Monster
    {
        public OldManMonster(int oldManLevel)
        {
            Health = 200 + 5 * oldManLevel;
            Strength = 200 + 2 * oldManLevel;
            Armor = 30;
            Precision = 50;
            MagicPower = 200;
            Stamina = 150;
            XPValue = 200 + oldManLevel;
            Name = "monster0345";
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
                        new StatPackage(DmgType.Air, Strength - 30, "Old Man uses Forced Wind Gust! (" + (Strength - 30) + " air damage)"),
                        
                    };
                }
                else if (random.NextDouble() > 0.4 && random.NextDouble() <= 0.8)
                {
                    Stamina -= 10;
                    return new List<StatPackage>() { new StatPackage(DmgType.Cut, Strength - 50, "Old Man stab you with his staff! (" + (Strength - 50) + " cut damage)") };
                }
                else
                {
                    Stamina -= 20;
                    return new List<StatPackage>()
                    {
                        new StatPackage(DmgType.Fire, Strength , "Old Man uses Fire Strike! (" + (Strength) + " fire damage)"),
                        
                    };
                }
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Old Man has no energy to attack anymore!") };
            }
        }
    }
}
