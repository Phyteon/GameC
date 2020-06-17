using System;
using System.Collections.Generic;
using Game.Engine.Skills;

namespace Game.Engine.CharacterClasses
{
    [Serializable]
    class Warrior : Player
    {
        // warrior class  - overrides only initial statistics and levelling up 
        public Warrior(GameSession ses) : base(ses)
        {
            // initial class statistics
            ClassName = "Warrior";
            Health = 100;
            Strength = 50;
            Armor = 0;
            Precision = 50;
            MagicPower = 0;
            Stamina = 100;
            Level = 1;
            Gold = 0;
        }

        protected override void LevelUp()
        {
            Level++;
            parentSession.SendText("\n");
            parentSession.SendColorText("Level Up! Level: " + Level, "yellow");
            List<string> validInputs = new List<string>() { "1", "2", "3", "4" }; // only accept these inputs
            parentSession.SendColorText("Choose a statistic to improve: +20 Health (press 1), +15 Strength (press 2), +5 Precision (press 3), +20 Stamina (press 4)", "yellow");
            string key = parentSession.GetValidKeyResponse(validInputs).Item1;
            // don't make changes directly, ask GameSession to do it right
            if (key == "1") parentSession.UpdateStat(1, 20);
            else if (key == "2") parentSession.UpdateStat(2, 15);
            else if (key == "3") parentSession.UpdateStat(4, 5);
            else if (key == "4") parentSession.UpdateStat(6, 20);
            LearnNewSkill(Index.WeaponSkill(this));
        }
    }
}
