using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Items;
using Game.Display;

namespace Game.Engine.Items.AnimalItems
{
    class WolfCompanion : Item
    {
        public WolfCompanion() : base("item0123") // zmienić wygląd
        {
            StrMod = 20;
            GoldValue = 10;
            PublicName = "Wolf";
        }
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.StrengthBuff +=  StrMod + currentPlayer.Strength /2;
        }
    }
}
