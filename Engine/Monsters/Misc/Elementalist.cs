using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Elementalist : Monster
    {
        public Elementalist(int elementalistLevel)
        {
            Health = 100 + 5 * elementalistLevel;
            Strength = 10 + elementalistLevel;
            Armor = 10;
            Precision = 50;
            MagicPower = 80 +  elementalistLevel;
            Stamina = 80;
            XPValue = 45 + elementalistLevel;
            Name = "monster1143";
            BattleGreetings = null;
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 10;
                int test = Index.RNG(0, 5);
                if (test == 1)
                {
                    return new List<StatPackage>()
					{ 
						new StatPackage(DmgType.Fire, 3 + MagicPower, "Elementalist uses fireball! ("+ (3 + MagicPower) +" fire damage)"),
						new StatPackage(DmgType.Fire, 3 + MagicPower, "Elementalist uses fireball! ("+ (3 + MagicPower) +" fire damage)")
					};
                }
                else if (test == 2)
                {
                    Health += 5 + (MagicPower / 2);
                    return new List<StatPackage>() { new StatPackage(DmgType.Water, 5 + (MagicPower/2), "Elementalist uses Ebb And Flow! (" + (5 + MagicPower/2) + " water damage," + (5 + MagicPower/2) +" regained health)") };
                }
                else if (test == 3)
                {
                    int test2 = Index.RNG(0, 6);
                    if (test2 == 1)
                    {
                        return new List<StatPackage>()
                        {
                            new StatPackage(DmgType.Earth, MagicPower/2, "Elementalist uses Mud Shot! (" + (MagicPower / 2) + " earth damage). Elementalist slowed you down and used another spell!"),
                            new StatPackage(DmgType.Fire, 3 + MagicPower, "Elementalist uses fireball! ("+ (3 + MagicPower) +" fire damage)"),
                            new StatPackage(DmgType.Fire, 3 + MagicPower, "Elementalist uses fireball! ("+ (3 + MagicPower) +" fire damage)")
                        };
                    }

                    else if (test2 == 2)
                    {
                        Health += 5 + (MagicPower / 2);
                        return new List<StatPackage>()
                        {
                            new StatPackage(DmgType.Earth, MagicPower/2, "Elementalist uses Mud Shot! (" + (MagicPower / 2) + " earth damage). Elementalist slowed you down and used another spell!"),
                            new StatPackage(DmgType.Water, 5 + (MagicPower / 2), "Elementalist uses Ebb And Flow! (" + (5 + MagicPower / 2) + " water damage," + (5 + MagicPower / 2) + " regained health)"),
                        };
                    }
                    else if (test2 == 3)
                    {
                        MagicPower += 2;
                        return new List<StatPackage>()
                        {
                            new StatPackage(DmgType.Earth, MagicPower/2, "Elementalist uses Mud Shot! (" + (MagicPower / 2) + " earth damage). Elementalist slowed you down and used another spell!"),
                            new StatPackage(DmgType.Air, 0, "Elementalist uses Rejuvenating Wind! (+2 spell damage)"),
                        };
                    }
                    else
                    {
                        return new List<StatPackage>()
                        {
                            new StatPackage(DmgType.Earth, MagicPower/2, "Elementalist uses Mud Shot! (" + (MagicPower / 2) + " earth damage). Elementalist slowed you down and used another spell!"),
                            new StatPackage(DmgType.Other, 0, "Elementalist missed her second spell"),
                        };
                    }
                }
                else
                {
                    MagicPower += 2;
                    return new List<StatPackage>() { new StatPackage(DmgType.Air, 0 , "Elementalist uses Rejuvenating Wind! (+2 spell damage)") };
                }
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Elementalist has no energy to attack anymore!") };
            }
        }
    }
}
