using System;

namespace Game.Engine.Items.EnhancedArmor
{
    [Serializable]
    public class DiamondArmor : Item
    {
        // no special effects, but stronger than BasicArmor and SteelArmor
        
        public DiamondArmor() : base("item1241")
        {
            PublicName = "DiamondArmor";
            GoldValue = 120;
            ArMod = 80;
        }
    }
}