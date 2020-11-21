using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Items;

namespace Game.Engine.Interactions.GuitarQuest
{
    [Serializable]
    class StringOnGroundInteraction:InteractionWithImage
    {
        protected LeonardoInteraction leonardo;
        bool successfullyVisited;
        public StringOnGroundInteraction(GameSession session, LeonardoInteraction leonardoQuestgiver) : base(session)
        {
            Name = "interaction0588";
            leonardo = leonardoQuestgiver;
            successfullyVisited = false;
        }

        protected override void RunContent()
        {
            if(leonardo.isQuestlineActive && !successfullyVisited)
            {
                parentSession.SendText("\nYou look through the rubble and find... a string! One of the five You are looking for!");
                EEEEEG.AddString();
                successfullyVisited = true;
            }
            else 
            {
                parentSession.SendText("\nThere might be something valueable in this pile of rubble, but right now, noene of it appeals to you");
            }
        }

    }
}
