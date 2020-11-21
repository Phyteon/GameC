using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.EgyptianInteractions
{
    [Serializable]
    class SethEncounter : PlayerInteraction
    {
        public Monsters.AnubisGuard anubis = new Monsters.AnubisGuard(2);
        private Items.DemonSword demonSword = new Items.DemonSword();

        //private int visited = 0; // how many times have you visited this place?
        public int payment = 0;
        public int visited = 0;
        public SethEncounter(GameSession ses) : base(ses)
        {
            Name = "interaction0820"; //chyba? może zmienić?
        }
        protected override void RunContent()
        {
            if (visited == 0)
                FirstVisit();
            else if (visited < 0)
            {
                parentSession.SendText("GO AWAY, YOU`VE GOT YOUR CHANCE");
                parentSession.FightRandomMonster();
            }
            else
                SecondVisit();
        }

        private void FirstVisit()
        {
            parentSession.SendText("\nWell, well, well... Who would have thought that I will see a human again? \nBOW IN FRONT OF ME, YOU WRETCH!");
            int choice = parentSession.GetListBoxChoice(new List<string>() { "Who are you?! Show me your face, YOU COWARD!", "*Bow in silence*" });
            switch (choice)
            {
                case 0:
                    parentSession.SendText("\nIM SETH! THE GOD OF THE DESERTS AND STORMS! THE DEMON OF CHAOS AND DARKNESS! \n NOW, YOU BRASH HUMAN, SAY HI TO MY FRIEND ANUBIS!");
                    parentSession.FightThisMonster(anubis);
                    if (anubis.Health == 0 || anubis.Stamina == 0)
                    {
                        VictoryWithAnubis();
                    }
                    else //when player looses with anubis
                    {
                        parentSession.SendText("You're too weak for me. Go away, you molly");
                    }

                    break;
                case 1:
                    parentSession.SendText("Welcome, my little human. My name is Seth. I am the greatest god of the deserts and storms. I'm currently planning on defeating my brother Osiris... \n Fate must have brought you to me... or is it something else?");
                    int choice2 = parentSession.GetListBoxChoice(new List<string>() { "Gratest Seth, I`m on my mission to find power and wealth. \n Luckily, faith was really gracious for me, since you seem like the definition of power!","I`m sorry, but fate must have made a mistake.." }); 
                    if (choice2 == 0)
                    {
                        parentSession.SendText("Oh, you fawn over me...But that`s true! I can give you power and wealth, but... \n but you need to show me your worth!");
                        parentSession.FightThisMonster(anubis); //walka z anubisem
                        if (anubis.Health == 0 || anubis.Stamina == 0)
                        {
                            VictoryWithAnubis();
                        }
                        else
                        {
                            parentSession.SendText("You're too weak for me. Go away, you molly");
                        }

                    }
                    else
                    {
                        parentSession.SendText("Oh... In this case... see you in hell!");
                        parentSession.FightRandomMonster();
                    }
                    break;
                default:
                    parentSession.SendText("TEST Go away!");
                    break;
            }
        }

        public static int sethTeam;
        private void VictoryWithAnubis()
        {
            parentSession.SendText("So you won... That proves you`re worthy recieving my bless. Do you want to fight on my side?");
            int choice3 = parentSession.GetListBoxChoice(new List<string>() { "Yes","No" });
            if(choice3==0)
            {
                parentSession.SendText("You won`t regret joining my side.. Here is my little gift for you.");
                parentSession.AddThisItem(demonSword);
                sethTeam = 1;
                parentSession.SendText("[You recieved The Demon Sword from Seth! Now you're a part of his team.]");
                parentSession.SendText("Now, go and find sphinx"); 
                visited ++; //next visit will be SecondVisit()
            }
            else
            {
                parentSession.SendText("WHAT DOES IT MEAN NO?! GO AWAY THEN AND NEVER COME BACK!");
                parentSession.FightRandomMonster(); 
                visited --; //player would never have a chance to be in seths team again
            }
         
        }

        public static List<ICommand> gameCommands = new List<ICommand>();

        public void SecondVisit()
        {
            int wyn = 0;
            foreach( ICommand i in gameCommands)
            {
                wyn++;
            }

            if (wyn==3)
            {
                foreach (ICommand com in gameCommands)
                {
                    com.Execute(parentSession);
                }
            }
            else
                parentSession.SendText("You don`t have informations about every God! GO BACK TO SPHINX AND GET IT!");
        }



    }
}


