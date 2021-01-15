using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class FireWitch : Monster
    {
        public int FireMagic;
        public FireWitch()
        {
            FireMagic = 150;
            Health = 80;
            Strength = 50;
            Armor = 0;
            Precision = 100;
            MagicPower = 50;
            Stamina = 50;
            XPValue = 70;
            Name = "monster1223";
            BattleGreetings = "Get ready for hellish magic!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Strength > 40)
            {

                if (MagicPower > 30)
                {
                    Stamina -= 10;
                    MagicPower -= 5;
                    FireMagic -= 10;
                    return new List<StatPackage>()
                    {
                            new StatPackage(DmgType.Cut, 10 , "Fire Witch stung you! (" + 10 +  " cut damage)"),
                            new StatPackage(DmgType.Psycho, 10, "Fire Witch hyptonized you (" + 10 +  " psycho damage)"),
                            new StatPackage(DmgType.Fire, 10, "Fire Witch set you on fire (" +10+ " fire damage)")
                    };
                }
                if (MagicPower > 10 && MagicPower <= 30)
                {
                    Stamina -= 5;
                    MagicPower -= 5;
                    FireMagic -= 10;
                    return new List<StatPackage>()
                    {
                        new StatPackage(DmgType.Psycho, 5, "Fire Witch has cursed you! (" + 5 + " psycho damage)"),
                        new StatPackage(DmgType.Fire, 10, "Fire Witch set you on fire (" +10+ " fire damage)")
                    };

                }
                else
                {
                    return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Fire Witch has no energy to attack anymore!") };
                }
            }
            if (Strength > 20 && Strength <= 40)
            {

                if (MagicPower > 30)
                {
                    Stamina -= 10;
                    MagicPower -= 5;
                    FireMagic -= 5;
                    return new List<StatPackage>()
                    {
                            new StatPackage(DmgType.Cut, 10 , "Fire Witch stung you! (" + 10 +  "cut damage)"),
                            new StatPackage(DmgType.Psycho, 10, "Fire Witch hypnotized you (" + 10 +  " psycho damage)"),
                            new StatPackage(DmgType.Fire, 10, "Fire Witch set your armor on fire (" +10+ " damage)")
                    };
                }
                if (MagicPower > 10 && MagicPower <= 30)
                {
                    Stamina -= 5;
                    MagicPower -= 5;
                    FireMagic -= 5;
                    return new List<StatPackage>()
                    {
                        new StatPackage(DmgType.Psycho, 5, "Fire Witch has cursed you! (" + 5 + " psycho damage)"),
                        new StatPackage(DmgType.Fire, 10, "Fire Witch set your armor on fire (" +10+ " fire damage)")
                    };

                }
                else
                {
                    return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Fire Witch has no energy to attack anymore!") };
                }
            }
            else
            {
                if (MagicPower > 30)
                {
                    Stamina -= 10;
                    MagicPower -= 5;
                    return new List<StatPackage>()
                    {
                            new StatPackage(DmgType.Cut, 10 , "Fire Witch stung you! (" + 10 +  " cut damage)"),
                             new StatPackage(DmgType.Psycho, 5, "Fire Witch has cursed you! (" + 5 + " psycho damage)"),
                    };
                }
                if (MagicPower > 10 && MagicPower <= 30)
                {
                    Stamina -= 5;
                    MagicPower -= 5;
                    return new List<StatPackage>()
                    {
                        new StatPackage(DmgType.Psycho, 5, "Fire Witch has cursed you! (" + 5 + " psycho damage)"),
                        new StatPackage(DmgType.Fire, 5, "The sword was set on fire (" +5+ " damage)")
                    };

                }
                else
                {
                    return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Fire Witch has no energy to attack anymore!") };
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
