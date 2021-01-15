using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class WeakenedDragon : AncientDragonState
    {
        public override List<StatPackage> BattleMoveHandle()
        {
            if (dragon.Stamina > 0)
            {
                dragon.Stamina -= 15;
                return new List<StatPackage> { new StatPackage(DmgType.Cut, 25 + dragon.Strength, "Ancient dragon cuts you with its wings for " + (25 + dragon.Strength) + " damage."),
                                               new StatPackage(DmgType.Air, 25 + dragon.MagicPower/2, "Ancient dragon wings' blow, deals " + (25 + dragon.MagicPower/2) + " damage.")};
            }
            else
            {
                dragon.Stamina += 90;
                dragon.SetState(new StaggeredDragon());
                return new List<StatPackage> { new StatPackage(DmgType.Crush, 50 + dragon.Strength, "Ancient dragon falls on the ground in anguish hurting you for " + (50 + dragon.Strength) + " damage, but it's exhausted. It's time to strike!") };
            }
        }

        public override void ReactHandle(List<StatPackage> packs)
        {
            foreach (StatPackage pack in packs)
            {
                dragon.Health -= pack.HealthDmg;
                dragon.Strength -= pack.StrengthDmg;
                dragon.Armor -= pack.ArmorDmg;
                dragon.Precision -= pack.PrecisionDmg;
                dragon.MagicPower -= pack.MagicPowerDmg;
                if (pack.HealthDmg > 50)
                {
                    if(Index.RNG(0,9) > 4)
                    {
                        dragon.SetState(new AngryDragon());
                    }
                    else
                    {
                        dragon.SetState(new StaggeredDragon());
                    }
                }
            }
        }
    }
}
