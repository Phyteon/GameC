using Game.Engine.Interactions.Built_In;
using Game.Engine.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions
{
    // meet with an old troll named Gymir
    // Gymir has also a brother - Hymir

    [Serializable]
    class GymirEncounter : PlayerInteraction
    {
        private GymirState currentState; // current state of this interaction (design pattern)
        private HymirEncounter myBrother; // store reference to Hymir    
        public GymirEncounter(GameSession ses, HymirEncounter myBrother) : base(ses)
        {
            parentSession = ses;
            Name = "interaction0003";
            this.myBrother = myBrother; // set reference to Hymir
            currentState = new GymirInitialState();
        }
        protected override void RunContent()
        {
            currentState.RunContent(parentSession, this, myBrother);
        }
        public void ChangeState(GymirState newState, bool isCompleted = false)
        {
            currentState = newState;
            if (isCompleted) Complete = true; // while changing state, we may also want to set this property
        }


        /*

        private int visited = 0; // how many times have you visited this place?
        private int payment = 0;
        protected override void RunContent()
        {
            if (visited == -1) // already visited this place and bad things happened 
            {
                parentSession.SendText("\nYou again, thief? Just wait until my back pain gets better... ");
                return;
            }
            if (visited > 0) // already visited this place 
            {
                parentSession.SendText("\nOh, hello. Thanks for coming, but I don't have any job for you right now.");
                return;
            }
            // standard encounter
            parentSession.SendText("\nHello adventurer. My name is Gymir. Could you help me chop this wood?");
            // get player choice
            int choice = parentSession.GetListBoxChoice(new List<string>() { "Sure, no problem!", "Everything comes with a price, you know.", "Do I look like a lumberjack to you?" });
            switch(choice)
            {
                case 0:
                    payment = 0;
                    ChopWood();
                    break;
                case 1:
                    parentSession.SendText("Come on, I don't have much money... is 15 gold enough?");
                    int choice2 = parentSession.GetListBoxChoice(new List<string>() { "*Sighs* Fine.", "Sorry, that's not enough." });
                    if(choice2 == 0)
                    {
                        payment = 15;
                        ChopWood();
                    }
                    else parentSession.SendText("People these days... go away then!");
                    break;
                default:
                    parentSession.SendText("No, you look like a useless vagabond. Go away!");
                    break;
            }
        }

        // what happens if you chop wood
        private void ChopWood()
        {
            parentSession.SendText("Great! You can use my axe over there.");
            int choice = parentSession.GetListBoxChoice(new List<string>() { "Spend the next hour chopping wood", "Wait until he goes back to his home and run away with the axe" });
            if(choice == 0)
            {
                if (payment == 0)
                {
                    parentSession.SendText("Thank you so much for your help! You should meet my brother Hymir, he is a really nice person just like you.");
                    myBrother.Strategy = new HymirFriendlyStrategy(); // Hymir will hear about this and he will like you now
                }
                else
                {
                    parentSession.SendText("Good. Here is your gold.");
                    parentSession.UpdateStat(8, payment); // +15 gold
                }
                visited++;
                Complete = true; // this interaction is now complete
            }
            else
            {
                parentSession.SendText("Wait, what are you doing? COME BACK HERE!");
                parentSession.AddThisItem(Index.ProduceSpecificItem("item1261")); //silver axe
                myBrother.Strategy = new HymirHostileStrategy(); // Hymir will hear about this and he will hate you now
                visited = -1; // Gymir will no longer let you work here
                Complete = true; // this interaction is now complete
            }
        }


        */
    }
}
