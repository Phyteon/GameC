using Game.Engine.Interactions.Built_In;
using Game.Engine.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Monsters;


namespace Game.Engine.Interactions.EchionNoiche
{
    [Serializable]
    class EchionEncounter : PlayerInteraction
    {
        private TempleEncounter temple;
        private NoicheEncounter noiche;
        private int visited = 0;
        public int fire = 0;
        public EchionEncounter(GameSession ses, NoicheEncounter noiche, TempleEncounter temple) : base(ses)
        {
            Name = "interaction1281";
            this.noiche = noiche;
            this.temple = temple;
        }
        protected override void RunContent()
        {
            if (visited == -1)
            {
                parentSession.SendText("\n*His body stopped moving. He is dead*");
                return;
            }
            if (visited == 5)
            {
                parentSession.SendText("\n*He winks at you*");
                parentSession.SendText("\nGo give it back to me. The other me. I will explain everything");
                return;
            }
            if (visited == 10)
            {
                parentSession.SendText("\nYou are a good human, you know? I haven't seen many like you in this times. Let me give you advice. Watch out for fire with this thing.");
                parentSession.SendText("\n*He points his finger at medallion*");
                return;
            }

            parentSession.SendText("\n *You see Ice Troll sleeping in the distance. What should you do?* ");
            int choice = parentSession.GetListBoxChoice(new List<string>() { "*Sneak up, and kill him while he is asleep*", "*Shout: * Weak up beast!", "*Walk away quietly*" });
            switch (choice)
            {
                case 0:
                    parentSession.SendText("*You started sneaking up on a troll. You notice a gold medallion on his neck. When you are two steps away from him, he suddenly wakes up.*");
                    parentSession.SendText("So, you wanted to kill me like that? With no honor? Well then, now you shall face consequences...");
                    parentSession.SendText("*Medallion on his neck started shimmering violently and whole body of the troll changed suddenly into a giant dragon*");
                    parentSession.SendText("*You realize now that it was a baaad decision...*");
                    parentSession.FightThisMonster(new Monsters.DeathDragon(1));
                    parentSession.UpdateStat(7, 450);
                    parentSession.SendText("\nNo, thats... thats impossible... None can defeat me in this form...");
                    parentSession.SendText("\n*You see how his body is shaking and he falls apart revealing that inside of this giant body was a dwarf. It's Noiche!!!*");
                    parentSession.SendText("\n*He takes off his medallion* Take this medalion. Go to the temple. You are much more worthy than I am. You can beat him. You are truly able to do that");
                    visited = -1;
                    fire = 1;
                    temple.Strategy = new TempleHostileStrategy();
                    noiche.Strategy = new NoicheHostileStrategy2();
                    break;
                case 1:
                    parentSession.SendText("*Troll stands and shakes his head*");
                    parentSession.SendText("What do you want from me?");
                    int choice2 = parentSession.GetListBoxChoice(new List<string>() { "I am here to kill you and take your medallion!", "Listen man, can I have your medallion, please? I really need it." });
                    if (choice2 == 0)
                    {
                        parentSession.SendText("Well, at least you have honor to face me! Let's see in which mood you found me!");
                        parentSession.SendText("*Medallion on his neck started shimmering and you see how his body shapeshift between various monsters and finally changes into one of them*");
                        parentSession.FightRandomMonster();
                        parentSession.UpdateStat(7, 50);
                        parentSession.SendText("\n*You see how his body is shaking and he falls apart revealing that inside of this giant body was a dwarf. It's Noiche!!!*");
                        parentSession.SendText("\nUh oh... That was a good fight. You are a great fighter. Take this medalion. You deserved it.");
                        noiche.Strategy = new NoicheFriendlyStrategy2();
                        temple.Strategy = new TempleHostileStrategy();
                        fire = 1;
                        visited = 5;
                        break;
                    }
                    else parentSession.SendText("*Troll shrugs his shoulders* Sure. Take it. I didn't need it anyway.");
                    noiche.Strategy = new NoicheFriendlyStrategy();
                    temple.Strategy = new TempleHostileStrategy();
                    fire = 1;
                    visited = 10;
                    break;
                default:
                    parentSession.SendText("*You are starting to walk away from the monster. But before you do that, you hear him muttering while he is asleep*");
                    parentSession.SendText("I know mommy... I know you are asking for the second time, but I didn't do that, I swear! Alright I ate those cookies, happy? I know I am easy to convince, so what? ");
                    break;
            }
        }

    }
}
