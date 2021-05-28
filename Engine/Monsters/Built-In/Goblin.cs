using System;
using System.Collections.Generic;

namespace Game.Engine.Monsters
{
    public class Goblin : Monster, IStrategist
    {
        public Goblin()
        {
            Health = 100;
            Strength = 30;
            Armor = 40;
            Precision = 50;
            Stamina = 100;
            XPValue = 15;
            Name = "Goblin Grineer";
            BattleGreetings = "Uk skoon gutora garkot!";
        }

        protected int strategy = 0;

        public override List<StatPackage> BattleMove()
        {
            throw new System.NotImplementedException();
        }

        public List<StatPackage> Aggressive()
        {
            if (Stamina > 0)
            {
                Stamina -= 20;
                int chance = Index.RNG(0, 10);
                switch (chance)
                {
                    case 0:
                        return new List<StatPackage>()
                        {
                            new StatPackage(DmgType.Physical, 50 + Strength,
                                "Goblin Grineer jest wyjatkowo zdenerwowany, wiec uzywa calej swojej sily(" + (50 + Strength) +
                                " dmg [Physical])")
                        };
                    case 1:
                        return new List<StatPackage>()
                        {
                            new StatPackage(DmgType.Physical, 25 + Strength,
                                "Goblin Grineer jest najedzony i wypoczety, wiec uderza z ogromna sila (" + (25 + Strength) +
                                " dmg [Physical])")
                        };
                    case 5:
                        return new List<StatPackage>()
                        {
                            new StatPackage(DmgType.Physical, 10 + Strength,
                                "Goblin Grineer atakuje! (" + (10 + Strength) +
                                " dmg [Physical])")
                        };
                    case 10:
                        return new List<StatPackage>()
                        {
                            new StatPackage(DmgType.Physical, Math.Abs(Strength - 20),
                                "Goblin Grineer potyka sie i rozwala se gupi ryj (" +
                                Math.Abs(Strength - 20) + " dmg [Physical])")
                        };
                    default:
                        return new List<StatPackage>()
                        {
                            new StatPackage(DmgType.Physical, 5 + Strength,
                                "Goblin Grineer atakuje! (" +
                                (5 + Strength) + " dmg [Physical])")
                        };

                }
            }
            else
            {
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.Physical, 0, "Goblin Grineer sie zmeczyl i musi sobie zjesc makowca")
                };
            }
        }

        public List<StatPackage> Defensive()
        {
            throw new System.NotImplementedException();
        }

        public List<StatPackage> Mixed()
        {
            throw new System.NotImplementedException();
        }

        public void ChooseStrategy()
        {
            throw new System.NotImplementedException();
        }
    }
}