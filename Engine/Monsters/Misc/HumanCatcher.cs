using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.Built_In
{
    [Serializable]
    class HumanCatcher : Monster
    {
        private int Poison;
        public HumanCatcher()
        {
            Poison = 75;
            Health = 60;
            Strength = 10;
            Armor = 0;
            Precision = 60;
            MagicPower = 5;
            Stamina = 20;
            XPValue = 40;
            Name = "monster1200";
            BattleGreetings = "";//doesn't say anything
        }
        public override List<StatPackage> BattleMove()
        {
            if (Poison > 0 && Stamina > 0)
            { 
                if (MagicPower > 0)
                {
                    Stamina -= 10;
                    Poison -= 20;
                    return new List<StatPackage>()
                    {

                        new StatPackage(DmgType.Cut, 5 + Strength, "Human Catcher uses Bite! ("+ (5 + Strength) +" cut damage)"),
                        new StatPackage(DmgType.Poison, 15, "Venom burns in your veins! (15 poison damage)"),
                        new StatPackage(DmgType.Earth, 10, "Earth spell damages you! (10 earth damage)")
                    };
                }
                else
                {
                    Stamina -= 10;
                    Poison -= 20;
                    return new List<StatPackage>()
                    {

                        new StatPackage(DmgType.Cut, 5 + Strength, "Human Catcher uses Bite! ("+ (5 + Strength) +" cut damage)"),
                        new StatPackage(DmgType.Poison, 15, "Venom burns in your veins! (15 poison damage)")
                            
                    };
                }
               
            }
            if (Poison < 0 && Stamina > 0)
            {
                if (MagicPower > 0)
                {
                    Stamina -= 10;
                    return new List<StatPackage>()
                    {

                        new StatPackage(DmgType.Cut, 5 + Strength, "Human Catcher uses Bite! ("+ (5 + Strength) +" cut damage)"),
                        new StatPackage(DmgType.Earth, 10, "Earth kills you (10 earth damage)")
                    };
                }
                else
                {
                    Stamina -= 10;
                    return new List<StatPackage>()
                    {

                        new StatPackage(DmgType.Cut, 5 + Strength, "Human Catcher uses Bite! ("+ (5 + Strength) +" cut damage)"),

                    };
                }
            }
            
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Human Catcher has no energy to catch you!") };
            }
        }
    }
}
