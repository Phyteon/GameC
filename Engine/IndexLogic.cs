using System;
using System.Collections.Generic;
using Game.Engine.Skills;
using Game.Engine.Items;
using Game.Engine.CharacterClasses;
using Game.Engine.Monsters;
using Game.Engine.Monsters.MonsterFactories;
using Game.Engine.Interactions;
using Game.Engine.Interactions.InteractionFactories;

namespace Game.Engine
{
    // methods used to generate skills, items and monsters by the game engine
    public static partial class Index
    {
        // interactions waiting to be drawn
        private static List<Interaction> waitingToBeDrawn = new List<Interaction>();

        // safe random number generator
        private static Random rnd = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
        public static int RNG(int x1, int x2)
        {
            return rnd.Next(x1, x2);
        }

        // create a list of three random magic skills
        public static List<Skill> MagicSkill(Player player)
        {
            List<Skill> newSkills = new List<Skill>();
            int counter = 0;
            while (newSkills.Count < 3)
            {
                Skill generated = magicSkillFactories[RNG(0, magicSkillFactories.Count)].CreateSkill(player);
                if (generated != null) newSkills.Add(generated);
                counter++;
                if (counter > 10) break; // safety check if there are less than three skills left in the library
            }
            return newSkills;
        }
        // create a list of three random weapon skills
        public static List<Skill> WeaponSkill(Player player)
        {
            List<Skill> newSkills = new List<Skill>();
            int counter = 0;
            while (newSkills.Count < 3)
            {
                Skill generated = weaponSkillFactories[RNG(0, weaponSkillFactories.Count)].CreateSkill(player);
                if (generated != null) newSkills.Add(generated);
                counter++;
                if (counter > 10) break; // safety check if there are less than three skills left in the library
            }
            return newSkills;
        }
        
        // produce a specific item based on its name - important for the display-engine interactions
        public static Item ProduceSpecificItem(string name)
        {
            foreach(Item item in items)
            {
                if (item.Name == name) return item;
            }
            return null;
        }
        
        // produce random class-specific or non-class-specific items - this one will be used to populate the game world
        public static Item RandomItem()
        {
            return itemFactories[RNG(0, itemFactories.Count)].CreateItem();
        }
        public static Item RandomClassItem(Player player)
        {
            if (player.ClassName == "Mage") return itemFactories[RNG(0, itemFactories.Count)].CreateNonWeaponItem();
            else if (player.ClassName == "Warrior") return itemFactories[RNG(0, itemFactories.Count)].CreateNonMagicItem();
            else return itemFactories[RNG(0, itemFactories.Count)].CreateItem();
        }

        // produce random monster factory
        public static MonsterFactory RandomMonsterFactory()
        {
            return monsterFactories[RNG(0, monsterFactories.Count)].Clone();
        }

        // produce an interaction or a group of interactions
        public static List<Interaction> DrawInteractions(GameSession parentSession)
        {
            return interactionFactories[RNG(0, interactionFactories.Count)].CreateInteractionsGroup(parentSession);
        }
        public static Interaction DrawInteraction(GameSession parentSession)
        {
            if (InteractionsList.Count == 0)
            {
                InitializeFactoryList(parentSession);
            }
            return interactionFactories[RNG(0, interactionFactories.Count)].CreateInteractionsGroup(parentSession)[0];
        }

        public static Interaction DrawInteraction(GameSession parentSession, int number)
        {
            if(InteractionsList.Count == 0)
            {
                InitializeFactoryList(parentSession);
            }
            if (InteractionsList.ContainsKey(number)) return InteractionsList[number];

            // check if there are some interactions still waiting to be drawn
            if (waitingToBeDrawn.Count > 0)
            {
                Interaction inter = waitingToBeDrawn[0];
                waitingToBeDrawn.RemoveAt(0);
                return inter;
            }
            // last possible case - draw a random interaction
            do
            {
                var tmp = interactionFactories[RNG(0, interactionFactories.Count)].CreateInteractionsGroup(parentSession);
                if (tmp.Count == 1) return tmp[0];
                else if (tmp.Count > 1)
                {
                    for (int i = 1; i <= tmp.Count; i++)
                    {
                        waitingToBeDrawn.Add(tmp[i]);
                    }
                    return tmp[0];
                }
            }
            while (true);
        }

        private static void InitializeFactoryList(GameSession parentSession)
        {
            foreach (Interaction inter in MainQuestFactory.CreateInteractionsGroup(parentSession))
            {
                int num = Int32.Parse(inter.Name.Replace("interaction", ""));
                InteractionsList.Add(num, inter);
            }
            foreach (InteractionFactory fact in interactionFactories)
            {
                foreach (Interaction inter in fact.CreateInteractionsGroup(parentSession))
                {
                    int num = Int32.Parse(inter.Name.Replace("interaction", ""));
                    InteractionsList.Add(num, inter);
                }
            }
        }
    }
}
