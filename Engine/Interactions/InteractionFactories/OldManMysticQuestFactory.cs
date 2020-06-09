using System;
using System.Collections.Generic;
using Game.Engine.Interactions.OldManMysticQuest;

namespace Game.Engine.Interactions.InteractionFactories
{
	[Serializable]
	class OldManMysticQuestFactory : InteractionFactory
	{
			bool used = true;
			public List<Interaction> CreateInteractionsGroup(GameSession parentSession)
			{
				if (used)
				{
					SpiderBoss boss1 = new SpiderBoss(parentSession);
					ButterflyBoss boss2 = new ButterflyBoss(parentSession);
					Boss3Encounter boss3 = new Boss3Encounter(parentSession);
					Boss4Encounter boss4 = new Boss4Encounter(parentSession);
	
					List<IBoss> boses = new List<IBoss>();
					// tutaj sobie dodajemy bossów w kolejności misji:
					boses.Add(boss1);
					boses.Add(boss2);
					boses.Add(boss3);
					boses.Add(boss4);

					Cacofonix cacofonix = new Cacofonix(parentSession);
					Mystic mystic = new Mystic(parentSession, boses);
					OldMan oldMan = new OldMan(parentSession, mystic, boses);
					Treasury treasury = new Treasury(parentSession, cacofonix, oldMan);

					used = false;
					return new List<Interaction>() { oldMan, mystic, cacofonix, treasury, boss1, boss2, boss3, boss4 };

				}
			else return new List<Interaction>();		
			}
		
	}
}