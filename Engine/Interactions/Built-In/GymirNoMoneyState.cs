using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Built_In
{
    [Serializable]
    class GymirNoMoneyState : GymirState
    {
        public override void RunContent(GameSession parentSession, GymirEncounter myself, HymirEncounter myBrother)
        {
            parentSession.SendText("\nHello there. Would you mind helping me chop wood again?");
            // get player choice
            int choice = parentSession.GetListBoxChoice(new List<string>() { "Sure, no problem!", "Everything comes with a price, you know.", "Do I look like a lumberjack to you?" });
            switch (choice)
            {
                case 0:
                    ChopWood(parentSession, myself, myBrother);
                    break;
                case 1:
                    parentSession.SendText("Sorry, I really don't have any spare money this time...");
                    int choice2 = parentSession.GetListBoxChoice(new List<string>() { "*Sighs* Fine.", "Sorry, no deal then." });
                    if (choice2 == 0)
                    {
                        ChopWood(parentSession, myself, myBrother);
                    }
                    else parentSession.SendText("People these days... go away then!");
                    break;
                default:
                    parentSession.SendText("No, you look like a useless vagabond. Go away!");
                    break;
            }
        }

        private void ChopWood(GameSession parentSession, GymirEncounter myself, HymirEncounter myBrother)
        {
            parentSession.SendText("Great! You can use my axe over there.");
            int choice = parentSession.GetListBoxChoice(new List<string>() { "Spend the next hour chopping wood", "Wait until he goes back to his home and run away with the axe" });
            if (choice == 0)
            {
                parentSession.SendText("Thank you so much for your help! You should meet my brother Hymir, he is a really nice person just like you.");
                myBrother.Strategy = new HymirFriendlyStrategy(); // Hymir will hear about this and he will like you now
                myself.ChangeState(new GymirCompleteState(), true); // this interaction is now complete
            }
            else
            {
                parentSession.SendText("Wait, what are you doing? COME BACK HERE!");
                parentSession.AddThisItem(Index.ProduceSpecificItem("item1261")); //silver axe
                myBrother.Strategy = new HymirHostileStrategy(); // Hymir will hear about this and he will hate you now
                myself.ChangeState(new GymirHostileState(), true); // this interaction is now complete, but Gymir will no longer let you work here
            }
        }
    }
}
