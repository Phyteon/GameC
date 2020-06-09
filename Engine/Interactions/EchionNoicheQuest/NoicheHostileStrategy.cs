using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.EchionNoiche
{
    [Serializable]
    class NoicheHostileStrategy : INoicheStrategy
    {
        public void Execute(GameSession parentSession, bool visited)
        {
            if (visited)
            {
                parentSession.SendText("\n*There is nothing left from the dwarf. You are standing there completely alone. Mayby it's time to think about the future.*");
                return;
            }
            else
            {
                parentSession.SendText("\n*As you approaching to the place where Noiche stood, you noticing that a floating dust in front of you suddenly started converging.*");
                parentSession.SendText("\n*Medallion heats up on your chest, and you see how dust in creating a silhouette of a dwarf.*");
                parentSession.SendText("\n*There is a web of red, glowing lines all around his body as if the energy from the medallion was holding him together.*");
                parentSession.SendText("\nHi *He smiles at you, but there is saddness in his eyes*");
                parentSession.SendText("\nI see you managed to charge the medallion. Well, its your burden from now on. *He turns away from you and looks at the sun*");
                parentSession.SendText("\nYou have no idea how many things happend on this world. Horrible things... *He turns back to look you in the eyes*");
                parentSession.SendText("\nI was once an apprentice of a very powerful wizard. He wanted to control everything everywhere. And I was sure that it was right.");
                parentSession.SendText("\nHe did so many unforgivable, unimaginable thigs... But one day he truely crossed the line. When he stole the eggs...");
                parentSession.SendText("\nPeople tought dragon was just a monster but I knew that he just wanted his kids back. ");
                parentSession.SendText("\nI stole the medallion and I wanted to release the creature. I charged the artifact and went to the temple. But it was to late. ");
                parentSession.SendText("\nDragon was blinded with fury. If I was ever to release him he would burn us all.");
                parentSession.SendText("\nSo I decided to keep the medallion. And then I realised how powerful it was");
                parentSession.SendText("\nThis medallion allows you to bilocate and shapeshift on an unimaginable scale.");
                parentSession.SendText("\nI recreated every creature killed by wizard. I INHABITATED this world, do you get it?");
                parentSession.SendText("\n*He waves his hand at the world around you*");
                parentSession.SendText("\nDo you see it all? Do you see it? I am EVERYWHERE!");
                parentSession.SendText("\nI separated my consciousness into thousands of living beings. I was eyes and ears of the planet.");
                parentSession.SendText("\nWizard was looking for me. Each time he caught me as an another creature I was trying to convince him to stop.");
                parentSession.SendText("\nIt drove him insane. Finally he hurled himself on the monument and set it on fire believing it will give him powers that I had.");
                parentSession.SendText("\nBut the only thing he did, was to sparkle the dragon fire once again. The beast was now more powerful and angry than ever.");
                parentSession.SendText("\nI was trying to slay it. I sent myself as a various creatures inside the temple to fight him, but I didn't stand a chance.");
                parentSession.SendText("\nEven as his own form I couldn't defeat him. So I tricked various adventurers into fighting me to check if they are worthy.");
                parentSession.SendText("\nSometimes they were just good humans so I rewarded them... Sometimes they were greedy and traitorous so I killed them");
                parentSession.SendText("\nAnd I was waiting for someone like you. Someone who won't just defeat the dragon, but also take this medallion away from me.");
                parentSession.SendText("\nI know its selfish. But, if you were me, you would understand. Go, adventurer. Thank you for relieving me from my burden");
                parentSession.SendText("\nI wish you good luck. Be well...");
                parentSession.SendText("\n*He smiles at you and walkes away. Once he got far enough from the medallion, his body fell apart*");
                parentSession.SendText("\n*This is it. This is the end of the story.*");
                parentSession.UpdateStat(7, 1000);
            }
        }
    }
}
