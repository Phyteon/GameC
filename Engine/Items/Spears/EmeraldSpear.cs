using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Spears
{
    [Serializable]
    class EmeraldSpear : Spear
    { 
        //more health means more precision
        public EmeraldSpear() : base("item1311")
        {
            PrMod = 30;
            GoldValue = 55;
            PublicName = "EmeraldSpear";
        }
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.PrecisionBuff += PrMod;
        }
    }
}
