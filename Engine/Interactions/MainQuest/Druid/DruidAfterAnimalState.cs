using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Druid
{
    [Serializable]
    class DruidAfterAnimalState : DruidState
    {
        public override void RunContent(GameSession parentSession, DruidEncounter myself, Wolf.WolfEncounter myWolf, Bear.BearEncounter myBear, Fox.FoxEncounter myFox, List<BasicWitch.BasicWitchEncounter> bWitches, MainWitch.MainWitchEncounter mWitch)
        {
            parentSession.SendText("As you have accomplished your part of the deal, now it's my turn. Let's talk about the Temple. What doy you want to konw?");
            int choice = parentSession.GetListBoxChoice(new List<string>() { "Where is the Temple?", "How does it looks like?", "How can I open it?" });
            switch (choice)
            {
                case 0:
                    parentSession.SendText("The Temple is located at the end of the forest, but be carefull, because withces and dark elves have their camps nearby.");
                    int choice2 = parentSession.GetListBoxChoice(new List<string>() { "How does it looks like?", "How can I open it?" });
                    switch (choice2)
                    {
                        case 0:
                            parentSession.SendText("It will probably be the biggest stone building you have ever seen in your life. It's strange that it was built by little fairies.");
                            parentSession.GetListBoxChoice(new List<string>() { "How can I open it?" });
                            parentSession.SendText("This is the part, where problems begin. To open the temple you have to correctly answer the questions that will appear on them. The number of questions is unknown to me as their content. You will probably have to show your diplomatic skills while talking to other inhabitants of this forest.");
                            break;
                        case 1:
                            parentSession.SendText("This is the part, where problems begin. To open the temple you have to correctly answer the questions that will appear on them. The number of questions is unknown to me as their content. You will probably have to show your diplomatic skills while talking to other inhabitants of this forest.");
                            parentSession.GetListBoxChoice(new List<string>() { "How does it looks like?" });
                            parentSession.SendText("It will probably be the biggest stone building you have ever seen in your life. It's strange that it was built by little fairies.");
                            break;
                    }
                    break;
                case 1:
                    parentSession.SendText("It will probably be the biggest stone building you have ever seen in your life. It's strange that it was built by little fairies.");
                    int choice3 = parentSession.GetListBoxChoice(new List<string>() { "Where is the Temple?", "How can I open it?" });
                    switch (choice3)
                    {
                        case 0:
                            parentSession.SendText("The Temple is located at the end of the forest, but be carefull, because withces and dark elves have their camps nearby.");
                            parentSession.GetListBoxChoice(new List<string>() { "How can I open it?" });
                            parentSession.SendText("This is the part, where problems begin. To open the temple you have to correctly answer the questions that will appear on them. The number of questions is unknown to me as their content. You will probably have to show your diplomatic skills while talking to other inhabitants of this forest.");
                            break;
                        case 1:
                            parentSession.SendText("This is the part, where problems begin. To open the temple you have to correctly answer the questions that will appear on them. The number of questions is unknown to me as their content. You will probably have to show your diplomatic skills while talking to other inhabitants of this forest.");
                            parentSession.GetListBoxChoice(new List<string>() { "How does it looks like?" });
                            parentSession.SendText("The Temple is located at the end of the forest, but be carefull, because withces and dark elves have their camps nearby.");
                            break;
                    }
                    break;
                case 2:
                    parentSession.SendText("This is the part, where problems begin. To open the temple you have to correctly answer the questions that will appear on them. The number of questions is unknown to me as their content. You will probably have to show your diplomatic skills while talking to other inhabitants of this forest.");
                    int choice4 = parentSession.GetListBoxChoice(new List<string>() { "Where is the Temple?", "How does it looks like" });
                    switch (choice4)
                    {
                        case 0:
                            parentSession.SendText("The Temple is located at the end of the forest, but be carefull, because withces and dark elves have their camps nearby.");
                            parentSession.GetListBoxChoice(new List<string>() { "How does it looks like" });
                            parentSession.SendText("It will probably be the biggest stone building you have ever seen in your life. It's strange that it was built by little fairies.");
                            break;
                        case 1:
                            parentSession.SendText("It will probably be the biggest stone building you have ever seen in your life. It's strange that it was built by little fairies.");
                            parentSession.GetListBoxChoice(new List<string>() { "Where is the Temple?" });
                            parentSession.SendText("The Temple is located at the end of the forest, but be carefull, because withces and dark elves have their camps nearby.");
                            break;
                    }
                    break;
            }
            parentSession.SendText("This is all I know son. You can now leave. Be careful and good luck!");

        }
    }
}
