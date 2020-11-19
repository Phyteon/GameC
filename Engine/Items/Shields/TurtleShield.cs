using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Shield
{
    [Serializable]
    class TurtleShield : Item
    {
        public TurtleShield() : base("item1360")
        {
            PublicName = "Turtle Shell Shield";
            PublicTip = "Sometimes reduces physical damage by 50%";
            GoldValue = 10;
            ArMod = 5;
        }
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.ArmorBuff += ArMod;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == DmgType.Cut || pack.DamageType == DmgType.Cut || pack.DamageType == DmgType.Cut)
            {
                int i = Index.RNG(0, 3);
                if (i == 1)
                    pack.HealthDmg = pack.HealthDmg*50/100;
            }
            return pack;
        }
    }
}
