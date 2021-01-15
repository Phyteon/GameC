using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Cerberus : Monster
    {
        public Cerberus()
        {
            Health = 120;
            Strength = 25;
            Armor = 0;
            Precision = 50;
            MagicPower = 0;
            Stamina = 120;
            XPValue = 130;
            Name = "monster1423";
            BattleGreetings = "Three heads are better than one!";
        }

        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 80)
            {
                Stamina -= 20;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, 15 + Strength, "Cerberus attacks you with his all heads! (" + (15 + Strength) + " cut damage)") };
            }
            else if (Stamina > 40 && Stamina <= 80)
            {
                Stamina -= 20;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, 10 + Strength, "Cerberus attacks you with his two heads! (" + (10 + Strength) + " cut damage)") };
            }
            else if (Stamina > 0 && Stamina <= 40)
            {
                Stamina -= 20;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, 5 + Strength, "Cerberus attacks you only with his one head! (" + (5 + Strength) + " cut damage)") };
            }
            else
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Cerberus goes to Hades to rest.") };
        }
    
    }
}
