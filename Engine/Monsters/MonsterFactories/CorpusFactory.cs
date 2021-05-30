using System;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    public class CorpusFactory : MonsterFactory
    {
        private int encounterNumber = 0;
        public override Monster Create()
        {
            if (encounterNumber == 0)
            {
                encounterNumber++;
                return new Corpus();
            }
            else if (encounterNumber == 1)
            {
                encounterNumber++;
                return new CorpusElite();
            }
            else return null;
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (encounterNumber == 0) return new Corpus().GetImage();
            else if (encounterNumber == 1) return new CorpusElite().GetImage();
            else return null;
        }
    }
}