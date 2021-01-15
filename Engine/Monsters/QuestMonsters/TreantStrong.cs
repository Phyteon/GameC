using Game.Engine.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.Built_In
{
    class TreantStrong : Monster
    {
        public int SpecialAttackCounter { get; protected set; }
        public TreantStrong()
        {
            Health = 325;
            Strength = 30;
            Armor = 10;
            Precision = 50;
            Stamina = 200;
            XPValue = 135;
            Name = "monster0012";
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
            Stamina += 100;
            Health += 20;
            return new List<StatPackage>() { new StatPackage(DmgType.Earth, 30, "Treant used vitality drain. He restores 75 stamina and 20 health. (" + (30) + " earth magic damage)") };
        }
    }
}
