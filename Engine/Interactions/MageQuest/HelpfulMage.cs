using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.MageQuest
{
    [Serializable]

    class HelpfulMage : ListBoxInteraction
    {
        public int PartOfHelpfulMageQuest { get; set; }

        public int NumberOfMagicThread { get; set; }

        public int NumberOfPhoenixFeather { get; set; }

        public int NumberOfGolemEye { get; set; }



        public HelpfulMage(GameSession ses) : base(ses)
        {
            Name = "interaction1120";
            PartOfHelpfulMageQuest = 0;
            NumberOfMagicThread = 0;
            NumberOfPhoenixFeather = 0;
            NumberOfGolemEye = 0;
            Enterable = false;
        }
        protected override void RunContent()
        {

            if (PartOfHelpfulMageQuest == 0)
            {
                parentSession.SendText("\nWelcome Adventurer! I'm Piright and i have dangerous mission for you, are you interested in this?");
                int choice1 = GetListBoxChoice(new List<string>() { "Yes, what is the mission?", "Sorry, maybe later" });
                switch (choice1)
                {
                    case 0:
                        parentSession.SendText("\nRecently, a lot of monsters have started to rule the world, can you take care of it?");
                        int choice2 = GetListBoxChoice(new List<string>() { "Okey, no problem", "Sorry, that's too much for me" });
                        if (choice2 == 0)
                        {
                            parentSession.SendText("\nPerfectly, let's start by clear SpiderCave, please find it and kill all 4 spiders which have Magic Thread! Then come back with Magic Thread to me");
                            PartOfHelpfulMageQuest += 1;
                        }
                        else parentSession.SendText("\nOh okey, so when you decide to do it come back");
                        break;
                    case 1:
                        parentSession.SendText("\nOh, okey, I will be waiting!");
                        break;
                    default:
                        parentSession.SendText("\nNevermind...");
                        break;
                }

                return;
            }
            // start with 1, if he make quest cave he get 2 level of quest
            if (PartOfHelpfulMageQuest == 1)
            {
                if (NumberOfMagicThread == 4)
                {
                    parentSession.SendText("\nCongratulations, i see that you clear the Cave! That's your reward (You got 40 xp and 20 gold)");
                    parentSession.UpdateStat(7, 40); //40 xp
                    parentSession.UpdateStat(8, 20); //20 gold
                    parentSession.SendText("\nNext part of mission is get Phoenix Feather, find the Phoenix Nest and kill the Phoenix to get it!");

                    PartOfHelpfulMageQuest += 1;
                }
                else
                {
                    parentSession.SendText("\nCome back when you get 4 Magic Thread!");
                }
                return;
            }
            //start with 2, if he make quest phoenix he get 3 level of quest
            if (PartOfHelpfulMageQuest == 2)
            {
                if (NumberOfPhoenixFeather == 2)
                {
                    parentSession.SendText("\nCongratulations, i see you bring me Phoenix Feather! That's your reward (You got 50 xp and 25 gold)");
                    parentSession.UpdateStat(7, 50);
                    parentSession.UpdateStat(8, 25);
                    parentSession.SendText("\nThe last part of mission is kill Golem and get his Eye, you can find Golem in Sanctuary, but take care it's demanding opponent! To get his Eye you need Power Catalizator, otherwise the eye will disappear. You can get Power Catalyst from my friend Herald, but he's on a expedition, so you have to find him first. He will know that i sent you, good luck!");
                    PartOfHelpfulMageQuest +=1;
                }
                else
                {
                    parentSession.SendText("\nCome back when you get 2 Phoenix Feather!");
                }
                return;
            }
            //start with 3, if he go to FriendlyMage, he get 4 level of quest and he will get eye golem
            if (PartOfHelpfulMageQuest == (3 | 4))
            {
                if (NumberOfGolemEye == 1)
                {
                    parentSession.SendText("\nCongratulations, i see you kill the Golem and get his eye! Here is reward! (You got 80 xp and 45 gold)");
                    parentSession.UpdateStat(7, 80);
                    parentSession.UpdateStat(8, 45);
                    parentSession.SendText("\nPlease get too this recipe of Item and find Smith, let him this recipe and he will give you a present from me");
                    PartOfHelpfulMageQuest +=1;
                }
                else
                {
                    parentSession.SendText("\nCome back when you get Golem's Eye!");
                }
                return;
            }
            //he start with 5 level of quest
            if (PartOfHelpfulMageQuest == 5)
            {
                parentSession.SendText("\nOh, hello. Thanks for coming, but I don't have any mission for you right now.");
                return;
            }

        }
    }
}

