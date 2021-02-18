using System;
using System.Collections.Generic;
using Game.Engine.Skills.BasicSkills;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.SkillFactories
{
    [Serializable]
    class BasicSpellFactory : SkillFactory
    {  
        // this factory produces skills from BasicSpells directory
        public Skill CreateSkill(Player player)
        {
            List<Skill> playerSkills = player.ListOfSkills;
            Skill known = CheckContent(playerSkills); // check what spells from the BasicSpells category are known by the player already
            if (known == null) // no BasicSpells known - we will return one of them
            {
                FireArrow s1 = new FireArrow();
                WindGust s2 = new WindGust();
                // only include elligible spells
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)]; // use Index.RNG for safe random numbers
            }
            else if (known.decoratedSkill == null) // a BasicSpell has been already learned, use decorator to create a combo
            {
                FireArrowDecorator s1 = new FireArrowDecorator(known);
                WindGustDecorator s2 = new WindGustDecorator(known);
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
                if (skill is FireArrow || skill is WindGust || skill is FireArrowDecorator || skill is WindGustDecorator ) return skill;
            }
            return null;
        }       

    }
}
