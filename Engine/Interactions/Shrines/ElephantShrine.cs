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
    class ElephantShrine : PlayerInteraction
    {
        public bool Used { get; protected set; }
        public ElephantShrine(GameSession ses) : base(ses)
        {
            Enterable = false;
            parentSession = ses;
            Name = "interaction0104";
        }
        protected override void RunContent()
        {
            Used = ShrineEffects.UseEffect(parentSession, 4, Used);
        }

    }
}