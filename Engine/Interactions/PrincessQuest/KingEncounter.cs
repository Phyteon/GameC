using Game.Engine.Items;
using Game.Engine.Monsters;
using System;
using System.Collections.Generic;

namespace Game.Engine.Interactions.PrincessQuest
{
    //this is a castle - you enter and talk with king about his daughter
    [Serializable]
    class KingEncounter : PlayerInteraction
    {
        private MageEncounter mage;
        private TowerEncounter tower;
        public int visited = 0;
        private bool ifQuestStarted = false;
        private bool ifGotAmulet = false;

        public KingEncounter(GameSession ses, MageEncounter mage, TowerEncounter tower) : base(ses)
        {
            Name = "interaction1080";
            this.mage = mage;
            this.tower = tower;
        }
        protected override void RunContent()
        {
            if (tower.ifSaved == 0 && ifQuestStarted == false) //if princess isn't saved yet
            {
                if (visited == -1) //if something bad happened before 
                {
                    parentSession.SendText("\nWhy are you looking for trouble again? Do you want to help me now?" +
                        " The princess is still trapped there in the cursed tower...");
                    TalkAboutPrincess();
                    return;
                }
                if (visited >= 0)
                {
                    parentSession.SendText("\nWelcome brave man. I'm an old king of this land and I've lost all hope..." +
                        " My daughter is trapped in a terrible cursed tower that is guarded by a witch and her dragon! Can you save her?");
                    TalkAboutPrincess();
                    return; 
                }
            }
            if (tower.ifSaved == 0 && ifQuestStarted == true)
            {
                if (visited == 1)
                {
                    parentSession.SendText("\nWhat are you doing here? Where's my daughter? Please hurry - save her quickly!");
                    visited+=1;
                    return;
                }
                if (visited == 2)
                {
                    parentSession.SendText("\nWhy are you showing up without her again? Come back here alone one more time and I'll butcher you!");
                    visited+=1;
                    return;
                }
                if (visited > 2)
                {
                    parentSession.SendText("\nI told you not to come back here without my daughter! Now you'll have to fight my Anubis Guard!");
                    FightGuard();
                    visited = 3;
                    return;
                }
            }
            if (tower.ifSaved == 1 && ifQuestStarted == true) //princess has been saved
            {
                if (visited <= -2) //you've already done the quest
                {
                    parentSession.SendText("\nThank you good man for saving my daughter, but I don't have any work for you anymore.");
                    return;
                }
                parentSession.SendText("\nThank you good man! There's your payment.\nYou've unlocked another quest - Gollum and the infinity ring - find" +
                    " the smith to find out more.");
                if (ifGotAmulet == true)
                {
                    mage.visited = -4;
                    parentSession.UpdateStat(8, 950);
                    parentSession.UpdateStat(7, 100);
                    visited = -2;
                    return;
                }
                mage.visited = -4;
                parentSession.UpdateStat(8, 1000);
                parentSession.UpdateStat(7, 100);
                visited = -2;
                return;
            }
        }
        private void TalkAboutPrincess()
        {
            int choice1 = parentSession.GetListBoxChoice(new List<string>() { "Tell me more my king, a cursed tower?" , "It seems like a very dangerous mission and my" +
                "prices are high...", "I've got better things to do - your daughter is propably dead by now anyway." });
            if (choice1 == 0)
            {
                parentSession.SendText("Yes, a wicked old witch came for her sixteenth birthday and kidnapped her! Many tried to save her since, but all failed...");
                int choice2 = parentSession.GetListBoxChoice(new List<string>() {"Witches don't kidnap people for no reason. What did you do to her that got her so upset?","Failed? " +
                    "I'm not experienced enough for such missions yet. Goodbye.", "You stupid people - it's not that hard to understand not to make more powerful creatures mad..." });
                if (choice2 == 0)
                {
                    parentSession.SendText("I don't know, she was so angry... She asked for something impossible.");
                    int choice3 = parentSession.GetListBoxChoice(new List<string>() { "Impossible? What was is? A treasure? A promise?", "It looks like you really " +
                        "made her mad. I don't deal with human-witches arguments - too risky."});
                    if (choice3 == 0)
                    {
                        parentSession.SendText("\nIT'S NOT YOUR BUSSINESS. Are you willing to save her or not?");
                        int choice4 = parentSession.GetListBoxChoice(new List<string>() { "Ok, I'll try. What should I do first?", "This seems too suspicious. You'll need to " +
                            "find somebody else to clean your mess." });
                        if (choice4 == 0)
                        {
                            SendForQuest();
                            return;
                        }
                        if (choice4 == 1)
                        {
                            return;
                        }
                    }
                    if (choice3 == 1)
                    {
                        visited++;
                        return;
                    }
                }
                if (choice2 == 1)
                {
                    visited++;
                    return;
                }
                if (choice2 == 2)
                {
                    parentSession.SendText("\nHOW DARE YOU CALL ME STUPID?!");
                    int choice5 = parentSession.GetListBoxChoice(new List<string>() { "Sorry my lord, please forgive me. I can help - for a price...", "I'm just " +
                        "calling things by its name!" });
                    if (choice5 == 0)
                    {
                        Negotiate();
                        return;
                    }
                    if (choice5 == 1)
                    {
                        parentSession.SendText("\nYou fool! Guard! Attack him!");
                        FightGuard();
                        return;
                    }
                }
            }
            else if (choice1 == 1)
            {
                Negotiate();
            }
            else //czyli choice1 == 2
            {
                return;
            }
        }
        private void SendForQuest()
        {
            parentSession.SendText("\nYou need to go to abandoned treehouse - you'll find an old mage there - he'll help you take care of the witch, " +
                "but you'll have to defeat the dragon yourself. Be careful! He's not friendly, but he'll know you came from me. Come back to me after you defeat" +
                " them.");
            visited = 1;
            ifQuestStarted = true;
            mage.ifQuestStarted = true;
            return;
        }
        private void FightGuard()
        {
            parentSession.FightThisMonster(new AnubisGuard(parentSession.currentPlayer.Level));
            visited = -1;
            return;
        }
        private void Negotiate()
        {
            parentSession.SendText("\nOf course good man! Whoever saves my daughter will get huge bags of gold and maybe something more...");
            int choice6 = parentSession.GetListBoxChoice(new List<string>() { "More? Like what?", "Gold is just fine. 2000 should do." });
            if (choice6 == 0)
            {
                parentSession.SendText("\nI can offer you a magic amulet that will help you fight the dragon, but you're payment will be smaller then...");
                int choice7 = parentSession.GetListBoxChoice(new List<string>() { "I'll stay with gold. Where should I look for this tower?", "Ok, I'll take the amulet." });
                if (choice7 == 0)
                {
                    SendForQuest();
                    return;
                }
                if (choice7 == 1)
                {
                    parentSession.SendText("Here you go.");
                    parentSession.AddThisItem(new FireproofAmulet());
                    SendForQuest();
                    return;
                }
            }
            if (choice6 == 1)
            {
                parentSession.SendText("Are you mad? I can offer you 1000.");
                int choice8 = parentSession.GetListBoxChoice(new List<string>() { "Then you'll have to save her yourself.", "Ok that's fair payment. Where should I go then?" });
                if (choice8 == 0)
                {
                    parentSession.SendText("Oh dear... Go away you stupid man! Guard, attack him!");
                    FightGuard();
                    return;
                }
                if (choice8 == 1)
                {
                    SendForQuest();
                    return;
                }
            }
        }
    }
}
