using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.EchionNoiche
{
    [Serializable]
    class NoicheHostileStrategy2 : INoicheStrategy
    {
        public void Execute(GameSession parentSession, bool visited)
        {
            if (visited)
            {
                parentSession.SendText("\n*There is nothing here but dust in the shape of dwarf...*");
                return;
            }
            else
            {
                parentSession.SendText("\n*You notice a pile of dust swirling in the air. Suddenly you hear the crackling voice: *");
                parentSession.SendText("\nThats not possible... How... ");
                parentSession.SendText("\nI... made a lot of mistakes... But he did the unforgivable...");
                parentSession.SendText("\nHe was the real monster. Dragon was never a threat. But he wanted power...");
                parentSession.SendText("\nSo many creatures are now gone because of him. So many lifes torturerd, choked, ripped apart in his labolatories.");
                parentSession.SendText("\nHe looked for a perfect living being... The one that he could skin and turn into an artifact.");
                parentSession.SendText("\nI was his apprentice... I couldn't let that happen... But it was too late. He found it.");
                parentSession.SendText("\nAnd he robbed the creature from it's greatest treasure. And used it as a trap.");
                parentSession.SendText("\nI... had to run away with the medallion... Otherwise... it would be a disaster...");
                parentSession.SendText("\nNone knew this except for me... Go to temple and fight the creature. Mayby this way you will save us.");
                parentSession.SendText("\nWatch out for fire... Do not make the same mistakes...");
                parentSession.SendText("\n*Voice disaperas and dust falls onto the ground. There is something shimmering in the pile. You recognize golden coins*");
                parentSession.SendText("\n*You have a feeling that this is not the whole story...*");
                parentSession.UpdateStat(8, 800);
            }
        }
    }
}
