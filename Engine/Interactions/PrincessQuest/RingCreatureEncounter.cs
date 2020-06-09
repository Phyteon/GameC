using Game.Engine.Items.Amulet;
using Game.Engine.Monsters;
using System;
using System.Collections.Generic;

namespace Game.Engine.Interactions.PrincessQuest
{
    //this interaction is just a little bit inspired by Hobbit, but at least it's a nice canvas to use plenty of features in the code
    [Serializable]
    class RingCreatureEncounter : ListBoxInteraction
    {
        private KingEncounter king;
        public int visited = 0;
        private int game = 0; //defines what prizes you chose when negotiating
        public RingCreatureEncounter(GameSession gameSession, KingEncounter king) : base(gameSession)
        {
            Name = "interaction1083";
            this.king = king;
        }
        protected override void RunContent()
        {
            if (king.visited == -2) //if the saving princess quest is done, but you haven't been to the smith yet
            {
                parentSession.SendText("\nTo unlock this location find the smith workshop.");
                return;
            }
            if (king.visited == -3) //if saving princess quest is done, and you've been to the smith
            {
                if (visited == 0 || visited == -2) //it's the first time you came here, or you were here before, but ran away before the creature noticed
                {
                    parentSession.SendText("\nYou've entered an old cave, but heard some noise, so you froze in waiting to see what was that." +
                        "\nCREATURE: Who's there? Hello? It must have been some rock falling down...");
                    StandardEncounter();
                    return;
                }
                if (visited == -1) //you came here, but sth bad happened before - you've fought with the creature's pet or ran away
                {
                    parentSession.SendText("\nCREATURE: INTRUDER! YOU AGAIN?! Where are you, I can't see you! Get out of hiding!");
                    StandardEncounter();
                    return;
                }
                if (visited == -3) //you've killed the creature and have its amulet already
                {
                    parentSession.SendText("\nThe cave is empty, you have nothing to look for here.");
                    return;
                }
            }
            else //if you haven't saved the princess yet
            {
                parentSession.SendText("To unlock this interaction you must complete the Saving Princess Quest. Find a castle and kill the dragon.");
                return;
            }
        }
        private void StandardEncounter()//what happens at a standard encounter with the creature
        {
            int choice1 = GetListBoxChoice(new List<string>() {"Go away silently not bothering the creature.", "Attack the creature.", "Wait " +
                "in hiding, quietly listening what the creature is saying." });
            if (choice1 == 0)
            {
                //50% chance to succesfully leave
                int random1 = Index.RNG(1, 101);
                if (random1 >= 50)
                {
                    parentSession.SendText("\nYou've tried to escape the cave, but you got caught in the creature's trap.");
                    EscapeTheTrap();
                    return;
                }
                else
                {
                    parentSession.SendText("You've succesfully left the cave and can come back here later.");
                    return;
                }
            }
            if (choice1 == 1)
            {
                parentSession.SendText("You've attacked the creature, but it was prepared and you end up in a hanging trap." +
                    "\nCREATURE: INTRUDER! INTRUDER! ARGH! I GOT YOU IN MY TRAP!!!");
                int choice2 = GetListBoxChoice(new List<string>() { "Stay quiet - let the mysterious creature talk.", "Try to escape the trap" });
                if (choice2 == 0)
                {
                    RiddleNegotiation();
                    return;
                }
                if (choice2 == 1)
                {
                    EscapeTheTrap();
                    return;
                }
            }
            if (choice1 == 2)
            {
                parentSession.SendText("\nCREATURE: Stupid people... If only they knew my treasure was here they would surely try to steal it.");
                int choice3 = GetListBoxChoice(new List<string>() {"Go out from hiding, peacefully, not trying to fight the creature.", "Attack " +
                    "the creature.", "Keep listening." });
                if (choice3 == 0)
                {
                    parentSession.SendText("\nYOU: Welcome mysterious creature, I'm not here to fight, I've lost my way when going to the town..." +
                        "\nCREATURE: A traveller? You shouldn't be here! Go away!");
                    int choice4 = GetListBoxChoice(new List<string>() { "Leave the cave.", "Attack the creature." });
                    if (choice4 == 0)
                    {   //if you try to leave without creature noticing you you have 50% chances to succesfully leave, but if
                        //you try to leave when you showed yourself to the creature you end up in a trap without other chances.
                        parentSession.SendText("\nYou've tried to escape the cave, but you got caught in the creature's trap.");
                        EscapeTheTrap();
                        return;
                    }
                    if (choice4 == 1)
                    {
                        parentSession.SendText("\nYou've tried to attack the creature, but it was prepared and you end up in a hanging trap." +
                            "\nCREATURE: INTRUDER! YOU FOOL! I GOT YOU IN MY TRAP!!!");
                        EscapeTheTrap();
                        return;
                    }
                }
                if (choice3 == 1)
                {
                    parentSession.SendText("\nYou've tried to attack the creature, but it was prepared and you end up in a hanging trap." +
                            "\nCREATURE: INTRUDER! YOU FOOL! YOU TRIED TO ATTACK ME AND I GOT YOU IN MY TRAP!!!");
                    EscapeTheTrap();
                    return;
                }
                if (choice3 == 2)
                {
                    parentSession.SendText("\nI should protect it better. If someone would know it takes only to reforge it into infinity ring...");
                    int choice5 = GetListBoxChoice(new List<string>() { "Attack.", "Leave." });
                    if (choice5 == 0)
                    {
                        parentSession.SendText("\nYou've tried to attack the creature, but it was prepared and you end up in a hanging trap." +
                            "\nCREATURE: INTRUDER! YOU FOOL! I GOT YOU IN MY TRAP!!! HOW LONG HAVE YOU BEEN HERE?!");
                        EscapeTheTrap();
                        return;
                    }
                    if (choice5 == 1)
                    {
                        int random2 = Index.RNG(1, 101);
                        if (random2 >= 50)
                        {
                            parentSession.SendText("\nYou've tried to escape the cave, but you got caught in the creature's trap.");
                            EscapeTheTrap();
                            return;
                        }
                        else
                        {
                            parentSession.SendText("\nYou've succesfully left the cave and can come back here later.");
                            return;
                        }
                    }
                }
            }
        }
        private void EscapeTheTrap()
        {
            int choice6 = GetListBoxChoice(new List<string>() { "Try to escape the trap.", "Try to negotiate." });
            if (choice6 == 0)
            {
                int random3 = Index.RNG(1, 101); //I use some random element in storytelling here
                if (random3 >= 50)
                {
                    parentSession.SendText("\nYou've succesfully escaped the trap and are free. Be careful next time!");
                    return;
                }
                else
                {
                    parentSession.SendText("\nYou didn't succed in escaping the trap and it only got tighter around your neck.");
                    RiddleNegotiation();
                    return;
                }
            }
            if (choice6 == 1)
            {
                parentSession.SendText("\nYOU: Hey hey! Easy! I might have something to give you that you may like.. Gold maybe? " +
                    "\nCREATURE: Gold? I might let you go then... Ok. We can play a game. You'll have to answer three riddles. If I win - I get " +
                    "your gold, and if you win - I'll let you go.");
                int choice8 = GetListBoxChoice(new List<string>() { "Agree.", "Ask what the creature is holding in his pocket." });
                if (choice8 == 0)
                {
                    game = 1;
                    RiddleTime();
                    return;
                }
                if (choice8 == 1)
                {
                    parentSession.SendText("\nYOU: It's not fair for me! You win my gold, then I should win something too! I can agree " +
                        "to something small... If I win you give me what you have in your pocket.\nCREATURE: It's not fair! But ok, you got " +
                        "a point. If you win I let you go and you can take what's in my pocket, but if you lose I take all your gold!");
                    int choice9 = GetListBoxChoice(new List<string>() {"Agree - lose 150 gold, or win supporting amulet.", "Disagree - lose 50 " +
                        "of your gold if you lose or escape freely if you win." });
                    if (choice9 == 0)
                    {
                        game = 1;
                        RiddleTime();
                        return;
                    }
                    if (choice9 == 1)
                    {
                        game = 2;
                        RiddleTime();
                        return;
                    }
                }
            }
        }
        private void RiddleNegotiation()
        {
            parentSession.SendText("\nNow that I catched you in my trap I have to figure out what to do with you. Maybe" +
                " I'll feed you to my monster friend...");
            int choice7 = GetListBoxChoice(new List<string>() { "Try to negotiate calmly.", "Answer agressively." });
            if (choice7 == 0)
            {
                parentSession.SendText("\nYOU: Hey hey! Easy! I might have something to give you that you may like.. Gold maybe? " +
                    "\nCREATURE: Gold? I might let you go then... Ok. We can play a game. You'll have to answer three riddles. If I win - I get " +
                    "your gold, and if you win - I'll let you go.");
                int choice8 = GetListBoxChoice(new List<string>() { "Agree.", "Ask what the creature is holding in his pocket." });
                if (choice8 == 0)
                {
                    game = 1;
                    RiddleTime();
                    return;
                }
                if (choice8 == 1)
                {
                    parentSession.SendText("\nYOU: It's not fair for me! You win my gold, then I should win something too! I can agree " +
                        "to something small... If I win you give me what you have in your pocket.\nCREATURE: It's not fair! But ok, you got " +
                        "a point. If you win I let you go and you can take what's in my pocket, but if you lose I take all your gold!");
                    int choice9 = GetListBoxChoice(new List<string>() {"Agree - lose 150 gold, or win supporting amulet.", "Disagree - lose 50 " +
                        "of your gold if you lose or escape freely if you win." });
                    if (choice9 == 0)
                    {
                        game = 1;
                        RiddleTime();
                        return;
                    }
                    if (choice9 == 1)
                    {
                        game = 2;
                        RiddleTime();
                        return;
                    }
                }
            }
            if (choice7 == 1)
            {
                parentSession.SendText("\nYOU: You stupid cow! I'll butcher you when I get out!\nCREATURE: You make me really mad! You will fight with my " +
                    "monster pet now! ");
                parentSession.FightRandomMonster();
                parentSession.SendText("\nCREATURE: You won the fight but don't come back here again!");
                visited = -1;
                return;
            }
        }
        private void RiddleTime() //what happens when you agree to riddles
        {
            parentSession.SendText("\nThere are three riddles ahead of you. Each has a single letter for an answer. Press a key for your answer." +
                "\nCREATURE: Ok, First riddle. I'm in you, but not in him, I go up, but not down, I'm in the colosseum, but not a tower, I'm in a puzzle" +
                ", but not a riddle.\nANSWER NOW.");
            string answer1 = parentSession.GetKeyResponse().Item1;
            if (answer1 == "U")
            {
                parentSession.SendText("\nCREATURE: You got it right, but next one won't be so easy! \nThe beginning of eternity, the" +
                    " end of a space. The beginning of every end, and the end of every place.");
                string answer2 = parentSession.GetKeyResponse().Item1;
                if (answer2 == "E")
                {
                    parentSession.SendText("You are correct again, but prepare to give me your gold! The last riddle will destroy you!\n" +
                        "What comes once in a minute, twice in a moment, but not once in a thousand years?");
                    string answer3 = parentSession.GetKeyResponse().Item1;
                    if (answer3 == "M")
                    {
                        parentSession.SendText("ARGH! YES, THE LETTER M, BUT I WON'T GIVE YOU THAT AMULET WITHOUT A FIGHT!");
                        parentSession.FightThisMonster(new Golem(parentSession.currentPlayer.Level));
                        if (game == 2)
                        {
                            parentSession.SendText("Congratulations, you've defeated the creature and gained a new item - The supporting amulet. You can go now to the smith " +
                            "and get your payment - infinity ring.");
                            parentSession.AddThisItem(new SupportingAmulet());
                            visited = -3;
                            return;
                        }
                        parentSession.SendText("\nCongratulations, you've defeated the creature. You can go to the smith to get your payment - infinity ring.");
                        visited = -3;
                        return;
                    }
                    if (answer3 != "M")
                    {
                        YouLost();
                        return;
                    }
                }
                if (answer2 != "E")
                {
                    YouLost();
                    return;
                }
            }
            if (answer1 != "U")
            {
                YouLost();
                return;
            }
        }
        private void YouLost()//what happens if you lose the game
        {
            if (game == 1)
            {
                parentSession.SendText("\nCREATURE: WRONG! The answer is letter 'u'. Give me your gold now!");
                parentSession.UpdateStat(8, -150);
                visited = -1;
                return;
            }
            if (game == 2)
            {
                parentSession.SendText("\nCREATURE: WRONG! The answer is letter 'u'. Give me your gold now!");
                parentSession.UpdateStat(8, -50);
                visited = -1;
                return;
            }
        }
    }
}
