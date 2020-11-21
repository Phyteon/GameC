using Game.Engine.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.LootingLute
{
    [Serializable]
    class SewersEncounter:PlayerInteraction
    {
        private int visited = 0;
        public CaveEncounter caveSituation;
        
        public bool haveBusinnesHere = false;
        public SewersEncounter(GameSession ses, CaveEncounter caveSituation) : base(ses)
        {
            Name = "interaction0622";
            this.caveSituation = caveSituation;
        }
        protected override void RunContent()
        {
            if (haveBusinnesHere == true)
            {
                if (visited == 0)
                {
                    parentSession.SendText("\nYou find entrance to sewers, but it's guarded by some misterious hooded man");
                    int choice1 = parentSession.GetListBoxChoice(new List<string>() { "Excuse me sir, will you let me in?", "*Leave*" });
                    switch (choice1)
                    {
                        case 0:
                            parentSession.SendText("\nI'm not allowed to let strangers here. But I think we can make a deal... 200 gold and I'll let you in");
                            Guard();
                            break;
                        default:
                            parentSession.SendText("\nYou leave this place");
                            break;
                    }
                }
                if (visited == 1)
                {
                    parentSession.SendText("\nIt's you again, do you have money?");
                    Guard();
                }
            }
            else
            {
                parentSession.SendText("\nYou find entrance to sewers, but you have no interest in entering it, so you leave it");
            }
        }
        protected void Guard()
        {
            bool haveRing = parentSession.TestForItem("item0382");
            if (haveRing==true)
            {
                int choice2 = parentSession.GetListBoxChoice(new List<string>() { "*Pay 200 gold*", "I'm going to enter this sewers wether you want it or not!", "*Show your ring*", "I will come back later then" });
                switch (choice2)
                {
                    case 0:
                        if (parentSession.CheckStat(8) >= 200) //check if we have 200 gold
                        {
                            parentSession.SendText("\nVery well, you can enter");
                            parentSession.UpdateStat(8, -200);
                            InSewers();
                        }
                        else
                        {
                            parentSession.SendText("\nYou don't have enough money");
                            visited = 1;
                        }
                        break;
                    case 1:
                        parentSession.SendText("\nI surelly don't want it...");
                        parentSession.FightThisMonster(new VampireKnight(parentSession.CheckStat(7)));
                        parentSession.SendText("\nYou defeated Vampire Knight and enter the sewers");
                        InSewers();
                        break;
                    case 2:
                        parentSession.SendText("\nOh, you have the ring, I didn't know, you can enter");
                        InSewers();
                        break;
                    default:
                        parentSession.SendText("\nDo what you want, I'm not going anywhere");
                        visited = 1;
                        break;
                }
            }
            else
            {
                int choice3 = parentSession.GetListBoxChoice(new List<string>() { "*Pay 200 gold*", "I'm going to enter this sewers wether you want it or not!", "I will come back later then" });
                switch (choice3)
                {
                    case 0:
                        if (parentSession.CheckStat(8) >= 200) //check if we have 200 gold
                        {
                            parentSession.SendText("\nVery well, you can enter");
                            parentSession.UpdateStat(8, -200);
                            InSewers();
                        }
                        else
                        {
                            parentSession.SendText("\nYou don't have enough money");
                            visited = 1;
                        }
                        break;
                    case 1:
                        parentSession.SendText("\nI surelly don't want it...");
                        parentSession.FightThisMonster(new VampireKnight(parentSession.CheckStat(7)));
                        parentSession.SendText("\nYou defeated Vampire Knight and enter the sewers");
                        InSewers();
                        break;
                    default:
                        parentSession.SendText("\nDo what you want, I'm not going anywhere");
                        visited = 1;
                        break;
                }
            }
        }
        protected void InSewers()
        {
            parentSession.SendText("\nYou enter sewers. It's dark here, but you can hear bats flying here. You go after sounds and meets the Lord of Vampires");
            int choice1 = parentSession.GetListBoxChoice(new List<string>() {"Excuse me, I'm looking for a lute and I've heard that you have it","*Try to sneak and find lute silently*","Hey you! I came here for lute, give it to me right now or die!" });
            switch(choice1)
            {
                case 0:
                    caveSituation.tavernHelper = 3;
                    parentSession.SendText("\nWell, that's true. It's mine now. And I don't want money, if you want to take my lute, first I need to see you in a fight with one of my servants");
                    int level = parentSession.CheckStat(7);
                    List<Monster> bats = new List<Monster>() {new AirBat(level), new EarthBat(level),new FireBat(level),new WaterBat(level) };
                    int random = Index.RNG(0, 4);
                    Monster bat = bats[random]; //one of four Elemental Bats
                    parentSession.FightThisMonster(bat);
                    parentSession.SendText("\nNow I know everything, you best get to know people by the way they fight. You are from Luthiers' Village, I know about the curse you are struggling with. You can take this lute, as you can see I appreciate the gift of music. I hope it will help you with your adventure");
                    parentSession.SendText("\nYou take a lute and exit sewers");
                    haveBusinnesHere = false;
                    caveSituation.tavernHelper = 3;
                    break;
                case 1:
                    caveSituation.tavernHelper = 3;
                    int level2 = parentSession.CheckStat(7);
                    parentSession.SendText("\nI can hear you! You're really stupid not knowing that I have super sensitive sense of hearing! And I hate sneaky bastards! Prepare to die!");
                    parentSession.FightThisMonster(new VampireKnight(level2 + 10));
                    parentSession.SendText("\nYou take a lute and exit sewers");
                    haveBusinnesHere = false;
                    caveSituation.tavernHelper = 3;
                    break;
                default:
                    caveSituation.tavernHelper = 3;
                    int level3 = parentSession.CheckStat(7);
                    parentSession.SendText("\nHahaha! You think you are going to beat me? Prepare to die!");
                    parentSession.FightThisMonster(new VampireKnight(level3 + 10));
                    parentSession.SendText("\nYou take a lute and exit sewers");
                    haveBusinnesHere = false;
                    caveSituation.tavernHelper = 3;
                    break;
            }
        }
    }
}
