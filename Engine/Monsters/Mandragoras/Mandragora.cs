using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Mandragora : Monster
    {
        public Mandragora()
        {
            Health = 5;
            Strength = 0;
            Armor = 0;
            Precision = 0;
            MagicPower = 0;
            Stamina = 10;
            XPValue = 10;
            Name = "monster1506";
            BattleGreetings = "*is it you, or this plant is just weird*";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 10;
                return new List<StatPackage>() { new StatPackage(DmgType.Cut, 5, "I have no idea how you did it, but you got a cut from a harmless plant. Poor you! (5 cut damage)") };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "I'm surprised that you expected more from a plant.") };
            }
        }
    }
}
