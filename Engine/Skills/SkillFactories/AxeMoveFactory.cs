using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;
using Game.Engine.Skills.AxeMoves;


namespace Game.Engine.Skills.SkillFactories
{
    [Serializable]
    class AxeMoveFactory : SkillFactory
    {
        public Skill CreateSkill(Player player)
        {
            List<Skill> playerSkills = player.ListOfSkills;
            Skill known = CheckContent(playerSkills);
            if (known == null)
            {
                HorrifyingCharge s1 = new HorrifyingCharge();
                BloodyCut s2 = new BloodyCut();
                BasicWeaponMoves.AxeCut s3 = new BasicWeaponMoves.AxeCut();

                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1);
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)];
            }
            else if (known.decoratedSkill == null)
            {
                BloodyCutDecorator s2 = new BloodyCutDecorator(known);
                List<Skill> tmp = new List<Skill>();
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)];
            }
            else return null;
        }
        private Skill CheckContent(List<Skill> skills)
        {
            foreach (Skill skill in skills)
            {
                if (skill is HorrifyingCharge || skill is BloodyCut || skill is BloodyCutDecorator || skill is BasicWeaponMoves.AxeCut) return skill;
            }
            return null;
        }
    }
}
