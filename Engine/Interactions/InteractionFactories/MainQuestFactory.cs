using Game.Engine.Interactions.GeneralQuestline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.InteractionFactories
{
    [Serializable]
    class MainQuestFactory : InteractionFactory
    {
        private int i = 0;
        public List<Interaction> CreateInteractionsGroup(GameSession parentSession)
        {
            if (i == 0)
            {
                i++;
                TrainingEncounter training = new TrainingEncounter(parentSession);
                GeneralQuestline.CampEncounter camp = new GeneralQuestline.CampEncounter(parentSession);
                GeneralQuestline.TreantEncounter treant = new GeneralQuestline.TreantEncounter(parentSession);
                GeneralQuestline.LibrarianEncounter librarian = new GeneralQuestline.LibrarianEncounter(parentSession, treant);
                GeneralEncounter general = new GeneralEncounter(parentSession, training, camp, librarian, treant);

                BasicWitch.BasicWitchEncounter bWitch = new BasicWitch.BasicWitchEncounter(parentSession);
                // the map constructor does not support multiple interactions of the same type for now
                //BasicWitch.BasicWitchEncounter bWitch1 = new BasicWitch.BasicWitchEncounter(parentSession);
                //BasicWitch.BasicWitchEncounter bWitch2 = new BasicWitch.BasicWitchEncounter(parentSession);
                //BasicWitch.BasicWitchEncounter bWitch3 = new BasicWitch.BasicWitchEncounter(parentSession);
                BasicDarkElf.BasicDarkElfEncounter bElf = new BasicDarkElf.BasicDarkElfEncounter(parentSession);
                //BasicDarkElf.BasicDarkElfEncounter bElf1 = new BasicDarkElf.BasicDarkElfEncounter(parentSession);
                //BasicDarkElf.BasicDarkElfEncounter bElf2 = new BasicDarkElf.BasicDarkElfEncounter(parentSession);
                //BasicDarkElf.BasicDarkElfEncounter bElf3 = new BasicDarkElf.BasicDarkElfEncounter(parentSession);
                List<BasicWitch.BasicWitchEncounter> bWitches = new List<BasicWitch.BasicWitchEncounter>();
                bWitches.Add(bWitch);
                //bWitches.Add(bWitch1);
                //bWitches.Add(bWitch2);
                //bWitches.Add(bWitch3);
                List<BasicDarkElf.BasicDarkElfEncounter> bElfs = new List<BasicDarkElf.BasicDarkElfEncounter>();
                bElfs.Add(bElf);
                //bElfs.Add(bElf1);
                //bElfs.Add(bElf2);
                //bElfs.Add(bElf3);
                MainDarkElf.MainDarkElfEncounter elf = new MainDarkElf.MainDarkElfEncounter(parentSession, null, bElfs);
                MainWitch.MainWitchEncounter witch = new MainWitch.MainWitchEncounter(parentSession, elf, bWitches);
                Interactions.Amulet.AmuletEncounter amulet = new Interactions.Amulet.AmuletEncounter(parentSession);
                Interactions.Trap.TrapEncounter trap = new Interactions.Trap.TrapEncounter(parentSession);
                elf = new MainDarkElf.MainDarkElfEncounter(parentSession, witch, bElfs);
                witch = new MainWitch.MainWitchEncounter(parentSession, elf, bWitches);
                Wolf.WolfEncounter wolf = new Wolf.WolfEncounter(parentSession, bWitches, witch);
                Bear.BearEncounter bear = new Bear.BearEncounter(parentSession, bWitches, witch);
                Fox.FoxEncounter fox = new Fox.FoxEncounter(parentSession, bWitches, witch);
                Druid.DruidEncounter druid = new Druid.DruidEncounter(parentSession, wolf, bear, fox, bWitches, witch);
                //Bear.BearEncounter woundedBear = new Bear.BearEncounter(parentSession, bWitches, witch);
                //Wolf.WolfEncounter woundedWolf = new Wolf.WolfEncounter(parentSession, bWitches, witch);
                //Fox.FoxEncounter woundedFox = new Fox.FoxEncounter(parentSession, bWitches, witch);
                TempleGates.GatesEncounter gates = new TempleGates.GatesEncounter(parentSession, elf, witch, librarian);
                List<Interaction> finalList = new List<Interaction>() { camp, training, treant, librarian, general, wolf,
                    druid, bear, fox, gates, witch, elf, bElf, /*bElf1, bElf2, bElf3,*/ bWitch, /*bWitch1, bWitch2, bWitch3,*/
                    amulet, trap };

                TempleQuestFactory pSmallFactory = new TempleQuestFactory(); 
                List<Interaction> pQuest = pSmallFactory.CreateInteractionsGroup(parentSession);
                foreach (Interaction quest in pQuest) { finalList.Add(quest); }

                NecromancerFactory mSmallFactory = new NecromancerFactory();
                List<Interaction> mQuest = mSmallFactory.CreateInteractionsGroup(parentSession);
                foreach (Interaction quest in mQuest) { finalList.Add(quest); }

                return finalList;
            }
            else return new List<Interaction>();
        }
    }
}
