using System;

namespace Game.Engine.Items.EnhancedArmor
{
    [Serializable]
    public class LeatherArmor : Item
    {
        //no special effects, the weakest armor
        
        public LeatherArmor() : base("item1240")
        {
            PublicName = "LeatherArmor";
            GoldValue = 20;
            ArMod = 10;
        }
    }
}