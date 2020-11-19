using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class DeathDragon : Monster
    {
        public DeathDragon(int deathDragonLevel)
        {
            Health = 100 + 8 * deathDragonLevel;
            Strength = 150 + deathDragonLevel;
            Armor = 40;
            Precision = 50;
            MagicPower = 35;
            Stamina = 150;
            XPValue = 100 + deathDragonLevel;
            Name = "monster1261";
            BattleGreetings = "It's time to my Danse Macabre!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Random random = new Random();
                if (random.NextDouble() <= 0.4)
                {
                    Stamina -= 10;
                    return new List<StatPackage>()
                    {
                        new StatPackage(DmgType.Cut, Strength - 20, "Death Dragon uses Black Breathe! (" + (Strength - 20) + " cut damage)"),
                        new StatPackage(DmgType.Poison, 10, "You feel devil blood inside your veins! (10 poison damage)")
                    };
                }
                else if (random.NextDouble() > 0.4 && random.NextDouble() <= 0.8)
                {
                    Stamina -= 5;
                    return new List<StatPackage>() { new StatPackage(DmgType.Cut, Strength - 65, "Death Dragon uses Tail Punch! (" + (Strength - 65) + " cut damage)") };
                }
                else
                {
                    Stamina -= 15;
                    return new List<StatPackage>()
                    {
                        new StatPackage(DmgType.Cut, Strength + 10, "Death Dragon uses Danse Macabre! (" + (Strength + 10) + " cut damage)"),
                        new StatPackage(DmgType.Poison, 30, "It feels like you've lost part of soul... (30 poison damage)")
                    };
                }
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Death Dragon has no energy to attack anymore!") };
            }
        }
    }
}
