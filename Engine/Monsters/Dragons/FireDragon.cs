using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class FireDragon : Monster
    {
        public FireDragon(int fireDragonLevel)
        {
            Health = 10 + 7 * fireDragonLevel;
            Strength = 80 + fireDragonLevel;
            Armor = 30;
            Precision = 50;
            MagicPower = 25;
            Stamina = 100;
            XPValue = 100 + fireDragonLevel;
            Name = "monster1260";
            BattleGreetings = "Global warming is nothing compared to me!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Random random = new Random();
                if (random.NextDouble() >= 0.5)
                {
                    Stamina -= 10;
                    return new List<StatPackage>()
                    { 
                        new StatPackage(DmgType.stab, Strength - 20, "Fire Dragon uses Fire Breathe! (" + (Strength - 20) + " stab damage)"),
                        new StatPackage(DmgType.fire, 20, "Fire have burnt your skin! (20 fire damage)")
                    };
                }
                else
                {
                    Stamina -= 5;
                    return new List<StatPackage>() { new StatPackage(DmgType.stab, Strength - 65, "Fire Dragon uses Tail Punch! (" + (Strength - 65) + " stab damage)") };
                }
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.none, 0, "Fire Dragon has no energy to attack anymore!") };
            }
        }
    }
}
