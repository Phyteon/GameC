using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine.Monsters
{
    [Serializable]
    class OldWolf : Monster
    {
        public OldWolf()
        {
            Health = 50;
            Strength = 15;
            Armor = 20;
            Precision = 70;
            MagicPower = 20;
            Stamina = 60;
            XPValue = 60;
            Name = "monster1153";
            BattleGreetings = "Now I'm back with... my life expierience! But also magic power!";
        }
        public override List<StatPackage> BattleMove()
        {
            int attackType = Index.RNG(1, 3);
            if (Stamina > 0)
            {
                if (attackType == 1)
                {
                    Stamina -= 10;
                    return new List<StatPackage>() { new StatPackage(DmgType.Cut, 10 + Strength, "Old Wolf uses Bite! (" + (10 + Strength) + " cut damage)") };
                }
                else if (attackType == 2)
                {
                    Stamina -= 15;
                    return new List<StatPackage>() { new StatPackage(DmgType.Poison, 20 + Strength, "Old Wolf uses Magic Bite! (" + (20 + Strength) + "magic cut damage)") };
                }
                else { return null; }
            }
            else if (MagicPower > 0 && attackType == 3)
            {
                MagicPower -= 20;
                return new List<StatPackage>() { new StatPackage(DmgType.Psycho, 30 + Strength, "Old Wolf uses his powers! (" + (30 + Strength) + "psycho magic cut damage)") };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Old Wolf has to rest now!") };
            }
        }
        public override void React(List<StatPackage> packs)
        {
            base.React(packs);
        }
    }
}

