using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Items;

namespace Game.Engine.Interactions.GuitarQuest
{
    [Serializable]
    class BeggarInteraction:PlayerInteraction
    {
        int relationshipLevel;
        private LeonardoInteraction leonardo;
        public BeggarInteraction(GameSession session, LeonardoInteraction leonardoQuestgiver) : base(session)
        {
            Name = "interaction0583";
            relationshipLevel = 0;
            leonardo = leonardoQuestgiver;
        }
        protected override void RunContent()
        {
          if (relationshipLevel == 0 &&leonardo.isQuestlineActive)
            {
                parentSession.SendText("\nGreetings adventurer. My name is Anielka, I used to be a great flutemaker, but because of life's cruelty i now have nothing");
                parentSession.SendText("\nWould you spare a coin for an old beggar?");
                int choice = parentSession.GetListBoxChoice(new List<string>() { "Yes, here you are (50 gold)", "No, I have no coin to spare" });
                if (choice == 0)
                {
                    parentSession.SendText("\nAh, thank you. I don't have much to give in return, but such generosity should be rewarded.");
                    parentSession.SendText("\nIt is a string, useless to me, but You might know what to use it for.");
                    EEEEEG.AddString();
                    relationshipLevel++;
                }
            }
            else {
                parentSession.SendText("\nHello Adventurer. I shan't bother you right now.");
            }
        }
    }
}
