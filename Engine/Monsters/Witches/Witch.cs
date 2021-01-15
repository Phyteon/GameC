using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Witch : Monster
    {
        public Witch()
        {
            Health = 50;
            Strength = 30;
            Armor = 0;
            Precision = 40;
            MagicPower = 30;
            Stamina = 40;
            XPValue = 20;
            Name = "monster1222";
            BattleGreetings = "Do you want an apple, sweatheart?";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Strength > 20)
            {

                if (MagicPower > 25)
                {
                    Stamina -= 10;
                    MagicPower -= 10;
                    return new List<StatPackage>()
                    {
                            new StatPackage(DmgType.Cut, 10 , "Witch stung you! (" + 10 +  " cut damage)"),
                            new StatPackage(DmgType.Psycho, 10, "Witch hyptonized you (" + 10 +  " psycho damage)"),
                    };
                }
                if (MagicPower > 10 && MagicPower <= 25)
                {
                    Stamina -= 5;
                    MagicPower -= 5;
                    return new List<StatPackage>()
                    {
                        new StatPackage(DmgType.Psycho, 5, "Witch has cursed you! (" + 5 + " cut damage)"),
                    };

                }
                else
                {
                    return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Witch has no energy to attack anymore!") };
                }
            }
            if (Strength > 10 && Strength <= 20)
            {

                if (MagicPower > 25)
                {
                    Stamina -= 10;
                    MagicPower -= 10;
                    return new List<StatPackage>()
                    {
                            new StatPackage(DmgType.Cut, 10 , "Witch stung you! (" + 10 +  "cut damage)"),
                            new StatPackage(DmgType.Psycho, 10, "Witch hypnotized you (" + 10 +  " psycho damage)"),
                    };
                }
                if (MagicPower > 10 && MagicPower <= 25)
                {
                    Stamina -= 5;
                    MagicPower -= 5;
                    return new List<StatPackage>()
                    {
                        new StatPackage(DmgType.Psycho, 5, "Witch has cursed you! (" + 5 + " cut damage)"),
                    };

                }
                else
                {
                    return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Witch has no energy to attack anymore!") };
                }
            }
            else
            {
                if (MagicPower > 25)
                {
                    Stamina -= 10;
                    MagicPower -= 5;
                    return new List<StatPackage>()
                    {
                            new StatPackage(DmgType.Cut, 10 , "Witch stung you! (" + 10 +  "cut damage)"),
                             new StatPackage(DmgType.Psycho, 5, "Witch has cursed you! (" + 5 + " cut damage)"),
                    };
                }
                if (MagicPower > 10 && MagicPower <= 25)
                {
                    Stamina -= 5;
                    MagicPower -= 5;
                    return new List<StatPackage>()
                    {
                        new StatPackage(DmgType.Psycho, 5, "Witch has cursed you! (" + 5 + " cut damage)"),
                    };

                }
                else
                {
                    return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Witch has no energy to attack anymore!") };
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
                    MagicPower -= pack.MagicPowerDmg;
                    numberOfAttacks++;
                }
            }
            else if (numberOfAttacks == 2)
            {
                foreach (StatPackage pack in packs)
                {
                    Health -= pack.HealthDmg;
                    MagicPower -= pack.MagicPowerDmg;
                    numberOfAttacks++;
                }
            }
            else if (numberOfAttacks >= 3)
            {
                foreach (StatPackage pack in packs)
                {
                    Health -= pack.HealthDmg;
                    numberOfAttacks++;
                }
            }
        }
    }
}
