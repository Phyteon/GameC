using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Muses
{
    [Serializable]
    class PolyhymniaEncounter : PlayerInteraction
    {
        private ApolloEncounter apollo;
        private EratoEncounter erato;
        private EuterpeEncounter euterpe;
        private TerpsichoreEncounter terpsichore;

        public PolyhymniaEncounter(GameSession ses, ApolloEncounter apollo, EratoEncounter erato, EuterpeEncounter euterpe, TerpsichoreEncounter terpsichore) : base(ses)
        {
            Name = "interaction1361";
            this.apollo = apollo;
            this.erato = erato;
            this.euterpe = euterpe;
            this.terpsichore = terpsichore;
        }
        protected override void RunContent()
        {
            //before starting quest
            if (apollo.isQuestActive == false) 
            {
                parentSession.SendText("\nHi! I'm Polihymnia. I'm busy right now. Come back later.");
                return;
            }

            //first meeting, after visiting Apollo
            if (apollo.meetApollo1 == true && apollo.meetPolyhymnia1 == false) 
            {
                Firstmeeting();
                return;
            }

            //after first meeting
            if (apollo.meetPolyhymnia1 == true && (erato.meetErato == false || euterpe.meetEuterpe == false || terpsichore.meetTerpsichore == false)) 
            {
                parentSession.SendText("\nPlyhymnia: Did you find the stolen Terpsichore's Lyre? No? Try to talk with Muses: Erato, Euterpe and Terpsichore and come back to me.");
                return;
            }

            //when we visited 3 muses - second meeting
            if (erato.meetErato && euterpe.meetEuterpe && terpsichore.meetTerpsichore && apollo.meetPolyhymnia2 == false) 
            {
                SecondMeeting();
                return;
            }

            //after second meeting
            if(apollo.meetPolyhymnia2 && apollo.getLyre == false)
            {
                parentSession.SendText("\nPolyhymnia: I'm tired. Go to Apollo.");
                return;
            }
            if(apollo.isQuestEnd)
            {
                parentSession.SendText("\nPolyhymnia: Thanks for help!");            
            }

        }
        private void Firstmeeting()
        {
            apollo.meetPolyhymnia1 = true;
            parentSession.SendText("\nHi! I'm Polihymnia. Apollo mentioned you. Together we are trying to resolve the conflict between my sisters.");
            parentSession.SendText("It all began that night when someone cast a spell on the village, someone stole Terpsichore's Lyre.\nThere was confusion and now everyone is accusing each other of stealing their instrument.\nI think when we find this thief, everyone will reconcile. Talk with muses and come back to me.");
            if (euterpe.meetEuterpe == false) //if player doesn't meet Euterpe
            {
                parentSession.SendText("Have you seen Euterpe? I'm worried about her, I haven't seen her since that night.");
            }
            parentSession.SendText("So now you know what to do. Find a thief!");
        }
        private void SecondMeeting()
        {
            apollo.meetPolyhymnia2 = true;
            parentSession.SendText("\nPolyhymnia: Hi! do you have any news?");
            int choice = parentSession.GetListBoxChoice(new List<string>() { "Oh, yes. But I feel lost in this case... *Tell the story*" });
            switch (choice)
            {
                default:
                    parentSession.SendText("Yes, it's very complicated, but to sum up:");
                    parentSession.SendText("1. Someone has stolen Terpsichore's Lyra.");
                    parentSession.SendText("2. Terpsichore has Erato's Kithara.");
                    parentSession.SendText("3. Erato has Euterpe's Flute");
                    parentSession.SendText("It seems that if we found the Lyre everything would return to normal.\nI'm too tired of this case. Go to Apollo, maybe he knows something new.");
                    break;
            }
        }
    }
}
