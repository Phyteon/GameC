using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.AnnItems
{
    [Serializable]
    class AnnMagicBook : Item
    {
        private int magicPowerAbsorption;
        public AnnMagicBook() : base("item1322")
        {
            MgcMod = 40;
            PrMod = 10;
            GoldValue = 80;
            PublicName = "Ann's Magic Book";
            PublicTip = "absorbs 50% of magic damage and adds it to magic attack";
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if (DmgTest.Magic(pack.DamageType))
            {
                magicPowerAbsorption = pack.MagicPowerDmg / 2;
            }
            return pack;
        }
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (DmgTest.Magic(pack.DamageType))
            {
                pack.MagicPowerDmg += magicPowerAbsorption;
            }
            return pack;
        }
    }
}
