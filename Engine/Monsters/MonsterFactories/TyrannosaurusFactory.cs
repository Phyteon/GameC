using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class TyrannosaurusFactory : MonsterFactory
    {
        private int a = 0;
        public override Monster Create()
        {
            if (a == 0)
            {
                a++;
                return new Tyrannosaurus();
            }

            else return null;
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (a == 0) return new Tyrannosaurus().GetImage();

            else return null;
        }
    }
}
