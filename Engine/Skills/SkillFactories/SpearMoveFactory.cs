using System;
using System.Collections.Generic;
using Game.Engine.Skills;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.SkillFactories
{
    [Serializable]
    class SpearMoveFactory : SkillFactory
    {
        // this factory produces skills from BasicWeaponMoves directory
        // note: since every skill in BasicWeaponMoves is meant for a different weapon, we don't use any combos or decorators here
        public Skill CreateSkill(Player player)
        {
            List<Skill> playerSkills = player.ListOfSkills;
            List<Skill> tmp = new List<Skill>();
            BasicWeaponMoves.SpearStab s1 = new BasicWeaponMoves.SpearStab();
            SpartanKick s2 = new SpartanKick();
            SpartanAid s3 = new SpartanAid();
            if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
            if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
            if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
            foreach (Skill skill in playerSkills) // don't offer skills which the player knows already
            {
                if (skill is BasicWeaponMoves.SpearStab) tmp.Remove(s1);
                if (skill is SpartanKick) tmp.Remove(s2);
                if (skill is SpartanAid) tmp.Remove(s3);
            }
            if (tmp.Count == 0) return null;
            return tmp[Index.RNG(0, tmp.Count)];
        }

    }
}
