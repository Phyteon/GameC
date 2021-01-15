using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]

    class DragonFactory : MonsterFactory
    { 
        private int encounterNumber = 0;
        private int rng = Index.RNG(1, 11);

        public override Monster Create()
        {
            if (encounterNumber == 0) // if this is the first time, return a Shadow Dragon or Rainbow Dragon
            {
                encounterNumber++;
                if (rng > 5)
                    return new RainbowDragon();
                else
                    return new ShadowDragon();
                
            }
            else if (encounterNumber == 1) // if this is the second time, return a Skeletal Dragon
            {
                encounterNumber++;
                return new SkeletalDragon();
            }
            else if (encounterNumber == 2) 
            {
                encounterNumber++;
                return new IceDragon();
            }
            else return null; 
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (encounterNumber == 0 && rng > 5)
                return new RainbowDragon().GetImage();
            else if(encounterNumber == 0 && rng < 5)
                return new ShadowDragon().GetImage();
            else if (encounterNumber == 1) return new SkeletalDragon().GetImage();
            else if (encounterNumber == 2) return new IceDragon().GetImage();
            else return null;
        }
    }
}
