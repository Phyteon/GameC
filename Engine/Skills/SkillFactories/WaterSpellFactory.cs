using System;
using System.Collections.Generic;
using Game.Engine.Skills.BasicSkills;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.SkillFactories
{
    [Serializable]
    class WaterSpellFactory : SkillFactory
    {  
        // this factory produces skills from BasicSpells directory
        public Skill CreateSkill(Player player)
        {
            List<Skill> playerSkills = player.ListOfSkills;
            Skill water = CheckContent(playerSkills); // check what spells from the BasicSpells category are known by the player already
            if (water == null) // no BasicSpells known - we will return one of them
            {
                AquaSpark s1 = new AquaSpark();
                HydroBlast s2 = new HydroBlast();
                // only include elligible spells
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)]; // use Index.RNG for safe random numbers
            }
            else if (water.decoratedSkill == null) // a BasicSpell has been already learned, use decorator to create a combo
            {
                AquaSparkDecorator s1 = new AquaSparkDecorator(water);
                HydroBlastDecorator s2 = new HydroBlastDecorator(water);
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
                if (skill is AquaSpark || skill is HydroBlast || skill is AquaSparkDecorator || skill is HydroBlastDecorator) return skill;
            }
            return null;
        }       

    }
}
