using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.EchionNoiche
{
    [Serializable]
    class NoicheHostileStrategy3 : INoicheStrategy
    {
        public void Execute(GameSession parentSession, bool visited)
        {
            if (visited)
            {
                parentSession.SendText("\n*Fire is everywhere. There is nothing left from the dwarf except for the raging flames.*");
                return;
            }
            else
            {
                parentSession.SendText("\n*There is a strange creature floating in front of you. It looks like a mass of varius flames surrounded by dust.*");
                parentSession.SendText("\n*That is definitely not a dwarf. Suddenly you hear many hissing angry voices coming out of this thing.*");
                parentSession.SendText("\nHe burned us alive... He melted our crust with us inside to create a monument to catch our father... This monster stole us from him...");
                parentSession.SendText("\nWe couldn't do anything... We were trapped in our shells, we were scratching it, but we had no chances...");
                parentSession.SendText("\nThis is the greatest sin on this earth... To take unhatched children of the dragon...");
                parentSession.SendText("\nWhen our father came for us we were nothing but a melted mass... So he gave us his breath knowing that it will drain him from his power...");
                parentSession.SendText("\nBut it sparkled our souls... We were there, waiting, in a form of fire... And you released us by bringing us this medallion...");
                parentSession.SendText("\nYou brought us the last sparkle we needed... Now we are free... And we shall burn anything...");
                parentSession.SendText("\nAnd mayby then we will reunite with father. Run, adventurer, run. Thank you for our freedom.");
                parentSession.SendText("\n*The creature explodes and another wave of flames starts covering the ground around you. You definitely should run*");
                parentSession.SendText("\n*You have a feeling that this is not the whole story...*");
                parentSession.UpdateStat(7, 400);
            }
        }
    }
}
