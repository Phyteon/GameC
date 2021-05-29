using System.Collections.Generic;

namespace Game.Engine.Monsters
{
    public interface IStrategist
    {
        List<StatPackage> BattleStrategy(Monster monster);
    }
}