using Game.Engine.Items.Attributes;
using Game.Engine.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Game.Engine.Interactions.Muses
{
    [Serializable]
    class ApolloEncounter : ListBoxInteraction
    {
        public bool isQuestActive = false;
        public bool isQuestEnd = false;
        public bool meetApollo1 = false;
        public bool meetApollo2 = false;
        public bool meetPolyhymnia1 = false;
        public bool meetPolyhymnia2 = false;
        public bool getLyre = false;
        public bool getFlute = false;
        public bool getKithara = false;

        public ApolloEncounter(GameSession ses) : base(ses)
        {
            Name = "interaction1360";
        }
        protected override void RunContent()
        {
            if (isQuestActive == false && meetApollo1 == false) //first meeting
            {
                FirstMeeting();
                return;
            }

            if(meetApollo1 == true && meetPolyhymnia1 == false) //interactions after first meeting
            {
                int k = Index.RNG(0, 100);
                if (k < 50)
                {
                    parentSession.SendText("\nYhym... I think everything started with Erato...");
                    return;
                }
                else
                {
                    parentSession.SendText("\nDo you have any news? Come back when you have something.");
                    return;
                }
            }

            if (meetPolyhymnia1 == true && meetPolyhymnia2 == false) //when we find out about the stolen Lyre
            {
                parentSession.SendText("\nApollo: Hello! What's going on?");
                int choice = GetListBoxChoice(new List<string>() { "Why didn't you mention the stolen Lyre?", });
                switch (choice)
                {
                    default:
                        parentSession.SendText("Emm... sorry, I had to forget.");
                        break;
                }
                return;
            }

            if (meetPolyhymnia2 == true && meetApollo2 == false) //after visiting Polyhymnia second time
            {
                SecondMeeting();
                return;
            }
            if (meetApollo2 && getLyre && isQuestEnd == false)
            {
                parentSession.SendText("Remember, don't say anything! I'll explain it to them later.");
                return;
            }
            if(isQuestEnd == true)
            {
                parentSession.SendText("Thanks for help!");
                return;
            }
            
        }

        private void FirstMeeting()
        {
            parentSession.SendText("\nHello adventurer! I'm Apollo, god of music and arts, sunlight and knowledge. I'm the leader of Muses. \nSomething terrible has happened...");
            parentSession.SendText("The curse that was cast on the village caused great chaos in the word of gods.");
            parentSession.SendText("My dear Muses argued and I can't reconcile them in any way.");
            parentSession.SendText("Do you want to help me? Of course, if you manage to resolve the conflict, you'll receive something in thanks.");
            int choice = GetListBoxChoice(new List<string>() { "Sure, no problem!", "Sorry, I have other things on my head." });
            switch (choice)
            {
                case 0:
                    parentSession.SendText("Great!\nThree of the muses: Erato, Euterpe and Terpsichore stole instruments from each other.");
                    parentSession.SendText("I heard that Erato took Flute from Eutherpe. Please, help them reach an agreement.\nPolyhymnia certainly will tell you more. Good luck!");
                    isQuestActive = true;
                    meetApollo1 = true;
                    break;
                default:
                    parentSession.SendText("Do you refuse the gods? Go away!");
                    isQuestActive = false;
                    break;
            }
        }

        private void SecondMeeting()
        {
            meetApollo2 = true;
            parentSession.SendText("\n*Apollo is playing the Lyre*");
            int choice = GetListBoxChoice(new List<string>() { "Hello! Nice Lyre!", "Is this Terpsichore's Lyre?!" });
            switch (choice)
            {
                case 0:
                    parentSession.SendText("Oh! You scared me, I didn't expect you!");
                    break;
                default:
                    parentSession.SendText("Oh! You scared me! Of course not! It is mine, I bought it in the Luthiers Village!");
                    break;
            }
            int choice2 = GetListBoxChoice(new List<string>() { "Can I try to play?", "*hmm he looks suspicious...* - distract him and take the Lyre", "- take the Lyre by force" });
            switch (choice2)
            {
                case 0:
                    parentSession.SendText("I'm sorry, but no, I paid a lot for this Lyre and you could damage it.");
                    int choice3 = GetListBoxChoice(new List<string>() { "*hmm he looks suspicious...* - distract him and take the Lyre", "- take the Lyre by force" });
                    switch (choice3)
                    {
                        case 0:
                            parentSession.SendText("What are you doing?! Give it back!");
                            break;
                        default:
                            parentSession.SendText("What are you doing?! My sweet Butterfly, take him!");
                            parentSession.FightThisMonster(new Butterfly(2));
                            break;
                    }
                    break;
                case 1:
                    parentSession.SendText("What are you doing?! Give it back!");
                    break;
                default:
                    parentSession.SendText("What are you doing?! My sweet Butterfly, take him!");
                    parentSession.FightThisMonster(new Butterfly(2));
                    break;
            }
            parentSession.AddThisItem(Index.ProduceSpecificItem("item1363")); // dostajemy Lirę
            getLyre = true;
            parentSession.SendText("\nOk! Ok! You got me! Yes, it's Terpsychore's Lyra. It's the most beautiful Lyra I've ever seen.");
            parentSession.SendText("I've always dreamed of having it and recently the opportunity has come for me,\nbut please, my Muses can't find out about it! They will hate me!");
            int choice4 = GetListBoxChoice(new List<string>() { "Ok, I won't say anything. But I recommend you telling them everything to avoid another conflict.", "I will think about it but I don't promise." });
            switch (choice4)
            {
                case 0:
                    parentSession.SendText("Thank you so much! You are a good man. I've hope that you give Lyre back to Terpsichore.");
                    break;
                default:
                    parentSession.SendText("Oh come on! I will pay you! How much do you want? 100 gold will be ok?");
                    int choice5 = GetListBoxChoice(new List<string>() { "Ok, that's enough", "Emmm... not really, I have to pay my water bill." });
                    switch (choice5)
                    {
                        case 0:
                            parentSession.SendText("Great! Here is your gold. So please, give Lyre back to Terpsichore and remember, you can't say anything!");
                            parentSession.UpdateStat(8, 100);
                            break;
                        default:
                            parentSession.SendText("Oh, ok. I will give you 200 gold.");
                            parentSession.SendText("Here is your gold. So please, give Lyre back to Terpsichore and remember, you can't say anything!");
                            parentSession.UpdateStat(8, 200);
                            break;
                    }
                    break;
            }
        }
        
    










    }
}
