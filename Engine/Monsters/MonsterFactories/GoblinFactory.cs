using System;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    public class GoblinFactory : MonsterFactory
    {
        private int encounterNumber = 0;

        public override Monster Create()
        {
            if (encounterNumber < 2)
            {
                encounterNumber++;
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