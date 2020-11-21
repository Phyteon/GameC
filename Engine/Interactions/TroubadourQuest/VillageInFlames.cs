using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Monsters;
using Game.Engine.Items;
//using Game.Engine.Interactions.AFewNew;
//using System.Timers;
using System.Threading;

namespace Game.Engine.Interactions.TroubadourQuest
{
    [Serializable]
    class VillageInFlames : PlayerInteraction
    {
        private int visited = 0; // visit counter, if > 0, somehow we killed hydra
        private int Flag = 0; //used later in coding padlock
        private int Flag1 = 0; // if we have a lute == 1
        private static int Timer = 10; //we need it in fork  
        public VillageInFlames(GameSession ses) : base(ses)
        {
            Name = "interaction0541";
        }
        protected override void RunContent()
        {
            if (visited == 0)
            {
                parentSession.SendText("                    *Deaf Willage while Hydra attack*");
                parentSession.SendText("[Someone from the screaming, deaf crowd]: Who the hell are you? Don't you see?");
                List<string> Items = parentSession.GetActiveItemNames();

                foreach (string item in Items) //looking for lute
                {
                    if (item == "item0544")//we have lute
                    {
                        int choice1 = parentSession.GetListBoxChoice(new List<string>() { "Show Lute", "Gesture you have to go" });
                        if (choice1 == 0)
                        {
                            parentSession.SendText("You are our Hero! But there is a problem, we closed the gate to " +
                                "prevent the Hydra from entering the city. It's locked with numbers written on gate. " +
                                "Your task is to read the numbers and unlock the gate, then close it. You must be fast" +
                                " and do everything in less than 10 seconds(remembering the number from the door also), otherwise Hydra will get you. If you succeed" +
                                " play the magic melody. Are you ready?");
                            int choice4 = parentSession.GetListBoxChoice(new List<string>() { "Of course! [Show Lute]", "Gesture your resignation" });
                            if(choice4==0)
                            {
                                Unlocking();
                            }
                            if(choice4 == 1)
                            {
                                parentSession.SendText("And this is our hero? Pff...");
                            }
                        }
                        if (choice1 == 1)
                        {
                            parentSession.SendText("And this is our hero? Pff...");
                        }
                        Flag1 = 1;
                        break;
                    }
                }
                if (Flag1 == 0) // we don't have lute
                {
                    //parentSession.ProduceItem("item0544");       //useful while testing, we do not have to meet Troubadour
                    int choice2 = parentSession.GetListBoxChoice(new List<string>() { "Show Sword", "Leave and add your Lute to active items (green edges in equipment)", "Gesture you have to go" });
                    if (choice2 == 0)
                    {
                        parentSession.SendText("You are crazy. This Hydra is immortal, 20 of our great men have died, are you sure?");
                        int choice3 = parentSession.GetListBoxChoice(new List<string>() { "Show Sword", "Gesture you have to go" });
                        if (choice3 == 0)
                        {
                            parentSession.SendText("Fool...");
                            parentSession.Wait(2000);
                            parentSession.FightThisMonster(new Hydra4(100));//we get high lvl hydra
                            Ending();

                        }
                        if (choice3 == 1)
                        {
                            parentSession.SendText("I thought so...");
                        }
                    }
                    if (choice2 == 1)
                    {
                        parentSession.SendText("Ok, be right back.");
                    }
                    if (choice2 == 2)
                    {
                        parentSession.SendText("I thought so...");
                    }
                }




            }
            else
            {
                parentSession.SendText("Hurray! Our Hero! As you see, we are rebuilding village. If you want to" +
                    " help us, you can buy something from our stuff:");

                Transaction();  // buy random items
                parentSession.SendText("Thank you for comming! See you!");
                
                
            }
        }
        private void Unlocking()
        {
            int iteration1 = 5;
            while (iteration1 > 0) //counting down
            {
                parentSession.SendText(iteration1.ToString());
                parentSession.Wait(1000);
                iteration1--;
            }


            ThreadStart job = new ThreadStart(ThreadJob); //initialize fork 
            Thread thread = new Thread(job);
            thread.Start(); // Timer start
            
            

            Information2 Info2 = new Information2(parentSession);
            Info2.Run(); // picture
            List<int> test = new List<int>() { }; // coding list
            List<int> correct = new List<int>() {4,2,7,0}; //correct code list

            while (Timer > -1)
            {
                parentSession.SendText(Timer + " seconds left"); //shows how much time left(when we choose something)
                Unlock(test); // coding method
            }

            if(test.Count == 4)
            {
                for (int iteration = 0; iteration < 5; iteration++)
                {
                    if (iteration == 4)
                    {
                        Flag = 1; // code is good, we can go next
                        break;
                    }
                    if (test[iteration] != correct[iteration])
                    {
                        break; // wrong code
                    }
                }   
            }

            test.Clear();
            correct.Clear();
            correct = new List<int>() { 0, 6, 6, 4, 2, 1, 3, 5, 7 }; // troubadour's melody

            if (Flag == 1) // good code
            {
                parentSession.SendText("[Unlocked! You got inside, but you don't have much time. Hydra " +
                    "will open the gate. You have 2 chances to play the melody correctly and calm the hydra.");
                int counter = 0;
                int counter1 = 0;

                while (counter1 < 2)
                {
                    while (counter != 9) // playing melody
                    {
                        int choice = parentSession.GetListBoxChoice(new List<string>() { "A", "D", "1E", "2E", "1F", "2F", "1G", "2G" });
                        Music(choice, test);
                        counter++;
                    }
                    counter = 0;


                    for(int i = 0;i<9;i++) //compare 
                    {
                        if(test[i] != correct[i])
                        {
                            test.Clear();
                            parentSession.SendText("[Nothing happens, last chance]");
                            break;  // if failed
                        }
                        if(i == 8)
                        {
                            counter1 = 2; // if correct, it breaks the loop
                            parentSession.SendText("[Hydra was effectively calmed down]");
                            parentSession.Wait(2000);
                            parentSession.FightThisMonster(new Hydra4(0)); //we get low lvl hydra
                        }
                    }

                    if(counter1 ==1) // second take failed
                    {
                        parentSession.Wait(2000);
                        parentSession.FightThisMonster(new Hydra4(100)); //we get high lvl hydra
                    }
                    counter1++;
                }

                //win

                Ending();
                
            }
            else // code is wrong
            {
                parentSession.SendText("[Wrong combination, Hydra is going to kill you]");
                parentSession.Wait(2000);
                parentSession.FightThisMonster(new Hydra4(100)); //high lvl hydra
                Ending();
            }

        }

        
        private static void ThreadJob() // Timer on fork
        {
            int i = 10;
            while(i != -1)
            {
                Thread.Sleep(1000);
                Timer--;
                i--;
            }
        }
        
        private void Unlock(List<int> test) // Process of decoding padlock, is used while ThreadJob
        {
            int Choice = parentSession.GetListBoxChoice(new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "Clear all", "Ready" });
            while (Choice != 11 && Timer > -1) // reference to our Timer changed by ThreadJob on fork
            {
                if (Choice != 10)
                {
                    parentSession.SendText(Timer + " seconds left");
                    test.Add(Choice);
                    Unlock(test);
                    break;
                }
                if (Choice == 10)
                {
                    parentSession.SendText(Timer + " seconds left");
                    test.Clear();
                    Unlock(test);
                    break;
                }
            }
            Timer = -1; // stops our list box (while choice == ready)
        }


        private void Ending() 
        {
            parentSession.SendText("Quest Complete! You earned 1000 Gold and 2000 XP.");
            parentSession.UpdateStat(7, 2000);//XP,val
            parentSession.UpdateStat(8, 1000);//Gold,val
            parentSession.SendText("[Crowd]: Hurray! Our Hero! ");
            visited++;
        }

        private void Transaction() // purchase method
        {
            Item item1 = Index.RandomClassItem(parentSession.currentPlayer);
            Item item2 = Index.RandomClassItem(parentSession.currentPlayer);
            Item item3 = Index.RandomClassItem(parentSession.currentPlayer);

            int SellTransaction = parentSession.GetListBoxChoice(new List<string>(){item1.PublicName + " [" + item1.GoldValue + "]",
                item2.PublicName +" [" + item2.GoldValue + "]",item3.PublicName +" [" + item3.GoldValue + "]", "Show me tips","Exit"});

            while (SellTransaction != 4)
            {

                SellTransaction = parentSession.GetListBoxChoice(new List<string>(){item1.PublicName + " [" + item1.GoldValue + "]",
                    item2.PublicName +" [" + item2.GoldValue + "]",item3.PublicName +" [" + item3.GoldValue + "]", "Show me tips","Exit"});

                if (SellTransaction == 0)
                {
                    if (item1.GoldValue <= parentSession.currentPlayer.Gold)
                    {
                        parentSession.AddThisItem(item1);
                        parentSession.currentPlayer.Gold -= item1.GoldValue;

                    }
                    else
                    {
                        parentSession.SendText("Sorry, you don't have enough gold to buy this.");
                    }
                }
                if (SellTransaction == 1)
                {
                    if (item2.GoldValue <= parentSession.currentPlayer.Gold)
                    {
                        parentSession.AddThisItem(item2);
                        parentSession.currentPlayer.Gold -= item2.GoldValue;
                    }
                    else
                    {
                        parentSession.SendText("Sorry, you don't have enough gold to buy this.");
                    }
                }
                if (SellTransaction == 2)
                {
                    if (item3.GoldValue <= parentSession.currentPlayer.Gold)
                    {
                        parentSession.AddThisItem(item3);
                        parentSession.currentPlayer.Gold -= item3.GoldValue;
                    }
                    else
                    {
                        parentSession.SendText("Sorry, you don't have enough gold to buy this.");
                    }
                }
                if (SellTransaction == 3)
                {
                    parentSession.SendText(item1.PublicName + "  " + item1.PublicTip);
                    parentSession.SendText(item2.PublicName + "  " + item2.PublicTip);
                    parentSession.SendText(item3.PublicName + "  " + item3.PublicTip);
                }
            }
        }

        private void Music(int choice, List<int> list) // Method used by Melody Test to find specific path
        {
            if (choice == 0)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources._1A);
                player.Play();
                list.Add(choice);
            }

            if (choice == 1)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources._5D);
                player.Play();
                list.Add(choice);
            }
            if (choice == 2)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources._4E);
                player.Play();
                list.Add(choice);

            }
            if (choice == 3)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources._6E);
                player.Play();
                list.Add(choice);
            }
            if (choice == 4)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources._3F);
                player.Play();
                list.Add(choice);
            }
            if (choice == 5)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources._7F);
                player.Play();
                list.Add(choice);
            }
            if (choice == 6)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources._2G);
                player.Play();
                list.Add(choice);
            }
            if (choice == 7)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources._8G);
                player.Play();
                list.Add(choice);
            }
        }
    }
}