using Game.Engine;
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
    class BerserkerShrine : PlayerInteraction
    {
        public bool Used { get; protected set; }
        public BerserkerShrine(GameSession ses) : base(ses)
        {
            Enterable = false;
            parentSession = ses;
            Name = "interaction0102";
        }
        protected override void RunContent()
        {
            Used = ShrineEffects.UseEffect(parentSession, 2, Used);
        }

    }
}