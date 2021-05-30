using System;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    public class GoblinFactory : MonsterFactory
    {
        private int encounterNumber = 0;
        private int chance;
        public GoblinFactory()
        {
            chance = Index.RNG(0, 101);
        }
        
        public override Monster Create()
        {
            if (encounterNumber == 0)
            {
                encounterNumber++;
                return new Goblin();
            }
            else if (encounterNumber == 1)
            {
                encounterNumber++;
                if (chance == 21)
                {
                    //return new Goblin(2000 * encounterNumber, 500 + encounterNumber * encounterNumber,
                        //500 + encounterNumber * encounterNumber,
                        //500 + encounterNumber * 2, 500, 10000);
                    return new Goblin();
                }

                //return new Goblin(100 + encounterNumber * encounterNumber, 30 + encounterNumber * encounterNumber,
                    //40 + encounterNumber * encounterNumber,
                    //50 + encounterNumber * 2, 100, 100);
                return new Goblin();
            }
            else return null;
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (encounterNumber < 2) return new Goblin().GetImage();
            else return null;
        }
    }
}