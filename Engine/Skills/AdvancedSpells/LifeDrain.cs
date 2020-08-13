using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSpells
{
	[Serializable]
    class LifeDrain:Skill
    {
        public LifeDrain() : base("spell0583", 5, 4)
        {
            PublicName = "Life drain - drains the enemy vital energy and replenishes HP and stamina";
            RequiredItem = Skill.MainItem.staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("air");
            response.HealthDmg = player.MagicPower;
            player.HealthBuff += Convert.ToInt32(response.HealthDmg * 0.5);
            player.StaminaBuff += Convert.ToInt32(response.HealthDmg * 0.5);
            response.CustomText = "The enemy's life energy is being drained. it replenishes the caster's vital strength";
            return new List<StatPackage>() { response };
        }
    }
}
