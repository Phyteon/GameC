using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    abstract class AncientDragonState
    {
        protected AncientDragon dragon;

        public void SetContext(AncientDragon _dragon)
        {
            this.dragon = _dragon;
        }

        public abstract List<StatPackage> BattleMoveHandle();

        public abstract void ReactHandle(List<StatPackage> packs);

    }
}
