using System;
using System.Collections.Generic;
using Game.Display;
using Game.Engine.Monsters;
using Game.Engine.Skills;
using Game.Engine.Interactions;
using Game.Engine.CharacterClasses;
using Game.Sound;

namespace Game.Engine
{
    // class representing a battle event
    class Battle : InteractionWithImage
    {
        protected BattleScene battleScene;
        protected int hpCopy, strCopy, armCopy, prCopy, mgCopy, staCopy; // after the battle, all statistics of the player are restored
        protected bool rewards, possibleToEscape, firstBlood = false;
        public Monster Monster { get; set; }
        public bool battleResult { get; private set; } = false; // has the player won?
        public SoundEngine SoundEngine;
        public Battle(GameSession ses, BattleScene scene, Monster monster, bool rewards = true, bool possibleToEscape = true) : base(ses)
        {
            Monster = monster;
            Name = "battle0001";
            this.rewards = rewards;
            this.possibleToEscape = possibleToEscape;
            battleScene = scene;
            battleScene.ImgSetup = GetImage();
            SoundEngine = new SoundEngine(SoundContext.Battle);
            parentSession.ChildSoundEngines.Add(SoundEngine);
        }

        protected override void RunContent()
         {
            // stop game music and play battle music
            parentSession.SoundEngine.PauseBackgroundMusic();
            SoundEngine.PlayBackgroundMusic();

            parentSession.SendText("\nBattle!");
            battleScene.SetupDisplay();
            CopyPlayerState();
            // battle
            if (Monster.BattleGreetings != null)
            {
                battleScene.SendColorText(Monster.BattleGreetings, "red");
                // play battle monster greetings 
                SoundEngine.WaitAndPlay(Monster.Name, SoundType.MonsterInit);
                battleScene.SendBattleText("");
            }
            if(!possibleToEscape)
            {
                battleScene.SendColorText("Warning - running away is disabled for this fight", "yellow");
                battleScene.SendBattleText("");
            }
            battleScene.SetSkills(parentSession.currentPlayer.ListAvailableSkills(possibleToEscape));
            while (Monster.Health > 0) // reminder: there will be a separate mechanism for what happens when Player.Health == 0 
            {
                if(parentSession.currentPlayer.ListAvailableSkills(possibleToEscape).Count == 0) // player has run out of stamina
                {
                    RestorePlayerState();
                    battleScene.SendColorText("No more skills to use - defeat! (press any key to continue)", "red");
                    parentSession.GetKeyResponse();
                    parentSession.SendText("No more skills to use - you lost the battle!");
                    battleScene.EndDisplay();
                    // stop battle music and resume main game music
                    SoundEngine.StopBackgroundMusic();
                    parentSession.SoundEngine.ResumeBackgroundMusic();
                    return;
                }
                // player attacks first
                Skill playerResponse = parentSession.GetListBoxResponse();
                if (playerResponse.PublicName == "Run away (only half of your wounds will heal!)")
                {
                    battleScene.EndDisplay();
                    if (firstBlood) parentSession.SendText("The monster is chasing you down and you have no time to properly tend to your wounds...");
                    else parentSession.SendText("It looks rather dangerous, better stay away from it.");
                    battleResult = false;
                    RestorePlayerState(false);
                    // stop battle music and resume main game music
                    SoundEngine.StopBackgroundMusic();
                    parentSession.SoundEngine.ResumeBackgroundMusic();
                    return;
                }
                // play item sound
                SoundEngine.WaitAndPlay(playerResponse.RequiredItem.ToString(), SoundType.BattleRequiredItem);
                firstBlood = true;
                List<StatPackage> playerAttack = parentSession.ModifyOffensive(playerResponse.BattleMove(parentSession.currentPlayer));
                Monster.React(playerAttack);
                foreach (StatPackage i in playerAttack) battleScene.SendColorText(i.CustomText, "green"); 
                parentSession.UpdateStat(6, -1*playerResponse.StaminaCost);
                battleScene.SetSkills(parentSession.currentPlayer.ListAvailableSkills(possibleToEscape));
                battleScene.ResetChoice();
                // now monster
                if (Monster.Health == 0) continue;
                battleScene.SendBattleText("");
                List<StatPackage> monsterAttack = parentSession.ModifyDefensive(Monster.BattleMove());
                foreach (StatPackage i in monsterAttack) battleScene.SendColorText(i.CustomText, "red");
                // play monster bite sound
                SoundEngine.WaitAndPlay(Monster.Name, SoundType.MonsterBite);
                parentSession.currentPlayer.React(monsterAttack);
                battleScene.RefreshStats();
                parentSession.RefreshStats();
            }
            // restore player state
            battleResult = true;
            RestorePlayerState();
            battleScene.SendColorText("Victory! (press any key to continue)", "green");
            parentSession.GetKeyResponse();
            battleScene.EndDisplay();
            parentSession.SendText("You won! XP gained: " + Monster.XPValue);
            if(rewards) VictoryReward();
            //parentSession.UpdateStat(7, Monster.XPValue); // for smoother display, this one was moved to GameSession.cs
            // stop battle music and resume main game music
            SoundEngine.StopBackgroundMusic();
            parentSession.SoundEngine.ResumeBackgroundMusic();
        }
        protected void CopyPlayerState()
        {
            // not very pretty, but I can't think of another solution that wouldn't make things more complicated
            hpCopy = parentSession.currentPlayer.Health - parentSession.currentPlayer.HealthBuff;
            strCopy = parentSession.currentPlayer.Strength - parentSession.currentPlayer.StrengthBuff;
            armCopy = parentSession.currentPlayer.Armor - parentSession.currentPlayer.ArmorBuff;
            prCopy = parentSession.currentPlayer.Precision - parentSession.currentPlayer.PrecisionBuff;
            mgCopy = parentSession.currentPlayer.MagicPower - parentSession.currentPlayer.MagicPowerBuff;
            staCopy = parentSession.currentPlayer.Stamina - parentSession.currentPlayer.StaminaBuff;
        }
        protected void RestorePlayerState(bool fullHP = true)
        {
            // restore statistics
            if (fullHP)
            {
                parentSession.currentPlayer.Health = hpCopy;
            }
            else
            {
                parentSession.currentPlayer.Health = (int)((parentSession.currentPlayer.Health + hpCopy) / 2);
                if (parentSession.currentPlayer.Health > hpCopy) parentSession.currentPlayer.Health = hpCopy;
                parentSession.currentPlayer.LostHP += hpCopy - parentSession.currentPlayer.Health;
            }
            parentSession.currentPlayer.Strength = strCopy;
            parentSession.currentPlayer.Armor = armCopy;
            parentSession.currentPlayer.Precision = prCopy;
            parentSession.currentPlayer.MagicPower = mgCopy;
            parentSession.currentPlayer.Stamina = staCopy;
            parentSession.currentPlayer.ResetBattleBuffs();
            parentSession.RefreshStats();
        }

        protected void ReportStats()
        {
            battleScene.SendColorText("Your HP: " + parentSession.currentPlayer.Health + " Your Stamina: " + parentSession.currentPlayer.Stamina, "blue");
            battleScene.SendColorText("Monster HP: " + Monster.Health, "blue");
        }
        protected void VictoryReward()
        {
            Random RNG = new Random();
            int test = RNG.Next(100);
            if (test < 10)
            {
                parentSession.SendText("It seems the monster was guarding an interesting item.");
                parentSession.AddRandomItem();
            }
            else if (test < 50)
            {
                int gold = 5 * (RNG.Next(9) + 1); ;
                parentSession.SendText("It seems the monster was guarding a bag of gold (+" + gold + " gold)");
                parentSession.currentPlayer.Gold += gold;
            }
        }

    }
}
