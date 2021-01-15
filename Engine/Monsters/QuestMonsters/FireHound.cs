using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class FireHound : Monster
    {
        public FireHound()
        {
            Health = 125;
            Strength = 50;
            Armor = 35;
            Precision = 80;
            MagicPower = 50;
            Stamina = 220;
            XPValue = 140;
            Name = "monster0015";
            BattleGreetings = null;
        }
        public override List<StatPackage> BattleMove()
        {
            int fireBite = Index.RNG(0, 10); 
            if(fireBite<4) //40% chance to set player on fire and deal adittional damage
            {
                return new List<StatPackage>() { 
                    new StatPackage(DmgType.Cut, 30 + strength, "Fire Hound bites you. (" + (30 + strength) + " cut damage)"),
                    new StatPackage(DmgType.Fire, 15, "Fire Hounds attack sets you on fire. (" + (15) + " fire damage)"),
                };
            }
            return new List<StatPackage>() { new StatPackage(DmgType.Cut, 30 + strength, "Fire Hound bites you. (" + (30 + strength) + " cut damage)") };

        }
    }
}
