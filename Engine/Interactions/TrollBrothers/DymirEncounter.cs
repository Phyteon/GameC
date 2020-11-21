using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Monsters;

namespace Game.Engine.Interactions.TrollBrothers
{
    [Serializable]
    class DymirEncounter : PlayerInteraction
    {
        private int visited = 0;
        public DymirEncounter(GameSession ses) : base(ses)
        {
            Name = "interaction1140";
        }
        protected override void RunContent()
        {
            if (visited == -1)
            {
                parentSession.SendText("\nDon't come here again! Honey?! Can you come here again for a second?");
                Elementalist wife = new Elementalist(1);
                parentSession.FightThisMonster(wife);
                parentSession.SendText("\nDon't hurt me please :c");
                return;
            }
            if (visited == 1)
            {
                parentSession.SendText("\nOh, hello. Do you have MY GOLD STONE?.");
                int choice = parentSession.GetListBoxChoice(new List<string>() { "Yes, here you go!", "Not yet...", "No and you will not get it anyway","Do you know the lyrics of 'Toss A Coin To Your Witcher'?"});
                parentSession.GetActiveItemNames();
                bool test = parentSession.TestForItem("item0852");
                if (choice == 0 && test == true)
                {
                    parentSession.SendText("\nOh my precious... My treasure... Oh yea, I forgot about reward... Take this trash and don't come here again! HONEY, LOOK WHAT I HAVE!!!\nHey! GIVE ME BACK MY GOLD STONE!!!");
                    Elementalist wife = new Elementalist(5);
                    parentSession.FightThisMonster(wife);
                    parentSession.SendText("\nDon't hurt me please, take it and don't come here again!");
                    parentSession.AddRandomItem();
                    parentSession.UpdateStat(8, 1);
                    visited = -1;
                }
                if (choice == 0 && test == false)
                {
                    parentSession.SendText("\nYou IDIOT! It's not a GOLD STONE! Don't come again without MY GOLD STONE!");
                }
                if (choice == 1)
                {
                    parentSession.SendText("\nSo what are you doing here?! Don't come again without MY GOLD STONE!");
                }
                if (choice == 2)
                {
                    parentSession.SendText("\nOh you're so dead... HONEY!!! YOUR EX HERE AGAIN FOR MORE MONEY!");
                    Elementalist wife2 = new Elementalist(10);
                    parentSession.FightThisMonster(wife2);
                    parentSession.SendText("\nDon't hurt me please :c");
                    visited = -1;
                }
                if (choice == 3)
                {
                    parentSession.SendText("\nOh my God... Everyone knows that...");
                    parentSession.SendText("\nWhen a humble bard");
                    parentSession.SendText("\nGraced a ride along");
                    parentSession.SendText("\nWith Geralt of Rivia");
                    parentSession.SendText("\nAlong came this song");
                    parentSession.SendText("\nWhen the White Wolf fought");
                    parentSession.SendText("\nA silver tongued devil");
                    parentSession.SendText("\nHis army of elves");
                    parentSession.SendText("\nAt his hooves did they revel");
                    parentSession.SendText("\nNow go find it!");
                }
            }
            parentSession.SendText("\nWife: OH MY LORD... HOW COULD YOU LOSE THAT STONE?!\nDymir's wife hits him with his double bass.\nDymir: Oh, hello! I haven't been expecting any guests... What ya want?");
            int choice2 = parentSession.GetListBoxChoice(new List<string>() { "Umm... Do you need any help?", "Sorry, not this house"});
            switch (choice2)
            {
                case 0:
                    parentSession.SendText("\nI lost my GOLD STONE which i have stol... i mean borrowed, yeah borrowed... from my brother Bymir");
                    parentSession.SendText("\nCould you help me? i threw it accidently to my another's brother, Fymir, puddle. It's not a normal puddle and i think you can easily do this.");
                    int choice3 = parentSession.GetListBoxChoice(new List<string>() { "Fine, Will I get something for that?.", "Are you serious? PUDDLE?! Go find it yourself!" });
                    if (choice3 == 0)
                    {
                        parentSession.SendText("\nWell, I can give you a reward. This thing is worth millions of gold! Now go away, you wouldn't want to see my wife.");
                        visited = 1;
                    }
                    else
                    {
                        parentSession.SendText("\nHoney! Your ex came here for money again!");
                        Elementalist wife = new Elementalist(5);
                        parentSession.FightThisMonster(wife);
                        parentSession.SendText("\nDon't hurt me please :c");
                        visited = -1;
                    }
                    break;
                case 1:
                    break;
            }
        }
    }
}
