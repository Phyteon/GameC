using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class MandragoraFactory : MonsterFactory
    {
        // this factory produces Mandragoras or Mandragorians

        private int encounterNumber = 0; // how many times has this factory been used already?
        public override Monster Create()
        {
            if (encounterNumber == 0) // if this is the first time, return a Mandragora
            {
                encounterNumber++;
                return new Mandragora();
            }
            else if (encounterNumber == 1) // if this is the second time, return a Mandragorian
            {
                encounterNumber++;
                return new Mandragorian();
            }
            else return null; // no more Mandragoras to fight
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (encounterNumber == 0) return new Mandragora().GetImage();
            else if (encounterNumber == 1) return new Mandragorian().GetImage();
            else return null;
        }
    }
}