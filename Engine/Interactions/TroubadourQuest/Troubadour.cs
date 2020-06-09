using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Game.Engine.Interactions.TroubadourQuest
{
    [Serializable]
    class Troubadour : ListBoxInteraction
    {
        private int visited = 0; //The second time we don't give a lute
        public Troubadour(GameSession ses) : base(ses)
        {
            Name = "interaction0540";
        }
        protected override void RunContent()
        {

            parentSession.SendText("Hey stranger, my village needs your help, can you help?");
            int choice = GetListBoxChoice(new List<string>() { "Sure, no problem!", "No way, I have more important things to do" });

            if (choice == 0)
            {
                parentSession.SendText("Our village was attacked by Great Hydra, no one can kill it, because of it's strength. " +
                    "However there is a way - the legendary melody played on lute, which weakens the hydra. Unfortunately some magic force made people deaf. " +
                    "I escaped... being a troubadour does not mean being brave. But you! You can take my lute play melody and kill it, would you?");
                int choice1 = GetListBoxChoice(new List<string>() { "Of course, people are the most important!", "I think, I'm not brave enough either... Good luck..." });
                if (choice1 == 0)
                {
                    parentSession.SendText("Ok! Let's learn this magic stuff then!");
                    LearnMusic();
                }
                if (choice1 == 1)
                {
                    parentSession.SendText("I thougth so...");
                }
            }
            else if (choice == 1)
            {
                parentSession.SendText("You're wasting dozens of people!");
            }
        }

        private void LearnMusic() 
        {
            int choice = GetListBoxChoice(new List<string>() { "Play whole song for me!", "A", "D", "1E", "2E", "1F", "2F", "1G", "2G", "I think, I'm ready", "It's stupid! I'm sick of it! I don't care!" });
            Music(choice); //recurensive call
            if (choice == 9)//begin test
            {
                parentSession.SendText("Play whole song, I must be sure I don't send you to certain death");
                List<int> correct = new List<int>() { 0, 6, 6, 4, 2, 1, 3, 5, 7 }; //melody code
                List<int> test = new List<int> { }; //our choices 
                int counter = 0;
                while (counter != 9)//after 9 sounds, comparison starts
                {
                    int choice1 = GetListBoxChoice(new List<string>() { "A", "D", "1E", "2E", "1F", "2F", "1G", "2G" });//only sounds
                    Music1(choice1, test);//Music1, because of extra argument - test and non recursive call
                    counter++;
                }
                int amount = 0;//counter
                foreach (int choicelist in test)//compare lists
                {

                    if (amount == 8)//exam passed
                    {
                        if (visited == 1)
                        {
                            parentSession.SendText("Exactly, very good, now I think, you are ready.");
                            
                        }
                        if(visited == 0)//1st time we get lute
                        {
                            visited++;//it's here because we get item here
                            parentSession.SendText("Exactly, very good, now I think, you are ready. Take my lute and kill this monster!");
                            parentSession.AddThisItem(Index.ProduceSpecificItem("item0544"));//lute
                            
                        }
                        test.Clear();
                        parentSession.SendText("But before killing, you should know, what you should be looking for... I'll show you my village.");
                        int choice2 = GetListBoxChoice(new List<string>() {"Ok, I'm ready, show it!" });
                        if(choice2 == 0)
                        {
                            Information1 Info1 = new Information1(parentSession);//picture
                            Info1.Run();//picture
                            break;
                        }
                    }
                    if (choicelist != correct[amount])//failed exam
                    {
                        parentSession.SendText("Practise more, It must be perfect");
                        test.Clear();
                        LearnMusic();//from the beginning
                    }
                    amount++;
                }
            }
            if (choice == 10)
            {
                parentSession.SendText("Someone stepped on your ear? Come back, when you calm down, it's worth it...");
            }
        }

        private void Music(int choice)//path finder method
        {
            if (choice == 0)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.Song);
                player.Play();
                LearnMusic();//from the beginning
            }
            if (choice == 1)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources._1A);
                player.Play();
                LearnMusic();
            }

            if (choice == 2)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources._5D);
                player.Play();
                LearnMusic();
            }
            if (choice == 3)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources._4E);
                player.Play();
                LearnMusic();
            }
            if (choice == 4)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources._6E);
                player.Play();
                LearnMusic();
            }
            if (choice == 5)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources._3F);
                player.Play();
                LearnMusic();
            }
            if (choice == 6)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources._7F);
                player.Play();
                LearnMusic();
            }
            if (choice == 7)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources._2G);
                player.Play();
                LearnMusic();
            }
            if (choice == 8)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources._8G);
                player.Play();
                LearnMusic();
            }
        }

        private void Music1(int choice, List<int> list)//method for test only
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
