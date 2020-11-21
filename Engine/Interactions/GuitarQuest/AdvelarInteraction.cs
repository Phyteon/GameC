using Game.Engine.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Items;

namespace Game.Engine.Interactions.GuitarQuest
{
    [Serializable]
    class AdvelarInteraction:PlayerInteraction
    {
        protected int relationshipLevel;
        private LeonardoInteraction leonardo;
        
        public AdvelarInteraction(GameSession session, LeonardoInteraction leonardoQuestgiver):base(session)
        {
            Name = "interaction0582";
            relationshipLevel = 0;
            leonardo = leonardoQuestgiver;
        }
        protected override void RunContent()
        {
            if (leonardo.isQuestlineActive)
            {
                if (relationshipLevel == 0)
                {
                    parentSession.SendText("\nHello there adventurer. What business do you come to me with?");
                    int choice = parentSession.GetListBoxChoice(new List<string>() { "I have come from Leonardo of Musicians' Town. I hear you posess an item of great value", "Do you have any troubles here?", "Oh no, nothing. Just passing by"});
                    switch (choice)
                    {
                        case 0:
                            parentSession.SendText("\nWell yes, I do posess an Item Leonardo might consider precious. It's right there in the bell. The string supports its heart.");
                            parentSession.SendText("\nI could of course sell it to you, but if you help me with a small problem I will give it to you as a reward.");
                            parentSession.SendText("\nI have found this one in a pile of rubble nearby. Maybe another one could be somewhere there?");
                            int choice2 = parentSession.GetListBoxChoice(new List<string>() { "I'll buy it off you (400 gold)", "What can I help you with?" });
                            if (choice2 == 0)
                            {
                                if (parentSession.currentPlayer.Gold >= 400)
                                {
                                    parentSession.currentPlayer.Gold -= 400;
                                    relationshipLevel++;
                                    EEEEEG.AddString();
                                    parentSession.SendText("\nHere you are, hope it is of some use to you!");
                                }
                                else { parentSession.SendText("\nseems like you don't have enough coin in your pockets. Come back another time"); }
                            }
                            else
                            {
                                PresentSecondaryQuest();
                            }
                            break;
                        case 1:
                            PresentSecondaryQuest();
                            
                            break;
                        default:
                            parentSession.SendText("Ah, well. Goodbye then");
                            break;
                    }                
                }
                else
                {
                    parentSession.SendText("Hello there adventurer, I hope you're having a good day!");
                }
               
            }
        }
        private void PresentSecondaryQuest()
        {
            parentSession.SendText("\nAh, you see. There's this Golem, that sat itself down on my basement hatch, and does not want to leave");
            parentSession.SendText("\nIf you help remove it from here. I'll give you the string");
            int choice = parentSession.GetListBoxChoice(new List<string>() { "Sure, I'll help", "Maybe another time" });
            if (choice == 0)
            {
                parentSession.SendText("\nHe's right here, get rid of him!");
                parentSession.FightThisMonster(new Golem(0));
                parentSession.SendText("\nGood, He's gone. Here you are, one of my most valuable posessions.");
                parentSession.SendText("\n*Advelar hands you a guitar string*");
                EEEEEG.AddString();
            }
            else {
                parentSession.SendText("\nVery well then, goodbye");
            }
        }
    }
}
