using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Axes
{
    [Serializable]
    class OrangeAxe : Axe
    {
        public OrangeAxe() : base("item1227")
        {
            PublicName = "Orange Axe";
            PublicTip = "20% of the arithmetic mean of stamina and precision points is converted to bonus damage of any type";
            GoldValue = 60;
        }
        private int x;
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            x = (currentPlayer.Stamina + currentPlayer.Precision) / 2;
        }
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            pack.HealthDmg += (20 * x) / 100;
            return pack;
        }
    }
}
