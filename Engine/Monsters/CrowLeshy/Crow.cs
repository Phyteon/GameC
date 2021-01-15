using System;
using System.Collections.Generic;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Crow : Monster
    {
        public Crow()
        {
            Health = 30;
            Strength = 2;
            Armor = 1;
            Precision = 60;
            Stamina = 80;
            XPValue = 13;
            Name = "monster1260";
            BattleGreetings = "Kra! Kra! The Crow has appeared.";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= Index.RNG(5, 21);
                int chance = Index.RNG(0, 11);
                switch (chance)
                {
                    case 0:
                        Health = 0;
                        return new List<StatPackage>() { new StatPackage(DmgType.Crush, 5 + Strength, "Crow sacrifices himself in charge and deals " + (5 + Strength) + " damage") };
                    default:
                        return new List<StatPackage>() { new StatPackage(DmgType.Cut, 1 + Strength, "Crow attacs you with claws and deals " + 1 + Strength + " damage") };
                }
            }
            else
            {
                Stamina += Index.RNG(20, 81);
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Crow needs to rest and regenerate his stamina. You are safe.")};
            }
        }
    }
}
