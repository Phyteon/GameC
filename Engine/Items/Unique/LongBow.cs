using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Items
{
	[Serializable]
	class LongBow : Item
	{
		public LongBow() : base("item1284")
		{
			PublicName = "Long Bow";
			GoldValue = 120;
			PublicTip = "increases precision by 50%";

		}
		public override void ApplyBuffs(Player currentPlayer, List<string> otherItems)
		{
			currentPlayer.PrecisionBuff += currentPlayer.Precision / 2; // adds 50% of current precision
		}
	}
}