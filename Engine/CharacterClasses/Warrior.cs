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
            ClassName = ""; // deprecated
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
            parentSession.SendColorText("Nowy poziom! Poziom: " + Level, "yellow");
            List<string> validInputs = new List<string>() { "1", "2", "3", "4" }; // only accept these inputs
            parentSession.SendColorText("Wybierz statystyke do ulepszenia: +20 Zdrowia (nacisnij 1), +10 Sily (nacisnij 2), +5 Precyzji (nacisnij 3), +20 Energii (nacisnij 4)", "yellow");
            string key = parentSession.GetValidKeyResponse(validInputs).Item1;
            // don't make changes directly, ask GameSession to do it right
            if (key == "1") parentSession.UpdateStat(1, 20);
            else if (key == "2") parentSession.UpdateStat(2, 10);
            else if (key == "3") parentSession.UpdateStat(4, 5);
            else if (key == "4") parentSession.UpdateStat(6, 20);
            if (Index.RNG(0, 100) > 50) LearnNewSkill(Index.WeaponSkill(this)); // warriors don't learn new skills as often as mages, but they gain statistics more quickly
        }
    }
}
