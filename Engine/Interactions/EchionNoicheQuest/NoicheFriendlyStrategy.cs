using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.EchionNoiche
{
    [Serializable]
    class NoicheFriendlyStrategy : INoicheStrategy
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
                parentSession.SendText("\nGreat job, adventurer! Here's your price!");
                parentSession.UpdateStat(7, 200);
                parentSession.UpdateStat(8, 200);
                parentSession.SendText("\n*He smiles for a moment*");
                parentSession.SendText("\nDo you want to hear a story about it?");
                parentSession.SendText("\n*You are nodding your head*");
                parentSession.SendText("\nWell then. Many, many years ago, a dragon was wreaking havoc across this land");
                parentSession.SendText("\nOne of the greatest wizards on the planet decided to put an end to it.");
                parentSession.SendText("\nHe created a magic monument and tricked dragon into breathing his flame breath on it.");
                parentSession.SendText("\nThe monument absorbed all energy and drained beast from its power.");
                parentSession.SendText("\nBut it wasn't enough. Monster was too powerful to kill so wizard decided to lock him inside a temple");
                parentSession.SendText("\nTo seal it he created a medallion from the scale he took from dragon's heart. He charged it by using fire from the monument.");
                parentSession.SendText("\nWhat he didn't know, was that he accidently made a very powerful artifact, the one that can actually RELEASE the dragon.");
                parentSession.SendText("\nHe knew he should destroy it but...");
                parentSession.SendText("\nOnce he realised how powerful it is, the greed took over. He decided to keep the medallion.");
                parentSession.SendText("\nThen he got robbed and killed and finally I managed to get it until this troll stole it from me.");
                parentSession.SendText("\nThe dragon is still trapped somewhere, waiting for his power to come back.");
                parentSession.SendText("\nBut now, there is no need to worry about it. Thank you once again!");
                parentSession.SendText("\n*You have a feeling that this is not the whole story...*");
            }
        }
    }
}
