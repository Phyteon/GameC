using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.OldManMysticQuest
{
    [Serializable]
    class FriendlyCacofonixStrategy : ICacofonixStrategy
    {
        public void ExecuteCacof(GameSession parentSession, bool visited)
        {
            if (visited)
            {
                parentSession.SendText("\nCacofonix: Hello my dear friend! You have to be very busy, go and fight this monsters!");
                return;
            }
            else
            {
                parentSession.SendText("\nCacofonix: Hello there! That was you fighting this Old Man right? I heard that you don`t want to hurt him...");
                parentSession.SendText("Cacofonix: I was there and I found musicality gift, you have good hearth and I heard that your village lost this so take that");
                parentSession.SendText("Cacofonix: Oh, and I found 100 gold there, maybe this will help you in future adventures!");
                parentSession.UpdateStat(8, 100);
                parentSession.UpdateStat(7, 1000);
                parentSession.SendText("CONGRATULATIONS! YOU SAVED THE VILLAGE!... suddenly you wake up and realize that all of this was just a dream...");
                parentSession.SendText("A DREAM BEFORE MECHANIC EXAM!!! DAMN, THERE IS NO TIME TO WASTE!!!!");
            }
        }
    }
}
