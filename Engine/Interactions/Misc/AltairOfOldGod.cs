using Game.Engine.Interactions.Built_In;
using Game.Engine.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Misc
{
    
    [Serializable]
    class AltairOfOldGod : ListBoxInteraction
    {
       
        private int visited = 0;
        private int health = 0;
        public AltairOfOldGod(GameSession ses) : base(ses)
        {
            Name = "interaction0973";
        }
        protected override void RunContent()
        {
            if (visited == -1) 
            {
                parentSession.SendText("\nThere used to be an Altair Of An Old God here, but I destroyed it.");
                return;
            }
  
            parentSession.SendText("\nSo there is an Altair Of An Old God. Maybe I can get some benefits from that?");
    
            int choice = GetListBoxChoice(new List<string>() { "I will sacrifice some of my blood", "Maybe I do not need to sacrifice my blood?", "No, I will be back here later!" });
            switch (choice)
            {
                case 0:
                    Sacrifice();
                    break;
                case 1:
                    parentSession.SendText("But there is a sign! You need to sacrifice something if you want to get Its attention!");
                    int choice2 = GetListBoxChoice(new List<string>() { "Okay. So I will sacrifice my blood.", "No, I do not want to do this! I will destroy this Altair Of An Old God!" });
                    if (choice2 == 0)
                    {
                        Sacrifice();
                    }
                    else
                    {
                        parentSession.SendText("You destroyed the Altair Of An Old God! You got bonus XP!");
                        parentSession.UpdateStat(7, 150);
                        visited = -1;
                    }
                    break;
                default:
                    parentSession.SendText("You left the Altair Of An Old God");
                    break;
            }
        }

        private void Sacrifice()
        {
            health = 10;
            parentSession.SendText("What can i get from you?");
            int choice = GetListBoxChoice(new List<string>() { "Get strength! [10 HP]", "Get precision! [10 HP]","Get stamina! [10 HP]","No! I want to destroy this Altair Of Old God!" });
            if (choice == 0)
            {
                parentSession.SendText("You feel that you are losing your health, but you gain more strength!");
                parentSession.UpdateStat(2, health);
				parentSession.UpdateStat(1, -1*health);
            }
            if (choice == 1)
            {
                parentSession.SendText("You feel that you are losing your health, but you gain more precision!");
                parentSession.UpdateStat(4, health);
				parentSession.UpdateStat(1, -1*health);
            }
            if (choice == 2)
            {
                parentSession.SendText("You feel that you are losing your health, but you gain more stamina!");
                parentSession.UpdateStat(6, health);
				parentSession.UpdateStat(1, -1*health);
            }
            else
            {
                parentSession.SendText("You destroyed Altair Of Old God! You got bonus XP!");
                parentSession.UpdateStat(7, 150);
                visited = -1; 
            }
        }
    }
}
