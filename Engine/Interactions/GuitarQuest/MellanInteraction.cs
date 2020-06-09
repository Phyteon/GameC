using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Items;

namespace Game.Engine.Interactions.GuitarQuest
{
    [Serializable]
    class MellanInteraction:ListBoxInteraction
    {
        protected int relationshipLevel;
        private LeonardoInteraction leonardo;
        private KellanInteraction kellanMyFriend;
        public bool isQuestActive;

        //private MellanInteraction():base(null) { }
        public MellanInteraction(GameSession session, LeonardoInteraction leonardoQuestgiver, KellanInteraction kellan) : base(session)
        {
            Name = "interaction0584";
            relationshipLevel = 0;
            kellanMyFriend = kellan;
            leonardo = leonardoQuestgiver;
        }
        protected override void RunContent()
        {
            if (relationshipLevel == 0 && leonardo.isQuestlineActive)
            {
                parentSession.SendText("\nGreetings adventurer. I know what you might require of me. I know of Leonardo and his quest to find the EEEEEG");
                parentSession.SendText("\nI have one of the strings you seek, And I would like to give it to you, however, I first need to find my friend Kellan");
                parentSession.SendText("\nI haven't the faintest idea where he could be, and he is a dear friend. I fear he may have been attacked. Would you help me, adventurer?");
                int choice = GetListBoxChoice(new List<string>() { "Yes, I will find Kellan", "I haven't the time right now" });
                if (choice == 0)
                {
                    parentSession.SendText("\nThank you. Tell him where you found me, and I shall give you the string. He will give you his one if you tell him I sent you");
                    isQuestActive = true;
                    relationshipLevel = 1;
                }
                else
                {
                    parentSession.SendText("\nVery well, but please reconsider it. I fear for my friend's life greatly");
                }
            }
            else if(relationshipLevel == 1 && leonardo.isQuestlineActive)
            {
                parentSession.SendText("\nWelcome back adventurer. Did you find Kellan?");
                List<string> foo = new List<string>() { "No, I haven't yet" };
                if (kellanMyFriend.isDead)
                {
                    foo.Add("Kellan is dead. Monsters killed him");
                }
                else
                {
                    foo.Add("Yes, he is on his way here right now");
                }
                int choice = GetListBoxChoice(foo);
                if (choice == 0)
                {
                    parentSession.SendText("Go on then, make haste! Find him please!");
                }
                else 
                {
                    if (kellanMyFriend.isDead)
                    {
                        parentSession.SendText("Oh no. Such a tragedy. Oh. I promised it to you. May it help you in your travels");
                    }
                    else
                    {
                        parentSession.SendText("That's good news. Here, have the string");
                    }
                    EEEEEG.AddString();
                }
            }
        }
    }
}
