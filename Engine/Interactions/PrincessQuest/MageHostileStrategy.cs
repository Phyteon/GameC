using System;

namespace Game.Engine.Interactions.PrincessQuest
{
    [Serializable]
    class MageHostileStrategy : IMageStrategy
    {
        public void Execute(GameSession ses, int visited)
        {
            ses.SendText("I've heard you've made the great King mad! Why are you looking for trouble here? Run away!");
        }
    }
}
