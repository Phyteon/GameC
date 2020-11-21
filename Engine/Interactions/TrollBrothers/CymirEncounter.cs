using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Skills.SimpleSkills;

namespace Game.Engine.Interactions.TrollBrothers
{
    [Serializable]
    class CymirEncounter : PlayerInteraction
    {
        private int visited = 0;
        private CaveEncounter cave;
        public CymirEncounter(GameSession ses, CaveEncounter cave) : base(ses)
        {
            Name = "interaction1143";
            this.cave = cave;

        }
        protected override void RunContent()
        {
            if (visited == 1)
            {
                parentSession.SendText("Hello, would you like some bat soup? Bon appetit!");
            }
            if (visited == -1)
            {
                parentSession.SendText("DON'T COME HERE AGAIN, YOU *$#^@$#%&$#!.");
                int choice = parentSession.GetListBoxChoice(new List<string>() { "You ^%#&#%#^^", "*Just go away*" });
            }

            if (visited == 2)
            {
                parentSession.SendText("\nAnd? Do you have these bats?");
                int choice = parentSession.GetListBoxChoice(new List<string>() { "Yes, here you go", "Not yet" });
                parentSession.GetActiveItemNames();
                bool test = parentSession.TestForItem("item0854");
                if (choice == 0 && test == true)
                {
                    cave.Strategy = new CaveNormalStrategy();
                    parentSession.SendText("\nPerfect! These bats will be ideal for my bat soup!");
                    parentSession.SendText("\nWould you like to help me make this soup? You will be able to try it first!");
                    int choice2 = parentSession.GetListBoxChoice(new List<string>() { "Why not?", "Sorry, but I need to go" });
                    if (choice2 == 0)
                    {
                        parentSession.SendText("\nGive me a big pot.");
                        int choice3 = parentSession.GetListBoxChoice(new List<string>() { "Give a pot", "Give a flower pot" });
                        if (choice3 == 0)
                        {
                            parentSession.SendText("\nOkay, it's time for some water.");
                            int choice4 = parentSession.GetListBoxChoice(new List<string>() { "Go to the toilet for water", "Go to the river for water" });
                            if (choice4 == 0)
                            {
                                parentSession.SendText("What are you doing??? GO AWAY %$!&#$^&#@$&$");
                                visited = -1;
                            }
                            else
                            {
                                parentSession.SendText("Can you give me these bats?");
                                int choice5 = parentSession.GetListBoxChoice(new List<string>() { "Give the bats from cave", "Give a baseball bat" });
                                if (choice5 == 0)
                                {
                                    parentSession.SendText("Perfect!!! Now you can try it. We did it! It is the best soup ever. You deserve a reward! Hope to see you again!");
                                    parentSession.UpdateStat(7, 200);
                                    parentSession.UpdateStat(8, 40);
                                    parentSession.AddRandomItem();
                                    visited = 1;
                                }
                                else
                                {
                                    parentSession.SendText("What are you doing??? GO AWAY %$!&#$^&#@$&$");
                                    parentSession.LearnThisSkill(new VerbalAbuse());
                                    visited = -1;
                                }
                            }
                        }
                        else
                        {
                            parentSession.SendText("What are you doing??? GO AWAY %$!&#$^&#@$&$");
                            parentSession.LearnThisSkill(new VerbalAbuse());
                            visited = -1;
                        }
                    }
                    else
                    {
                        parentSession.SendText("Okay, you #$%$#@#$@%#@S#%#%. I don't need your help anyway!");
                        parentSession.LearnThisSkill(new VerbalAbuse());
                        visited = -1;
                    }
                }
                if (choice == 0 && test == false)
                {
                    cave.Strategy = new CaveNormalStrategy();
                    parentSession.SendText("Okay, you #$%$#@#$@%#@S#%#%. I don't need your help anyway!");
                    parentSession.LearnThisSkill(new VerbalAbuse());
                    visited = -1;
                }
            }
            
            if (visited == 0)
            {
                parentSession.SendText("\nOh, hello adventurer. I'm Cymir, chef of this restaurant since we lost the Gift of The Music. Would you like to help me cook something?");
                int choice = parentSession.GetListBoxChoice(new List<string>() { "Yes, what are you cooking?", "Sorry, but I came here to eat" });
                if (choice == 0)
                {
                    cave.Strategy = new CaveQuestStrategy();
                    parentSession.SendText("\nI'm trying a new recipe from my brother Fymir. He catches water bats in his magical pond and makes a soup of these bats.");
                    parentSession.SendText("\nI want to try do it with diffrent kind of bats. Fire bat can make this soup more spicy. Don't you think? Anyway, go to the nearest cave and kill 3 bats.");
                    visited = 2;
                }
                if (choice == 1)
                {
                    parentSession.SendText("\nOh, okay... &^$#*@^ &@$#$*$ #^@&!");
                    parentSession.LearnThisSkill(new VerbalAbuse());
                    visited = -1;
                }
            }
        }
    }
}
