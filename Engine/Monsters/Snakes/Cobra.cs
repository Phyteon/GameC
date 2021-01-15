using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Cobra : Monster
    {
        public Cobra()
        {
            Health = 65;
            Strength = 20;
            Armor = 15;
            Precision = 50;
            MagicPower = 10;
            Stamina = 75;
            XPValue = 30;
            Name = "monster1303";
            BattleGreetings = "Beware! I'm coming!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 60) //atak uzależniony od staminy
            {
                Stamina -= 10;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, 15 + Strength, "Cobra uses Bite! (" + (15 + Strength) + " cut damage)") };
            }

            if (Stamina > 40 && Stamina <= 60)
            {
                Stamina -= 10;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, 10 + Strength, "Cobra uses Sting! (" + (10 + Strength) + " cut damage)") };
            }

            if (Stamina > 20 && Stamina <= 40)
            {
                Stamina -= 5;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, 5 + Strength, "Cobra uses Bite! (" + (5 + Strength) + " cut damage)") };
            }
            if (Stamina > 0 && Stamina <= 20)
            {
                Stamina -= 5;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, 5, "Cobra uses Sting! (5 cut damage)") };
            }

            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Cobra has no energy to attack anymore!") };
            }
        }
        public override void React(List<StatPackage> packs)
        {
            foreach (StatPackage pack in packs)
            {
                if(Stamina > 35)
                {
                    if (packs != null) packs[0].CustomText += "\n Cobra dodges part of your attack!";
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
