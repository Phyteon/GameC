using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Monsters.Built_In;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class HumanCatcherFactory : MonsterFactory
    {
        private int a = 0;
        public override Monster Create()
        {
            if (a == 0)
            {
                a++;
                return new HumanCatcher();
            }
            else return null;
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (a == 0) return new HumanCatcher().GetImage();

            else return null;
        }
    }
}
