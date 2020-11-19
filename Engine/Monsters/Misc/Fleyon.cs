using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Fleyon : Monster 
    {
        private int turnNumber = 1;
        private string avoid = "";
        public Fleyon(int fleyonLevel)
        {
            Health = 50 + 5 * fleyonLevel;
            Strength = 60 + fleyonLevel;
            Armor = 20;
            Precision = 70;
            MagicPower = 0;
            Stamina = 70;
            XPValue = 50 + fleyonLevel;
            Name = "monster1362";
            BattleGreetings = "I am very agile. I can avoid being hit. Can you catch me?";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                if (turnNumber == 1)
                {
                    Stamina -= 10;
                    turnNumber++;
                    return new List<StatPackage>() { new StatPackage(DmgType.Poison, ((Strength + Precision) / 10), avoid + "Fleyon uses poisonous bite! (Decrease Precision and Strenght by " + ((Strength + Precision) / 10) + " )") };
                }
                else
                {
                    List<StatPackage> tmp = new List<StatPackage>();
                    tmp.Add(new StatPackage(DmgType.Cut, 5 + Strength / 2, avoid + "Fleyon uses bite! (" + Strength / 2 + " physical damage)"));
                    tmp.Add(new StatPackage(DmgType.Cut, (Precision + Strength) / 5, avoid + "Fleyon scratched you! (" + (Precision + Strength) / 5 + " physical damage)"));
                    return new List<StatPackage>() { tmp[Index.RNG(0, tmp.Count)] };
                }
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, avoid + "Fleyon has no energy to attack anymore!") };
            }
        }
        public override void React(List<StatPackage> packs)
        {
            int i = Index.RNG(0, 2);
            foreach (StatPackage pack in packs)
            {
                if ((pack.DamageType == DmgType.Water || pack.DamageType == DmgType.Earth || pack.DamageType == DmgType.Air || pack.DamageType == DmgType.Fire) && i == 0)
                {
                    avoid = "Fleyon avoids being hit!\n";
                }
                else
                {
                    health -= pack.HealthDmg;
                    Strength -= pack.StrengthDmg;
                    Armor -= pack.ArmorDmg;
                    Precision -= pack.PrecisionDmg;
                    MagicPower -= pack.MagicPowerDmg;
                    avoid = "";
                }
            }
        }
    }
}
