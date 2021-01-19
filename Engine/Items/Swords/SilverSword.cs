using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Swords
{
    [Serializable]
    class SilverSword : Sword
    {
        public SilverSword() : base("item1121")
        {
            StrMod = 10;
            GoldValue = 40;
            PublicName = "Silver Sword";
            PublicTip = "Bonus health points: level*10";
        }
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            base.ApplyBuffs(currentPlayer, otherItems);
            currentPlayer.HealthBuff += currentPlayer.Level * 10;
        }
    }
}
