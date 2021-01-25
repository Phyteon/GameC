using Game.Engine.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.GeneralQuestline
{
    [Serializable]
    class LibrarianForestInfoState : LibrarianState
    {
        public bool firstConversation = true;
        public override void RunContent(GameSession parentSession, LibrarianEncounter myself, TreantEncounter treant)
        {
            if (firstConversation)
            {
                parentSession.SendText("\nWelcome to my Library. My name is Marvin. Do you need any help?");
                parentSession.GetListBoxChoice(new List<string>() { "I was sent here by general Terneus. I am looking for any information about creatures that might live in the forest" });
                parentSession.SendText("\nNowadays the forest is inhabited by typical wild animals - bears, wolfes, deers etc. However this was not always an ordinary place");
                parentSession.GetListBoxChoice(new List<string>() { "*continue*" });
                parentSession.SendText("\nLong time ago, it was a forest full of magical creatures. Satyrs, trolls, gnomes, nymphs and forest fairies are only some of the creatures that we know once lived there");
                parentSession.GetListBoxChoice(new List<string>() { "*continue*" });
                parentSession.SendText("\nAfter humans came to this land, drudis are responsible for keeping the order in the forest. Once in a while, there are stories that someone saw a mythical creature roaming in the forest.");
                parentSession.GetListBoxChoice(new List<string>() { "Were there any big, tree-like looking creatures?" });
                parentSession.SendText("\nThere is a legend that the forest is protected by a treant. This creature while in slumber, looks like a normal tree. It awakens when the forest might be in danger. Noone saw a treant in decades.");
                parentSession.GetListBoxChoice(new List<string>() { "*continue*" });
                parentSession.SendText("\nTreants are known to be quite powerfull creatures. Not only they are strong, but are capable of using magic as well. Have you seen one lately?");
                parentSession.GetListBoxChoice(new List<string>() { "Not personaly, but there is a strong suspicion that there's near the military camp. I need to prepare in case i would have to fight one." });
                parentSession.SendText("\nFascinating! In my provate collection I have a amulet, that is supposed to protect the wearer from treant magic. It might come in handy.");
                parentSession.AddThisItem(new TreantProtectionAmulet());
                parentSession.GetListBoxChoice(new List<string>() { "Thank you for your help" });
                firstConversation = false;
                treant.Strategy = new TreantActiveStrategy();
                return;
            }
            else
            {
                parentSession.SendText("\nHello again. Need anyhing?");
                int choice = parentSession.GetListBoxChoice(new List<string>() { "Can you remind me what you said about the forest and the treant?", "I was just passing by" });
                switch(choice)
                {
                    case 0:
                        parentSession.SendText("\nNowadays the forest is inhabited by typical wild animals - bears, wolfes, deers etc. However this was not always an ordinary place.");
                        parentSession.GetListBoxChoice(new List<string>() { "*continue*" });
                        parentSession.SendText("\nLong time ago, it was a forest full of magical creatures. Satyrs, trolls, gnomes, nymphs and forest fairies are only some of the creatures that we know once lived there.");
                        parentSession.GetListBoxChoice(new List<string>() { "*continue*" });
                        parentSession.SendText("\nAfter humans came to this land, drudis are responsible for keeping the order in the forest. Once in a while, there are seeings of a mythical creature roaming in the forest.");
                        parentSession.GetListBoxChoice(new List<string>() { "*continue*" });
                        parentSession.SendText("\nThere is a legend that the forest is protected by a treant. This creature, while in slumber, looks like a normal tree. It awakens when the forest might be in danger. Noone saw a treant in decades.");
                        parentSession.GetListBoxChoice(new List<string>() { "*continue*" });
                        parentSession.SendText("\nTreants are known to be quite powerfull creatures. Not only they are strong, but are capable of using magic as well.");
                        parentSession.GetListBoxChoice(new List<string>() { "Thanks again" });
                        return;
                    default:
                        return;
                }

            }

        }
    }
}
