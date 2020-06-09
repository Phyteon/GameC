using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Items;
using Game.Engine.Monsters;

namespace Game.Engine.Interactions.OldManMysticQuest
{
    [Serializable]
    class Boss4Encounter: ListBoxInteraction, IBoss
    { 
        public bool IsDefeated { get; set; }
        public string NameView { get; set; }
        public Item item { get; set; }
        public Boss4Encounter(GameSession ses) : base(ses)
        {
            Name = "interaction0344";
            
            IsDefeated = false;
            item = new Nenya();
        }
        int hydraNumber = 1;
        
        protected void FightHydra() //method that help with fighting all hydras one by one
        {
            
            if(hydraNumber == 1)
            {
                hydraNumber++;
                parentSession.FightThisMonster(new Hydra1(parentSession.currentPlayer.Level));
            }
            else if (hydraNumber == 2)
            {
                hydraNumber++;
                parentSession.FightThisMonster(new Hydra2(parentSession.currentPlayer.Level));
            }
            else if (hydraNumber == 3)
            {
                hydraNumber++;
                parentSession.FightThisMonster(new Hydra3(parentSession.currentPlayer.Level));
            }
            else
            {
                parentSession.FightThisMonster(new Hydra4(parentSession.currentPlayer.Level));
                hydraNumber = -1;
            }
            
        }
        
        protected override void RunContent()
        {
            if (parentSession.TestForItem(item.Name) == true && IsDefeated == false)
            {
                parentSession.SendText("Opening the doors..");
                FightHydra();
                for (int i = 1; i<=3; i++)
                {
                    parentSession.SendText("Another hydra approached, what do you do?");
                    int choice1 = GetListBoxChoice(new List<string>() { "Fight", "Escape" });
                    switch (choice1)
                    {
                        case (0):
                            FightHydra();
                            break;
                        default:
                            parentSession.SendText("Mission failed... we get them next time");
                            i = 3;
                            break;
                    }
                    
                }
                if (hydraNumber == -1)
                {
                    parentSession.SendText("You defeated 4th boss! Find an Old Man");
                    IsDefeated = true;
                }
            }
            else if (parentSession.TestForItem(item.Name) != true)
            {
                parentSession.SendText("You cannot fight this boss, required item needed...");
            }
            else
            {
                parentSession.SendText("This monster was already beaten");
            }
        }
    }
}
