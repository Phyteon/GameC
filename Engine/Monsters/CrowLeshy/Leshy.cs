using System;
using System.Collections.Generic;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Leshy : Monster
    {
        private bool rage = false;

        public Leshy()
        {
            Health = 150;
            Strength = 10;
            Armor = 10;
            Precision = 80;
            Stamina = 200;
            XPValue = 35;
            Name = "monster1261";
            BattleGreetings = "You felt the darkness coming from the depths of the forest. Leshy is coming ...";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= Index.RNG(20, 41);
                int chance = Index.RNG(0, 11);
                if(rage)
                {
                    return new List<StatPackage>() { new StatPackage(DmgType.Crush, Strength, "Leshy is furious and deals a series of two blows. First blow deals (" + Strength + ")"), new StatPackage(DmgType.Crush, Strength + 2, "Second blow deals (" + (Strength + 2) + ")")};
                }
                else
                {
                    switch (chance)
                    {
                        case 0:
                            return new List<StatPackage>() { new StatPackage(DmgType.Earth, 8 + Strength, 3, 0, 0, 0, "Leshy hits the ground and causes an earthquake. He deals (" + (8 + Strength) + " damage) and reduce your armor by 3 points.") };
                        default:
                            return new List<StatPackage>() { new StatPackage(DmgType.Crush, 5 + Strength, "Leshy attacks with his big paw and deals (" + (5 + Strength) + " damage)") };
                    }
                }
            }
            else
            {
                Stamina += Index.RNG(20, 81);
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Leshy needs to rest and regenerate his stamina. You are safe.")};
            }
        }

        public override void React(List<StatPackage> packs)
        {
            base.React(packs);

            if (Health < 40)
                rage = true;
        }
    }
}
