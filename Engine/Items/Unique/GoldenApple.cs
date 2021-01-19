using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.MyItems
{
    [Serializable]
    class GoldenApple : Item
    {
        public GoldenApple() : base("item1212")
        {
            PublicName = "Golden Apple";
            PublicTip = "Each 7 points of strength is converted into 1 point of bonus magic power points.";
            GoldValue = 35;
            MgcMod = 5;
        }
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.MagicPowerBuff += MgcMod + currentPlayer.Strength / 7;
        }
    }
}
