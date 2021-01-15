using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class DarkWitch : Monster
    {
        public int DarkMagic;
        public DarkWitch()
        {
            DarkMagic = 30;
            Health = 250;
            Strength = 100;
            Armor = 0;
            Precision = 150;
            MagicPower = 80;
            Stamina = 120;
            XPValue = 120;
            Name = "monster1224";
            BattleGreetings = "Let's see some black magic!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Strength > 40)
            {

                if (MagicPower > 40)
                {
                    Stamina -= 10;
                    MagicPower -= 5;
                    DarkMagic -= 10;
                    return new List<StatPackage>() 
                    {
                            new StatPackage(DmgType.Cut, 10 , "Dark Witch stung you! (" + 10 +  " cut damage)"),
                            new StatPackage(DmgType.Psycho, 10, "Dark Witch hyptonized you (" + 10 +  " psycho damage)"),
                            new StatPackage(DmgType.Other, 10, "You have been turned to stone (" +10+ " damage)")
                    };
                }
                if (MagicPower > 20 && MagicPower <= 40)
                {
                    Stamina -= 5;
                    MagicPower -= 5;
                    DarkMagic -= 10;
                    return new List<StatPackage>()
                    { 
                        new StatPackage(DmgType.Psycho, 5, "Dark Witch has cursed you! (" + 5 + " psycho damage)"),
                        new StatPackage(DmgType.Other, 10, "You have been turned to stone (" +10+ " damage)")
                    };

                }
                else
                {
                    return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Dark Witch has no energy to attack anymore!") };
                }
            }
            if (Strength > 20 && Strength <= 40)
            {

                if (MagicPower > 40)
                {
                    Stamina -= 10;
                    MagicPower -= 5;
                    DarkMagic -= 5;
                    return new List<StatPackage>()
                    {
                            new StatPackage(DmgType.Cut, 10 , "Dark Witch stung you! (" + 10 +  "cut damage)"),
                            new StatPackage(DmgType.Psycho, 10, "Dark Witch hypnotized you (" + 10 +  " psycho damage)"),
                            new StatPackage(DmgType.Other, 10, "You have been turned to frog (" +10+ " damage)")
                    };
                }
                if (MagicPower > 20 && MagicPower <= 40)
                {
                    Stamina -= 5;
                    MagicPower -= 5;
                    DarkMagic -= 5;
                    return new List<StatPackage>()
                    {
                        new StatPackage(DmgType.Psycho, 5, "Dark Witch has cursed you! (" + 5 + " psycho damage)"),
                        new StatPackage(DmgType.Other, 10, "You have been turned to frog (" +10+ " damage)")
                    };

                }
                else
                {
                    return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Dark Witch has no energy to attack anymore!") };
                }
            }
            else
            {
                if (MagicPower > 40)
                {
                    Stamina -= 10;
                    MagicPower -= 5;
                    return new List<StatPackage>()
                    {
                            new StatPackage(DmgType.Cut, 10 , "Dark Witch stung you! (" + 10 +  " cut damage)"),
                             new StatPackage(DmgType.Psycho, 5, "Dark Witch has cursed you! (" + 5 + " psycho damage)"),
                    };
                }
                if (MagicPower > 20 && MagicPower <= 40)
                {
                    Stamina -= 5;
                    MagicPower -= 5;
                    return new List<StatPackage>()
                    {
                        new StatPackage(DmgType.Psycho, 5, "Dark Witch has cursed you! (" + 5 + " psycho damage)"),
                        new StatPackage(DmgType.Other, 10, "You have been turned to cow! (" +10+ " damage)")
                    };

                }
                else
                {
                    return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Dark Witch has no energy to attack anymore!") };
                }
            }
        }
        private int numberOfAttacks = 0;
        public override void React(List<StatPackage> packs)
        {
            numberOfAttacks++;
            if (numberOfAttacks == 1)
            {
                foreach (StatPackage pack in packs)
                {

                    Health -= pack.HealthDmg;
                    Strength -= pack.StrengthDmg;
                    Precision -= pack.PrecisionDmg;
                    MagicPower -= pack.MagicPowerDmg;
                    numberOfAttacks++;

                }
            }
            else if (numberOfAttacks == 2)
            {
                foreach (StatPackage pack in packs)
                {
                    Health -= pack.HealthDmg;
                    Strength -= pack.StrengthDmg;
                    MagicPower -= pack.MagicPowerDmg;
                    numberOfAttacks++;
                }
            }
            else if (numberOfAttacks >= 3)
            {
                foreach (StatPackage pack in packs)
                {
                    Health -= pack.HealthDmg;
                    MagicPower -= pack.MagicPowerDmg;
                    numberOfAttacks++;
                }
            }
        }
    }
}
