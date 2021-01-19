using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Chains
{
    [Serializable]
    class ArmorChain : Item
    {
        public ArmorChain() : base("item1182")
        {

            PublicName = "Armor Chain";
            PublicTip = "extra 20% reduction of damage to your armor";
            GoldValue = 50;
            ArMod = 30;
            HpMod = 10;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            pack.ArmorDmg = 80 * pack.ArmorDmg / 100;
            return pack;
        }
    }
}
