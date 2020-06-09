using Game.Engine.Monsters;
using System;
using System.Collections.Generic;

namespace Game.Engine.Interactions.PrincessQuest
{
    [Serializable]
    class TowerEncounter : ListBoxInteraction
    {
        public int ifSaved = 0;
        public bool ifMageVisited = false;
        public TowerEncounter(GameSession parentSession) : base(parentSession)
        {
            Name = "interaction1082";
        }

        protected override void RunContent()
        {

            if (ifMageVisited == false)
            {
                parentSession.SendText("\nHahahah! Welcome brave adventurer, how dare you bother me? I'm a mad witch and I'll " +
                    "feed you to my dragon! Curious Why? Ask the king in his castle!");
                return;
            }
            if (ifMageVisited == true && ifSaved == 0)
            {
                parentSession.SendText("\nThis castle isn't guarded by the witch - do you want to fight the dragon and save the princess?");
                int choice = GetListBoxChoice(new List<string>() { "Yes.", "No, exit." });
                if (choice == 0)
                {
                    parentSession.FightThisMonster(new DeathDragon(parentSession.currentPlayer.Level));
                    ifSaved = 1;
                    return;
                }
                if (choice == 1)
                {
                    return;
                }
            }
            if (ifMageVisited == true && ifSaved == 1)
            {
                parentSession.SendText("You've killed the dragon, nothing to do here anymore.");
            }
        }
    }
}
