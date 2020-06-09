using Game.Engine.Items;
using System;
namespace Game.Engine.Interactions.PrincessQuest
{
    [Serializable]
    class SmithEncounter : ConsoleInteraction
    {
        private KingEncounter king;
        private RingCreatureEncounter ring;
        public int visited = 0;
        public SmithEncounter(GameSession ses, KingEncounter k, RingCreatureEncounter r) : base(ses)
        {
            Name = "interaction1084";
            king = k;
            ring = r;
        }
        protected override void RunContent()
        {

            if (king.visited >= -1) //if saving princess quest isn't done yet
            {
                parentSession.SendText("To unlock this interaction you must complete the Saving Princess Quest. Find castle and kill the dragon.");
                return;
            }
            if (king.visited == -2 && visited == 0) // if you completed the princess saving quest and now you came here for the first time
            {
                parentSession.SendText("\nSMITH: I've heard you've saved the great King's daughter from the evil witch and the dragon! That's impressive, " +
                    "I might find some work for you... Go and find the old cave, you'll find a creature there - it bothers me for years now, but nobody " +
                    "could help me get rid of it. Please take care of it and come back ");
                king.visited = -3;
                visited = 1;
                return;
            }
            if (king.visited == -3 && visited >= 1 && ring.visited != -3) // if you've been here before and started the golum quest
            {
                parentSession.SendText("\nSMITH: Did you get the amulet yet? No? Find it then and come back!");
                visited++;
                return;
            }
            if (king.visited == -3 && visited >= 1 && ring.visited == -3)
            {
                parentSession.SendText("\nSMITH: I see you've killed the gollum! I can give you an infinity ring now as a prize. Thank you!");
                parentSession.AddThisItem(new InfinityRings());
                parentSession.UpdateStat(7, 100);
                visited = -1;
                return;
            }
            if (visited == -1)
            {
                parentSession.SendText("\nSMITH: It's nice to see you again, but I don't have any work for you now.");
            }

        }
    }
}
