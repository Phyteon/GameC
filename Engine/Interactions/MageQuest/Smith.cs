using Game.Engine.Items.AmuletsAndPotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.MageQuest
{
    [Serializable]

    class Smith:ListBoxInteraction
    {
            
        private HelpfulMage myMage;

        public Smith(GameSession ses, HelpfulMage myMage) : base(ses) //#1
        {
            Name = "interaction1122";
            Enterable = true;
            this.myMage = myMage;
        }

        protected override void RunContent()
        {
            if (myMage.PartOfHelpfulMageQuest == 5) //#1
            {
                parentSession.SendText("\nHello Adventurer, I'm Smith! Piright said that you would come, i see you have receipe of Item, that's good, let me a second, i have something for you!");
                parentSession.AddThisItem(new AmuletOfHealing());
                return;

            }
            else
            {
                parentSession.SendText("\nHey i'm Smith, how can i help you?");

                int choice1 = GetListBoxChoice(new List<string>() { "What do you do?", "Nevermind" });
                switch (choice1)
                {
                    case 0:
                        parentSession.SendText("\nIf you wanna i can craft for you random Item, it will cost you 80 gold");
                        int choice2 = GetListBoxChoice(new List<string>() { "Paid 80 gold and get random Item", "Sorry, I'm not interested" });
                        switch (choice2)
                        {
                            case 0:
                                {
                                    parentSession.AddRandomItem();
                                    break;
                                }
                            case 1:
                                {
                                    parentSession.SendText("Okey, that's not a problem, see you soon");
                                    break;
                                }

                        }
                        break;
                    case 1:

                        parentSession.SendText("Okey, see you soon");
                        break;
                    default:
                        parentSession.SendText("\nNevermind...");
                        break;
                }

                return;
            }


        }
    }
}
