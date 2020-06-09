using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Items;

namespace Game.Engine.Interactions.GuitarQuest
{
    [Serializable]
    class KellanInteraction:ListBoxInteraction
    {
        protected int relationshipLevel;
        private LeonardoInteraction leonardo;
        public MellanInteraction mellanMyFriend;
        public bool isDead;

        public KellanInteraction(GameSession session, LeonardoInteraction leonardoQuestgiver) : base(session)
        {
            Name = "interaction0585";
            relationshipLevel = 0;
            leonardo = leonardoQuestgiver;

        }
        protected override void RunContent()
        {
            if (relationshipLevel == 0 && leonardo.isQuestlineActive)
            {
                parentSession.SendText("\nHello there adventurer. Do you know where my friend Mellan is? I can't seem to find him, and he must fear for my safety tremendously.");
                if (mellanMyFriend.isQuestActive)
                {
                    int choice = GetListBoxChoice(new List<string>() { "Yes, Mellan sent me, he wants you to come to him. ", "Yes. I know where Mellan is, and he is right to fear for your safety (kill him)", "What? who? where? Goodbye"});
                    switch (choice)
                    {
                        case 0:
                            parentSession.SendText("\nOh, that is great news. Point me in his direction and I'll go. Here, have this string as a reward");
                            EEEEEG.AddString();
                            relationshipLevel = 1;
                            break;
                        case 1:
                            parentSession.SendText("\nNo, no please DON'T AAAURGHH");
                            Enterable = false;
                            isDead = true;
                            EEEEEG.AddString();
                            Name = "interaction0590";
                            parentSession.RefreshMonstersDisplay();
                            //change sprite to dead body
                            relationshipLevel = 1;
                            break;
                        default:
                            parentSession.SendText("\nOh well, I won't bother you then");
                            break;
                    }
                }
                else {
                    parentSession.SendText("Oh, I see you've no idea what I'm talking about. Farewell then");
                }
            }
            else if(leonardo.isQuestlineActive)
            {
                parentSession.SendText("I'm off to Mellan in a few minutes!");
            }
            else
            {
                parentSession.SendText("Oh, I'm lost, I'm lost, I'm terribly lost");
            }
        }
    }
}
