using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Swords
{
    [Serializable]
    class DiaxSword : Sword
    {
        public DiaxSword() : base("item1120")
        {
            StrMod = 10;
            GoldValue = 60;
            PublicName = "Diax Sword";
            PublicTip = "15-20 bonus points to precision";
        }
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            base.ApplyBuffs(currentPlayer, otherItems);
            int q = Index.RNG(15, 21);
            currentPlayer.PrecisionBuff += q;
        }
    }
}
