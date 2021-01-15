using System;
using System.Collections.Generic;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class TrollEvolved : Monster
    {
        public TrollEvolved()
        {
            Health = 120;
            Strength = 30;
            Armor = 0;
            Precision = 10;
            MagicPower = 0;
            Stamina = 200;
            XPValue = 150;
            Name = "monster1341";
            BattleGreetings = "I am stronger now! You don't have enough power to kill me!!! He He He!";
        }
        public override void React(List<StatPackage> packs)
        {
            Stamina += 15;
            base.React(packs);
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                int combo = Index.RNG(0, 7);
                if (combo == 0)
                {
                    Health = 0;
                    Stamina -= 300;
                    return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "You won a lottery, so I will die:( ! ") };
                }
                else if (combo > 0 && combo < 6)
                {
                    if (Stamina > 100)
                    {
                        Stamina -= 100;
                        return new List<StatPackage>() { new StatPackage(DmgType.Crush, 15, "I'm crushing you" + (15) + " crush damage)") };

                    }
                    else if (Stamina < 100 && Stamina > 20)
                    {
                        Stamina -= 40;
                        return new List<StatPackage>() { new StatPackage(DmgType.Crush, 5, "Ooo!!! I'm crushing you" + (5) + " crush damage)") };

                    }
                    else
                    {
                        Stamina -= 10;
                        return new List<StatPackage>() { new StatPackage(DmgType.Crush, 1, "I'm crushing you! (" + (1) + " crush damage)") };
                    }
                }
                else
                {
                    return new List<StatPackage>() { new StatPackage(DmgType.Crush, 20, 10, 0, 5, 0, "It's a combo attack!!!") };
                }
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "The troll has died") };
            }
        }
    }
}