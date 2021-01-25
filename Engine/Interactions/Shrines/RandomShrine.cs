using Game.Engine.Interactions.Built_In;
using Game.Engine.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Interactions.Shrines;

namespace Game.Engine.Interactions.Shrines
{
    [Serializable]
    class RandomShrine : PlayerInteraction
    {
        public bool Used { get; protected set; }
        public RandomShrine(GameSession ses) : base(ses)
        {
            Enterable = false;
            parentSession = ses;
            Name = "interaction0100";
        }
        protected override void RunContent()
        {
            //this shrine either gives a random shrine effect, or ocasionally gives you special trinket
            int special = Index.RNG(0, 100);
            if(special<15)
            {
                parentSession.AddThisItem(new OrbOfGods());
            }
            else
            {
                int effect = Index.RNG(1, 6);
                switch (effect)
                {
                    case 1:
                        Used = ShrineEffects.UseEffect(parentSession, effect, Used);
                        return;
                    case 2:
                        Used = ShrineEffects.UseEffect(parentSession, effect, Used);
                        return;
                    case 3:
                        Used = ShrineEffects.UseEffect(parentSession, effect, Used);
                        return;
                    case 4:
                        Used = ShrineEffects.UseEffect(parentSession, effect, Used);
                        return;
                    case 5:
                        Used = ShrineEffects.UseEffect(parentSession, effect, Used);
                        return;
                }
            }

        }

    }
}