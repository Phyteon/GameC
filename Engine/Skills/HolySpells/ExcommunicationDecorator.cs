using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.HolySpells
{
    [Serializable]
    class ExcommunicationDecorator:SkillDecorator
    {
        public ExcommunicationDecorator(Skill skill) : base("Excommunication", 40, 3, skill)
        {
            MinimumLevel = 4;
            PublicName = "COMBO -  Your enemy's magic power is decreased by 50% of your strongest statistic (1/3 chance) or your weakest statistic(1/3 chance) " + decoratedSkill.PublicName.Replace("COMBO: ", "");
        }
        public override List<StatPackage> BattleMove(Engine.CharacterClasses.Player player)
        {
            List<int> myList = new List<int>(); // using a list of all player statistics
            myList.Add(player.MagicPower);
            myList.Add(player.Strength);
            myList.Add(player.Precision);
            myList.Add(player.Stamina);
            myList.Add(player.Health);
            myList.Add(player.Armor);
            myList.Sort();//sorting the list
            StatPackage response = new StatPackage(DmgType.Air);
            int randomNumber = Index.RNG(0, 3);
            if (randomNumber == 0)//Strongest stat 
            {
                response.MagicPowerDmg = (int)(myList[myList.Count - 1] * 0.5);
                response.CustomText = "You use Excommunication and decrease your enemies magic power by " + (int)(myList[myList.Count - 1] * 0.5); 
            }
            else if (randomNumber == 1)//weakest 
            {
                int i = 0;
                while (myList[i] == 0)//first stat that is not equal to 0 will be used
                {
                    i++;
                }

                response.MagicPowerDmg = (int)(myList[i]*0.5);
                response.CustomText = "You use Excommunication and decrease your enemies magic power by " + (int)(myList[myList.Count - 1] * 0.5); 
            }
            else    //miss
            {
                response.DamageType = DmgType.Other;
                response.MagicPowerDmg = 0;
                response.CustomText = "You try to use Excommunication, but you miss!";
            }
            
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
