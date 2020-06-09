using System;

namespace Game.Engine.Interactions.PrincessQuest
{
    [Serializable]
    class MageNeutralStrategy : IMageStrategy
    {
        public void Execute(GameSession ses, int visited)
        {
            if (visited == 0)
            {
                ses.SendText("\nWhat are you doing here stranger? You aren't here about the princess? Go away then! Find a castle first.");
                visited++;
                return;
            }
            if (visited > 0)
            {
                ses.SendText("\nWhy are you coming back! Go away, find that castle first...");
            }
        }
    }
}
