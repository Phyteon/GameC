using System;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    public class DeadlineFactory : MonsterFactory
    {
        private int encounterNumber = 0;
        public override Monster Create()
        {
            if (encounterNumber < 2)
            {
                encounterNumber++;
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