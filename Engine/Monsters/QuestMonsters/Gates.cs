using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.Forest
{
    class Gates : Monster
    {
        public Gates()
        {
            Health = 2000;
            Strength = 70;
            Name = "monster0027";
            BattleGreetings = "Click!";
        }

        public override List<StatPackage> BattleMove()
        {
            health -= 2000;
            return new List<StatPackage>() { new StatPackage(DmgType.Cut, Strength, "WRONG ANSWER! (" + (Strength) + " cut damage)") };

        }
    }
}
