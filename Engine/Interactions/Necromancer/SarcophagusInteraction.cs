using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using Game.Engine.Monsters;

namespace Game.Engine.Interactions.Built_In
{

    [Serializable]
    class SarcophagusInteraction : PlayerInteraction
    {
        //You can freely add monsters to this dictionary, number presents how likely it is to appear


        private Dictionary<Monster, int> monsters = new Dictionary<Monster, int>()
        {
            {new Rat(), 3 },
            {new Bat(), 5 },
            {new VampireKnight(), 1 }
        };


        //Here you can edit maximum and minimum of gold player can find

        int minGold = 10;
        int maxGold = 50;


        int content;
        bool opened = false;
        public SarcophagusInteraction(GameSession parentSession) : base(parentSession)
        {
            Random rnd = new Random();
            Name = "interaction0151";
            Enterable = false;
            content = rnd.Next(3);
            
        }

        protected override void RunContent()
        {

            if (opened == false)
            {
                parentSession.SendText("\nYou found a sarcophagus, do you want to open it?");

                int choice = parentSession.GetListBoxChoice(new List<string>() { "Open the sarcophagus", "Leave it be" });
                switch (choice)
                {

                    case 0:
                        parentSession.SendText("You have opened the sarcophagus");

                        bool result = oppening();
                        

                        if (result == true)
                        {
                            parentSession.RemoveCurrentlyVisitedInteraction();
                        }
                        break;

                    default:
                        parentSession.SendText("You left it");
                        break;


                }
            }
        }

        protected bool oppening()
        {
            opened = true;
            switch (content)
            {
                case (0):
                    parentSession.SendText("There is nothing inside");
                    return true;

                case (1):
                    parentSession.SendText("You found some gold");
                    Random rnd = new Random();
                    parentSession.UpdateStat(8, rnd.Next(minGold, maxGold));
                    return true;

                case (2):
                    parentSession.SendText("You found something");
                    parentSession.AddRandomItem();
                    return true;


                   
                case int n when (n >= 3): //This part could use some testing
                    List<Monster> monsterList = new List<Monster>();
                    

                    foreach(KeyValuePair<Monster,int> kvp in monsters)
                    {
                        for (int i = 0; i < kvp.Value; i++) monsterList.Add(kvp.Key); //Edit here in case of out of range
                    }

                    parentSession.SendColorText("There is hostile" + monsterList[n - 3].Name + "inside", "red"); //Edit here if it gives wrong name
                    return parentSession.FightThisMonster(monsterList[n-3], true);

                

                default:
                    return false;
            }    

        }
    }
}

