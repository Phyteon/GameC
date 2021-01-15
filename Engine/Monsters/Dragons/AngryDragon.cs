using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class AngryDragon :AncientDragonState
    {
        public override List<StatPackage> BattleMoveHandle()
        {
            if (dragon.Stamina > 0)
            {
                dragon.Stamina -= 60;
                return new List<StatPackage> { new StatPackage(DmgType.Crush, 50 + dragon.Strength, "Ancient dragon smashes you for " + (50 + dragon.Strength) + " damage."),
                                               new StatPackage(DmgType.Fire, 100 + dragon.MagicPower, "Ancient dragon breathes fire on you, dealing " + (100 + dragon.MagicPower) + " damage.")};
            }
            else
            {
                dragon.Stamina += 150;
                dragon.SetState(new WeakenedDragon());
                return new List<StatPackage> { new StatPackage(DmgType.Air, 10 + dragon.MagicPower/4, "Ancient dragon flaps its wings dealing " + (10 + dragon.MagicPower / 2) + " damage.") };
            }
        }

        public override void ReactHandle(List<StatPackage> packs)
        {
            foreach (StatPackage pack in packs)
            {
                dragon.Health -= pack.HealthDmg/2;
                dragon.Strength -= pack.StrengthDmg/2;
                dragon.Armor -= pack.ArmorDmg/2;
                dragon.Precision -= pack.PrecisionDmg/2;
                dragon.MagicPower -= pack.MagicPowerDmg/2;
            }
        }
    }
}
