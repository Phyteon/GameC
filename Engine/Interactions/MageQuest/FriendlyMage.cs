using Game.Engine.Skills.HolySpells;
using Game.Engine.Skills.SomeSeriousSpells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup.Localizer;

namespace Game.Engine.Interactions.MageQuest
{
    [Serializable]

    class FriendlyMage : ListBoxInteraction
    {
        private HelpfulMage myMage;
        private FriendlyWarrior myWarrior;

        public int WarriorEmblem { get; set; }

        public FriendlyMage(GameSession ses, HelpfulMage myMage, FriendlyWarrior myWarrior) : base(ses) //#1
        {
            Name = "interaction1121";
            Enterable = false;
            this.myMage = myMage;
            this.myWarrior = myWarrior;

        }

        protected override void RunContent()
        {
            parentSession.SendText("Hey i'm local mage, my name is Herald, how can i help you?");

            int choice1 = GetListBoxChoice(new List<string>() { "What do you do?", "I have mission to do!" });
            switch (choice1)
            {
                case 0:
                    parentSession.SendText("\nThe task of local magicians is teaching new magic skills");
                    int choice2 = GetListBoxChoice(new List<string>() { "Really? Could you teach me new skills?","Could you teach me normal skills?", "Okey, thanks for conversation" });
                    switch (choice2)
                    { 
                        case 0:
                            {
                                SellSkills();
                                break;
                            }
                        case 1:
                            {
                                parentSession.SendText("Sorry, i can only teach you magic skills. If you wanna teach normal skills you should go to my friend Anski - he's a local warrior");
                                if (myWarrior.MageAmulet == 0)
                                {
                                    parentSession.SendText("Take this amulet for him, if you have some lucky you will get a discount");
                                    myWarrior.MageAmulet += 1;
                                }
                                break;
                            }
                        case 3:
                            {
                                parentSession.SendText("\nSee you soon");
                                break;
                            }
                    
                    }                
                    break;
                case 1:
                    if (myMage.PartOfHelpfulMageQuest == 3) //#1
                    {
                        parentSession.SendText("\nOh i see you have seal of Piright's! He's my good friend, and he always leave messeges if i have to meet someone, wait a second");
                        parentSession.SendText("\n *Herald is looking for something in his magic bag*");
                        parentSession.SendText("\nNow I see, you come to get Power Catalyst, that's not a problem, that's it, after complete mission let it Piright, he will give me it back by the way");
                        myMage.PartOfHelpfulMageQuest += 1; //#1
                        parentSession.SendText("\nGood luck on your mission!");
                    }
                    else
                    {
                        parentSession.SendText("\nGood joke my friend, i see that you don't have proper seal");
                    }
                    break;
                default:
                    parentSession.SendText("\nNevermind...");
                    break;
            }

            return;

        }   

        private void SellSkills()
        {

                parentSession.SendText("\nYes, i can teach you the following skills for a fee");
                int choice3 = GetListBoxChoice(new List<string>() { "Ice Spike - 50 gold", "Magic Arrow - 60 gold", "Stone Skind - 45 gold", "Blessing - 30 gold", "I'm not interesting" });
                switch (choice3)
                {
                    case 0:
                        parentSession.UpdateStat(8, -50);
                        parentSession.LearnThisSkill(new IceSpike());
                        break;
                    case 1:
                        parentSession.UpdateStat(8, -60);
                        parentSession.LearnThisSkill(new MagicArrow());
                        break;
                    case 2:
                        parentSession.UpdateStat(8, -45);
                        parentSession.LearnThisSkill(new StoneSkin());
                        break;
                    case 3:
                        parentSession.UpdateStat(8, -30);
                        parentSession.LearnThisSkill(new Blessing());
                        break;
                    case 4:
                        parentSession.SendText("Okey, See you soon");
                        break;
                }
            
        }


    }
}
