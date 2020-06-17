using System;
using System.Collections.Generic;
using Game.Engine.Skills;

namespace Game.Engine.CharacterClasses
{
    [Serializable]
    class Mage : Player
    {
        // mage class  - overrides only initial statistics and levelling up 
        public Mage(GameSession ses) : base(ses)
        {
            // initial class statistics
            ClassName = "Mage";
            Health = 100;
            Strength = 20;
            Armor = 0;
            Precision = 50;
            MagicPower = 50;
            Stamina = 100;
            Level = 1;
            Gold = 0;
        }

        protected override void LevelUp()
        {
            Level++;
            parentSession.SendText("\n");
            parentSession.SendColorText("Level Up! Level: " + Level, "yellow");
            List<string> validInputs = new List<string>() { "1", "2", "3", "4", "5" }; // only accept these inputs
            parentSession.SendColorText("Choose a statistic to improve: +20 Health (press 1), +10 Strength (press 2), +5 Precision (press 3), +15 Magic Power (press 4), +20 Stamina (press 5)", "yellow");
            string key = parentSession.GetValidKeyResponse(validInputs).Item1;
            // don't make changes directly, ask GameSession to do it right
            if (key == "1") parentSession.UpdateStat(1, 20);
            else if (key == "2") parentSession.UpdateStat(2, 10);
            else if (key == "3") parentSession.UpdateStat(4, 5);
            else if (key == "4") parentSession.UpdateStat(5, 15);
            else if (key == "5") parentSession.UpdateStat(6, 20);
            List<Skill> ss = Index.MagicSkill(this);
            LearnNewSkill(Index.MagicSkill(this)); 
        }

    }
}
