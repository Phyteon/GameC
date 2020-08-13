using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;
using Game.Engine.Items.BasicArmor;

namespace Game.Engine.Skills.SomeSeriousSpells
{
    [Serializable]
    class StoneSkin: Skill
    {
        public StoneSkin(): base("Stone Skin", 15, 1)
        {
            PublicName = "Stone Skin: increase your armor stats by 30 + your current armor stat/4! [earth]";
            RequiredItem = Skill.MainItem.staff;
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage reaction = new StatPackage(DmgType.earth);
            player.Armor = player.Armor + (30 + player.Armor / 4);
            reaction.HealthDmg = 0;
            reaction.CustomText = "You use Stone Skin! You will get ( " + (30 + player.Armor/4) + " ) armor buff! ";
            return new List<StatPackage>() { reaction };
        }
    }
}
