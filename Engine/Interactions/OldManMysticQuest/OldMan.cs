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
	class OldMan : PlayerInteraction, IOldMan
	{
		public bool AllMissionCompleted { get; set; }
		int visited = 0;
		Mystic mystic;
		int mission = 0;
		List<IBoss> boses;

		//item którego damy teraz jest przykładowy:
		Clef item = new Clef();

		public OldMan(GameSession ses, Mystic myMystic, List<IBoss> myBoses) : base(ses)
		{
			Name = "interaction0267";
			Enterable = false;
			mystic = myMystic;
			boses = myBoses; 
		}


		protected override void RunContent()
		{
			//za pierwszym razem:
			if (visited == 0)
			{
				visited = 1;
				//Rozmowa:
				parentSession.SendText(
					"\nOld Man: Hello! How can I help you?"
					+ "\nPlayer: I hear you have a problem with the musicality."
					+ "\nOld Man: That's right. Surely Mystic sent you here? Don't trust him, he's a fraud, he cheated on me!"
);
				//Odpowiedź
				List<string> choices1 = new List<string>() { "\nPlayer:  No, I don't know who you're talking about.", "\nPlayer: Yes, I was at his place." };
				int index1 = parentSession.GetListBoxChoice(choices1);
				if(index1 == 0)
				{
					// "Nie, nie wiem o kim mówisz."

					// nie zdradziliśmy mistyka więc nie będzie na nas zły:
					mystic.strategy = new MysticFrendlyStrategy();

					// więc opowie nam swoją historyjkę
					parentSession.SendText(
						"\nOld Man: uh... That's good. We've been arguing recently about who's the better musician."
						+ "We organized a duel in which I lost. And he got the title of the best musician in the village"
						+ "But at one point I noticed that there were little elves in his guitar that actually played for him."
						+ "I got so angry I took that guitar away from him. We haven't spoken to each other since.");

					parentSession.SendText(
						"\nOld Man: Back to the subject."
						+ "Our village has been famous for making flawless musical instruments since the dawn of time."
						+ "Creating instruments is not only a passion but also the main source of income."
						+ "Some time ago, monsters stole from our vault the gift of musicality which we have used for a long time"
						+ "We must exterminate them as soon as possible!"
						+ "\nGo north and find a monster named:" + boses[0].NameView + " I'll tell you what's next."
						+ "I'm giving you a cello key without which you won't be able to fight, dear!");
					parentSession.AddThisItem(item);
				}
				else if (index1 == 1)
				{
					// na 70% mistyk dowie się o zdradzie:
					int chance = Index.RNG(1, 100);
					if (chance <= 70)
						mystic.strategy = new MysticCheatStrategy();
					else
						mystic.strategy = new MysticFrendlyStrategy();

					// "tak, byłem u niego."
					// więc nie opowie nam historyjki :c
					parentSession.SendText(
						"\nOld Man: I knew it! Get out of here!"
						+ "\nPlayer: Wait! What about the village? He said we were in danger."
						+ "\nOld Man: *Sighs* Okay, so some time ago monsters stole the gift of musicality from our vault."
						+ "\nEach of them holds part of the key to the vault where our gift is. You have to destroy them"
						+ "\nGo north and find a monster named:" + boses[0] + " later I'll tell you what's next"
						+ "\nYou can buy from me a cell-key that will help you fight for " + item.GoldValue + " gold");

					List<string> choices2 = new List<string>() { "\nPlayer: No, thank you. I can manage without him."  };
					if (parentSession.currentPlayer.Gold >= item.GoldValue)
						choices2.Add("\nPlayer: I'm buying.");

					int index2 = parentSession.GetListBoxChoice(choices1);

					if(index2 == 0)
					{
						parentSession.SendText("\nOld Man: Okay, go ahead.");
					}
					else
					{
						
						parentSession.currentPlayer.Gold -= item.GoldValue;
						parentSession.AddThisItem(item);
						parentSession.SendText("\nOld Man: A good choice, I hope you can handle it.");
					}

				}

				//misja pierwsza:
				IncrementMission();

			}

			//za następnym razem:
			else
			{
				IBoss helpBoss = boses[mission - 1];

				//sprawdzam czy ostatni boss został pokonany:
				if(boses[boses.Count-1].IsDefeated == true)
				{
					//pomocnik dla drugiej osoby
					AllMissionCompleted = true;
					
					//Zakończyliśmy misję (Kontynuację robi ktoś inny)
					parentSession.SendText("\nOld Man: Congratulations! You fought all the monsters, so we have the key to the vault.");
				}
				else
				{
					//jeśli został pokonany:
					if(helpBoss.IsDefeated == true)
					{
						IncrementMission();
						parentSession.SendText("\nOld Man: Well done. Now find and destroy the monster called: " 
							+ boses[mission -1].NameView 
							+ "then I'll tell you what's next");
					}
					//jeśli nie został pokonany:
					else
					{
						//będzie mówił jakieś dialogi losowo:
						int pointer = Index.RNG(0, 3);
						string dialog;
						switch (pointer)
						{
							case 0:
								dialog = "Nice weather, isn't it?";
								break;
							case 1:
								dialog = "What are you waiting for? you must find this monster and destroy it!";
								break;
							case 2:
								dialog = "They say monsters have feelings too. . . but that obviously doesn't explain their behaviour!";
								break;
							case 3:
								dialog = "Since the gift of musicality was stolen from us, the village has become gloomy...";
								break;
							default:
								dialog = "Hang on!";
								break;
						}
						parentSession.SendText("\nOld Man: " + dialog);
					}

				}
			}




		}

		//funkcja pomocnicza co bym nie zapomniał że trzeba zaktualizować misję w dwóch miejscach
		void IncrementMission()
		{
			mission++;
			mystic.Mission++;

		}



	}
}
