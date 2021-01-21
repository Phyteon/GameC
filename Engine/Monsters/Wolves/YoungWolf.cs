using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine.Monsters
{
    [Serializable]
    class YoungWolf : Monster
    {
        public YoungWolf()
        {
            Health = 80;
            Strength = 25;
            Armor = 15;
            Precision = 50;
            MagicPower = 0;
            Stamina = 70;
            XPValue = 100;
            Name = "monster1152";
            BattleGreetings = "You mess with me => you mess with whole pack";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 60)
            {
                Stamina -= 10;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, 15 + Strength, "Wolf bites you! (" + (15 + Strength) + " cut damage)") };
            }

            if (Stamina > 20 && Stamina <= 60)
            {
                Stamina -= 10;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, 10 + Strength, "Wolf scratches you! (" + (5 + Strength) + " cut damage)") };
            }

            if (Stamina > 0 && Stamina <= 20)
            {
                Stamina -= 5;
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 5 + Strength, "Wolf growls! (" + (5 + Strength) + " cut damage)") };
            }

            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Wolf has to rest now... but he will return soon!") };
            }
        }
        public override void React(List<StatPackage> packs)
        {
            //base.React(packs);
            //Young wolf is fast so it's harder to hurt him
            if(Strength >= 10)
            {
                if (packs != null) packs[0].CustomText += "\n Young wolf is so fast it's hard to hurt him.";
                foreach (StatPackage pack in packs)
                {
                    Health -= 50 * pack.HealthDmg / 100;
                    Strength -= 50 * pack.HealthDmg / 100;
                    Armor -= pack.ArmorDmg;
                    Precision -= pack.PrecisionDmg;
                    MagicPower -= pack.MagicPowerDmg;
                }
            }
            else
            {
                if (packs != null) packs[0].CustomText += "\n Young wolf is tired now...";
                foreach (StatPackage pack in packs) //when wolf is tired he loses his precision and armor
                {
                    Health -= pack.HealthDmg;
                    Strength -= pack.StrengthDmg;
                    Armor = 0;
                    Precision = 0;
                    MagicPower = 0;
                }
            }
            
        }

    }
}
