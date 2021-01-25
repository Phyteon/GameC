using Game.Engine.Interactions.GeneralQuestline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.GeneralQuestline
{
    [Serializable]
    class GeneralDuringTreantState : GeneralState
    {
        public override void RunContent(GameSession parentSession, GeneralEncounter myself, TrainingEncounter training, CampEncounter camp, LibrarianEncounter librarian, TreantEncounter treant)
        {

            parentSession.SendText("\nHow's the progress, soldier?");
            if (camp.Decision && treant.Complete)
            {
                parentSession.GetListBoxChoice(new List<string>() { "I managed to clear the area near the camp. In fact, there was a hostile treant close to it. Thankfully, I defetead it and the camp should be safe now." });
                parentSession.SendText("\nHoly Smoke! I can't believe there was an old mystic creature so close to the city. Well done soldier!");
                parentSession.GetListBoxChoice(new List<string>() { "*continue*" });
                parentSession.SendText("\nDefeating a creature like this is not an easy task! I didn't know you were capable of handling yourself that well, soldier. I might actually need your help with harder, more important tasks.");
                parentSession.GetListBoxChoice(new List<string>() { "Whatever you command, Sir" });
                //DialogueBeforeSecondChapter(parentSession, myself, librarian);
                myself.ChangeState(new GeneralDuringTreantState(), true); //chwilowe zakończenie questlineu dla testów
            }
            else if (!camp.Decision && treant.Complete)
            {
                parentSession.GetListBoxChoice(new List<string>() { "I managed to clear the area near the camp. There are no more bandits close to the camp anymore. There was a hostile treant nearby, but I've taken care of it." });
                parentSession.SendText("\nHmmm, a treant... Interesting. Surely noone would expect that creature to be around here. Anyway, great job soldier!");
                parentSession.GetListBoxChoice(new List<string>() { "*continue*" });
                parentSession.SendText("\nDefeating a creature like this is not an easy task! I didn't know you were capable of handling yourself that well, soldier. I might actually need your help with harder, more important tasks.");
                //DialogueBeforeSecondChapter(parentSession, myself, librarian;
                myself.ChangeState(new GeneralDuringTreantState(), true); //chwilowe zakończenie questlineu dla testów
            }
            
            else
            {
                parentSession.GetListBoxChoice(new List<string>() { "I didn't clear the whole area yet. I'm working on it, Sir" });
                parentSession.SendText("\nThen you probably should get back to work, soldier!");
                return;
            }
        }
        /*
         * Witaj Marciello. Stworzyłem tą funkcję przejściową żeby było wyraźnie zaznaczone, gdzie ja skończyłem swoją część questlineu.
         * Jak ją napiszesz to odkomentuj tylko 24 i 33 linijkę.
        */
        private void DialogueBeforeSecondChapter(GameSession parentSession, GeneralEncounter myself, LibrarianEncounter librarian)
        {
            librarian.ChangeState(new LibrarianDefaultState()); //tej linijki raczej nie zmieniaj pliska
            parentSession.SendText("\nI need to get a 'Heart of the Forest'. Maybe druid called Bulgur would know something about it. He lives in the forest, not far away from the military camp."); //jak chcesz to to też możesz zmienić
            parentSession.GetListBoxChoice(new List<string>() { "*continue*" }); //stosowałem taki trick z *continue*, żeby dialogi nie były za długie. Nie musisz tego stosować, ale będzie spójniej wyglądała całość
            parentSession.SendText("\nGo to the Spooky Forest");
            myself.ChangeState(new GeneralAmuletState()); // już ty będziesz musiał dopisać stan generała jak będzie oczekiwał na wykonanie dalszych czynności.
        }
    }
}
