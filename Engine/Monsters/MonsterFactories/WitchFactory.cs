using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class WitchFactory : MonsterFactory
    {
        private int encounterNumber = 0;
        public override Monster Create()
        {
            if (encounterNumber == 0)
            {
                encounterNumber++;
                int rng = Index.RNG(1, 51);
                if (rng > 20)
                    encounterNumber++;
                 return new Witch();
            }
            else if (encounterNumber == 1)
            {
                encounterNumber++;
                int rng = Index.RNG(1, 51);
                if (rng > 20)
                    encounterNumber++;
                 return new FireWitch();
            }
            else if (encounterNumber == 2)
            {
                encounterNumber++;
                return new DarkWitch();
            }
            else return null;
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (encounterNumber == 0) return new Witch().GetImage();
            else if (encounterNumber == 1) return new FireWitch().GetImage();
            else if (encounterNumber == 2) return new DarkWitch().GetImage();
            else return null;

        }
    }
}
