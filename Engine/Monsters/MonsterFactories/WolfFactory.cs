using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class WolfFactory : MonsterFactory
    {
        private int a = 0;
        public override Monster Create()
        {
            if (a == 0)
            {
                a++;
                return new YoungWolf();
            }

            else if (a == 1)
            {
                a++;
                return new OldWolf();
            }
            
            else return null;
        }

        public override System.Windows.Controls.Image Hint()
        {
            if (a == 0) return new YoungWolf().GetImage();
            else if (a == 1) return new OldWolf().GetImage();
            else return null;
        }
    }
}
