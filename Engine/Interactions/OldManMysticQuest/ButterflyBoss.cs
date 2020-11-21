using Game.Engine.CharacterClasses;
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
	class ButterflyBoss : PlayerInteraction, IBoss
	{
        public Item item { get; set; }

        public int NumberOfBoss { get; set; }

        public bool IsDefeated { get; set; }

        public bool HaveSkill { get; set; }

        public string NameView { get; set; }

        Butterfly boss;

        public ButterflyBoss(GameSession ses) : base(ses)
        {

            NameView = "Butterfly";
            Name = "interaction0271";
            NumberOfBoss = 2;
            item = new WindStaff();

        }

        int visited = 0;
        protected override void RunContent()
        {
            boss = new Butterfly((int)(parentSession.currentPlayer.Level * 1.1));

            //sprawdzam czy mam odpowiedni przedmiot:
            if (parentSession.TestForItem(item.Name) == true & visited == 0)
            {
                visited++;
                parentSession.SendText("*opening the door*");
                parentSession.FightThisMonster(boss);
                IsDefeated = true;
                parentSession.SendText("You defeated the monster!");
            }
            else if(IsDefeated == true)
            {

                parentSession.SendText("Congratulations.");
            }
            else
            {
                parentSession.SendText("You don't have the right item to start a battle.");
            }

        }


    }
}
