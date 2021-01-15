using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Viper : Monster
    {
        public Viper()
        {
            Health = 40;
            Strength = 10;
            Armor = 7;
            Precision = 30;
            MagicPower = 0;
            Stamina = 50;
            XPValue = 15;
            Name = "monster1301";
            BattleGreetings = "I will bite you!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0) //atak losowy
            {
                int chance = Index.RNG(0, 10);
                if (chance < 6)
                {
                    Stamina -= 10;
                    return new List<StatPackage>() { new StatPackage(DmgType.Cut, 7 + Strength, "Viper attacks you (" + (7 + Strength) + " cut damage)") };
                }
                else
                {
                    Stamina -= 20;
                    health += 10;
                    return new List<StatPackage>()
                    {
                        new StatPackage(DmgType.Other, 20 + Strength, "Viper hurts you badly (" + (20 + Strength) + " damage) and gains 10 health"),
                    };
                }
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Viper has no energy to attack anymore!") };
            }
        }
        public override void React(List<StatPackage> packs)
        {
            foreach (StatPackage pack in packs)
            {
                int chance = Index.RNG(0, 10);
                if (chance < 6)
                {
                    if (packs != null) packs[0].CustomText += "\n Viper dodges part of your attack!";
                    Health -= 10;
                }
                else
                {
                    base.React(packs);
                }
            }
        }
    }
}
