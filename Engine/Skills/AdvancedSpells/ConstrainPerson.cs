using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSpells
{
	[Serializable]
    class ConstrainPerson:Skill
    {
        public ConstrainPerson() : base("spell0581", 10, 4)
        {
            PublicName = "Constrain person - takes a random amount of strength from the enemy 10+(0-4)*MP";
            RequiredItem = Skill.MainItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            Random rng = new Random();
            StatPackage response = new StatPackage(DmgType.Air);
            int multiplier = rng.Next(0, 4);
            response.StrengthDmg = 10 + multiplier * player.MagicPower;
            response.CustomText = "A spell falls upon the enemy making it difficult for him to move";
            return new List<StatPackage>() { response };
        }
    }
}
