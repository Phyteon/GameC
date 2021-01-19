using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class TargetDummy : Monster
    {
        public TargetDummy()
        {
            Health = 50;
            Strength = 0;
            Armor = 0;
            Precision = 0;
            Stamina = 0;
            XPValue = 15;
            Name = "monster0011";
            BattleGreetings = null;
        }
        public override List<StatPackage> BattleMove()
        {
            return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Don't worry, target dummy can't hit you back") };
        }
    }
}
