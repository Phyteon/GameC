using System;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    public class DeadlineFactory : MonsterFactory
    {
        private int encounterNumber = 0;
        private int chance;

        public DeadlineFactory()
        {
            chance = Index.RNG(0, 101);
        }
        public override Monster Create()
        {
            if (encounterNumber == 0)
            {
                encounterNumber++;
                return new Deadline();
            }
            else if (encounterNumber == 1)
            {
                encounterNumber++;
                if (chance == 21)
                {
                    //return new Deadline(2000 * encounterNumber * encounterNumber, 1000 * encounterNumber,
                        //500 + encounterNumber * encounterNumber,
                        //500 + encounterNumber * 2, 500, 10000);\
                    return new Deadline();
                }

                //return new Deadline(30 + encounterNumber * encounterNumber, 50 + encounterNumber * encounterNumber,
                    //100 + encounterNumber * encounterNumber,
                    //50 + encounterNumber * 2, 100, 50);
                return new Deadline();
            }
            else return null;
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (encounterNumber < 2) return new Deadline().GetImage();
            else return null;
        }
    }
}