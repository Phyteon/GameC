using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine.Interactions.Misc
{
    [Serializable]
    class BloodFountainInteraction : PlayerInteraction
    {
        private int payment = 0;
        public BloodFountainInteraction(GameSession ses) : base(ses)
        {
            Name = "interaction0681";
        }
        protected override void RunContent()
        {
            parentSession.SendText("\nEngraved script on the fountain says: 'If you want my power you need to make the payment'");
            int choice = parentSession.GetListBoxChoice(new List<string>() { "*Throw a coin*", "*Cut your skin to donate blood*", "*Leave*" });
            switch(choice)
            {
                case 0:
                    payment = -10;
                    MakePayment();
                    break;
                case 1:
                    payment = -15;
                    MakePayment();
                    break;
                default:
                    break;
            }
        }

        private void MakePayment()
        {
            if (payment == -10)
            {
                parentSession.SendText("Nothing happend. That's not what I was supposed to do."); //zapłacenie złotem nic nie zrobiło tylko przepadła moneta
                parentSession.UpdateStat(8, payment);
            }
            if (payment == -15)
            {
                parentSession.SendText("Mysterious fog possessed your body. You feel much stronger.");//upuszczenie krwi pozwoliło wypełnić cię jakąś magiczną mocą wzmacniająca twoją postać
                parentSession.UpdateStat(1, payment);// -15 zdrowia
                parentSession.UpdateStat(2, 50);//+50 do siły
                parentSession.UpdateStat(4, 15);//+ 15 precyzji
                parentSession.UpdateStat(5, 30);//+30 mocy magicznej
                parentSession.UpdateStat(6, 40);//+40 staminy
            }
        }
    }
}
