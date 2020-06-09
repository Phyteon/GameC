using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Monsters;

namespace Game.Engine.Interactions.EchionNoiche
{
    [Serializable]
    class TempleHostileStrategy : ITempleStrategy
    {
        public int visit;
        public void Execute(GameSession parentSession, bool visited)
        {
            if (visited)
            {
                parentSession.SendText("\n*Temple collapsed and there is no chance to go inside it again*");
                visit = 10;
                return;
            }
            else
            {
                parentSession.SendText("\n*You entered a temple. You feel very uncomfortable. There is a piedestal in the middle.*");
                parentSession.SendText("\n*Suddenly everything starts shaking and you hear an ominous voice in your head*");
                parentSession.SendText("\nAfter all those years you are back to give me back whats mine. But do not expect redemption. Your journey ends here");
                parentSession.SendText("\n*Piedestal shatters into million pieces and a giant dragon emerges from the floor. He looks very familiar*");
                parentSession.FightThisMonster(new Monsters.DeathDragon(1));
                parentSession.UpdateStat(7, 700);
                parentSession.SendText("\n*Dragon falls to the ground convulsing violently*");
                parentSession.SendText("\nThey took away my children... my freedom... and now you are taking my life");
                parentSession.SendText("\nI hope you are better than them");
                parentSession.SendText("\n*His whole body dissolves into sparkling dust. In this light you see enourmous writing on the floor, in the place when piedestal was before*");
                parentSession.SendText("\nREDIVIVUS IGNIS POTESTAS");
                parentSession.SendText("\n*The temple is collapsing. You are running out of it in the last second*");
                visit = 10;
                return;
            }
        }
    }
}
