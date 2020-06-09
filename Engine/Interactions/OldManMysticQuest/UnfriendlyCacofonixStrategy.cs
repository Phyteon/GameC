using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.OldManMysticQuest
{
    [Serializable]
    class UnfriendlyCacofonixStrategy : ICacofonixStrategy
    {
        
        public void ExecuteCacof(GameSession parentSession, bool visited)
        {
            if (visited)
            {
                parentSession.SendText("\nCacofonix: Oh, it`s you... I don`t want to talk...");
                return;
            }
            else
            {
                parentSession.SendText("\nCacofonix: Hello there! That was you fighting this Old Man right? I heard that you wanted to kill him...");
                parentSession.SendText("Cacofonix: I was there and I found musicians gift, if you want to take it back you have to pay 200 gold");
                if (parentSession.CheckStat(8) >= 200)
                {
                    parentSession.SendText("Cacofonix: I see that you have enough money, so take it and go away you bastard...");
                    parentSession.UpdateStat(8, -200);
                    parentSession.UpdateStat(7, 1000);
                    parentSession.SendText("CONGRATULATIONS! YOU SAVED THE VILLAGE!... suddenly you wake up and realize that all of this was just a dream...");
                    parentSession.SendText("A DREAM BEFORE MECHANIC EXAM!!! DAMN, THERE IS NO TIME TO WASTE!!!!");
                }
                else
                {
                    parentSession.SendText("Cacofonix: It looks like you dont have enough money, come back later.");
                }
            }
        }
    }
}
