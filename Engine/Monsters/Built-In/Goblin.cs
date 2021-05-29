using System;
using System.Collections.Generic;

namespace Game.Engine.Monsters
{
    public class Goblin : Monster
    {
        protected IStrategist strategy;
        protected List<IStrategist> strategies = new List<IStrategist>()
        {
            new GoblinAggressive(),
            new GoblinDefensive(),
            new GoblinMixed()
        };
        public Goblin()
        {
            Health = 100;
            Strength = 30;
            Armor = 40;
            Precision = 50;
            Stamina = 100;
            XPValue = 15;
            Name = "sample"; // TODO: Choose picture
            BattleGreetings = "Uk skoon gutora garkot!";
        }

        public override List<StatPackage> BattleMove()
        {
            return strategy.BattleStrategy(this);
        }

        public override List<StatPackage> React(List<StatPackage> packs)
        {
            int health_dmg = 0;
            List<StatPackage> ans = new List<StatPackage>();
            foreach (StatPackage pack in packs)
            {
                Health -= pack.HealthDmg;
                health_dmg += pack.HealthDmg;
                Strength -= pack.StrengthDmg;
                Armor -= pack.ArmorDmg;
                Precision -= pack.PrecisionDmg;
                MagicPower -= pack.MagicPowerDmg;
                ans.Add(pack); 
            }

            if (Health - health_dmg <= 0.25 * Health)
            {
                strategy = strategies[1];
            }
            else if (Health - health_dmg > 0.25 * Health && Health - health_dmg <= 0.5 * Health)
            {
                strategy = strategies[2];
            }
            else
            {
                strategy = strategies[0];
            }
            return ans;
        }
    }

    public class GoblinAggressive : IStrategist
    {
        public List<StatPackage> BattleStrategy(Monster monster)
        {
            monster.Armor -= 10;
            if (monster.Stamina > 0)
            {
                monster.Stamina -= 20;
                int chance = Index.RNG(0, 10);
                switch (chance)
                {
                    case 0:
                        return new List<StatPackage>()
                        {
                            new StatPackage(DmgType.Physical, 50 + monster.Strength,
                                "Goblin Grineer jest wyjatkowo zdenerwowany, wiec uzywa calej swojej sily(" + (50 + monster.Strength) +
                                " dmg [Physical])")
                        };
                    case 1:
                        return new List<StatPackage>()
                        {
                            new StatPackage(DmgType.Physical, 25 + monster.Strength,
                                "Goblin Grineer jest najedzony i wypoczety, wiec uderza z ogromna sila (" + (25 + monster.Strength) +
                                " dmg [Physical])")
                        };
                    case 5:
                        return new List<StatPackage>()
                        {
                            new StatPackage(DmgType.Physical, 10 + monster.Strength,
                                "Goblin Grineer atakuje! (" + (10 + monster.Strength) +
                                " dmg [Physical])")
                        };
                    case 10:
                        return new List<StatPackage>()
                        {
                            new StatPackage(DmgType.Physical, Math.Abs(monster.Strength - 20),
                                "Goblin Grineer potyka sie i rozwala se gupi ryj (" +
                                Math.Abs(monster.Strength - 20) + " dmg [Physical])")
                        };
                    default:
                        return new List<StatPackage>()
                        {
                            new StatPackage(DmgType.Physical, 5 + monster.Strength,
                                "Goblin Grineer atakuje! (" +
                                (5 + monster.Strength) + " dmg [Physical])")
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
    }

    public class GoblinDefensive : IStrategist
    {
        public List<StatPackage> BattleStrategy(Monster monster)
        {
            monster.Armor += 30;
            monster.Health += 5;
            if (monster.Stamina > 0)
            {
                monster.Stamina -= 5;
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
    }

    public class GoblinMixed : IStrategist
    {
        public List<StatPackage> BattleStrategy(Monster monster)
        {
            monster.Armor += 15;
            if (monster.Stamina > 0)
            {
                monster.Stamina -= 10;
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.Physical, monster.Strength, "Goblin Grineer wzmocnil swoja obrone i wykonuje sredni atak (" + monster.Strength + " dmg [Physical]")
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
    }
}