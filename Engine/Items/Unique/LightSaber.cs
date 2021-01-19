using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.MyItems
{
    [Serializable]
    class Lightsaber : Sword
    {
        public Lightsaber() : base("item1213")
        {
            PublicName = "Lightsaber";
            PublicTip = "Each 3 points of armor is converted into 1 point of bonus precision points and you receive a 15% bonus to physical damage you deal in this battle.";
            GoldValue = 55;
            PrMod = 10;
        }
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.PrecisionBuff += PrMod + currentPlayer.Armor / 3;
        }
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (DmgTest.Physical(pack.DamageType))
            {
                pack.HealthDmg = 115 * pack.HealthDmg / 100;
            }
            return pack;
        }
    }
}
