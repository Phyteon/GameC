using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class StaggeredDragon : AncientDragonState
    {
        public override List<StatPackage> BattleMoveHandle()
        {
            dragon.Stamina += 30;
            return new List<StatPackage> { new StatPackage(DmgType.Other, 0, "Ancient dragon is staggered and is trying to regain focus. It is time for you to strike!")};
        }

        public override void ReactHandle(List<StatPackage> packs)
        {
            foreach (StatPackage pack in packs)
            {
                dragon.Health -= pack.HealthDmg*2;
                dragon.Strength -= pack.StrengthDmg*2;
                dragon.Armor -= pack.ArmorDmg*2;
                dragon.Precision -= pack.PrecisionDmg*2;
                dragon.MagicPower -= pack.MagicPowerDmg*2;
            }
            dragon.SetState(new WeakenedDragon());
        }
    }
}
