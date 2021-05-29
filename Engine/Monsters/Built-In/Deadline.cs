using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Game.Engine.Monsters
{
    [Serializable]
    public class Deadline : Monster
    {
        protected IStrategist strategy;

        protected List<IStrategist> strategies = new List<IStrategist>()
        {
            
        };
        public Deadline()
        {
            Health = 30;
            Strength = 50;
            Armor = 100;
            Precision = 50;
            Stamina = 100;
            XPValue = 50;
            Name = "deadline";
            BattleGreetings = "Zawsze jestem blizej niz ci sie wydaje...";
        }
        
        public Deadline(int health, int strength, int armor, int precision, int stamina, int xpval)
        {
            Health = health;
            Strength = strength;
            Armor = armor;
            Precision = precision;
            Stamina = stamina;
            XPValue = xpval;
            Name = "deadline";
            BattleGreetings = "Zawsze jestem blizej niz ci sie wydaje...";
        }

        
        // TODO: Add override of the react function
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

    public class DeadlineAggressive : IStrategist
    {
        public List<StatPackage> BattleStrategy(Monster monster)
        {
            if (monster.Stamina > 0)
            {
                monster.Stamina -= 1; // Deadline is a very tough and resilient opponent...
                int chance = Index.RNG(0, 11);
                switch (chance)
                {
                    case 0:
                        return new List<StatPackage>()
                        {
                            new StatPackage(DmgType.Psycho, 50 + monster.Strength,
                                "Deadline zastosowal podroz w czasie i jest na wczoraj (" + (50 + monster.Strength) +
                                " dmg [Psycho])")
                        };
                    case 1:
                        return new List<StatPackage>()
                        {
                            new StatPackage(DmgType.Psycho, 25 + monster.Strength,
                                "Deadline sie zaktualizowal i dodal do siebie nowe wymagania (" + (25 + monster.Strength) +
                                " dmg [Psycho])")
                        };
                    case 5:
                        return new List<StatPackage>()
                        {
                            new StatPackage(DmgType.Psycho, 10 + monster.Strength,
                                "Deadline groznie sie na ciebie patrzy i przyprawia cie o ciarki (" + (10 + monster.Strength) +
                                " dmg [Psycho])")
                        };
                    case 10:
                        return new List<StatPackage>()
                        {
                            new StatPackage(DmgType.Psycho, Math.Abs(monster.Strength - 20),
                                "Deadline przeniosl sie w czasie ale pomylil sobie kierunek i przenosi sie na za miesiac (" +
                                (25 + monster.Strength) + " dmg [Psycho])")
                        };
                    default:
                        return new List<StatPackage>()
                        {
                            new StatPackage(DmgType.Psycho, 5 + monster.Strength,
                                "Deadline teleportuje sie za ciebie i wbija ci pinezke ze swoim terminem w plecy (" +
                                (25 + monster.Strength) + " dmg [Psycho])")
                        };
                }
            }
            else
            {
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.Psycho, 0, "Deadline sie zmeczyl nekaniem cie i musi odpoczac")
                };
            }
        }
    }

    public class DeadlineDefensive : IStrategist
    {
        public List<StatPackage> BattleStrategy(Monster monster)
        {
            monster.Armor += 10;
            monster.Health += 10;
            if (monster.Stamina > 0)
            {
                monster.Stamina -= 5;
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.Psycho, 10, "Deadline wzmocnil swoja obrone i wykonuje tylko slaby atak (" + 10 + " dmg [Psycho]")
                };
            }
            else
            {
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.Physical, 0, "Deadline probuje sie bronic ale juz mu brakuje sil")
                };
            }
        }
    }

    public class DeadlineMixed : IStrategist
    {
        public List<StatPackage> BattleStrategy(Monster monster)
        {
            monster.Armor += 15;
            if (monster.Stamina > 0)
            {
                monster.Stamina -= 10;
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.Psycho, monster.Strength, "Deadline wzmocnil swoja obrone i wykonuje sredni atak (" + monster.Strength + " dmg [Psycho]")
                };
            }
            else
            {
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.Psycho, 0, "Deadline zmeczyl sie obrona i atakiem, musi odpoczac")
                };
            }
        }
    }
}