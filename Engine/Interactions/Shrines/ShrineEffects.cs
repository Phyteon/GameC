using Game.Engine.Interactions.Built_In;
using Game.Engine.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Interactions.Shrines;

namespace Game.Engine.Interactions.Shrines
{
    class ShrineEffects
    {
        /* Shrine Effects - num chooses which effect should be used
         * (0th shrine is the random shrine using all of below)
         * 1 - Battle Shrine
         * 2 - Berserker Shrine
         * 3 - Cat Shrine
         * 4 - Elephant Shrine
         * 5 - Hunter Shrine
         */
        static public bool UseEffect(GameSession parentSession, int num, bool used)
        {
            if (!used)
            {
                parentSession.SendText("Do you want to pray to this shrine?");
                int choice = parentSession.GetListBoxChoice(new List<string>() { "*proceed*", "*walk away*" });
                switch (num)
                {
                    case 1:
                        if (choice == 0)
                        {
                            parentSession.SendText("You feel the force flow through you");
                            parentSession.AddRandomClassItem(); //add class item
                            parentSession.UpdateStat(6, -15); //take stamina
                            parentSession.UpdateStat(4, -5); //take precision
                        }
                        break;
                    case 2:
                        if (choice == 0)
                        {
                            parentSession.SendText("You feel the force flow through you");
                            if (parentSession.currentPlayer.ClassName == "Warrior")
                            {
                                parentSession.UpdateStat(2, 15); //add strength
                                parentSession.UpdateStat(1, -20); //take health
                            }
                            else if (parentSession.currentPlayer.ClassName == "Mage")
                            {
                                parentSession.UpdateStat(5, 15); //add magic power
                                parentSession.UpdateStat(1, -20); //take health
                            }
                        }
                        break;
                    case 3:
                        if (choice == 0)
                        {
                            parentSession.SendText("You feel the force flow through you");
                            parentSession.UpdateStat(6, 40);
                            if (parentSession.currentPlayer.ClassName == "Warrior") parentSession.UpdateStat(2, -15);
                            if (parentSession.currentPlayer.ClassName == "Mage") parentSession.UpdateStat(5, -15);
                        }
                        break;
                    case 4:
                        if (choice == 0)
                        {
                            parentSession.SendText("You feel the force flow through you");
                            parentSession.UpdateStat(6, -40); //take stamina
                            parentSession.UpdateStat(3, 15); //add armor
                            parentSession.UpdateStat(3, 10); //add health
                            if (parentSession.currentPlayer.ClassName == "Warrior") parentSession.UpdateStat(2, 5);
                            if (parentSession.currentPlayer.ClassName == "Mage") parentSession.UpdateStat(5, 5);
                        }
                        break;
                    case 5:
                        if(choice == 0)
                        {
                            parentSession.SendText("You feel the force flow through you");
                            parentSession.UpdateStat(4, 15); //add precision
                            parentSession.UpdateStat(1, 20); // takes health

                        }
                        break;
                }
                if (choice == 0) return true;
            }
            else
            {
                parentSession.SendText("This shrine is already used");
                return true;
            }
            return false;
        }
    }
}
