using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Items;
using Game.Engine.Monsters;

namespace Game.Engine.Interactions.TrollBrothers
{
    [Serializable]
    class BymirEncounter : PlayerInteraction
    {
        private int visited = 0;
        public BymirEncounter(GameSession ses) : base(ses)
        {
            Name = "interaction1142";
        }
        protected override void RunContent()
        {
            if (visited == 0)
            {
                parentSession.SendText("\nDon't bother me. I'm praying to Our Lord to get my GOLD STONE back and hope my brother Dymir will be hit by lightning");
                parentSession.SendText("\nPraise be to God, Our Lord! I hope my stupid brother Dymir will be judged justly... Praise be to God, Our Lord!");
                int choice = parentSession.GetListBoxChoice(new List<string>() { "Umm... I found something for you", "Okay, I won't", "Do you know the lyrics of 'Toss A Coin To Your Witcher'?" });
                parentSession.GetActiveItemNames();
                bool test = parentSession.TestForItem("item0852");
                if (choice == 0 && test == true)
                {
                    parentSession.SendText("\nUnbelievable! Lord sent you, my child, from heaven. Tell me, will Dymir be hit by lightning? Or nevermind. Keep this stone, it will be a present from our town to God (+ 300 xp)");
                    parentSession.UpdateStat(7, 300);
                    visited = 1;
                }
                if (choice == 0 && test == false)
                {
                    UndeadBishop bishop = new UndeadBishop(1);
                    parentSession.SendText("\nYou IDIOT! It's not my GOLD STONE! Attack Jymir, Kymir and Lymir!");
                    parentSession.FightThisMonster(bishop);
                    parentSession.FightThisMonster(bishop);
                    parentSession.FightThisMonster(bishop);
                    visited = 1;
                }
                if (choice == 2)
                {
                    parentSession.SendText("\nThat's my brother's favourite song!");
                    parentSession.SendText("\nWhen a humble bard");
                    parentSession.SendText("\nGraced a ride along");
                    parentSession.SendText("\nWith Geralt of Rivia");
                    parentSession.SendText("\nAlong came this song");
                    parentSession.SendText("\nWhen the White Wolf fought");
                    parentSession.SendText("\nA silver tongued devil");
                    parentSession.SendText("\nHis army of elves");
                    parentSession.SendText("\nAt his hooves did they revel");
                }
                else
                {
                    return;
                }
            }
            if (visited == 1)
            {
                parentSession.SendText("\nPraise be to God, Our Lord! I hope my stupid brother Dymir will be judged justly... Praise be to God, Our Lord!");
            }
        }
    }
}
