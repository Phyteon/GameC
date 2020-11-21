using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Muses
{
    [Serializable]
    class EuterpeEncounter: PlayerInteraction
    {
        public bool meetEuterpe = false;
        private bool meet2 = false;
        private bool isNervous = false;
        private ApolloEncounter apollo;

        public EuterpeEncounter(GameSession ses, ApolloEncounter apollo) : base(ses)
        {
            Name = "interaction1363";
            this.apollo = apollo;
        }
        protected override void RunContent()
        {
            if (apollo.isQuestActive == false) // before first meeting
            {
                parentSession.SendText("\n*Euterpe crying* What do you want? Leave me alone! I don't wanna talk!");
                return;
            }
            if (apollo.meetPolyhymnia1 == true && meetEuterpe == false && isNervous == false) // first meeting, after talking to Polyhymnia
            {
                parentSession.SendText("\n*Euterpe crying* What are you doing here? Leave me alone!");
                int choice = parentSession.GetListBoxChoice(new List<string>() { "Can we just talk?", "Ok, sorry." });
                switch (choice)
                {
                    case 0:
                        parentSession.SendText("I'm not feeling well, I lost my instrument, my sisters think I stole the Terpsichore's Lyre...");
                        int choice2 = parentSession.GetListBoxChoice(new List<string>() { "Maybe they are right.", "I understand you must feel terrible. How can I help you?" });
                        switch (choice2)
                        {
                            case 0:
                                parentSession.SendText("Are you kidding? I would never do that! I love my sisters and I don't want to argue with them!\nGo away, if you're also going to accuse me, I don't want to talk to you.");
                                isNervous = true;
                                break;
                            default:
                                meetEuterpe = true;
                                parentSession.SendText("Thak you so much, it would be great if you get my Flute back from Erato. I will try to find out something about the Lyre.");
                                break;
                        }
                        break;
                    default: //kiedy rezygnujemy z rozmowy
                        break;
                }
                return;
            }
            if (isNervous && meetEuterpe == false) // wkurzona, po pierwszym spotkaniu
            {
                parentSession.SendText("\nEuterpe: Why did you come here again? Will you still accuse me?");
                int choice = parentSession.GetListBoxChoice(new List<string>() { "No, I want to apologize. I trust you. How can I help?", "Haha! Nobody will believe your fairy tales!" });
                switch (choice)
                {
                    case 0:
                        meetEuterpe = true;
                        parentSession.SendText("Thanks, it would be great if you get my Flute back from Erato. I will try to find out something about the Lyre.");
                        break;
                    default:
                        parentSession.SendText("I will not waste time talking to you.");
                        break;
                }
                return;
            }
            if(meetEuterpe && apollo.getFlute == false) // po pierwszysm spotkaniu i przekazanej informacj
            {
                parentSession.SendText("\nEuterpe: I don't have new information. Go get my flute back!");
                return;
            }

            if (apollo.getFlute && meet2 == false)
            {
                parentSession.SendText("\nEuterpe: Do you have my Flute?");
                int choice = parentSession.GetListBoxChoice(new List<string>() { "Yes, here it is.  *give Flute back" });
                switch (choice)
                {
                    case 0:
                        parentSession.RemovableItems = true;
                        parentSession.SendText("Thank you! Give me it back and I have something for you...");
                        parentSession.SendText("\n*** drag Flute outside of the item grid ***");
                        meet2 = true;
                        //zwróć item
                        break;
                }
                return;
            }
            if (meet2 && apollo.isQuestEnd == false)
            {
                if (parentSession.TestForItem("item1364"))
                {
                    parentSession.SendText("\n*** drag Flute outside of the item grid ***");
                    //zwróc item
                    return;
                }
                else
                {
                    parentSession.SendText("Thank you! Finally we have a happy end. Thank you for your help. This magic potion is for you.");
                    parentSession.RemovableItems = false;
                    parentSession.SendText("*** +50MP ***");
                    parentSession.UpdateStat(5, 50);
                    apollo.isQuestEnd = true;
                    return;
                }
            }
            else
            {
                parentSession.SendText("Euterpe: Hello! You have greetings from the world of gods!");
                return;
            }
        }
    }
}
