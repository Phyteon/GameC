using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class LightFlash : Skill
    {
        // light flash: -15 precision debuff fot the enemy
        // only useful against enemies that rely on precision to land an attack (so not against e.g. rats)
        public LightFlash() : base("Light Flash", 10, 1) 
        { 
            PublicName = "Light Flash: decrease enemy precision stat by 15 [fire]";
            RequiredItem = RequiredItem.Staff;
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(DmgType.Fire);
            response.PrecisionDmg = 15;
            response.CustomText = "You use Light Flash! (enemy precision decreased by 15)";
            return new List<StatPackage>() { response };
        }
    }
}
