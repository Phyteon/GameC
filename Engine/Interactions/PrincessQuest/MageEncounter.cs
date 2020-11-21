using System;
using System.Collections.Generic;
using Game.Engine.Items;
using Game.Engine.Interactions;

namespace Game.Engine.Interactions.PrincessQuest
{
    [Serializable]
    class MageEncounter : PlayerInteraction
    {
        public int visited = 0;
        public bool ifQuestStarted = false;
        public TowerEncounter tower;
        public IMageStrategy Strategy { get; set; }
        public MageEncounter(GameSession ses, TowerEncounter tower) : base(ses) 
        {
            Name = "interaction1081";
            Strategy = new MageNeutralStrategy();
            this.tower = tower;
        }
        protected override void RunContent()
        {
            if (ifQuestStarted == false)
            {
                Strategy.Execute(parentSession, visited);
                visited++;
            }
            else if (ifQuestStarted == true && visited == -2) //if quest started and the mage already asked you about the amulet
            {
                if (parentSession.TestForItem("item0863") == true)
                {
                    parentSession.SendText("\nI see you got this amulet. Maybe you'll be the first one that won't end up as a dragon's breakfast. " +
                        "Now I can help you deal with a witch - you don't have to worry about her - but the beast is on you.");
                    int choice2 = parentSession.GetListBoxChoice(new List<string>() { "Ok mage, farewell then and good luck to us both!", "Wait... Can you tell me what" +
                        " happened with the princess? The king seemed very sketchy about this situation..."});
                    if (choice2 == 0)
                    {
                        visited = -3;
                        tower.ifMageVisited = true;//now you need to go to the tower
                        return;
                    }
                    if (choice2 == 1)
                    {
                        parentSession.SendText("\nThus was a scary and sad story. The witch that kidnapped the girl was her godmother. She promised " +
                            "to guard her and in exchange the King promised to give her the biggest treasure he had in his kingdom - the staff of " +
                            "imortality. When the time came the witch got really mad at king for not keeping his promise, and took what was also " +
                            "the most dear to his heart - his daughter. The king went to the tower and tried to give the staff to the godmother, but " +
                            "she was blinded by anger and turned crazy. Now the princess is stuck in the tower, but the witch is weak and I can easily deal with her" +
                            ". The dragon on the other hand is your duty. Good luck .");
                        int choice3 = parentSession.GetListBoxChoice(new List<string>() { "Wow, thank you mage. Good luck." });
                        if (choice3 == 0)
                        {
                            tower.ifMageVisited = true;
                            visited = -3;
                            return;
                        }
                    }
                }
            }
            else if (ifQuestStarted == true && visited == -3) //you need to go to the tower now
            {
                parentSession.SendText("\nWhat are you doing here? Go to the tower and kill that dragon!");
            }
            else if (ifQuestStarted == true && visited == -4) //if quest is done
            {
                parentSession.SendText("\nDo you remember good old times? Killing the dragon was a good adventure...");
            }
            else //if you come here after castle
            {
                visited = -1;
                parentSession.SendText("\nYou've come a long way from the castle. I can help you win this fight, if you prove yourself to me!");
                int choice1 = parentSession.GetListBoxChoice(new List<string>() { "What do you need old mage?", "It's too much work, maybe " +
                    "I'll come back here another time."});
                if (choice1 == 0)
                {
                    parentSession.SendText("You need to find the Supporting Amulet. When you do, come back and we'll talk.");
                    visited = -2; //now you can talk with the mage about the amulet
                    return;
                }
                if (choice1 == 1)
                {
                    return;
                }
            }
        }
    }
}
