using Game.Engine.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.Built_In
{
    class TreantWeak : Monster
    {
        public int SpecialAttackCounter { get; protected set; }
        public TreantWeak()
        {
            Health = 325;
            Strength = 30;
            Armor = 10;
            Precision = 50;
            Stamina = 200;
            XPValue = 135;
            Name = "monster0013";
            BattleGreetings = "I shall protect my forest";
            SpecialAttackCounter = 0;
        }
        public override List<StatPackage> BattleMove()
        {
            if (Health >= 150) //phase one
            {
                return StandardAttack();
            }
            else //phase two
            {
                switch (SpecialAttackCounter)
                {
                    case 3:
                        SpecialAttackCounter = 0;
                        return VitalityDrain();
                    default:
                        SpecialAttackCounter += 1;
                        return StandardAttack();
                }

            }

        }
        protected List<StatPackage> StandardAttack()
        {
            if (Stamina > 25)
            {
                Stamina -= 25;
                return new List<StatPackage>() { new StatPackage(DmgType.Crush, 15 + Strength, "Treant swings his giant arm at you," + (15 + Strength) + " crush damage") };
            }
            else
            {
                return VitalityDrain();
            }
        }
        protected List<StatPackage> VitalityDrain()
        {
            Stamina += 15;
            Health += 5;
            return new List<StatPackage>() { new StatPackage(DmgType.Earth, 10, "Treant used vitality drain, but it's power is greatly reduced. He restores 20 stamina and 10 health. (" + (5) + " earth magic damage)") };
        }
    }
}
