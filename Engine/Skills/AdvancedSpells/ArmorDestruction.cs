using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.MoreSpells
{
    [Serializable]
    class ArmorDestruction : Skill
    {
        //50% chance to completly ruin enemy's armor
        public ArmorDestruction() : base("Armor destruction", 20, 2)
        {
            PublicName = "Armor destruction: 50% chance to ruin monster's armor [magic]";
            RequiredItem = Skill.MainItem.staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.none);

            if(Index.RNG(0,2) > 0)
            {
                response.ArmorDmg = 2000;//  I guess monster cant have more armor than that
                response.CustomText = "You use armor destruction, your enemy has no armor now";
            }
            else
            {
                response.ArmorDmg = 0;
                response.CustomText = "You try to destruct monster's armor but it doesn't work";
            }
            
            return new List<StatPackage>() { response };
        }
    }
}
