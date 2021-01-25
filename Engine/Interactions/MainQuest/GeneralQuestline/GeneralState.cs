using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.GeneralQuestline
{
    [Serializable]
    abstract class GeneralState 
    {
        // trzeba podawaæ jako argument interakcje ¿eby póŸniej móc sprawdziæ np. czy s¹ skoñczone
        public abstract void RunContent(GameSession ses, GeneralEncounter myself, TrainingEncounter training, CampEncounter camp, LibrarianEncounter librarian, TreantEncounter treant);
    }
} 
