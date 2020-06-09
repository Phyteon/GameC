using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Items;

namespace Game.Engine.Interactions.TrollBrothers
{
    [Serializable]
    class FymirEncounter : ListBoxInteraction
    {
        private int visited = 0;
        public FymirEncounter(GameSession ses) : base(ses)
        {
            Name = "interaction1141";
        }
        protected override void RunContent()
        {
            if (visited == 0)
            {
                parentSession.SendText("\nHello adventurer! I'm Fymir the Fisherman. Do you want to fish here?");
                int choice = GetListBoxChoice(new List<string>() { "Yea, why not?", "Why would i fish in a puddle?"});
                if (choice == 0)
                {
                    parentSession.SendText("It won't be so easy, I hope you know lyrics of my favourite song, 'Toss A Coin To Your Witcher'.");
                    int choice2 = GetListBoxChoice(new List<string>() { "Give me a second...", "Of course, everyone here knows it" });
                    if (choice2 == 0)
                    {
                    }
                    else
                    {
                        parentSession.SendText("\nOkay, so let's start.");
                        int choice3 = GetListBoxChoice(new List<string>() { "When a humble bard", "When a defiant bard" });
                        if (choice3 == 0)
                        {
                            int choice4 = GetListBoxChoice(new List<string>() { "With Geralt of Rivia", "Graced a ride along" });
                            if (choice4 == 0)
                            {
                                parentSession.SendText("\nDISGRACE TO THIS BEAUTIFUL SONG! GO AWAY");
                            }
                            else
                            {
                                int choice5 = GetListBoxChoice(new List<string>() { "Graced a ride along", "With Geralt of Rivia" });
                                if (choice5 == 0)
                                {
                                    parentSession.SendText("\nDISGRACE TO THIS BEAUTIFUL SONG! GO AWAY");
                                }
                                else
                                {
                                    int choice6 = GetListBoxChoice(new List<string>() { "Along came this song", "Along came this note" });
                                    if (choice6 == 0)
                                    {
                                        parentSession.SendText("\nOkay, okay. You know the lyrics. You can fish here. By the way, did Dymir send you here?");
                                        visited++;
                                    }
                                    else
                                    {
                                        parentSession.SendText("\nDISGRACE TO THIS BEAUTIFUL SONG! GO AWAY");
                                    }
                                }
                            }
                        }
                        else
                        {
                            parentSession.SendText("\nDISGRACE TO THIS BEAUTIFUL SONG! GO AWAY");

                        }
                    }
                }
            }
            if (visited == 1)
            {
                parentSession.SendText("\nBy the way, did Dymir send you here?");
                int choice2 = GetListBoxChoice(new List<string>() { "Yea, he wanted to get his GOLD STONE", "Who?" });
                if (choice2 == 0)
                {
                    parentSession.SendText("\nWell, good luck then! Be careful, I saw some monsters guarding it");
                    int choice = GetListBoxChoice(new List<string>() { "Catch something", "Go away" });
                    if (choice == 0)
                    {
                        int test = Index.RNG(0, 101);
                        if (test <= 25)
                        {
                            parentSession.FightRandomMonster();
                        }
                        if (test > 25 && test <= 40)
                        {
                            GoldStone gold = new GoldStone();
                            parentSession.FightRandomMonster();
                            parentSession.AddThisItem(gold);
                            parentSession.SendText("\nWow, you got it. You shold give it to Bymi... I meant Dymir!!!");
                            visited = 2;
                        }
                        if (test > 40)
                        {
                            parentSession.SendText("\nNot even a nibble...");
                        }
                    }
                }
                else
                {
                    parentSession.SendText("Nevermind");
                    int choice = GetListBoxChoice(new List<string>() { "Catch something", "Go away" });
                    if (choice == 0)
                    {
                        int test = Index.RNG(0, 101);
                        if (test <= 25)
                        {
                            parentSession.FightRandomMonster();
                        }
                        if (test > 25 && test <= 40)
                        {
                            parentSession.AddRandomItem();
                        }
                        if (test > 40)
                        {
                            parentSession.SendText("\nNot even a nibble...");
                        }
                    }
                }
            }
            if (visited == 2)
            {
                int choice = GetListBoxChoice(new List<string>() { "Catch something", "Go away" });
                if (choice == 0)
                {
                    int test = Index.RNG(0, 101);
                    if (test <= 25)
                    {
                        parentSession.FightRandomMonster();
                    }
                    if (test > 25 && test <= 40)
                    {
                        parentSession.AddRandomItem();
                    }
                    if (test > 40)
                    {
                        parentSession.SendText("\nNot even a nibble...");
                    }
                }
            }
        }
    }
}
