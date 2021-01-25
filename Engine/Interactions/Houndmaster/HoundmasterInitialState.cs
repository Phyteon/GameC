using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Houndmaster
{
    [Serializable]
    class HoundmasterInitialState : HoundmasterState
    {
        public override void RunContent(GameSession parentSession, HoundmasterEncounter myself, IceHoundEncounter iceHound, FireHoundEncounter fireHound, ShadowHoundEncounter shadowHound)
        {
            parentSession.SendText("\nWelcome. My name is Ezrael, I train wild animals. Lately i had an alchemist gave me his hounds to train. ");
            parentSession.GetListBoxChoice(new List<string>() { "*continue*" });
            parentSession.SendText("\nDuring their training they managaed to escape. They are quite dangerous beasts. Do you think you could help me find them? Naturally, you will be highly rewarded");
            int decision = parentSession.GetListBoxChoice(new List<string>() { "I can help you with that", "Sorry, I'm busy right now" });
            if (decision == 1) return;
            parentSession.SendText("\nThank you very much. There are 3 hounds, you will recognise them easly. Come back to me when you manage to find them all");
            parentSession.GetListBoxChoice(new List<string>() { "Sure, I'm on my way" });
            parentSession.AddInteractionToMap(iceHound);
            parentSession.AddInteractionToMap(fireHound);
            parentSession.AddInteractionToMap(shadowHound);
            myself.ChangeState(new HoundmasterWaitingState());
            return;
        }
    }
}
