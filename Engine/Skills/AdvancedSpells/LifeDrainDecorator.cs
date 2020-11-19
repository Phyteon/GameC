using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSpells
{
	[Serializable]
    class LifeDrainDecorator:SkillDecorator
    {
        public LifeDrainDecorator(Skill skill) : base("spell0583", 5, 4,skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = "COMBO: Life drain - drains the enemy vital energy and replenishes HP and stamina" + skill.PublicName;
            RequiredItem = Skill.MainItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Air);
            response.HealthDmg = player.MagicPower;
            player.HealthBuff += Convert.ToInt32(response.HealthDmg * 0.5);
            player.StaminaBuff += Convert.ToInt32(response.HealthDmg * 0.5);
            response.CustomText = "The enemy's life energy is being drained. it replenishes the caster's vital strength";

            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
            
        }
    }
}
