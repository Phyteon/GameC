using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.Forest
{
    class Trap : Monster
    {
        public Trap()
        {
            Health = 2000;
            Strength = 50;
            Name = "monster0028";
            BattleGreetings = "Click!";
        }

        public override List<StatPackage> BattleMove()
        {
            health -= 2000;
            return new List<StatPackage>() { new StatPackage(DmgType.Cut, Strength, "You fall into trap! (" + ( Strength) + " cut damage)") };

        }
    }
}
