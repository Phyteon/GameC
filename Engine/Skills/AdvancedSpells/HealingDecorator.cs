using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.MoreSpells
{
    [Serializable]
    class HealingDecorator : SkillDecorator
    {
        public HealingDecorator(Skill skill) : base("Healing", 10, 2, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 2;
            PublicName = "COMBO - extra 50 Hp [magic] AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Other);
            player.Health += 50;
            response.CustomText = "You heal yourself with 50 Hp";

            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
