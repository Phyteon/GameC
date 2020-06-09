
using System;

namespace Game.Engine.Interactions.OldManMysticQuest
{
	[Serializable]
	class MysticFrendlyStrategy : IMysticStrategy
	{
		int visit = 0;
		public void Talk(GameSession session, Mystic mystic)
		{
			IBoss actualBoss = mystic.Boses[mystic.Mission - 1];

			if(visit == 0)
			{
				visit++;
				session.SendText("\nMystic: I heard you're supposed to defeat a monster called " + actualBoss.NameView + ". I have something to help you beat him.");
				session.AddThisItem(actualBoss.item);
				session.SendText("\nHere you go. " + actualBoss.item.PublicName + ". You can't do it without it. Way to go!");
			}
			else
			{
				RandomDialog(session);
			}

		}

		void RandomDialog(GameSession ses)
		{
			//będzie mówił jakieś dialogi losowo:
			int pointer = Index.RNG(0, 3);
			string dialog;
			switch (pointer)
			{
				case 0:
					dialog = "What a beautiful day, isn't it?";
					break;
				case 1:
					dialog = "Oh! You scared me. . . What about the monster?";
					break;
				case 2:
					dialog = "Remember not to trust anyone in this village.";
					break;
				case 3:
					dialog = "It's good that there are good people like you in the world.";
					break;
				default:
					dialog = "Hang on!";
					break;
			}
			ses.SendText("\nMystic: " + dialog);
		}





	}

}

