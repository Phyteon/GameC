using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Axes
{
    [Serializable]
    class BlueAxe : Axe
    {
        public BlueAxe() : base("item1228")
        {
            GoldValue = 120;
            PublicName = "Blue Axe";
            PublicTip = "30% of health points are converted into bonus strength points";
        }
        private int x;
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            x = currentPlayer.Health;
            currentPlayer.StrengthBuff += (30*x)/100;
        }
    }
}
