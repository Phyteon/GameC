using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class ButterflyEvolved:Monster
    {

        public ButterflyEvolved(int butterflyLevel)
        {
            Health = 30 + 5 * butterflyLevel;
            Strength = 15 + 2 * butterflyLevel;
            Armor = 0;
            Precision = 10;
            MagicPower = 10;
            Stamina = 25;
            XPValue = 35 + butterflyLevel;
            Name = "monster0863";
            BattleGreetings = "You heartless creature! You smashed me into a wet pile of goo. But I will not give up! Ha! I can poison you now!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 12;
                return new List<StatPackage>()
                { 
                    //inne battle move niż w Butterfly
                    new StatPackage(DmgType.water, 6 + Strength, " Evolved Butterfly uses its body to slow your actions and weaken you! (" + (6 + Strength) + " magical damage)"),
                    new StatPackage(DmgType.poison, 25, "Red like lava, venom burns in your veins (25 poison damage)")
                };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.none, 0, "Butterfly is defeated completely. It's harmless to you") };
            }
            
        }
    }
}
