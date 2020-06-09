
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.OldManMysticQuest
{
	[Serializable]
	class Mystic : ListBoxInteraction
	{
		public int Visited { get; set; } = 0;
		public IMysticStrategy strategy;
		public int Mission { get; set; } = 0;
		public List<IBoss> Boses;

		//Dodatkowa metoda potrzebna do strategii
		public new int GetListBoxChoice(List<string> choices)
		{
			return parentSession.ListBoxInteractionChoice(choices);
		}

		public Mystic(GameSession ses, List<IBoss> myBoses) : base(ses)
		{
			Name = "interaction0268";
			Enterable = false;
			strategy = new MysticFrendlyStrategy();
			Boses = myBoses;
		}

		protected override void RunContent()
		{
			if (Visited == 0 & Mission == 0)
			{
				parentSession.SendText(
					"\nMystic: Hello!"
					+"Our village has been famous for making flawless musical instruments since the flooding of history."
					+"Creating instruments is not only a passion but also a major source of income."
					+"Some time ago a terrible thing happened, we can't tune our instruments. We are in danger of extinction!"
					+"\nWill you help us?");

				List<string> choices = new List<string>() { "Player: Yes, of course!", "Player: Unfortunately I don't have time, maybe another time." };
				int index = GetListBoxChoice(choices);
				if (index == 0)
				{
					Visited = 1;
					parentSession.SendText("\nMystic: Great! You have to find the old man - I heard he had his fingers in it, but don't say anything about me!");
				}
				else
				{
					parentSession.SendText("\nMystic: I understand. . . If you change your mind, you know where to find me.");
				}


			}
			else
			{
				if (Mission == 0)
					RandomDialog(parentSession);
				else
					strategy.Talk(parentSession, this);
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
