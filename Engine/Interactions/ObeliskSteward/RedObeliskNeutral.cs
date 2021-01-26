using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Built_In
{
    // neutral Hymir strategy - not much happens here

    [Serializable]
    class RedObeliskNeutral : IObeliskStrategy
    {
        public List<string> Execute(GameSession parentSession, bool complete, StewardEncounter myself, List<string> list)
        {
           

            int choice = parentSession.GetListBoxChoice(new List<string>() { "Go away", "Make a sacrafice" });
            switch (choice)
            {
                case 0:
                break;
                case 1:
                parentSession.UpdateStat(1, -5); // +15 gold
                parentSession.SendText("\n");
                parentSession.SendColorText("5 point damage","red");
                parentSession.SendColorText("You make a sacrifice, but it costs...", "red");
                return (Order(parentSession, myself, list));
                default:
                parentSession.SendText("No, you look like a useless vagabond. Go away!");
                break;

            }

            return list; // executing this strategy means HymirEncounter is still not complete
        }

        public List<string> Order(GameSession parentSession, StewardEncounter myself, List<string> list)
        {
            if (list.Count == 0)
            {
                if (myself.order[0] == "red") list.Add("red"); ;
            }
            else
            {
                for (int i = 0; i < list.Count; i++)

                    if (list[i] == myself.order[i])
                    {
                        if (i == 4)
                        {
                            myself.ChangeState(new StewadrNeutralState());
                            parentSession.SendText("Something has changed");
                        }
                        else if ((i == list.Count - 1) & myself.order[i + 1] == "red")
                        {
                            list.Add("red");
                        }
                    }
                    else
                    {
                        list.Clear();
                        break;
                    }
            }
            return list;
        }
    }
}
