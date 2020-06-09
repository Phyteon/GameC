using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.EgyptianInteractions
{
    [Serializable]
    class SphinxEncounter : ListBoxInteraction
    {
        //items which sphinx could give to you 
        private Items.GoldStone goldStone = new Items.GoldStone();
        private Items.OsirisArmor.OsirisStaff osirisStaff = new Items.OsirisArmor.OsirisStaff();
        private Items.OsirisArmor.OsirisSabre osirisSabre = new Items.OsirisArmor.OsirisSabre();
        private Items.OsirisArmor.OsirisEye osirisEye = new Items.OsirisArmor.OsirisEye();
        //commands for gods 
        public DeathCommand deathCommand;

        //gods
        private RaaEncounter raa;
        private OsirisEncounter osiris;
        private HorusEncounter horus;
        public ICommand Command { get; set; }

        private int choice;
        private int poprawna;
        
        public SphinxEncounter(GameSession ses, OsirisEncounter osiris, RaaEncounter raa, HorusEncounter horus) : base(ses)
        {
            Name = "interaction0821";
            this.osiris = osiris;
            this.raa = raa;
            this.horus = horus;
           
        }

        //if player won with anubis and got a demon sword, he can ask how to defeat any of the gods
        protected override void RunContent()
        {
            parentSession.SendText("Welcome. Im Sphinx, Master of the Riddles");
            if (SethEncounter.sethTeam==1)
                HereFromSethsOrder();
            else
                HereNotFromSethsOrder();

        }

        //adding a DeathCommand to the list in Seths class
        public void Defeat(ICommand com)
        {
            SethEncounter.gameCommands.Add(com);
        }

        //GodCheck - checks if the player asked about one of the gods before
        private List<string> gods = new List<string>();
        private string letter;
        private bool GodCheck()
        {
            foreach (string i in gods)
            {
                if (i == letter)
                    return false;
          
            }
            return true;
        }

        public void HereFromSethsOrder()
        {
            parentSession.SendText("I can see you are here because of Seth. I know his plans. Which God interests you?");
            int choice01 = GetListBoxChoice(new List<string>() { "Osiris...", "Raa...", "Horus..." });
            if (choice01 == 0)
            {
                letter = "o";
                if (GodCheck() == true)
                {
                    bool Answer = DrawARiddle();
                    if (Answer == true)
                    {
                        parentSession.SendText("Your Answer is correct. I will tell Seth how to defeat " + osiris.name + ". \n Here is your prize [Osiris Eye]");
                        deathCommand = new DeathCommand(osiris);
                        Defeat(deathCommand);
                        parentSession.AddThisItem(osirisEye);
                        gods.Add("o");
                    }
                    else
                    {
                        IncorrectAnswer();
                    }
                }
                else
                    parentSession.SendText("You`ve asked me about Osiris.");


            }
            if (choice01 == 1)
            {
                letter = "r";
                if (GodCheck() == true)
                {
                    bool Answer = DrawARiddle();
                    if (Answer == true)
                    {
                        parentSession.SendText("Your Answer is correct. I will tell Seth how to defeat " + raa.name + ". \n Here is your prize [Osiris Sabre]");
                        deathCommand = new DeathCommand(raa);
                        Defeat(deathCommand);
                        parentSession.AddThisItem(osirisSabre);
                        gods.Add("r");
                    }
                    else
                    {
                        IncorrectAnswer();
                    }
                }
                else
                    parentSession.SendText("You`ve asked me about Raa.");

            }
            if (choice01 == 2)
            {
                letter = "h";
                if (GodCheck() == true)
                {
                    bool Answer = DrawARiddle();
                    if (Answer == true)
                    {
                        parentSession.SendText("Your Answer is correct. I will tell Seth how to defeat " + horus.name + ". \n Here is your prize [Osiris Staff]");
                        deathCommand = new DeathCommand(horus);
                        Defeat(deathCommand);
                        parentSession.AddThisItem(osirisStaff);
                        gods.Add("h");

                    }
                    else
                    {
                        IncorrectAnswer();
                    }
                }
                else
                    parentSession.SendText("You`ve asked me about Horus.");

            }
        }

        public void HereNotFromSethsOrder()
        {
            parentSession.SendText("I`m Sphinx. I can see you`re here by chance. Well, I will give you a chance to win a mystic item. \n Answer my riddle. ");
            bool Answer = DrawARiddle();
            if (Answer == true)
            {
                parentSession.SendText("Your Answer is correct. Here is your prize. [Gold Stone]");
                parentSession.AddThisItem(goldStone);
            }
            else
            {
                IncorrectAnswer();
            }
        }


        // drawing a random riddle
        public bool DrawARiddle()
        {
            int number = Index.RNG(1, 5);
            
            if (number == 1)
            {
                parentSession.SendText("Tell me: Which creature has one voice and yet becomes four-footed and two-footed and three-footed?");
                poprawna = 1;
                choice = GetListBoxChoice(new List<string>() { "student","human", "dog" });
            }
            else if (number == 2)
            {
                parentSession.SendText("Tell me: What always comes, but it never comes today?");
                poprawna = 0;
                choice = GetListBoxChoice(new List<string>() { "tomorrow", "good mark", "Santa Claus" });
            }
            else if (number == 3)
            {
                parentSession.SendText("Tell me: I speak without a mouth and hear without ears. I have no body, but I come alive with wind. What am I? ");
                poprawna = 2;
                choice = GetListBoxChoice(new List<string>() { "ghost", "butterfly", "echo" });
            }
            else
            {
                parentSession.SendText("Tell me: You measure my life in hours and I serve you by expiring. I'm quick when I'm thin and slow when I'm fat.");
                poprawna = 1;
                choice = GetListBoxChoice(new List<string>() { "milk", "candle", "sportsman" });

            }

            if (poprawna == choice)
            {
                return true;
            }
            else
                return false;
        }


        public void IncorrectAnswer()
        {
            parentSession.SendText("Your Answer is incorrect, human. \n [Random statistic - 10]");
            int stat = Index.RNG(1, 9);
            parentSession.UpdateStat(stat, -10);
            parentSession.FightRandomMonster();
        }
    }

}
