using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.InteractionFactories
{
    [Serializable]
    class TempleQuestFactory : InteractionFactory
    {
        private int i = 0;
        public List<Interaction> CreateInteractionsGroup(GameSession parentSession)
        {
            if (i == 0)
            {
                i++;
                Random rnd = new Random();
                List<string> Colors = new List<string>();
                List<string> myColors = new List<string>();
                List<string> AvailableColours = new List<string>();
                AvailableColours.Add("red");
                AvailableColours.Add("blue");
                AvailableColours.Add("yellow");
                AvailableColours.Add("green");
                int j = 0;
                while (j != 5)
                {
                    Colors.Add(AvailableColours[rnd.Next(AvailableColours.Count())]);
                    j++;
                }                
                
                GateEncounter gate =new GateEncounter(parentSession, "interaction0030");                
                GateEncounter gate2 =new GateEncounter(parentSession, "interaction0031");
                StewardEncounter steward = new StewardEncounter(parentSession, Colors, gate2);
                RedObeliskEncounter red = new RedObeliskEncounter(parentSession, myColors, steward);
                BlueObeliskEncounter blue = new BlueObeliskEncounter(parentSession, myColors, steward);
                GreenObeliskEncounter green = new GreenObeliskEncounter(parentSession, myColors, steward);
                YellowObeliskEncounter yellow = new YellowObeliskEncounter(parentSession, myColors, steward);            


                return new List<Interaction>() { red, steward, blue, green, yellow, gate, gate2 };
            }
            else return new List<Interaction>();
        }

        public Interaction CreateInteraction(GameSession parentSession, int num)
        {
            return null;
        }
    }
}
