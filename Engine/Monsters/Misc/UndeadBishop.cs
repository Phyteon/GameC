using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class UndeadBishop : Monster
    {

        public UndeadBishop(int monsterLevel)
        {
            Health = 50 + 10 * monsterLevel;
            Strength = 5 + monsterLevel;
            Armor = 15;
            Precision = 1;
            MagicPower = 40 + 10 * monsterLevel;
            Stamina = 50;
            XPValue = 400 + monsterLevel;
            Name = "monster0221";
            BattleGreetings = "My Faith is stronger than death!";
        }
        int strategyNumber;//Used in React()
        int combinedHealthDamage;//Used in React()
        public override void React(List<StatPackage> packs)
        {   
            base.React(packs);
            foreach (StatPackage pack in packs)
            {
                combinedHealthDamage += pack.HealthDmg;
            }
            if (combinedHealthDamage > 0.5 * Health) //If more than half HP is taken at once, it will be stunned and won't move
            {
                strategyNumber = 2;
            }
            else //If not, then things will procede normally
            {
                strategyNumber = 1; 
            }
        }

        public override List<StatPackage> BattleMove()
        {
            if (strategyNumber == 1) 
            {
                return new List<StatPackage>() { new StatPackage(DmgType.none, 0, "Critical Hit! The Undead Bishop gets stunned and can't attack") };
            }  
            else      
			{
				if (Stamina > 20)
				{
					Stamina -= 20;
					// Casting an earthquake  Spell 
					return new List<StatPackage>() { new StatPackage(DmgType.earth, 25 + MagicPower, "The Undead Bishop summons devil's anger and shakes the Earth! (" + (25 + MagicPower) + ") earth damage!)") };
				}
				else if (Stamina > 0)
				{
					Stamina -= 15;
					//Weaker attack, deals less dmg
					return new List<StatPackage>() { new StatPackage(DmgType.fire, 10 + MagicPower, "The Undead Bishop schorches your conscience with Flames of Hell!! (" + (5 + MagicPower) + ") water damage!)") };
				}
				else
				{
					int random = Index.RNG(0, 2);
					if (random == 1)
					{
						Health = 0;
						return new List<StatPackage>() { new StatPackage(DmgType.fire, 10 + 10 * MagicPower, "In his last move The Undead Bishop explodes with devil's energy! (" + (5 + MagicPower) + ") fire damage!)") };
					}
					Stamina += 10;       
					return new List<StatPackage>() { new StatPackage(DmgType.none, 0, "The Undead Bishop rests and regenerates 10 stamina.")};
				}
			}
        }
    }
}
