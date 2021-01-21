using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;
using Game.Engine.Skills.SwordMoves;

namespace Game.Engine.Skills.SkillFactories
{
    [Serializable]
    class SwordMoveFactory : SkillFactory
    {
        // this factory produces skills from SwordMoves directory
        public Skill CreateSkill(Player player)
        {
            List<Skill> playerSkills = player.ListOfSkills;
            List<Skill> tmp = new List<Skill>();
            FastSlash s1 = new FastSlash();
            BasicWeaponMoves.SwordSlash s2 = new BasicWeaponMoves.SwordSlash();
            if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
            if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
            foreach (Skill skill in playerSkills) // don't offer skills which the player knows already
            {
                if (skill is FastSlash) tmp.Remove(s1);
                if (skill is BasicWeaponMoves.SwordSlash) tmp.Remove(s2);
            }
            if (tmp.Count == 0) return null;
            return tmp[Index.RNG(0, tmp.Count)];
        }
    }
}
