using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Muses
{
    [Serializable]
    class EratoEncounter: ListBoxInteraction
    {
        public bool meetErato = false;
        private bool meet2 = false;
        private ApolloEncounter apollo;
        private EuterpeEncounter euterpe;
        private int k = 0;

        public EratoEncounter(GameSession ses, ApolloEncounter apollo, EuterpeEncounter euterpe) : base(ses)
        {
            Name = "interaction1362";
            this.apollo = apollo;
            this.euterpe = euterpe;
        }
        protected override void RunContent()
        {
            if (apollo.isQuestActive == false) // before first meeting
            {
                Meeting();
                return;
            }
           
            if((apollo.meetApollo1 || euterpe.meetEuterpe) && apollo.meetApollo2 == false) // po pierwszym spotkaniu z Apollo // lub po spotkaniu euterpe
            {
                Meeting();
                meetErato = true;
                int choice = GetListBoxChoice(new List<string>() { "Nice to meet you! We have a beautiful day today!", "Why did you take the Euterpe Flute?" });
                switch (choice)
                {
                    case 0:
                        parentSession.SendText("Not really. I miss my Kitar, this stupid Terpsichora doesn't want to give me it back! Could you talk to her?");
                        break;
                    default:
                        parentSession.SendText("Why do you blame me right away?! You'd better ask Terpsichore about my Kithara.");
                        break;
                }
                return;
            }
            
            if (apollo.getKithara && meet2 == false)
            {
                parentSession.SendText("\nErato: Do you have my Kithara?");
                int choice = GetListBoxChoice(new List<string>() { "Yes, here it is.  *give Kithara back" });
                switch (choice)
                {
                    case 0:
                        parentSession.RemovableItems = true;
                        parentSession.SendText("Thank you! Give me it back and I will give you something too!");
                        parentSession.SendText("\n*** drag Kithara outside of the item grid ***");
                        meet2 = true;
                        //zwróć item
                        break;
                }
                return;
            }
            if (meet2 && apollo.getFlute == false)
            {
                if (parentSession.TestForItem("item1365"))
                {
                    parentSession.SendText("\n*** drag Kithara outside of the item grid ***");
                    return;
                }
                else
                {
                    parentSession.SendText("Thank you! Please return Flute to Euterpe and this water from the source of life is for you...");
                    parentSession.AddThisItem(Index.ProduceSpecificItem("item1364"));
                    apollo.getFlute = true;
                    parentSession.RemovableItems = false;
                    parentSession.SendText("*** +30HP***");
                    parentSession.UpdateStat(1, 30);
                    return;
                }
            }
            else
            {
                Meeting();
                return;
            }

        }
        private void Meeting()
        {
            parentSession.SendText("\nHi! I'm Erato, Muse of love poetry.");
            if (k == 0)
            {
                parentSession.SendText("\nRoses are red,\nViolets are blue,\nI like donuts,\nDonuts are good.");
                k++;
                return;
            }
            if (k == 1)
            { 
                parentSession.SendText("\nRoses are red,\nViolets are blue,\nI can’t rhyme,\nBanana");
                k++;
                return;
            }
            if (k == 2)
            { 
                parentSession.SendText("\nRoses are red,\nViolets are blue,\nI’m unoriginal,\nThis is all I can do.");
                k=0;
                return;
            }
        }
    }
}
