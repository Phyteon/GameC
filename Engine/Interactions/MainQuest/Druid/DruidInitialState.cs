using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Druid
{
    [Serializable]
    class DruidInitialState : DruidState
    {

        public override void RunContent(GameSession parentSession, DruidEncounter myself, Wolf.WolfEncounter myWolf, Bear.BearEncounter myBear, Fox.FoxEncounter myFox, List<BasicWitch.BasicWitchEncounter> bWitches, MainWitch.MainWitchEncounter mWitch)
        {
            parentSession.SendText("\nGreetings my friend. Are you lost?");
            // get player choice
            int choice = parentSession.GetListBoxChoice(new List<string>() { "No. Why do you think so?", "Hello old man. We are in Spooky Forest. Who are you?"});
            switch (choice)
            {
                case 0:
                    parentSession.SendText("We are in ancient Enchanted Forest. We rarely have visitors here. Anyway my name is Bulgur. I'm just a simple greybeard trying to study misteries of this place.");
                    int choice2 = parentSession.GetListBoxChoice(new List<string>() { "I thought it's Spooky Forest." });
                    if (choice2 == 0)
                    {
                        parentSession.SendText("Poor narrow minded villagers. They are always afraid of the things they don't understand. Let's clarify something son. Some time ago this forest was full of little fairies. As you have probably noticed, this place isn't so colorful anymore thanks to your unsatisfied ancestors. They wanted to learn fairie's secrets of magic. Due to the tortures and executions this forest is literally soaked with blood and full of dark magic. That's the reason why your friends call this place 'Spooky Forest'. People always want power to rule the world, so be careful who do you trust young one.");
                    }
                    else parentSession.SendText("...");
                    break;
                case 1:
                    parentSession.SendText("My name is Bulgur. I'm trying to study misteries of this place. To clarify we are in enhanced forest. Some time ago this forest was full of little fairies. As you have probably noticed, this place isn't so colorful anymore thanks to your unsatisfied ancestors. They wanted to learn fairie's secrets of magic. Due to the tortures and executions this forest is literally soaked with blood and full of dark magic. That's the reason why your friends call this place 'Spooky Forest'. People always want power to rule the world, so be careful who do you trust young one.");
                    break;
            }
            int choice3 = parentSession.GetListBoxChoice(new List<string>() { "That's terrible. Could you tell me something about the Temple?", "I didn't come here for history lessons old man. Where is the Temple?" });
            switch (choice3)
            {
                case 0:
                    parentSession.SendText("Of coures, the Temple... \n Watch out!");
                    parentSession.GetListBoxChoice(new List<string>() { "???" });
                    break;
                case 1:
                    parentSession.SendText("Patience young man. The Temple... \n Watch out!");
                    parentSession.GetListBoxChoice(new List<string>() { "???" });
                    break;
            }
            parentSession.FightThisMonster(new Monsters.Forest.Wolf(), false);
            parentSession.SendText("Thank god, you were here. \n Please take this gold. It's useless for me.");
            parentSession.UpdateStat(8, 20);
            parentSession.SendText("As you have just noticed, the forest isn't peolpe friendly anymore. I'm trying to discover what's causing animals aggresive behavior. \n Could you help me son?");
            int choice4 = parentSession.GetListBoxChoice(new List<string>() {"Of course, how can I help?", "Everything comes with a price old man."});
            switch (choice4)
            {
                case 0:
                    break;
                case 1:
                    parentSession.SendText("In this case, let's make a deal. You will help me and I will tell you everything I know about the Temple and I will open the entrence to deeper parts of the forest.. Is it ok?");
                    parentSession.GetListBoxChoice(new List<string>() { "Deal." });
                    break;
            }
            parentSession.SendText("Splendidly! I need to examine animals behavior so you have to fight one of them and bring it to me alive or dead. Your choice. \n Which one do you choose?");
            int choice5 = parentSession.GetListBoxChoice(new List<string>() { "Wolf", "Bear.","Fox" });
            
            switch (choice5)
            { 
                case 0:
                    myself.IsWolfChosen = true;
                    myself.IsBearChosen = false;
                    myself.IsFoxChosen = false;
                    myWolf.ChangeState(new Wolf.WolfInteractionState());
                    myBear.ChangeState(new Bear.BearFightState());
                    myFox.ChangeState(new Fox.FoxFightState());


                    break;
                case 1:
                    myself.IsWolfChosen = false;
                    myself.IsBearChosen = true;
                    myself.IsFoxChosen = false;
                    myBear.ChangeState(new Bear.BearInteractionState());
                    myWolf.ChangeState(new Wolf.WolfFightState());
                    myFox.ChangeState(new Fox.FoxFightState());
                    break;
                case 2:
                    myself.IsWolfChosen = false;
                    myself.IsBearChosen = false;
                    myself.IsFoxChosen = true;
                    myFox.ChangeState(new Fox.FoxInteractionState());
                    myWolf.ChangeState(new Wolf.WolfFightState());
                    myBear.ChangeState(new Bear.BearFightState());
                    break;
            }
            parentSession.SendText("You can find him outside my house.");
            myself.ChangeState(new DruidAnimalState(), false);
        }
    }
}
