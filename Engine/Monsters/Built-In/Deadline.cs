using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Game.Engine.Monsters
{
    [Serializable]
    public class Deadline : Monster, IStrategist
    {
        public Deadline()
        {
            Health = 30;
            Strength = 50;
            Armor = 100;
            Precision = 50;
            Stamina = 100;
            XPValue = 30;
            Name = "the scariest monster";
            BattleGreetings = "Zawsze jestem blizej niz ci sie wydaje...";
        }

        // TODO: Add override of the react function
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 1; // Deadline is a very tough and resilient opponent...
                int chance = Index.RNG(0, 10);
                switch (chance)
                {
                    case 0:
                        return new List<StatPackage>()
                        {
                            new StatPackage(DmgType.Psycho, 50 + Strength,
                                "Deadline zastosowal podroz w czasie i jest na wczoraj (" + (50 + Strength) +
                                " dmg [Psycho])")
                        };
                    case 1:
                        return new List<StatPackage>()
                        {
                            new StatPackage(DmgType.Psycho, 25 + Strength,
                                "Deadline sie zaktualizowal i dodal do siebie nowe wymagania (" + (25 + Strength) +
                                " dmg [Psycho])")
                        };
                    case 5:
                        return new List<StatPackage>()
                        {
                            new StatPackage(DmgType.Psycho, 10 + Strength,
                                "Deadline groznie sie na ciebie patrzy i przyprawia cie o ciarki (" + (10 + Strength) +
                                " dmg [Psycho])")
                        };
                    case 10:
                        return new List<StatPackage>()
                        {
                            new StatPackage(DmgType.Psycho, Math.Abs(Strength - 20),
                                "Deadline przeniosl sie w czasie ale pomylil sobie kierunek i przenosi sie na za miesiac (" +
                                (25 + Strength) + " dmg [Psycho])")
                        };
                    default:
                        return new List<StatPackage>()
                        {
                            new StatPackage(DmgType.Psycho, 5 + Strength,
                                "Deadline teleportuje sie za ciebie i wbija ci pinezke ze swoim terminem w plecy (" +
                                (25 + Strength) + " dmg [Psycho])")
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
        public List<StatPackage> Aggressive()
        {
            throw new NotImplementedException();
        }

        public List<StatPackage> Defensive()
        {
            throw new NotImplementedException();
        }

        public List<StatPackage> Mixed()
        {
            throw new NotImplementedException();
        }

        public void ChooseStrategy()
        {
            throw new NotImplementedException();
        }
    }
}