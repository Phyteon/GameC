using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.SkillFactories
{
    [Serializable]
    class FireSpellFactory : SkillFactory
    {
        // this factory produces skills from BasicWeaponMoves directory
        // note: since every skill in BasicWeaponMoves is meant for a different weapon, we don't use any combos or decorators here
        public Skill CreateSkill(Player player)
        {
            List<Skill> playerSkills = player.ListOfSkills;
            List<Skill> tmp = new List<Skill>();
            List<Skill> drawn = new List<Skill>();
            BasicSkills.FireArrow s1 = new BasicSkills.FireArrow();
            AsteroidPunch s2 = new AsteroidPunch();
            FireBeekeeper s3 = new FireBeekeeper();
            FireBreath s4 = new FireBreath();
            if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
            if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
            if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
            if (s4.MinimumLevel <= player.Level) tmp.Add(s4);
            foreach (Skill skill in playerSkills) // don't offer skills which the player knows already
            {
                if (skill is BasicSkills.FireArrow) tmp.Remove(s1);
                if (skill is AsteroidPunch) tmp.Remove(s2);
                if (skill is FireBeekeeper) tmp.Remove(s3);
                if (skill is FireBreath) tmp.Remove(s4);
            }
            if (tmp.Count == 0) return null;
            return tmp[Index.RNG(0, tmp.Count)];
        }

    }
}
