using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class RainbowDragon : Monster
    {
        public RainbowDragon()
        {
            Health = 120;
            Strength = 25;
            Armor = 0;
            Precision = 60;
            MagicPower = 25;
            Stamina = 120;
            XPValue = 100;
            Name = "monster1426";
            BattleGreetings = "Colors give me strength!";
        }

        private int button = 0;

        public override void React(List<StatPackage> packs)
        {
            base.React(packs);
            foreach (StatPackage pack in packs)
            {
                if (pack.DamageType == DmgType.Fire || pack.DamageType == DmgType.Air || pack.DamageType == DmgType.Water || pack.DamageType == DmgType.Earth || pack.DamageType == DmgType.Psycho)
                {
                    button = 1;
                    MagicPower = 30;
                }
                else
                    button = 0;
            }
        }

        public override List<StatPackage> BattleMove()
        {
            if (button == 0)
            {
                if (Stamina > 0)
                {
                    Stamina -= 10;
                    return new List<StatPackage>() 
                    {
                        new StatPackage(DmgType.Other, 0, "Well... There is no magic in you, I will not overstrain myself."),
                        new StatPackage(DmgType.Cut, Strength, "Rainbow Dragon uses his colorful strength! (" + (Strength) + " cut damage)")
                    };
                }
                else
                {
                    return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Even the dragon must rest!") };
                }
            }
            else
            {
                if (Stamina > 0)
                {
                    Stamina -= 30;
                    return new List<StatPackage>() 
                    {
                        new StatPackage(DmgType.Other, 0, "Wow... I can feel magic in you, let's fight seriously!"),
                        new StatPackage(DmgType.Psycho, MagicPower, "Rainbow Dragon uses magic of colors! (" + (MagicPower) + " psycho damage)")
                    };
                }
                else
                {
                    return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Even the dragon must rest!") };
                }
            }
        }
    }
}
