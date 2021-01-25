using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Items;

namespace Game.Engine.Interactions.Druid
{
    [Serializable]
    class DruidAnimalState : DruidState
    {
        public override void RunContent(GameSession parentSession, DruidEncounter myself, Wolf.WolfEncounter myWolf, Bear.BearEncounter myBear, Fox.FoxEncounter myFox, List<BasicWitch.BasicWitchEncounter> bWitches, MainWitch.MainWitchEncounter mWitch)
        {
            Bear.BearEncounter woundedBear = new Bear.BearEncounter(parentSession, bWitches,mWitch);
            Wolf.WolfEncounter woundedWolf = new Wolf.WolfEncounter(parentSession, bWitches, mWitch);
            Fox.FoxEncounter woundedFox = new Fox.FoxEncounter(parentSession, bWitches, mWitch);
            if (myself.IsWolfChosen == true)
            {
                if (parentSession.TestForItem("item0134") == false) // will check for a wolf
                {
                    parentSession.SendText("Come back to me with an animal.");
                }
                else if (parentSession.TestForItem("item0134") == true)
                {
                    parentSession.SendText("Oh, you're back. Let me see this poor creature.");
                    parentSession.RemoveThisItem(Index.ProduceSpecificItem("item0134")); 
                    parentSession.SendText("Say hi to your new companion.");
                    parentSession.AddThisItem(Index.ProduceSpecificItem("item0123")); //item0123
                    myself.ChangeState(new DruidAfterAnimalState(), false);
                    parentSession.AddInteractionToMap(woundedBear);
                    parentSession.AddInteractionToMap(woundedFox);
                    woundedBear.ChangeState(new Bear.BearWoundedState());
                    woundedFox.ChangeState(new Fox.FoxTrappedState());
                }
                if (parentSession.TestForItem("item0124") == false)
                {
                    parentSession.SendText("Come back to me with an animal.");
                }
                else if (parentSession.TestForItem("item0124") == true)
                {
                    parentSession.SendText("Oh, you're back. What a pity that he's dead. Let me see.");
                    parentSession.SendText("At least you didn't waste a good leather.");
                    myself.ChangeState(new DruidAfterAnimalState(), false);
                    parentSession.AddInteractionToMap(woundedBear);
                    parentSession.AddInteractionToMap(woundedFox);
                    woundedBear.ChangeState(new Bear.BearWoundedState());
                    woundedFox.ChangeState(new Fox.FoxTrappedState());
                }
            }
            else if (myself.IsFoxChosen == true)
            {
                if (parentSession.TestForItem("item0133") == false) // will check dead animal
                {
                    parentSession.SendText("Come back to me with an animal.");
                }
                else if (parentSession.TestForItem("item0133") == true)
                {
                    parentSession.SendText("Oh, you're back. Let me see this poor creature.");
                    parentSession.RemoveThisItem(Index.ProduceSpecificItem("item0133")); 
                    parentSession.SendText("Say hi to your new companion.");
                    parentSession.AddThisItem(Index.ProduceSpecificItem("item0121")); //item0123
                    myself.ChangeState(new DruidAfterAnimalState(), false);
                    parentSession.AddInteractionToMap(woundedWolf);
                    parentSession.AddInteractionToMap(woundedBear);
                    woundedWolf.ChangeState(new Wolf.WolfWoundedState());
                    woundedBear.ChangeState(new Bear.BearTrappedState());
                }
                else if (parentSession.TestForItem("item0130") == false)
                {
                    parentSession.SendText("Come back to me with an animal.");
                }
                else if (parentSession.TestForItem("item0130") == true)
                {
                    parentSession.SendText("Oh, you're back. What a pity that he's dead. Let me see.");

                    parentSession.SendText("At least you didn't waste a good leather.");

                    myself.ChangeState(new DruidAfterAnimalState(), false);
                    parentSession.AddInteractionToMap(woundedWolf);
                    parentSession.AddInteractionToMap(woundedBear);
                    woundedWolf.ChangeState(new Wolf.WolfWoundedState());
                    woundedBear.ChangeState(new Bear.BearTrappedState());
                }
            }
            else if (myself.IsBearChosen == true)
            {
                if (parentSession.TestForItem("item0132") == false) // will check dead animal
                {
                    parentSession.SendText("Come back to me with an animal.");
                }
                else if (parentSession.TestForItem("item0132") == true)
                {
                    parentSession.SendText("Oh, you're back. Let me see this poor creature.");
                    parentSession.RemoveThisItem(Index.ProduceSpecificItem("item0132")); 
                    parentSession.SendText("Say hi to your new companion.");
                    parentSession.AddThisItem(Index.ProduceSpecificItem("item0120")); //item0123
                    myself.ChangeState(new DruidAfterAnimalState(), false);
                    parentSession.AddInteractionToMap(woundedFox);
                    parentSession.AddInteractionToMap(woundedWolf);
                    woundedFox.ChangeState(new Fox.FoxWoundedState());
                    woundedWolf.ChangeState(new Wolf.WolfTrappedState());
                }
                else if (parentSession.TestForItem("item0125") == false)
                {
                    parentSession.SendText("Come back to me with an animal.");
                }
                else if (parentSession.TestForItem("item0125") == true)
                {
                    parentSession.SendText("Oh, you're back. What a pity that he's dead. Let me see.");

                    parentSession.SendText("At least you didn't waste a good leather.");

                    myself.ChangeState(new DruidAfterAnimalState(), false);
                    parentSession.AddInteractionToMap(woundedFox);
                    parentSession.AddInteractionToMap(woundedWolf);
                    woundedFox.ChangeState(new Fox.FoxWoundedState());
                    woundedWolf.ChangeState(new Wolf.WolfTrappedState());

                    // OTWARCIE PRZEJŚCIA DO DALSZEJ CZĘŚCI LASU!!!!!!!
                }
            }

        }
    }
}
