using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.MainDarkElf
{
    [Serializable]
    class MainDarkElfTaregtState : MainDarkElfState
    {
        public override void RunContent(GameSession parentSession, MainDarkElfEncounter myself, MainWitch.MainWitchEncounter mWitch, List<BasicDarkElf.BasicDarkElfEncounter> bElfs)
        {
            int choice = parentSession.GetListBoxChoice(new List<string>() { "Die you renegade!", "Greetings. I'm searching for some information about the Temple." });
            switch (choice)
            {
                case 0:
                    parentSession.SendText("\nLet me guess. The Witch sent you? There's no need to fight. What do you want?");
                    int choice2 = parentSession.GetListBoxChoice(new List<string>() { "Tell me something interesting about the Temple.", "You won't manipulate me! Prepare yourself to die!" });
                    switch (choice2)
                    {
                        case 0:
                            parentSession.SendText("\nI could but, information has it's price. Bring me a head of this Witch who sent you. Deal?");
                            int choice3 = parentSession.GetListBoxChoice(new List<string>() { "You won't manipulate me! Prepare yourself to die!", "Deal" });
                            switch (choice3)
                            {
                                case 0:
                                    parentSession.FightThisMonster(new Monsters.Forest.MainDarkElf(), false);
                                    parentSession.SendText("Stop! You won. I will tell you something but spare my life. Fairies had their main rule. They had to pray to the Spirit of the Moon every full moon and ask him for the meagic he generates. \nTake this fake head and give it to the witch.");
                                    int choice4 = parentSession.GetListBoxChoice(new List<string>() { "Thank you.", "I prefere the real one." });
                                    switch (choice4)
                                    {
                                        case 0:
                                            parentSession.SendText("Also take some money and fake head.");
                                            myself.ChangeState(new MainDarkElfGratefulState());
                                            parentSession.AddThisItem(Index.ProduceSpecificItem("item0127"));
                                            parentSession.UpdateStat(8, 50);
                                            break;
                                        case 1:
                                            parentSession.RemoveCurrentlyVisitedInteraction();
                                            parentSession.AddThisItem(Index.ProduceSpecificItem("item0126"));
                                            foreach (BasicDarkElf.BasicDarkElfEncounter bElf in bElfs)
                                            {
                                                bElf.Strategy = new BasicDarkElf.BasicDarkElfHostileStrategy();
                                            }
                                            parentSession.UpdateStat(7, 500);
                                            break;
                                    }
                                    break;
                                case 1:
                                    myself.ChangeState(new MainDarkElfWaitingState());
                                    mWitch.ChangeState(new MainWitch.MainWitchBetrayedState());
                                    break;
                            }
                            break;
                        case 1:
                            parentSession.FightThisMonster(new Monsters.Forest.MainDarkElf(), false);
                            parentSession.SendText("Stop! You won. I will tell you something but spare my life. Fairies had their main rule. They had to pray to the Spirit of the Moon every full moon and ask him for the meagic he generates. \nTake this fake head and give it to the witch.");
                            int choice5 = parentSession.GetListBoxChoice(new List<string>() { "Thank you.", "I prefere the real one." });
                            switch (choice5)
                            {
                                case 0:
                                    parentSession.SendText("Also take some money and fake head.");
                                    myself.ChangeState(new MainDarkElfGratefulState());
                                    parentSession.AddThisItem(Index.ProduceSpecificItem("item0127"));
                                    parentSession.UpdateStat(8, 50);
                                    break;
                                case 1:
                                    parentSession.RemoveCurrentlyVisitedInteraction();
                                    parentSession.AddThisItem(Index.ProduceSpecificItem("item0126"));
                                    foreach (BasicDarkElf.BasicDarkElfEncounter bElf in bElfs)
                                    {
                                        bElf.Strategy = new BasicDarkElf.BasicDarkElfHostileStrategy();
                                    }
                                    parentSession.UpdateStat(7, 500);
                                    break;
                            }
                            break;
                        

                    }                   
                    break;
                case 1:
                    parentSession.SendText("\nI could but, information has it's price. Bring me a head of this Witch who sent you. Deal?");
                    int choice7 = parentSession.GetListBoxChoice(new List<string>() { "You won't manipulate me! Prepare yourself to die!", "Deal" });
                    switch (choice7)
                    {
                        case 0:
                            parentSession.FightThisMonster(new Monsters.Forest.MainDarkElf(), false);
                            parentSession.SendText("Stop! You won. I will tell you something but spare my life. Fairies had their main rule. They had to pray to the Spirit of the Moon every full moon and ask him for the meagic he generates. \nTake this fake head and give it to the witch.");
                            int choice8 = parentSession.GetListBoxChoice(new List<string>() { "Thank you.", "I prefere the real one." });
                            switch (choice8)
                            {
                                case 0:
                                    parentSession.SendText("Also take some money and fake head.");
                                    myself.ChangeState(new MainDarkElfGratefulState());
                                    parentSession.AddThisItem(Index.ProduceSpecificItem("item0127"));
                                    parentSession.UpdateStat(8, 50);
                                    break;
                                case 1:
                                    parentSession.RemoveCurrentlyVisitedInteraction();
                                    parentSession.AddThisItem(Index.ProduceSpecificItem("item0126"));
                                    foreach (BasicDarkElf.BasicDarkElfEncounter bElf in bElfs)
                                    {
                                        bElf.Strategy = new BasicDarkElf.BasicDarkElfHostileStrategy();
                                    }
                                    parentSession.UpdateStat(7, 500);
                                    break;
                            }
                            break;
                        case 1:
                            myself.ChangeState(new MainDarkElfWaitingState());
                            mWitch.ChangeState(new MainWitch.MainWitchBetrayedState());
                            break;
                    }
                    break;


            }
        }
    }
}
