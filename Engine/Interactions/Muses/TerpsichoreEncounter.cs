using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Muses
{
    [Serializable]
    class TerpsichoreEncounter : PlayerInteraction
    {
        public bool meetTerpsichore = false;
        private bool meet2 = false;
        private ApolloEncounter apollo;
        private EratoEncounter erato;

        public TerpsichoreEncounter(GameSession ses, ApolloEncounter apollo, EratoEncounter erato) : base(ses)
        {
            Name = "interaction1364";
            this.apollo = apollo;
            this.erato = erato;
        }
        protected override void RunContent()
        {
            if (apollo.meetPolyhymnia1 == false) //przed questem
            {
                parentSession.SendText("\nHi! I'm Terpsichore. Have you seen my Lyra?");
                return;
            }

            if ((apollo.meetPolyhymnia1 || erato.meetErato) && apollo.getLyre == false) //po rozmowie z Erato lub po rozmownie z Polihymnią
            {
                parentSession.SendText("\nHi! I'm Terpsichore. Have you seen my Lyra?");
                int choice = parentSession.GetListBoxChoice(new List<string>() { "Unfortunately not, but I heard you have Erato's Kitara. Is it true?", "Unfortunately not." });
                switch (choice)
                {
                    case 0:
                        parentSession.SendText("Emm... Yeeees, but my Lyra has been stolen. How would I practice? I promise, I will give the Kithara back, but please, first find my Lyre.");
                        meetTerpsichore = true;
                        break;
                    default:
                        parentSession.SendText("So why did you come here?");
                        break;
                }
                return;
            }

            if (apollo.getLyre && meet2 == false)
            {
                parentSession.SendText("\nTerpsichore: Have you found my Lyre?");
                int choice = parentSession.GetListBoxChoice(new List<string>() { "Yes, here it is.  *give Lyre back*" });
                switch (choice)
                {
                    case 0:
                        parentSession.RemovableItems = true;
                        parentSession.SendText("Fantastic! I have something for you as a reward...");
                        parentSession.SendText("\n*** drag Lyre outside of the item grid ***");
                        meet2 = true;
                        //zwróć item
                        break;
                }
                return;
            }
            if (meet2 && apollo.getKithara == false)
            {
                if (parentSession.TestForItem("item1363"))
                {
                    parentSession.SendText("\n*** drag Lyre outside of the item grid ***");
                    return;
                }
                else
                {
                    parentSession.SendText("Please return Kithara to Erato and it's for you...");
                    parentSession.AddThisItem(Index.ProduceSpecificItem("item1365"));
                    apollo.getKithara = true;
                    parentSession.RemovableItems = false;
                    parentSession.SendText("*** +60XP ***");
                    parentSession.UpdateStat(7, 60);
                    return;
                }
            }
            else
            {
                parentSession.SendText("\nTerpsichore: Hi! What's up?");
                return;
            }
        }
    }
}
