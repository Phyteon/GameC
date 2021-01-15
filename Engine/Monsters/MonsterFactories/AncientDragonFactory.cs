using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class AncientDragonFactory : MonsterFactory
    {
        int EncounterNumber = 0;
        public override Monster Create()
        {
            if (EncounterNumber == 0)
            {
                EncounterNumber++;
                return new AncientDragon();
            }
            else return null;
        }

        public override System.Windows.Controls.Image Hint()
        {
            if (EncounterNumber == 0) return new AncientDragon().GetImage();
            else return null;
        }
    }
}
