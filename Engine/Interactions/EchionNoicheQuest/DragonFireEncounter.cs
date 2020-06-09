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
    class DragonFireEncounter : ListBoxInteraction
    {
        
        private EchionEncounter echion;
        private NoicheEncounter noiche;
        private TempleEncounter temple;
        private int visited = 0;
        public DragonFireEncounter(GameSession ses, EchionEncounter echion, NoicheEncounter noiche, TempleEncounter temple) : base(ses)
        {
            Name = "interaction1283";
            this.echion = echion;
            this.noiche = noiche;
            this.temple = temple;
        }
        protected override void RunContent()
        {
            if (visited == -1)
            {
                parentSession.SendText("\nMonument is entirely on fire. In a few minutes it will burn the whole forest. And there is nothing you can do about it.");
                return;
            }
            if (visited == 1)
            {
                parentSession.SendText("\nThe monument is dormant. Now you can see it up close. You notice that it's not a rock.");
                parentSession.SendText("\nThis is some kind of crust. You recognize it. This is crust from dragon eggs! Someone was very smart here...");
                return;
            }
            if (visited == 2) 
            {
                parentSession.SendText("\nFire is raging all around you and there is definitely no additional gold here. Nice plan, dumbass...");
                return;
            }
            if (echion.fire == 1)
            {
                parentSession.SendText("\nThere is a great fire burning on monument in front of you. It gets bigger as you get closer, but the heat doesn't seem to affect you.");
                parentSession.SendText("\nMedallion is shaking on your neck. You cannot explain it, but somehow you know that this is it. This is the fire that can charge the amulet.");
                parentSession.SendText("\nYou know that you have to cast a spell for medallion to work. But you also now that casting a wrong spell might be very dangerous.");
                parentSession.SendText("\nYou are trying to remember all magic incantations that you learn in your life.");
                int choice = GetListBoxChoice(new List<string>() { "*Hederae suae hostis mei circumplica*", "*Vita mortis cordia*", "*Redivivus ignis potestas*", "*Aurum potestas est*", "*Posuit orbem in igne*", "*Respirare est draco*" });
                switch (choice)
                {
                    case 2:
                        parentSession.SendText("\nFire starts raging. It swirls and dances around you and you feel it's power inside your body");
                        parentSession.SendText("\nMedallion opens and all of the flames around you are pouring inside. You have a feeling that every single trait of yours is more powerful than ever");
                        parentSession.SendText("\nPower of the flame of the dragon is now reborn inside your body");
                        parentSession.UpdateStat(2, 500);
                        parentSession.UpdateStat(3, 500);
                        parentSession.UpdateStat(4, 500);
                        parentSession.UpdateStat(7, 500);
                        noiche.Strategy = new NoicheHostileStrategy();
                        visited = 1;
                        break;
                    case 3:
                        parentSession.SendText("\nMayby quoting your favourite book wasn't such a good idea? I mean, why would it work, right?");
                        parentSession.SendText("\nAnyways, something definitely went wrong. The fire explodes hurling your body away. You feel great pain");
                        parentSession.SendText("\nThe flames are now sky high. Your medallion opens and you see how its energy is getting consumed by fire");
                        parentSession.SendText("\nConflagration is spreading all around you. Whatever you just did, was a mistake");
                        temple.Strategy = new TempleHostileStrategy2();
                        noiche.Strategy = new NoicheHostileStrategy3();
                        visited = 2;
                        break;
                    default:
                        parentSession.SendText("\nSomething went wrong. The fire explodes hurling your body away. You feel great pain");
                        parentSession.SendText("\nThe flames are now sky high. Your medallion opens and you see how its energy is getting consumed by fire");
                        parentSession.SendText("\nConflagration is spreading all around you. Whatever you just did, was a mistake");
                        temple.Strategy = new TempleHostileStrategy2();
                        noiche.Strategy = new NoicheHostileStrategy3();
                        visited = -1;
                        break;
                }
            }
            else
            {
                parentSession.SendText("\n*There is a big fire on the monument in front of you. The heat almost burns your face*");
                parentSession.SendText("\n*You are moving away from the fire*");
                return;
            }
        }
    }
}
