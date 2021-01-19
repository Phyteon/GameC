using System;
using System.Collections.Generic;
using Game.Engine.Skills.SkillFactories;
using Game.Engine.Monsters.MonsterFactories;
using Game.Engine.Items;
using Game.Engine.Items.ItemFactories;
using Game.Engine.Items.BasicArmor;
using Game.Engine.Items.EnhancedArmor;
using Game.Engine.Items.Axes;
using Game.Engine.Items.Swords;
using Game.Engine.Items.Spears;
using Game.Engine.Interactions.InteractionFactories;
using Game.Engine.Items.AnnItems;
using Game.Engine.Items.MyItems;
using Game.Engine.Items.BasicAmulet;
using Game.Engine.Items.Shields;
using Game.Engine.Items.Ring;
using Game.Engine.Items.Chains;
using Game.Engine.Items.Heads;
using Game.Engine.Items.AnimalItems;
using Game.Engine.Items.Amulet;



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
            new AdaptiveArmor(),
            new LeatherArmor(),
            new DiamondArmor(),
            new AntiPoisonArmor(),
            new HpAmulet(),
            new StrAmulet(),
            new MgcAmulet(),
            new ArmorChain(),
            new StaminaChain(),
            new MagicChain(),
            new PrecisionChain(),
            new GymirAxe(),
            new BlueAxe(),
            new OrangeAxe(),
            new DiamondAxe(),
            new IronAxe(),
            new BlazingAxe(),
            new FierySword(),
            new DiaxSword(),
            new SilverSword(),
            new EmeraldSpear(),
            new SharpSpear(),
            new BasicShield(),
            new WoodenShield(),
            new VikingShield(),
            new SteelShield(),
            new AntiMagicDmgRing(),
            new AntiPhysicalDmgRing(),
            new MagicRing(),
            new HealthRing(),
            new EnhancementRing(),
            new AnnPoison(),
            new AnnShuriken(),
            new AnnMagicBook(),
            new BigBertha(),
            new BloodyArmor(),
            new MjolnirAxe(),
            new LongBow(),
            new CrystalBall(),
            new GoldenApple(),
            new Lightsaber(),
            // secondary quest items start below
            new OldTravelerArmor(),
            new OldTravelerAxe(),
            new OldTravelerHat(),
            new OldTravelerPotion(),
            new OldTravelerSpear(),
            new OldTravelerStaff(),
            new OldTravelerSword(),
            // main quest items start below
            new OrbOfGods(),
            new TreantProtectionAmulet(),
            new Amulet(),
            new Bear(),
            new BearCompanion(),
            new BearHat(),
            new DarkElfFakeHead(),
            new DarkElfHead(),
            new Fox(),
            new FoxCompanion(),
            new FoxHat(),
            new WitchFakeHead(),
            new WitchHead(),
            new Wolf(),
            new WolfCompanion(),
            new WolfHat(),
        };

        private static List<ItemFactory> itemFactories = new List<ItemFactory>()
        {
            new BasicArmorFactory(),
            new EnhancedArmorFactory(),
            new BasicAmuletFactory(),
            new ChainFactory(),
            new AxeFactory(),
            new SwordFactory(),
            new SpearFactory(),
            new ShieldFactory(),
            new RingFactory(),
            new AnnItemsFactory(),
            new UniqueItemsFactory(),
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
