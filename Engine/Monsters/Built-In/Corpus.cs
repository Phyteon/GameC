﻿using System;
using System.Collections.Generic;

namespace Game.Engine.Monsters
{
    [Serializable]
    public class Corpus : Monster
    {
        protected IStrategist strategy;
        protected List<IStrategist> strategies = new List<IStrategist>()
        {
            new CorpusAggressive(),
            new CorpusDefensive(),
            new CorpusMixed()
        };
        public Corpus()
        {
            Health = 400;
            Strength = 100;
            Armor = 100;
            Precision = 50;
            Stamina = 100;
            XPValue = 100;
            Name = "monster0010";
            BattleGreetings = "Je yette pke Yotkuy. Je ate pke Yotkuy.";
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

            if (Health - health_dmg <= 0.1 * Health)
            {
                strategy = strategies[1];
            }
            else if (Health - health_dmg > 0.1 * Health && Health - health_dmg <= 0.25 * Health)
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
    public class CorpusAggressive : IStrategist
    {
        public List<StatPackage> BattleStrategy(Monster monster)
        {
            monster.Armor -= 10;
            if (monster.Stamina > 0)
            {
                monster.Stamina -= 20;
                int chance = Index.RNG(0, 11);
                switch (chance)
                {
                    case 0:
                        return new List<StatPackage>()
                        {
                            new StatPackage(DmgType.Other, 50 + monster.Strength,
                                "Szeregowy Corpusu dostal rozkaz zabicia cie wszelkimi mozliwymi sposobami," +
                                " wiec uzywa calej swojej sily(" + (50 + monster.Strength) +
                                " dmg [Other])")
                        };
                    case 1:
                        return new List<StatPackage>()
                        {
                            new StatPackage(DmgType.Other, 25 + monster.Strength,
                                "Szeregowy Corpusu jest na patrolu w krytycznym obszarze ich dzialan," +
                                " chce wyeliminowac cie na miejscu (" + (25 + monster.Strength) +
                                " dmg [Other])")
                        };
                    case 5:
                        return new List<StatPackage>()
                        {
                            new StatPackage(DmgType.Other, 10 + monster.Strength,
                                "Szeregowy Corpusu atakuje z wyjatkowa precyzja! (" + (10 + monster.Strength) +
                                " dmg [Other])")
                        };
                    case 10:
                        return new List<StatPackage>()
                        {
                            new StatPackage(DmgType.Other, 0,
                                "Szeregowy Corpusu nie trafia atakujac cie ( 0 dmg [Other])")
                        };
                    default:
                        return new List<StatPackage>()
                        {
                            new StatPackage(DmgType.Other, 5 + monster.Strength,
                                "Szeregowy Corpusu atakuje! (" +
                                (5 + monster.Strength) + " dmg [Other])")
                        };

                }
            }
            else
            {
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.Other, 0, "Szeregowy corpusu sie zmeczyl i musi odpoczac")
                };
            }
        }
    }
    
    public class CorpusDefensive : IStrategist
    {
        public List<StatPackage> BattleStrategy(Monster monster)
        {
            
            if (monster.Stamina > 0)
            {
                monster.Armor += 30;
                monster.Health += 50;
                monster.Stamina -= 5;
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.Other, 5, "Szeregowy Corpusu wzmocnil swoja obrone, wykorzystuje specjalny" +
                                                         " artefakt by ukrasc ci zycie (50 Hp) i wykonuje tylko slaby atak ( 5 dmg [Physical])")
                };
            }
            else
            {
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.Other, 0, "Szeregowy Corpusu probuje sie bronic ale juz mu brakuje sil")
                };
            }
        }
    }
    
    public class CorpusMixed : IStrategist
    {
        public List<StatPackage> BattleStrategy(Monster monster)
        {
            monster.Armor += 15;
            if (monster.Stamina > 0)
            {
                monster.Stamina -= 10;
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.Other, monster.Strength, "Szeregowy Corpusu wzmocnil swoja obrone" +
                                                                        " i wykonuje sredni atak (" + monster.Strength + " dmg [Other]")
                };
            }
            else
            {
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.Other, 0, "Szeregowy Corpusu zmeczyl sie obrona i atakiem, musi odpoczac")
                };
            }
        }
    }
}