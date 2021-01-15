﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class ChinchillaFactory : MonsterFactory
    {
        private int encounterNumber = 0;

        public override Monster Create()
        {
            if (encounterNumber == 0)
            {
                if (Index.RNG(1, 101) > 80)
                    encounterNumber = 1;
                else
                    encounterNumber = 2;
                return new Chinchilla();
            }
            else if (encounterNumber == 1)
            {
                encounterNumber = encounterNumber + 2;
                return new ChinchillaAngel();
            }
            else if (encounterNumber == 2)
            {
                encounterNumber = encounterNumber + 2;
                return new ChinchillaDemon();
            }
            else return null;
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (encounterNumber == 0) return new Chinchilla().GetImage();
            else if (encounterNumber == 1) return new ChinchillaAngel().GetImage();
            else if (encounterNumber == 2) return new ChinchillaDemon().GetImage();
            else return null;
        }
    }
}
