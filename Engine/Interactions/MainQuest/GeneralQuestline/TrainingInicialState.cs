using Game.Engine.Interactions.Built_In;
using Game.Engine.Interactions.GeneralQuestline;
using Game.Engine.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.GeneralQuestline
{
    [Serializable]
    class TrainingInitialState : TrainingState
    {
        bool fight = false; //you have to go through both parts. 3rd option will skip this proces
        bool introduction = false;

        public override void RunContent(GameSession parentSession, TrainingEncounter myself)
        {

            parentSession.SendText("\nHello Recruit. Here you can learn about the basics of combat and basic utilities provided for soldiers. I know that you might already know this stuff, however there's a formal requirement that we go through this training. What would you like to start with?");
            while(!fight || !introduction)
            {
                if (!fight && !introduction)
                {
                    InitialConversation(parentSession, myself);
                }
                else if (fight && !introduction)
                {
                    AfterFightConversation(parentSession, myself);
                }
                else if (!fight && introduction)
                {
                    AfterIntroductionConversation(parentSession, myself);
                }
            }
            parentSession.SendText("I think we are done here then. You are now officialy a soldier. Here's a little gift that might come in handy");
            parentSession.AddRandomClassItem();
            myself.ChangeState(new TrainingCompleteState(), true);

        }


        private void InitialConversation(GameSession parentSession, TrainingEncounter myself)
        {
            int choice = parentSession.GetListBoxChoice(new List<string>() { "Tell me about the combat", "Tell me about the utilities", "I already know everything about these things." });
            switch (choice)
            {
                case 0:
                    FightDialogue(parentSession, myself);
                    parentSession.SendText("\nSee that target dummy over there? You can fight him so you get a feel what combat looks like");
                    parentSession.FightThisMonster(new TargetDummy());
                    fight = true;
                    break;
                case 1:
                    IntroductionDialogue(parentSession, myself);
                    introduction = true;
                    break;
                default:
                    parentSession.SendText("All right then, just don't blame me for your lack of knowledge later");
                    fight = true;
                    introduction = true;
                    break;
            }
        }

        private void AfterFightConversation(GameSession parentSession, TrainingEncounter myself)
        {
            int choice = parentSession.GetListBoxChoice(new List<string>() { "Can you tell me about the combat again?", "Tell me about the utilities", "I think I already know the rest" });
            switch (choice)
            {
                case 0:
                    FightDialogue(parentSession, myself);
                    break;
                case 1:
                    IntroductionDialogue(parentSession, myself);
                    introduction = true;
                    break;
                default:
                    parentSession.SendText("All right then, just don't blame me for your lack of knowledge later");
                    introduction = true;
                    break;
            }
        }

        private void AfterIntroductionConversation(GameSession parentSession, TrainingEncounter myself)
        {
            int choice = parentSession.GetListBoxChoice(new List<string>() { "Tell me about the combat", "Can you tell me about the utilities again?", "I think I already know the rest" });
            switch (choice)
            {
                case 0:
                    FightDialogue(parentSession, myself);
                    parentSession.SendText("\nSee that target dummy over there? You can fight him so you get a feel what combat looks like");
                    parentSession.FightThisMonster(new TargetDummy());
                    fight = true;
                    break;
                case 1:
                    IntroductionDialogue(parentSession, myself);
                    break;
                default:
                    parentSession.SendText("All right then, just don't blame me for anything later");
                    fight = true;
                    break;
            }
        }



        private void FightDialogue(GameSession parentSession, TrainingEncounter myself)
        {
            parentSession.SendText("\nAs you would expect, sometimes as a soldier you will be required to draw your weapon in order to fight. You might encounter some hostile creatures that you will need to deal with.");
            parentSession.GetListBoxChoice(new List<string>() { "*continue*" });
            parentSession.SendText("\nNaturally, the attacks that you will be able to perform during combat depend on equipped weapons, and skills that you will learn by gaining experiance.");
            parentSession.GetListBoxChoice(new List<string>() { "*continue*" });
            parentSession.SendText("\nEvery attack you perform uses your stamnina. In difficult fights make sure you use it wisely, as without enough stamina you won't be able to flee from the fight.");
            parentSession.GetListBoxChoice(new List<string>() { "*continue*" });
        }

        private void IntroductionDialogue(GameSession parentSession, TrainingEncounter myself)
        {
            parentSession.SendText("There are 3 types of utilities provided for soldiers - shop, medic and fountains");
            parentSession.GetListBoxChoice(new List<string>() { "*continue*" });
            parentSession.SendText("In shops you can purchase additional armor. You can also sell unwanted gear. Quite handy if you need a specific kind of armor right away, or want to get rid of junk from your inventory.");
            parentSession.GetListBoxChoice(new List<string>() { "*continue*" });
            parentSession.SendText("After victories you will be taken care of, and your health will be restored. However, when you ran away from your opponent you might be left with small amount of health. You can use additional paid medic service to regian lost health");
            parentSession.GetListBoxChoice(new List<string>() { "*continue*" });
            parentSession.SendText("If for some reason, you wanted to forget a skill that you learned, you can use a fountain.");
        }

        
    }
}
