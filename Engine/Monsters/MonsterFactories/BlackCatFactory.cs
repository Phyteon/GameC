using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class BlackCatFactory : MonsterFactory
    {
        private int encounterNumber = 0;
        public override Monster Create()
        {
            if (encounterNumber == 0)
            {
                encounterNumber++;
                int rng = Index.RNG(1, 101);
                if (rng > 50)
                {
                    encounterNumber++;
                }
                return new BlackCat();
            }
            else if (encounterNumber == 1)
            {
                encounterNumber++;
                return new CatWizard();
            }
            else return null;
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (encounterNumber == 0) return new BlackCat().GetImage();
            else if (encounterNumber == 1) return new CatWizard().GetImage();
            else return null;
        }
    }
}
