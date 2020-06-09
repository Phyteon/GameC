using Game.Engine.CharacterClasses;
using Game.Engine.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.LootingLute
{
    [Serializable]
    class StudentHouseEncounter:ListBoxInteraction
    {
        public SewersEncounter sewersSituation;
        private int visited = 0;
        public bool haveKey = false;
        public StudentHouseEncounter(GameSession ses, SewersEncounter sewersSituation) : base(ses)
        {
            Name = "interaction0621";
            Enterable = true;
            
            this.sewersSituation = sewersSituation;
        }
        protected override void RunContent()
        {
            if (visited==0)
            {
                parentSession.SendText("\nYou find a house.");
                int choice1 = GetListBoxChoice(new List<string>() { "\nTry to enter the house", "Leave" });
                switch (choice1)
                {
                    case 0:
                        haveKey = parentSession.TestForItem("item0382");
                        if (haveKey == true)
                        {

                            parentSession.SendText("\n*You enter a house using a key and meet a man*\nWhaaat?! How the heck have you got a key to my house?! You will regret that! Meet my guard, Scotty, he will teach you good manners!");
                            parentSession.FightThisMonster(new Thug(parentSession.CheckStat(7)));
                            parentSession.SendText("\nYou defeated my guard! Who are you? And why have you entered my house?");
                            int choice2 = GetListBoxChoice(new List<string>() { "I’m looking for some lute, a stranger in a tavern asked me to get it to him", "I’m here to take a lute and you better tell me where it is or you’ll finish just like your bodyguard!", });
                            switch (choice2)
                            {
                                case 0:
                                    parentSession.SendText("\nYou work for this scum? Well, I have bad news for you anyway, the other day a man in a hood came here and offered me big amount of money for this lute. I sold it! But we can make a deal. I have 500 gold coins and they can be yours if you’ll just tell me, where he’s hiding.");
                                    int choice3 = GetListBoxChoice(new List<string>() { "*Tell the truth* He’s hiding in a Tavern.", "*Lie* He’s hiding in a cave in the forest.", "*Refuse* I don’t want money, tell me where is the lute." });
                                    switch (choice3)
                                    {
                                        case 0:
                                            parentSession.SendText("\nVery well, here’s your money. And now get out, I have some business to do…");
                                            parentSession.UpdateStat(8, 500);
                                            sewersSituation.caveSituation.tavernHelper = -1;
                                            visited = 1;
                                            break;
                                        case 1:
                                            parentSession.SendText("\nWho are you trying to lie to? This dude will never hide in forest, he’s more feminine than lady at this matter! I think Scotty already feels better and he want some revenge…");
                                            parentSession.FightThisMonster(new ThugSurvivor(parentSession.CheckStat(7) + 1));
                                            parentSession.SendText("\nAlright, alright! I don’t want to fight with you anymore. I will tell you where the lute is. The guy told something about how this lute will be perfect for his lord for listening to. It was a sunny day, but he wore a hood and black robe. I think he might have been a vampire! You should check in sewers. Here, take some money for not killing me.");
                                            parentSession.SendText("\nYou receive 200 gold");
                                            parentSession.UpdateStat(8, 200);
                                            sewersSituation.haveBusinnesHere = true;
                                            visited = 1;
                                            break;
                                        default:
                                            parentSession.SendText("\nAghh fine! I don’t want to fight with you anymore. The guy told something about how this lute will be perfect for his lord for listening. It was a sunny day, but he wore a hood and black robe. I think he might have been a vampire! You should check in sewers.");
                                            parentSession.SendText("You receive xp for being good person");
                                            parentSession.UpdateStat(7, 500);
                                            sewersSituation.haveBusinnesHere = true;
                                            visited = 1;
                                            break;
                                    }
                                    break;
                                default:
                                    parentSession.SendText("\nI think Scotty already feels better and he want some revenge…");
                                    parentSession.FightThisMonster(new ThugSurvivor(parentSession.CheckStat(7) + 1));
                                    parentSession.SendText("\nAlright! I don’t want to fight with you anymore.I sold it to some misterious guy, he told something about how this lute will be perfect for his lord for listening. It was a sunny day, but he wore a hood and black robe. I think he might have been a vampire! You should check in sewers.");
                                    parentSession.SendText("\nYou receive xp for forcing information");
                                    parentSession.UpdateStat(7, 300);
                                    sewersSituation.haveBusinnesHere = true;
                                    visited = 1;
                                    break;
                            }
                        }
                        else
                        {
                            parentSession.SendText("\nYou're trying to open the door, but it's closed");
                        }
                        break;
                    default:
                        parentSession.SendText("\nYou leave this house in peace");
                        break;
                }

            }
            else
            {
                parentSession.SendText("\nYou decide not to disturb people here anymore");
            }
        }
    }
}
