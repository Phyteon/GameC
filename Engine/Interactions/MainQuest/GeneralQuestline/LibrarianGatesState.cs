using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.GeneralQuestline
{
    [Serializable]
    class LibrarianGatesState : LibrarianState
    {
        public override void RunContent(GameSession parentSession, LibrarianEncounter myself, TreantEncounter treant)
        {
            parentSession.SendText("\nWelcome back to my Library. Do you need any help?");
            parentSession.GetListBoxChoice(new List<string>() { "I'm searching for the informations about the kings from Enchanted Forest. Could you help me?" });
            parentSession.SendText("\nOf course, which one interests you?");
            parentSession.GetListBoxChoice(new List<string>() { "The one who built the Temple." });
            parentSession.SendText("\nThe name of this powerful king was Kaan. He was the gratest Fairie's king this world had. Because of his birth during full Moon night, he was strongly connected with the Spirit of the Moon, which gave him an ability to draw energy from the Moon. Every full Moon fairies under his commads were undefeatable.");
            parentSession.SendText("\nThat is why our ancestors attacked them during moon eclipse.");
            parentSession.GetListBoxChoice(new List<string>() { "Thank you." });
            parentSession.SendText("\nNo problem.");



        }
    }
}
