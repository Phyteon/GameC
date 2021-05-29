using System;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    public class GoblinFactory : MonsterFactory
    {
        private int encounterNumber = 0; 
        public override Monster Create()
        {
            if (encounterNumber == 0)
            {
                encounterNumber++;
                return new Goblin();
            }
            else
            {
                int chance = Index.RNG(0, 10000);
                encounterNumber++;
                if (chance == 2137)
                {
                    return new Goblin(2000 * encounterNumber, 500 + encounterNumber * encounterNumber, 500 + encounterNumber * encounterNumber,
                        500 + encounterNumber * 2, 500, 10000);
                }
                return new Goblin(100 + encounterNumber * encounterNumber, 30 + encounterNumber * encounterNumber, 40 + encounterNumber * encounterNumber,
                    50 + encounterNumber * 2, 100, 100);
            }
        }
        public override System.Windows.Controls.Image Hint()
        {
            return new Goblin().GetImage();
        }
    }
}