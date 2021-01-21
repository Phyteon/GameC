using System;
using System.Collections.Generic;
using Game.Engine.Skills.BasicSkills;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.SkillFactories
{
    [Serializable]
    class SelfBuffsFactory : SkillFactory
    {
        // this factory produces skills from BasicSpells directory
        public Skill CreateSkill(Player player)
        {
            List<Skill> playerSkills = player.ListOfSkills;
            Skill self = CheckContent(playerSkills); // check what spells from the BasicSpells category are known by the player already
            if (self == null) // no BasicSpells known - we will return one of them
            {
                Empower s1 = new Empower();
                Heal s2 = new Heal();
                Regenerate s3 = new Regenerate();
                // only include elligible spells
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)]; // use Index.RNG for safe random numbers
            }
            else if (self.decoratedSkill == null) // a BasicSpell has been already learned, use decorator to create a combo
            {
                EmpowerDecorator s1 = new EmpowerDecorator(self);
                HealDecorator s2 = new HealDecorator(self);
                RegenerateDecorator s3 = new RegenerateDecorator(self);
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)];
            }
            else return null; // a combo of BasicSpells has been already learned - this factory doesn't offer double combos so we stop here
        }
        private Skill CheckContent(List<Skill> skills) // wrapper method for checking
        {
            foreach (Skill skill in skills)
            {
                if (skill is Empower || skill is Heal || skill is Regenerate || skill is EmpowerDecorator || skill is HealDecorator || skill is RegenerateDecorator) return skill;
            }
            return null;
        }

    }
}
