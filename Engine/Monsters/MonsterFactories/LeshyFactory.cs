using System.Windows.Controls;
using System;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class LeshyFactory : MonsterFactory
    {
        private int counter = 0;
        public override Monster Create()
        {
            if(counter < 4)
            {
                ++counter;
                return new Crow();
            }
            else if (counter == 4)
            {
                ++counter;
                return new Leshy();
            }
            else
                return null;
        }

        public override Image Hint()
        {
            if (counter < 4)
                return new Crow().GetImage();
            else if (counter == 4)
                return new Leshy().GetImage();
            else
                return null;
        }
    }
}
