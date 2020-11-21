using Game.Engine.Items;
using System;
using System.Collections.Generic;

namespace Game.Engine.Interactions
{
    // a special interaction used for buying and selling items
    // if you want a clear example of how to write your own interesting interaction, this is probably NOT the right place 
    // see Gymir and Hymir files instead
    [Serializable]
    class ShopInteraction : PlayerInteraction
    {
        private Item it1, it2, it3;
        public ShopInteraction(GameSession parentSession) : base(parentSession) 
        {
            while (it1 == null) it1 = Index.RandomClassItem(parentSession.currentPlayer);
            while (it2 == null) it2 = Index.RandomClassItem(parentSession.currentPlayer);
            while (it3 == null) it3 = Index.RandomClassItem(parentSession.currentPlayer);
            Name = "interaction0001";
        }
        protected override void RunContent()
        {
            parentSession.SendText("\nWelcome! You may now sell your items by dragging them outside of the item grid.");
            parentSession.SendText("You may also press I to see the value of your items, B to buy items or ENTER to leave.");
            parentSession.RemovableItems = true;
            parentSession.ItemSellFlag = true;
            while(true)
            {
                string key = parentSession.GetValidKeyResponse(new List<string>() { "Return", "I", "B" }).Item1;
                if (key == "Return") break;
                else if (key == "I") parentSession.ListAllItemsCost();
                else
                {
                    parentSession.SendText("Here is what I have to offer today: ");
                    parentSession.SendText(it1.PublicName + " for " + (it1.GoldValue + 20) + " gold (press 1)"); 
                    parentSession.SendText(it2.PublicName + " for " + (it2.GoldValue + 20) + " gold (press 2)");
                    parentSession.SendText(it3.PublicName + " for " + (it3.GoldValue + 20) + " gold (press 3)");
                    while (true)
                    {
                        string key2 = parentSession.GetValidKeyResponse(new List<string>() { "Return", "1", "2", "3" }).Item1;
                        if (key2 == "Return")
                        {
                            parentSession.RemovableItems = false;
                            parentSession.ItemSellFlag = false;
                            return;
                        }
                        else if (key2 == "1") SellItem(it1);
                        else if (key2 == "2") SellItem(it2);
                        else if (key2 == "3") SellItem(it3);
                    }        
                }
            }
            parentSession.RemovableItems = false;
            parentSession.ItemSellFlag = false;
        }
        protected void SellItem(Item it)
        {
            if (parentSession.currentPlayer.Gold >= it.GoldValue + 20)
            {
                parentSession.AddThisItem(it);
                parentSession.UpdateStat(8, -1 * it.GoldValue - 20);
            }
            else parentSession.SendText("Sorry, you don't have enough gold to buy this!");
        }
    } 
}
