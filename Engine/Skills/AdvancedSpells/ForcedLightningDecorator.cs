using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSpells
{
	[Serializable]
    class ForcedLightningDecorator : SkillDecorator
    {
        public ForcedLightningDecorator(Skill skill) : base("spell0582", 60, 3, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = "COMBO: Forced Lightning - UNLIMITED POWER (5-10*MP) 10% chance to hurt self" + skill.PublicName;
            RequiredItem = Skill.MainItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            Random rng = new Random();
            StatPackage response = new StatPackage(DmgType.Fire);
            int multiplier = rng.Next(5, 10);
            response.HealthDmg = multiplier * player.MagicPower;
            response.CustomText = "Forceful lightning envelops the enemy.";

            multiplier = rng.Next(0, 9);

            if (multiplier == 0)
            {
                player.Health -= player.MagicPower;
            }
            response.CustomText += "The lightning ricoshets and strikes back at the caster";

            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
