using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.LootingLute
{
    [Serializable]
    class TavernEncounter:PlayerInteraction
    {
         
        public static StudentHouseEncounter studentHouseSituation;
        private bool haveBeer = false;
         // has this place been visited?
        public TavernEncounter(GameSession ses, StudentHouseEncounter keyToHouse) : base(ses)
        {
            Name = "interaction0620";
            Enterable = true;
            studentHouseSituation = keyToHouse;
            
        }
        
        protected override void RunContent()
        {
            
            if (studentHouseSituation.sewersSituation.caveSituation.tavernHelper == -2)//Entering second time after good ending makes bard going somewhere else
            {
                
                parentSession.SendText("\nYou enter a tavern, but nothing interesting happens. You decide to leave");
                studentHouseSituation.sewersSituation.caveSituation.strategy = new CaveFriendlyStrategy();
                return;
            }
            if (studentHouseSituation.sewersSituation.caveSituation.tavernHelper == -1)//after bad ending
            {
                parentSession.SendText("\nYou enter a tavern, but you feel everyones eyes on you. You decide to leave");
                studentHouseSituation.sewersSituation.caveSituation.strategy = new CaveHostileStrategy();
                return;
            }
            if (studentHouseSituation.sewersSituation.caveSituation.tavernHelper == 4)//after good ending
            {
                parentSession.SendText("\nHello my friend! Thanks to you a can play my lute again!");
                studentHouseSituation.sewersSituation.caveSituation.tavernHelper = -2;
                return;
            }
            if (studentHouseSituation.sewersSituation.caveSituation.tavernHelper == 0)
            {
                parentSession.SendText("\nYou enter a tavern.");
                int choice1 = parentSession.GetListBoxChoice(new List<string>() { "Buy a beer", "Talk to stranger", "Leave" });
                switch (choice1)
                {
                    case 0:
                        parentSession.UpdateStat(8, -5);
                        parentSession.SendText("\nYou bought a beer");
                        haveBeer = true;
                        break;
                    case 1:
                        if (haveBeer)
                        {
                            parentSession.SendText("\nI see you have a beer and you’re looking for company, would you mind sitting with me and talking?");
                            int choice3 = parentSession.GetListBoxChoice(new List<string>() { "Not at all, thank you for invitation", "Piss off, you're drunk!" });
                            switch (choice3)
                            {
                                case 0:
                                    parentSession.SendText("\nEhh, it's hard to be bard these days you know? I'm Dante by the way! *gives you a hand to shake*");
                                    int choice4 = parentSession.GetListBoxChoice(new List<string>() { "*Just shake his hand and don't talk*", "*Shake his hand* Nice to meet you, my name is...", "*Don't shake his hand* Nice to meet you Dante, but I prefer not to reveal my name." });
                                    if (choice4 == 0)
                                    {
                                        studentHouseSituation.sewersSituation.caveSituation.tavernHelper = 1;
                                        parentSession.SendText("\nHmm, you're quite a quiet guy, but I think you could help me with my problem. You see, I have lost my lute, the best lute in my life, made in Luthiers' Village long before the curse has been cast on them, poor people. You look like a real adventurer that I could use help. Will you help me getting it back?");
                                        QuestStart();
                                    }
                                    else if (choice4 == 1)
                                    {
                                        studentHouseSituation.sewersSituation.caveSituation.tavernHelper = 1;
                                        parentSession.SendText("\nDon't tell me your name, I'm in a bit trouble and I'm afraid that the people that are after me could harm you if I knew your name... But you look like a real adventurer that I could use help. You see, I have lost my lute, the best lute in my life, made in Luthiers' Village long before the curse has been cast on them, poor people. Will you help me getting it back?");
                                        QuestStart();
                                    }
                                    else
                                    {
                                        studentHouseSituation.sewersSituation.caveSituation.tavernHelper = 1;
                                        parentSession.SendText("\nSmart move, better not to tell your name to strangers like me, but I have nothing to lose, I’m not safe anywhere. You see, I have lost my lute, the best lute in my life, made in Luthiers' Village long before the curse has been cast on them, poor people. Maybe you’ll help me? you look like a real adventurer that I could use help. Will you help me getting it back?");
                                        QuestStart();
                                    }
                                    break;
                                default:
                                    parentSession.SendText("\nBad day huh? I don't care, if you'll change your mind come back");
                                    break;
                            }
                        }
                        else
                        {
                            parentSession.SendText("\nWhat do you want from me? I’m sure he’s sent you for me!");
                            int choice2 = parentSession.GetListBoxChoice(new List<string>() { "What are you talking about? Who’s “he”?", "*lie* Yes, and now you’re going to pay me!" });
                            switch (choice2)
                            {
                                case 0:
                                    parentSession.SendText("\nI don't believe you!");
                                    break;
                                default:
                                    parentSession.SendText("\nWell, I have literally nothing to lose(Stranger runs away)");
                                    studentHouseSituation.sewersSituation.caveSituation.tavernHelper = -1; //No posibility to start this quest
                                    break;
                            }
                        }
                        break;
                    default:
                        break;

                }
            }
            if (studentHouseSituation.sewersSituation.caveSituation.tavernHelper == 1)
            {
                parentSession.SendText("\nYou came back! Will you help me now?");
                QuestStart();
            }
            if (studentHouseSituation.sewersSituation.caveSituation.tavernHelper == 2)
            {
                parentSession.SendText("\nYou don't have my lute, do you? Please, it's very important to me!");
            }
            if (studentHouseSituation.sewersSituation.caveSituation.tavernHelper == 3)
            {
                parentSession.SendText("\nYou came back! With my lute! I don't know how to thank you! Are you fine?");
                int choice1 = parentSession.GetListBoxChoice(new List<string>() { "It wasn't easy to get it back, I hope for a reward.", "Yeeeaah, it was really easy..." });
                switch (choice1)
                {
                    case 0:
                        parentSession.SendText("\nOf course you deserve a reward! Here, take this money, I have won some by playing cards during your absence. I know it's not much for your help, but I promise, if we meet again I will have something really nice for you. It was nice to meet you!");
                        parentSession.UpdateStat(7, 500);
                        parentSession.UpdateStat(8, 200);
                        studentHouseSituation.sewersSituation.caveSituation.tavernHelper = 4;
                        break;
                    default:
                        parentSession.SendText("\nYou're kidding right? You really have sense of humour my friend! Here, take this money, I have won some by playing cards during your absence. I know it's not much for your help, but I promise, if we meet again I will have something really nice for you. It was nice to meet you!");
                        parentSession.UpdateStat(7, 500);
                        parentSession.UpdateStat(8, 200);
                        studentHouseSituation.sewersSituation.caveSituation.tavernHelper = 4;
                        break;
                }
            }


        }
        protected void QuestStart()
        {

            int choice1 = parentSession.GetListBoxChoice(new List<string>() { "Sure, no problem.", "I don’t have time for this right now." });
            switch(choice1)
            {
                case 0:
                    studentHouseSituation.sewersSituation.caveSituation.tavernHelper = 2;
                    studentHouseSituation.haveKey = true;
                    parentSession.SendText("\nYes! Thank you so much! So, here’s the deal, I was giving a lesson of singing to some pretty lady. Of course, I’m a professional, and I practice extraordinary methods of teaching. It appears that husband of this lady didn’t care much for artistic education of his wife. Anyway, I had to run away using my well-developed skills of climbing down the balcony. I’m afraid that my lute is still there. You have to get it back, I believe in you! I cannot pay you right now, but I can pawn you my ring. Here is a ring, which in fact is a magic key to this house, I used to use it for, ekhm, easier access to my student of course!");
                    parentSession.AddThisItem(Index.ProduceSpecificItem("item0382")); //Armor ring
                    studentHouseSituation.haveKey = true;
                    studentHouseSituation.sewersSituation.caveSituation.tavernHelper = 2;
                    break;
                default:
                    studentHouseSituation.sewersSituation.caveSituation.tavernHelper = 1;
                    parentSession.SendText("\nOkay, then come back if you’ll have some. I’ll be waiting.");
                    studentHouseSituation.sewersSituation.caveSituation.tavernHelper = 1;
                    break;
            }

        }
    }
}
