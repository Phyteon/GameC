using Game.Engine.Monsters;
using Game.Engine.Monsters.Built_In;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Necromancer
{
    [Serializable]
    class NecromancerHostileState : NecromancerState
    {
        bool victory = false;
        public override void RunContent(GameSession parentSession, NecromancerEncounter necro, LichEncounter lich)
        {
            parentSession.SendText("\nYou are approaching the tower, it looks like it won't be an eazy climb");
            switch(parentSession.GetListBoxChoice(new List<string>() { "Enter the Tower", "Leave" }))
            {
                case 0:
                    
                    
                    for (int i=0; i < 5; i++)
                    {
                        List<Monster> monsters = new List<Monster> { new Bat(), new Tarantula() };
                        Random rnd = new Random();
                        victory = parentSession.FightThisMonster(monsters[rnd.Next(monsters.Count)], true);
                        if (victory == false) break;
                    }
                    if (victory == true)
                    {


                        parentSession.SendText("You are approaching the final floor");
                        parentSession.FightThisMonster(new HostileNecromancer());
                        parentSession.SendText("Now you can collect the Golem's hearth");
                        if (necro.QuestStarted == false)
                        {
                            parentSession.SendText("It seems like you also found the key");
                            parentSession.AddThisItem(necro.Key);
                            
                        }
                        necro.ChangeState(new NecromancerDeadState(), true);
                    }


                    break;
                default:
                    break;
            }
        }
    }
}
