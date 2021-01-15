using Game.Engine.Monsters.Built_In;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class TrollFactory : MonsterFactory
    {
        private int encounterNumber = 0; 
        public override Monster Create()
        {
            if (encounterNumber <=1) 
            {
                encounterNumber++;
                return new Troll();
            }
            else if (encounterNumber == 2) 
            {
                encounterNumber++;
                return new TrollEvolved();
            }
            else return null; 
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (encounterNumber <=1 ) return new Troll().GetImage();
            else if (encounterNumber == 2) return new TrollEvolved().GetImage();
            else return null;
        }
    }
}
