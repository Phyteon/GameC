using Game.Engine.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.GuitarQuest
{
    [Serializable]
    class LeonardoInteraction:PlayerInteraction
    {
        int relationshipLevel;
        public bool isQuestlineActive;
        //TODO: Implement different pieces of the questline into the constructor
        public LeonardoInteraction(GameSession session) : base(session) 
        {
            Name = "interaction0581";
            relationshipLevel = 0;
            isQuestlineActive = false;
        }
        

        protected override void RunContent()
        {
            if (relationshipLevel < 0) { parentSession.SendText("\nOh, It's you again. Did you come to apologise?");
                int choice = parentSession.GetListBoxChoice(new List<string>() { "\nYes, I'm sorry for my previous behaviour", "No, you buffoon. I came to kill you." });
                if (choice == 1)
                {
                    parentSession.SendText("\nVery well. I accept your apology. Come back later, and we'll talk about the search.");
                    relationshipLevel = 0;
                }
                else {
                    parentSession.SendText("\nNO PLEASE DON'T NOOOOOOOO!");
                    Enterable = false;
                    if (!parentSession.TestForItem("item0590")) parentSession.AddThisItem(new EEEEEG());
                    EEEEEG.AddString();
                    isQuestlineActive = true;
                }
            }
            else
            {
                if (relationshipLevel == 0)
                {
                    parentSession.SendText("\nAh, welcome Adventurer. My name is Leonardo of Musicians' Town.");
                    parentSession.SendText("\nI have been studying the legend of the Enormously Electrifying Extremely Exceptional Electric Guitar");
                    parentSession.SendText("\nWould you care to help me in my search? The reward shall be enormously helpful in your adventures!");

                    int choice = parentSession.GetListBoxChoice(new List<string>() { "I would be most glad to help you", "I do not have time for such tasks right now.", "And who are you to talk to me this way? Get lost!" });
                    switch (choice)
                    {
                        case 0:
                            PresentQuest();
                            relationshipLevel = 1;
                            isQuestlineActive = true;
                            break;
                        case 2:
                            parentSession.SendText("\nHmpfh, such anger. I would have no use doing business with you anyway.");
                            relationshipLevel = -1;
                            break;
                        default:
                            parentSession.SendText("\nOh well, come back if you have the time later. Farewell.");
                            break;
                    }
                }
                else if (relationshipLevel == 1)
                {
                    if (EEEEEG.stringCount == 5)
                    {
                        parentSession.SendText("\nOh, you have managed to find the five missing strings! That's great news.");
                        parentSession.SendText("\nI'll study the guitar's desing, and then... I have one more surprise for you");
                        parentSession.SendText("\n*Leonardo takes out some papers, and gets to work. Hours pass, but in the end, he exclaims:*");
                        parentSession.SendText("\nAHA! I've figured it out. I can now reproduce the magic woven into this thing!");
                        parentSession.SendText("\nSince I can do that, it means I've no use for the Guitar itself. You can keep it, it's fully stringed now");
                        parentSession.SendText("\nGoodbye adventurer, Fare thee well!");
                        Enterable = false;
                        relationshipLevel++;
                    }
                    else
                    {
                        parentSession.SendText("Have you found the five strings yet?");
                    }
                }
                
            }
        }

        protected void PresentQuest()
        {
            parentSession.SendText("\nVery well then. I shall explain what I need from you. I seek this artefact to study its intricate design.");
            parentSession.SendText("\nAfter that it is useless to me. The completed Enormously Electrifying Extremely Exceptional Electric Guitar shall be your reward");
            parentSession.SendText("\nI have the body of the guitar, bud it requres six strings. I ask you to take the body and return to me once you've collected five of the six strings");
            parentSession.SendText("\nI've heard of a Blacksmith named Advelar who could be in posession of one of the five strings you ought to find");
           
            if (!parentSession.TestForItem("item0590")) parentSession.AddThisItem(new EEEEEG());
            
        }
    }
}
