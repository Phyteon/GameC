using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    class ArabicSkeleton : Monster
    {
        public ArabicSkeleton(int skeletonLevel)
        {
            Health = 30 + 5 * skeletonLevel;
            Strength = 10 + 5 * skeletonLevel;
            Armor = 0;
            Precision = 20;
            MagicPower = 20;
            Stamina = 50;
            XPValue = 20 + 5* skeletonLevel;
            Name = "monster0830";
            BattleGreetings = "Hi! I miss a bone... Can I borrow yours?";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 10;
                return new List<StatPackage>() { new StatPackage(DmgType.stab, 5 + Strength, "Skeleton stabs you!(" + (10 + Strength) + " stab damage)") };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.none, 0, "Skeleton has no energy to attack anymore!") };
            }
        }
    }
}
