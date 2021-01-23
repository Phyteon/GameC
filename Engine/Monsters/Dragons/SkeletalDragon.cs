using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class SkeletalDragon : Monster
    {
        public SkeletalDragon()
        {
            Health = 110;
            Strength = 15;
            Armor = 0;
            Precision = 50;
            MagicPower = 15;
            Stamina = 50;
            XPValue = 150;
            Name = "monster1421";
            BattleGreetings = "I still feel magic in my bones!";
        }

        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 10;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, MagicPower + Strength, "Skeletal Dragon uses magic and strength from his old bones! (" + (MagicPower + Strength) + " cut damage)") };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Even the dragon must rest!") };
            }
        }
    }
}
