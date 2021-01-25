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
    class HunterShrine : PlayerInteraction
    {
        public bool Used { get; protected set; }
        public HunterShrine(GameSession ses) : base(ses)
        {
            Enterable = false;
            parentSession = ses;
            Name = "interaction0105";
        }
        protected override void RunContent()
        {
            Used = ShrineEffects.UseEffect(parentSession, 5, Used);
        }

    }
}