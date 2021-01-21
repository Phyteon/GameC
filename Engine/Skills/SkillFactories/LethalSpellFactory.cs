using System;
using System.Collections.Generic;
using Game.Engine.Skills.BasicSkills;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.SkillFactories
{
    [Serializable]
    class LethalSpellFactory : SkillFactory
    {  
        // this factory produces skills from BasicSpells directory
        public Skill CreateSkill(Player player)
        {
            List<Skill> playerSkills = player.ListOfSkills;
            Skill lethal = CheckContent(playerSkills); // check what spells from the BasicSpells category are known by the player already
            if (lethal == null) // no BasicSpells known - we will return one of them
            {
                DarkVortex s1 = new DarkVortex();
                IceVortex s2 = new IceVortex();
                SoilVortex s3 = new SoilVortex();
				TyphoonVortex s4 = new TyphoonVortex();
                Frenzy s5 = new Frenzy();
                // only include elligible spells
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
                if (s4.MinimumLevel <= player.Level) tmp.Add(s4);
                if (s4.MinimumLevel <= player.Level) tmp.Add(s5);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)]; // use Index.RNG for safe random numbers
            }
            else if (lethal.decoratedSkill == null) // a BasicSpell has been already learned, use decorator to create a combo
            {
                VortexDecorator s1 = new VortexDecorator(lethal);
                FrenzyDecorator s2 = new FrenzyDecorator(lethal);
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)];
            }
            else return null; // this factory doesn't offer combos so we stop here
        }
        private Skill CheckContent(List<Skill> skills) // wrapper method for checking
        {
            foreach (Skill skill in skills)
            {
                if (skill is DarkVortex || skill is SoilVortex || skill is IceVortex || skill is TyphoonVortex || skill is Frenzy || skill is VortexDecorator || skill is FrenzyDecorator) return skill;
            }
            return null;
        }       

    }
}
