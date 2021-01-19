using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Shields
{
    [Serializable]
    class VikingShield : Item
    {
        public VikingShield() : base("item1226")
        {
            PublicName = "Viking Shield";
            PublicTip = "15% health is converted to armor";
            GoldValue = 60;
            ArMod = 10;
        }
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.ArmorBuff += ArMod + currentPlayer.Health / 15;
        }
    }
}
