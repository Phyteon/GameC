using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Skills;
using Game.Engine.Items;

namespace Game.Engine.Interactions.OldManMysticQuest
{
	[Serializable]
	class MysticCheatStrategy : IMysticStrategy
	{
		int visit = 0;
		public void Talk(GameSession session, Mystic mystic)
		{

			IBoss actualBoss = mystic.Boses[mystic.Mission - 1];

			if (visit == 0)
			{
				visit++;
				Item actualItem = actualBoss.item;

				session.SendText(
					"\nMystic: It's you! I heard you told Old Man that we saw each other. That was not the deal!"
					+ "\nI can help you, but not for free. I'm counting 80 gold + item costs, in this case: " 
					+ actualItem.GoldValue 
					+ " gold");
				
				List<string> choises1 = new List<string>() { "Player: Maybe another time." };
				if(session.currentPlayer.Gold >= (80 + actualItem.GoldValue))
					choises1.Add("Player: Okay, hold the money.");

				int index1 = mystic.GetListBoxChoice(choises1);
				if (index1 == 0)
				{
					session.SendText("\nMystic: Go on.");
				}
				else
				{
					session.currentPlayer.Gold -= (80 + actualItem.GoldValue);
					session.AddThisItem(actualItem);
					session.SendText("\nMystic: Don't waste it!");
				}
			}
			else
			{
				//będzie mówił jakieś dialogi losowo:
				int pointer = Index.RNG(0, 3);
				string dialog;
				switch (pointer)
				{
					case 0:
						dialog = "Don't bother me!"; ;
						break;
					case 1:
						dialog = "Move! The monsters won't exterminate themselves.";
						break;
					case 2:
						dialog = "Remember not to trust anyone in this village.";
						break;
					case 3:
						dialog = "And you still come here?";
						break;
					default:
						dialog = "Hang on!";
						break;
				}
				session.SendText("\nMystic: " + dialog);
			}

		}
	}
}
