using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class IceDragon: Monster
    {
        public IceDragon(int dragonLevel)
        {
            Health = 200 + 5 * dragonLevel;
            Strength = 200 + dragonLevel;
            Armor = 0;
            Precision = 50;
            MagicPower = 300;
            Stamina = 200;
            XPValue = 100 + dragonLevel;
            Name = "monster0483";
            BattleGreetings = "I catched from an Ice Egg! Now you have to fight with me!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 10;
                //  
                return new List<StatPackage>()
                {
                  new StatPackage(DmgType.Water, 5 + Strength, "Dragon uses ice magic! (" + (Strength) + " magical damage)")
                };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Dragon has no energy to attack anymore!") };
            }
        }
    }
}
