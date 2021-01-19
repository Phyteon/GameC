using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.AnimalItems
{
    class FoxCompanion : Item
    {
        public FoxCompanion() : base("item0121") // zmienić wygląd
        {
            PrMod = 30;
            GoldValue = 10;
            PublicName = "Fox";
        }
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.PrecisionBuff += currentPlayer.Strength / 2;
        }
    }

}
