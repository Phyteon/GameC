using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class AncientDragon : Monster
    {

        protected AncientDragonState state = null;

        public AncientDragon()
        {
            Health = 500;
            Strength = 150;
            Armor = 200;
            Precision = 100;
            MagicPower = 150;
            Stamina = 300;
            XPValue = 1000;
            Name = "monster1380";
            BattleGreetings = "Rooaaar!";
            this.SetState(new AngryDragon());
        }

        public void SetState(AncientDragonState _state)
        {
            this.state = _state;
            this.state.SetContext(this);
        }

        public override List<StatPackage> BattleMove()
        {
            return this.state.BattleMoveHandle();
        }

        public override void React(List<StatPackage> packs)
        {
            this.state.ReactHandle(packs);
        }
    }
}

