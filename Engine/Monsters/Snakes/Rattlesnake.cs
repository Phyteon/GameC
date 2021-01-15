using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Rattlesnake : Monster
    {
        public Rattlesnake()
        {
            Health = 50;
            Strength = 12;
            Armor = 10;
            Precision = 40;
            MagicPower = 0;
            Stamina = 60;
            XPValue = 20;
            Name = "monster1302";
            BattleGreetings = "Wanna play with my rattle?";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 10;
                int chance = Index.RNG(0, 10); //atak losowy
                switch (chance)
                {
                    case 0:
                        return new List<StatPackage>() { new StatPackage(DmgType.Cut, 8 + Strength, "Rattlesnake bites you! (" + (8 + Strength) + " cut damage)") };
                    default:
                        return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Rattlesnake can't bite you (0 damage)") };
                }
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Rattlesnake has no energy to fight anymore!") };
            }
        }
        public override void React(List<StatPackage> packs)
        {
            foreach (StatPackage pack in packs)
            {
                int ch = Index.RNG(0, 11);
                if(ch > 4)
                {
                    if (packs != null) packs[0].CustomText += "\n Rattlesnake dodges part of your attack!";
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
