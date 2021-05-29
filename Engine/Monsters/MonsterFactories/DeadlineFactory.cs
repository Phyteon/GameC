using System;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    public class DeadlineFactory : MonsterFactory
    {
        private int encounterNumber = 0; 
        public override Monster Create()
        {
            if (encounterNumber <= 5)
            {
                encounterNumber++;
                return new Deadline();
            }
            else
            {
                int chance = Index.RNG(0, 100000);
                encounterNumber++;
                if (chance == 21370)
                {
                    return new Deadline(2000 * encounterNumber * encounterNumber, 1000 * encounterNumber, 500 + encounterNumber * encounterNumber,
                        500 + encounterNumber * 2, 500, 10000);
                }
                return new Deadline(30 + encounterNumber * encounterNumber, 50 + encounterNumber * encounterNumber, 100 + encounterNumber * encounterNumber,
                    50 + encounterNumber * 2, 100, 50);
            }
        }
        public override System.Windows.Controls.Image Hint()
        {
            return new Deadline().GetImage();
        }
    }
}