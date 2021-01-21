using System;
using System.Collections.Generic;
using Game.Engine.Skills.BasicSkills;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.SkillFactories
{
    [Serializable]
    class WindSpellFactory : SkillFactory
    {
        // this factory produces skills from BasicSpells directory
        public Skill CreateSkill(Player player)
        {
            List<Skill> playerSkills = player.ListOfSkills;
            Skill advanced = CheckContent(playerSkills); // check what spells from the BasicSpells category are known by the player already
            if (advanced == null) // no BasicSpells known - we will return one of them
            {
                WindGust s1 = new WindGust();
                Hurricane s2 = new Hurricane();
                // only include elligible spells
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)]; // use Index.RNG for safe random numbers
            }
            else if (advanced.decoratedSkill == null) // a BasicSpell has been already learned, use decorator to create a combo
            {
                WindGustDecorator s1 = new WindGustDecorator(advanced);
                HurricaneDecorator s2 = new HurricaneDecorator(advanced);
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
                if (skill is WindGust || skill is Hurricane || skill is WindGustDecorator || skill is HurricaneDecorator) return skill;
            }
            return null;
        }

    }
}
