using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class WaspFactory : MonsterFactory
    {
        private int a = 0;    //encounter number
        public override Monster Create()
        {
            if (a == 0)
            {
                a++;
                return new Wasp();
            }

            else if (a == 1)
            {
                a++;
                return new Wasp();
            }

            else if (a == 2)
            {
                a++;
                return new MagicWasp();
            }

            else return null;
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (a == 0) return new Wasp().GetImage();

            else if (a == 1) return new Wasp().GetImage();

            else if (a == 2) return new MagicWasp().GetImage();

            else return null;
        }


    }
}
