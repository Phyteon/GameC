using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class SnakeFactory : MonsterFactory
    {
        private int encounterNumber = 0; // how many times has this factory been used already?
        public override Monster Create()
        {
            if (encounterNumber == 0) // if this is the first time, return a Viper
            {
                encounterNumber++;
                return new Viper();
            }
            else if (encounterNumber == 1) // if this is the second time, return a Rattlesnake
            {
                encounterNumber++;
                return new Rattlesnake();
            }
            else if (encounterNumber == 2) // if this is the third time, return a Cobra
            {
                encounterNumber++;
                return new Cobra();
            }
            else if (encounterNumber == 3) // if this is the fourth time, return a Python
            {
                encounterNumber++;
                return new Python();
            }
            else return null; // no more snakes to fight
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (encounterNumber == 0) return new Viper().GetImage();
            else if (encounterNumber == 1) return new Rattlesnake().GetImage();
            else if (encounterNumber == 2) return new Cobra().GetImage();
            else if (encounterNumber == 3) return new Python().GetImage();
            else return null;
        }
    }
}
