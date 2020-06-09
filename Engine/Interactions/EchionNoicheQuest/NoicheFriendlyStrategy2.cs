using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.EchionNoiche
{
    [Serializable]
    class NoicheFriendlyStrategy2 : INoicheStrategy
    {
        public void Execute(GameSession parentSession, bool visited)
        {
            if (visited)
            {
                parentSession.SendText("\nHello again! Thank you very much for help!");
                return;
            }
            else
            {
                parentSession.SendText("\nOh my God, you have it, you have my medallion!");
                parentSession.SendText("\nSo, you want to know how it is possible that I am here and there right?");
                parentSession.SendText("\nAnd what was the point of this entire adventure?");
                parentSession.SendText("\nWell... *He points at medallion*");
                parentSession.SendText("\nThis is a very powerful artifact. It gives you power of bilocation and shapeshifting");
                parentSession.SendText("\nIt means that you can create copies of yoursef, and they will share your consciousness.");
                parentSession.SendText("\nAdditionally you can shapeshift into whatever you want, and your copies are able to do the same.");
                parentSession.SendText("\nThis world is corrupted. So I decided to test every person who meets me.");
                parentSession.SendText("\nIf they have honor to face me, and not kill me while I am asleep, I can either give them medallion or fight them as some random monster.");
                parentSession.SendText("\nBut if they try to sneak up on me, then I change into something bigger, I am changing into a beast that gave power to this artifact.");
                parentSession.SendText("\nNone can defeat me then. I am robbing their bodies, and waiting for another one.");
                parentSession.SendText("\nBut you decided to be a good person, so I am giving you a price. I am proud of you.");
                parentSession.UpdateStat(7, 300);
                parentSession.UpdateStat(8, 300);
                parentSession.SendText("\nAnd for the record: you cannot run away with the medallion. Its power is still afecting me, even if its not on my neck.");
                parentSession.SendText("\nWhats more, I can sense it and you cannot use it, unless you charge it.");
                parentSession.SendText("\nBut this is kinda hard *He smiles confidently*");
                parentSession.SendText("\nGood bye, adventurer!");
                parentSession.SendText("\n*You have a feeling that this is not the whole story...*");
            }
        }
    }
}
