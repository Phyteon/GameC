using Game.Engine.Monsters.Built_In;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Necromancer
{
    [Serializable]
    class LichEncounter : PlayerInteraction
    {
        NecromancerEncounter necromancer;
        public LichEncounter(GameSession ses, NecromancerEncounter necro) : base(ses)
        {
            Name = "interaction0152";
            necromancer = necro;
        }
        protected override void RunContent()
        {
            if (necromancer.Complete == true)
            {
                parentSession.SendText("It seems like youve killed the old man, as my gratidude you may live");
                parentSession.RemoveCurrentlyVisitedInteraction();
            }
            if (parentSession.TestForItem("catacombsKey") == true && necromancer.Complete == false)
            {
                parentSession.SendText("Look at you, another puppet of a necromancer, the only difference is that, this one is still alive");
                parentSession.FightThisMonster(new Lich());
                parentSession.AddThisItem(necromancer.Staff);
                parentSession.RemoveCurrentlyVisitedInteraction();
            }
            else parentSession.SendText("The gate is closed");
            

        }
    }  
}
