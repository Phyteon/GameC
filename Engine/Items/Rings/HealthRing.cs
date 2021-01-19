using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Ring
{
    [Serializable]
    class HealthRing : Item
    {
        // gives 30hp and increase total health by 25%

        public HealthRing() : base("item1243")
        {
            PublicName = "HealthRing";
            PublicTip = "increase total health by 25%";
            GoldValue = 70;
            HpMod = 30;
        }

        public override void ApplyBuffs(Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.HealthBuff += HpMod + 4 * currentPlayer.HealthBuff / 100;
        }

    }
}
