using Game.Engine.CharacterClasses;
using Game.Engine.Skills.AdvancedWeaponMoves;
using Game.Engine.Skills.AdvancedWeaponTechniques;
using Game.Engine.Skills.UpgradedWeaponMoves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.MageQuest
{
    [Serializable]
    class FriendlyWarrior:PlayerInteraction
    {
        public int MageAmulet { get; set; }


        public FriendlyWarrior(GameSession ses) : base(ses)
        {
            Name = "interaction1126";
            Enterable = false;
            MageAmulet = 0;
        }

        protected override void RunContent()
        {
            parentSession.SendText("\nHello Adventurer! I'm local warrior, do you wanna learn new normal skills?");
            int choice2 = parentSession.GetListBoxChoice(new List<string>() { "Really? Could you teach me new skills?", "Could you teach me mage skills?", "Okey, thanks for conversation" });
            switch (choice2)
            {
                case 0:
                    {
                        SellSkills();
                        break;
                    }
                case 1:
                    {
                        parentSession.SendText("Sorry, i can only teach you normal skills. If you wanna teach mage skills you should go to my friend Herald - he's a local mage");
                        break;
                    }
                case 3:
                    {
                        parentSession.SendText("\nSee you soon");
                        break;
                    }

            }
        }


        private void SellSkills()
        {
            if(MageAmulet>=1)
            {

                parentSession.SendText("\nYes, i can teach you the following skills for a fee");
                if (MageAmulet == 1)
                {
                    parentSession.SendText("\nI see you have amulet for me, thanks a lot for it. In exchange for providing it, I have for you promotion!");
                    MageAmulet +=1;
                }

                int choice3 = parentSession.GetListBoxChoice(new List<string>() { "Enchanted Slash - 40 gold - promotion!", "Whirl - 60 gold", "Axe Throw - 45 gold", "Aura of a Sword - 35 gold", "I'm not interesting" });
                switch (choice3)
                {
                    case 0:
                        parentSession.UpdateStat(8, -40);
                        parentSession.LearnThisSkill(new EnchantedSlash());
                        break;
                    case 1:
                        parentSession.UpdateStat(8, -60);
                        parentSession.LearnThisSkill(new Whirl());
                        break;
                    case 2:
                        parentSession.UpdateStat(8, -45);
                        parentSession.LearnThisSkill(new AxeThrow());
                        break;
                    case 3:
                        parentSession.UpdateStat(8, -35);
                        parentSession.LearnThisSkill(new AuraOfASword());
                        break;
                    case 4:
                        parentSession.SendText("Okey, See you soon");
                        break;
                }
            }
            else
            {
                parentSession.SendText("\nYes, i can teach you the following skills for a fee");
                int choice3 = parentSession.GetListBoxChoice(new List<string>() { "Enchanted Slash - 60 gold", "Whirl - 60 gold", "Axe Throw - 45 gold", "Aura of a Sword - 35 gold", "I'm not interesting" });
                switch (choice3)
                {
                    case 0:
                        parentSession.UpdateStat(8, -60);
                        parentSession.LearnThisSkill(new EnchantedSlash());
                        break;
                    case 1:
                        parentSession.UpdateStat(8, -60);
                        parentSession.LearnThisSkill(new Whirl());
                        break;
                    case 2:
                        parentSession.UpdateStat(8, -45);
                        parentSession.LearnThisSkill(new AxeThrow());
                        break;
                    case 3:
                        parentSession.UpdateStat(8, -35);
                        parentSession.LearnThisSkill(new AuraOfASword());
                        break;
                    case 4:
                        parentSession.SendText("Okey, See you soon");
                        break;
                }
            }

        }
    }
}
