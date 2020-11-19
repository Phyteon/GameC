using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.UpgradedWeaponMoves
{
    [Serializable]
    class EnchantedSlash:Skill
    {

        private int chance;
        public EnchantedSlash() : base("Enchanted Slash", 30, 2)
        {
            PublicName = "Enchanted Slash [requires sword]: {(0.2*Str + 0.2*Pr) damage [cut] and (0.2*Str + 0.2*Pr) damage [incised]}*random value from 1 to 5";
            RequiredItem = Skill.MainItem.Sword;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            chance = Index.RNG(1, 6);
            StatPackage response1 = new StatPackage(DmgType.Cut);
            response1.HealthDmg = (int)(0.1 * player.Strength*chance) + (int)(0.1 * player.Precision*chance);
            StatPackage response2 = new StatPackage(DmgType.Cut);
            response2.HealthDmg = (int)(0.1 * player.Strength*chance) + (int)(0.1 * player.Precision*chance);



            response2.CustomText = "You use Enchanted Slash! (" + ((int)(0.2 * player.Strength*chance) + (int)(0.2 * player.Precision*chance)) + " cut damage, " + ((int)(0.2 * player.Strength*chance) + (int)(0.2 * player.Precision*chance))*chance + " incised damage)";
            return new List<StatPackage>() { response1, response2};
        }
    }
}