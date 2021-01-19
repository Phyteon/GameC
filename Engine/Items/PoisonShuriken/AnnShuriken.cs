using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.AnnItems
{
    [Serializable]
    class AnnShuriken : Item
    {
        public AnnShuriken() : base("item1321")
        {
            StrMod = 15;
            PrMod = 10;
            GoldValue = 25;
            PublicName = "Ann's Shuriken";
            PublicTip = "precision depends on health; if you have Ann's Poison, an extra buff is added;";
        }

        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            AnnPoison poison1 = new AnnPoison();

            if (otherItems.Contains(poison1.Name))
            {
                currentPlayer.StrengthBuff += poison1.StrMod + StrMod;
                currentPlayer.PrecisionBuff += PrMod * currentPlayer.Health / 100 + 15;
            }
            else
            {
                currentPlayer.StrengthBuff += StrMod;
            }
        }
    }
}
