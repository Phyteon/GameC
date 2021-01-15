using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Python : Monster
    {
        public Python()
        {
            Health = 70;
            Strength = 30;
            Armor = 25;
            Precision = 60;
            MagicPower = 20;
            Stamina = 100;
            XPValue = 50;
            Name = "monster1304";
            BattleGreetings = "Sssstay away! You'll regret it if you come over!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Health > 50) //atak uzależniony od staminy
            {
                if (Stamina > 70)
                {
                    Stamina -= 10;
                    return new List<StatPackage>() { new StatPackage(DmgType.Crush, 20 + Strength, "Python charges forward! (" + (20 + Strength) + " crush damage)") };
                }

                if (Stamina > 0 && Stamina <= 70)
                {
                    Stamina -= 10;
                    return new List<StatPackage>() { new StatPackage(DmgType.Poison, 15 + MagicPower, "Python's magic power burns you! (" + (15 + MagicPower) + " poison damage)") };
                }
                else
                {
                    return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Python has no energy to attack anymore!") };
                }
            }
            else
            {
                if (Stamina > 50)
                {
                    Stamina -= 10;
                    return new List<StatPackage>() { new StatPackage(DmgType.Cut, 10 + Strength, "Python uses Bite! (" + (10 + Strength) + " cut damage)") };
                }
                if(Stamina > 20 && Stamina <= 50)
                {
                    Stamina -= 5;
                    return new List<StatPackage>() { new StatPackage(DmgType.Crush, 20, "Python cruches you! (20 crush damage)") };
                }
                if(Stamina > 0 && Stamina <= 20)
                {
                    Stamina -= 5;
                    return new List<StatPackage>() { new StatPackage(DmgType.Cut, 5 + Strength, "Python charges forward! (" + (5 + Strength) + " cut damage)") };

                }
                else
                {
                    return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Python has no energy to attack anymore!") };
                }
            }
        }
        public override void React(List<StatPackage> packs) // receive the result of your opponent's action
        {
            foreach (StatPackage pack in packs)
            {
                if(Health > 40)
                {
                    if (packs != null) packs[0].CustomText += "\n Python dodges part of your attack!";
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
