using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class MagiciansCan:Sword
    {

        public MagiciansCan() : base("item0581")
        {
            PublicName = "Magician's can";
            PublicTip = "After attacking the can opens and lets out a spell. It resets after every attack";
            GoldValue = 120;
        }

        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            Random rnd = new Random();
            if (pack.CustomText == null)
            {
                switch (rnd.Next(1, 3))
                {
                    case 1:
                        pack.DamageType = DmgType.Fire;
                        pack.ArmorDmg = 4;
                        pack.HealthDmg = 8;
                        pack.CustomText += " A fire briefly blazes out of the can before disappearing into thin air. The can is closed again.";
                        break;
                    case 2:
                        pack.DamageType = DmgType.Water;
                        pack.PrecisionDmg = 5;
                        pack.HealthDmg = 10;
                        pack.CustomText += " A stream of water bursts out of the can and hits the enemy in the face. The can is closed again";
                        break;
                    case 3:
                        pack.DamageType = DmgType.Earth;
                        pack.StrengthDmg = 6;
                        pack.HealthDmg = 15;
                        pack.CustomText += " The can shakes and a boulder falls upon the enemy. The can is still closed";
                        break;
                }
            }
            return pack;
        }
    }
}
