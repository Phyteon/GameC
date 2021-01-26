using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine;

namespace Game.Engine.Interactions.Built_In
{
    [Serializable]
    class OldTravelerInitialState : OldTravelerState
    {
        private int payment = 0;
        public override void RunContent(GameSession parentSession, OldTravelerEncounter myself)
        {
            parentSession.SendText("\nWelcome adventurer. I am an old traveler that travels around space. If you kill few monsters I will reward you. Will you manage to do that?");

            int choice = parentSession.GetListBoxChoice(new List<string>() { "Yes, I will.", "Can you give me something without killing the monsters?" });
            switch (choice)
            {
                case 0:
                    KillMonsters(parentSession, myself);
                    break;
                case 1:
                    parentSession.SendText("How dare you ask questions like that! Go away!");
                    myself.ChangeState(new OldTravelerHostileState(), true);
                    break;
            }
        }
        private void KillMonsters(GameSession parentSession, OldTravelerEncounter myself)
        {
            parentSession.SendText("Great! With each monster killed you get 3 gold and a surprise item! Goodluck!");
            int choice = parentSession.GetListBoxChoice(new List<string>() { "Kill 1 monster", "Kill 3 monsters", "Kill 6 monsters" });
            string Item = "item1321";
            if(choice == 0)
            {
                parentSession.FightRandomMonster();
                parentSession.SendText("Good. Here is your 3 gold and a surprise item");
                parentSession.UpdateStat(8, payment);
                parentSession.AddRandomClassItem();
                myself.ChangeState(new OldTravelerComplete(), true);
            }
            if(choice == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    parentSession.FightRandomMonster();
                }
                parentSession.SendText("Good. Here is your 9 gold and a surprise item");
                parentSession.UpdateStat(8, payment);
                parentSession.AddRandomClassItem();
                parentSession.AddThisItem(Index.ProduceSpecificItem(Item));

                myself.ChangeState(new OldTravelerComplete(), true);
            }
            else if(choice == 2)
            {
                for (int i = 0; i < 6; i++)
                {
                    parentSession.FightRandomMonster();
                }
                parentSession.SendText("Good. Here is your 18 gold and a surprise item");
                parentSession.UpdateStat(8, payment);
                parentSession.AddRandomClassItem();
                parentSession.AddThisItem(Index.ProduceSpecificItem("item1320"));
                parentSession.AddThisItem(Index.ProduceSpecificItem("item1321"));
                myself.ChangeState(new OldTravelerComplete(), true);
            }
        }
    }
}

