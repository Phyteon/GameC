using System;
using System.Collections.Generic;
using Game.Engine.Skills.SkillFactories;
using Game.Engine.Monsters.MonsterFactories;
using Game.Engine.Items;
using Game.Engine.Items.ItemFactories;
using Game.Engine.Items.BasicArmor;
using Game.Engine.Interactions.InteractionFactories;


namespace Game.Engine
{
    // contains information about skills, items and monsters that will be available in the game
    public static partial class Index
    {
        private static List<SkillFactory> magicSkillFactories = new List<SkillFactory>()
        {
            new BasicSpellFactory(),
        };

        private static List<SkillFactory> weaponSkillFactories = new List<SkillFactory>()
        {
            new BasicWeaponMoveFactory(),
        };

        private static List<Item> items = new List<Item>()
        {
            new BasicStaff(),
            new BasicSpear(),
            new BasicAxe(),
            new BasicSword(),
            new SteelArmor(),
            new AntiMagicArmor(),
            new BerserkerArmor(),
            new GrowingStoneArmor(),
            // quest items (if applicable) start below
            new GymirAxe(),
        };

        private static List<ItemFactory> itemFactories = new List<ItemFactory>()
        {
            new BasicArmorFactory(),
        };

        private static List<MonsterFactory> monsterFactories = new List<MonsterFactory>()
        {
            // x4
            new Monsters.MonsterFactories.RatFactory(),
            new Monsters.MonsterFactories.RatFactory(),
            new Monsters.MonsterFactories.RatFactory(),
            new Monsters.MonsterFactories.RatFactory(),
            new Monsters.MonsterFactories.BatFactory(),
            new Monsters.MonsterFactories.BatFactory(),
            new Monsters.MonsterFactories.BatFactory(),
            new Monsters.MonsterFactories.BatFactory(),
            new Monsters.MonsterFactories.SpiderFactory(),
            new Monsters.MonsterFactories.SpiderFactory(),
            new Monsters.MonsterFactories.SpiderFactory(),
            new Monsters.MonsterFactories.SpiderFactory(),
            // x2
            new Monsters.MonsterFactories.MandragoraFactory(),
            new Monsters.MonsterFactories.MandragoraFactory(),
            new Monsters.MonsterFactories.BlackCatFactory(),
            new Monsters.MonsterFactories.BlackCatFactory(),
            new Monsters.MonsterFactories.WaspFactory(),
            new Monsters.MonsterFactories.WaspFactory(),
            new Monsters.MonsterFactories.EagleFactory(),
            new Monsters.MonsterFactories.EagleFactory(),
            new Monsters.MonsterFactories.SnakeFactory(),
            new Monsters.MonsterFactories.SnakeFactory(),
            new Monsters.MonsterFactories.WolfFactory(),
            new Monsters.MonsterFactories.WolfFactory(),
            new Monsters.MonsterFactories.BoarFactory(),
            new Monsters.MonsterFactories.BoarFactory(),
            // x1
            new Monsters.MonsterFactories.CerberusFactory(),
            new Monsters.MonsterFactories.TrollFactory(),
            new Monsters.MonsterFactories.FieryAliceFactory(),
            new Monsters.MonsterFactories.ChinchillaFactory(),
            new Monsters.MonsterFactories.CursedMirrorFactory(),
            new Monsters.MonsterFactories.SlimeFactory(),
            new Monsters.MonsterFactories.BoulderFactory(),
            new Monsters.MonsterFactories.WitchFactory(),
            new Monsters.MonsterFactories.HumanCatcherFactory(),
            new Monsters.MonsterFactories.LeshyFactory(),
            new Monsters.MonsterFactories.MedusaFactory(),
            new Monsters.MonsterFactories.AncientDragonFactory(),
            new Monsters.MonsterFactories.DragonFactory(),
            new Monsters.MonsterFactories.TyrannosaurusFactory(),
        };

        public readonly static InteractionFactory MainQuestFactory = new GymirHymirFactory();

        private static List<InteractionFactory> interactionFactories = new List<InteractionFactory>()
        {
            new SkillForgetFactory(),
            new HealInteractionFactory(),
        };

    }
}
