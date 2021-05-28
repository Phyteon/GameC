using System.Collections.Generic;

namespace Game.Engine.Monsters
{
    public interface IStrategist
    {
        List<StatPackage> Aggressive(); // This strategy will focus on attack
        List<StatPackage> Defensive(); // This strategy will focus on defense/running away
        List<StatPackage> Mixed(); // Mix of the two strategies
        void ChooseStrategy(List<StatPackage> pkg); // Function for deciding what strategy is best suited
    }
}