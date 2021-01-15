using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class SlimeFactory : MonsterFactory
    {
        private int encounterNumber = 0;
        public override Monster Create()
        {
            if (encounterNumber == 0)
            {
                encounterNumber++;
                return new SmallSlime();
            }
            else if (encounterNumber == 1)
            {
                encounterNumber++;
                return new MediumSlime();
            }
            else if (encounterNumber == 2)
            {
                encounterNumber++;
                return new BigSlime();
            }
            else return null;
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (encounterNumber == 0) return new SmallSlime().GetImage();
            else if (encounterNumber == 1) return new MediumSlime().GetImage();
            else if (encounterNumber == 2) return new BigSlime().GetImage();
            else return null;
        }
    }
}
