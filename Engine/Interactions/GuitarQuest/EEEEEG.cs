using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Items
{
    [Serializable]
    class EEEEEG:Item
    {
        public static int stringCount { get; private set; }
        public EEEEEG() : base("item0590")
        {
            PublicName = "Enormously Electrifying Extremely Exceptional Electric Guitar";
            PublicTip = "A mysterious artefact of unknown origin. Legend says, when fully-stringed it can be extremely powerful";
            GoldValue = 0;
        }
        public override void ApplyBuffs(Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.StrengthBuff += Convert.ToInt32(currentPlayer.Strength * 0.1);
        }
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            pack.HealthDmg += stringCount * 10;
            pack.ArmorDmg += stringCount * 2;
            return pack;
        }
        public static void AddString()
        {
            if(stringCount>=0 && stringCount<6) stringCount++;
           /* This used to work, but is broken because of a different implementation method. Keeping it here for future reference
            * 
            * switch (stringCount)
            {
                case 1:
                    PublicName = "Enormously Electrifying Extremely Exceptional Electric Guitar (one string)";
                    break;
                case 2:
                    PublicName = "Enormously Electrifying Extremely Exceptional Electric Guitar (two strings)";
                    break;
                case 3:
                    PublicName = "Enormously Electrifying Extremely Exceptional Electric Guitar (three strings)";
                    break;
                case 4:
                    PublicName = "Enormously Electrifying Extremely Exceptional Electric Guitar (four strings)";
                    break;
                case 5:
                    PublicName = "Enormously Electrifying Extremely Exceptional Electric Guitar (five strings)";
                    break;
                case 6:
                    PublicName = "Enormously Electrifying Extremely Exceptional Electric Guitar (fully stringed)";
                    break;

            }
           */
        }

    }
}
