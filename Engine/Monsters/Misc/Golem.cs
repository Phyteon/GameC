using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Golem:Monster
    {
        public Golem(int golemLevel)
        {
            Health = 150 +10 * golemLevel;
            Strength = 100 + 10*golemLevel;
            Armor = 10;
            Precision = 80;
            MagicPower = 0;
            Stamina = 0;
            XPValue = 100 + 2*golemLevel;
            Name = "monster0583";
            BattleGreetings = "I shall crush your weakling bones. Fear my strength"; //(he will do it in a while)
           
        }

        public override List<StatPackage> BattleMove()
        {
            if (stamina >= 10)
            {
                stamina = 0; return new List<StatPackage>() { new StatPackage(DmgType.Cut, strength * 2, "The golem attacks mightily with its stony hands. They're surprisingly sharp. " + strength*2 + " damage") };
            }
            else
            {
                int t = 10 - stamina;
                stamina++; return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "The golem is gearing up to an attack, it looks like he'll be ready in " + t + " turns") };
            }
        }
        public override void React(List<StatPackage> packs)//every spell that hits the golem quickens his attack
        {
           foreach(StatPackage foo in packs)
            {
                if (foo.DamageType == DmgType.Air || foo.DamageType == DmgType.Earth || foo.DamageType == DmgType.Water || foo.DamageType == DmgType.Fire || foo.DamageType == DmgType.Psycho || foo.DamageType == DmgType.Water) stamina++;
            }
            base.React(packs);
        }
    }
}
