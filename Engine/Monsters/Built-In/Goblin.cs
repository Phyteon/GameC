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

        private Strategies strategy = Strategies.Defensive;

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
            if (Stamina > 0)
            {
                Stamina -= 5;
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.Physical, 5, "Goblin Grineer wzmocnil swoja obrone i wykonuje tylko slaby atak (" + 5 + " dmg [Physical]")
                };
            }
            else
            {
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.Physical, 0, "Goblin Grineer probuje sie bronic ale juz mu brakuje sil")
                };
            }
        }

        public List<StatPackage> Mixed() // TODO: Make sure that each turn also value required to move is checked
        {
            if (Stamina > 0)
            {
                Stamina -= 10;
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.Physical, Strength, "Goblin Grineer wzmocnil swoja obrone i wykonuje sredni atak (" + Strength + " dmg [Physical]")
                };
            }
            else
            {
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.Physical, 0, "Goblin Grineer zmeczyl sie obrona i atakiem, musi odpoczac")
                };
            }
        }

        public void ChooseStrategy(List<StatPackage> pkg)
        {
            var dmg = 0;
            foreach (var pack in pkg)
            {
                dmg += pack.HealthDmg;
            }

            if (Health - dmg <= 0.25 * Health)
            {
                strategy = Strategies.Defensive;
            }
            else if (0.45 * Health <= Health - dmg && Health - dmg <= 0.5 * Health)
            {
                strategy = Strategies.Mixed;
            }
            else
            {
                strategy = Strategies.Aggressive;
            }
        }

        public override List<StatPackage> React(List<StatPackage> packs)
        {
            return base.React(packs);
        }
    }
}