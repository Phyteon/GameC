using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class BoulderFactory : MonsterFactory
    {
        private int b;
        List<int> numbers = new List<int>();
        private int x = 1;
        public BoulderFactory()
        {           
            for (int i= 0; i<=2; i++)
            {
                b = Index.RNG(0, 3);
                numbers.Add(b);                
            }                       
        }
        public override Monster Create()
        {
            if (numbers[x-1] == 0)
            {
                x++;
                return new Boulder();
            }
            else if (numbers[x-1] == 1)
            {
                x++;
                return new BoulderBeast();
            }
            else if (numbers[x-1] == 2)
            {
                x++;
                return new DiamondBeast();
            }
            else return null;
        }

        public override System.Windows.Controls.Image Hint()
        {
            //resetX();
            if (numbers[x-1] == 0) return new Boulder().GetImage();
            else if (numbers[x-1] == 1) return new BoulderBeast().GetImage();
            else if (numbers[x-1] == 2) return new DiamondBeast().GetImage();
            else return null;
        }

        /*private object resetX()
        {
            if (x > 3)
                return null;
            else return x;

                //x = 1;
        }*/
        private void resetX()
        {
            if (x > 3) x = 1;
        }
    }
}
