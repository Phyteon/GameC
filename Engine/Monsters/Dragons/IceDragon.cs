using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class IceDragon : Monster
    {
        public IceDragon()
        {
            Health = 400;
            Strength = 100;
            Armor = 50;
            Precision = 60;
            MagicPower = 90;
            Stamina = 250;
            XPValue = 95;
            Name = "monster1125";
            BattleGreetings = "I'm an Ice Dragon from Scandinavia! You have to try very hard to make me suffer.";
        }

        public override List<StatPackage> BattleMove()
        {
            if (Health > 200)
            {
                Stamina -= 40;
                Strength -= 10;
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.Air, 50, "Ice Dragon breathes frosty air! (" + 50 + " freeze damage")
                };
            }


            if (Health > 0 && Health <= 200)
            {
                Stamina -= 35;
                Strength -= 10;
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.Crush, 40, "Ice Dragon uses Ice Balls! (" + 40 + " crush damage)")
                };
            }

            else
            {
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.Other, 0, "Ice Dragon has to rest")
                };
            }

        }

        int playerAttack = 0;

        public override void React(List<StatPackage> packs) 
        {
            playerAttack++;

            if (playerAttack >= 4)
            {
                foreach (StatPackage pack in packs) 
                {
                    Health -= pack.HealthDmg;
                    Strength -= pack.StrengthDmg;
                    Armor -= pack.ArmorDmg;
                    Precision -= pack.PrecisionDmg;
                    MagicPower -= pack.MagicPowerDmg;
                }
            }   
            else
            {
                if (packs != null) packs[0].CustomText += "\n Ice Dragon resists your attack!";
            }
        }

    }
}
