using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Interactions.OldManMysticQuest
{
    [Serializable]
    class Clef : Items.Item
    {
        public Clef() : base("item0269")
        {
            PublicName = "Clef";
            PublicTip = "Is very important to kill music monsters.";
            GoldValue = 100;
        }
        public override void ApplyBuffs(Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.MagicPowerBuff += Convert.ToInt32(0.1 * currentPlayer.MagicPower);
        }
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            pack.PrecisionDmg += 10;
            return base.ModifyOffensive(pack, otherItems);
        }

    }
}
