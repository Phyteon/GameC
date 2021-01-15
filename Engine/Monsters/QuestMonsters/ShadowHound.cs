using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Monsters
{
    [Serializable]
    class ShadowHound : Monster
    {
        public ShadowHound()
        {
            Health = 40;
            Strength = 35;
            Armor = 20;
            Precision = 80;
            MagicPower = 50;
            Stamina = 220;
            XPValue = 140;
            Name = "monster0016";
            BattleGreetings = null;
        }
        public override List<StatPackage> BattleMove()
        {
            return new List<StatPackage>() { new StatPackage(DmgType.Psycho, 15 + strength, "Shadow Hound bites you. (" + (30 + strength) + " psycho damage)") };
        }
        public override void React(List<StatPackage> packs)
        {
            int dodgeAttack = Index.RNG(0, 100); // chance to dodge attack is 75%
            if (dodgeAttack < 75)
            {
                return;
            }
            else
            {
                foreach (StatPackage pack in packs)
                {
                    Health -= pack.HealthDmg;
                    Strength -= pack.StrengthDmg;
                    Armor -= pack.ArmorDmg;
                    Precision -= pack.PrecisionDmg;
                    MagicPower -= pack.MagicPowerDmg;
                }
            }

        }
    }
}
