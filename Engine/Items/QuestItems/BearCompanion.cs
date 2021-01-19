using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.AnimalItems
{
    class BearCompanion : Item
    {
        public BearCompanion() : base("item0120") // zmienić wygląd
        {
            HpMod = 30;
            GoldValue = 10;
            PublicName = "Bear";
        }
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.StrengthBuff += currentPlayer.Health / 2;
        }
    }
}
