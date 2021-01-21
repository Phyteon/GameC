using System;
using System.Collections.Generic;
using Game.Engine.Skills.BasicSkills;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.SkillFactories
{
    [Serializable]
    class EarthSpellFactory : SkillFactory
    {  
        // this factory produces skills from BasicSpells directory
        public Skill CreateSkill(Player player)
        {
            List<Skill> playerSkills = player.ListOfSkills;
            Skill earth = CheckContent(playerSkills); // check what spells from the BasicSpells category are known by the player already
            if (earth == null) // no BasicSpells known - we will return one of them
            {
                GroundSwirl s1 = new GroundSwirl();
                Earthquake s2 = new Earthquake();
                // only include elligible spells
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)]; // use Index.RNG for safe random numbers
            }
            else if (earth.decoratedSkill == null) // a BasicSpell has been already learned, use decorator to create a combo
            {
                GroundSwirlDecorator s1 = new GroundSwirlDecorator(earth);
                EarthquakeDecorator s2 = new EarthquakeDecorator(earth);
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)];
            }
            else return null; // a combo of BasicSpells has been already learned - this factory doesn't offer double combos so we stop here
        }
        private Skill CheckContent(List<Skill> skills) // wrapper method for checking
        {
            foreach (Skill skill in skills)
            {
                if (skill is GroundSwirl || skill is Earthquake || skill is GroundSwirlDecorator || skill is EarthquakeDecorator) return skill;
            }
            return null;
        }       

    }
}
