using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.MoreSpells
{
    [Serializable]
    class Healing : Skill
    {
        //increasess player's Hp (+50)
        public Healing() : base("Healing", 10, 2)
        {
            PublicName = "extra 50 Hp [magic]";
            RequiredItem = Skill.MainItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Other);
            player.Health += 50;
            response.CustomText = "You heal yourself with 50 Hp";
            return new List<StatPackage>() { response };
        }
    }
}
