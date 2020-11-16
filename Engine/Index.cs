using System;
using System.Collections.Generic;
using Game.Engine.Skills.SkillFactories;
using Game.Engine.Monsters.MonsterFactories;
using Game.Engine.Items;
using Game.Engine.Items.ItemFactories;
using Game.Engine.Items.BasicArmor;
using Game.Engine.Interactions.InteractionFactories;
using Game.Engine.Items.BasicRing;
using Game.Engine.Items.Amulet;
using Game.Engine.Items.OsirisArmor;
using Game.Engine.Items.AmuletsAndPotions;
using Game.Engine.Items.Shield;
using Game.Engine.Items.Attributes;
using Game.Engine.Interactions.TroubadourQuest;

namespace Game.Engine
{
    // contains information about skills, items and monsters that will be available in the game
    public partial class Index
    {
        private static List<SkillFactory> magicSkillFactories = new List<SkillFactory>()
        {
            new BasicSpellFactory(),
            new AdvancedSpellsFactory1(),
            new AdvancedSpellsFactory2(),
            new AdvancedSpellsFactory3(),
            new HolySpellsFactory(),
            new BuffSpellsFactory(),
            new WaterSpellFactory(),
            new OsirisMovesFactory(),
            new ArmorDerivedSpellFactory(),
            new SimpleSkillsFactory(),
        };

        private static List<SkillFactory> weaponSkillFactories = new List<SkillFactory>()
        {
            new BasicWeaponMoveFactory(),
            new AdvancedWeaponMoveFactory(),
            new AxeCutFactory(),
            new SwordMoveFactory(),
            new SpearMoveFactory(),
            new ArmorDerivedSpellFactory(),
            new SimpleSkillsFactory(),
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
            new CrystalSword(),
            new InfinitySword(),
            new MoonlightSword(),
            new DemonSword(),
            new GreatSword(),
            new ButchersSword(),
            new Katana(),
            new ArmorRing(),
            new HealthRing(),
            new InfinityRings(),
            new MageRing(),
            new LuckyCharmAmulet(),
            new MageDuelistAmulet(),
            new SupportingAmulet(),
            new AntiPoisonAmulet(),
            new AmuletOfHealing(),
            new AmuletOfNegotiation(),
            new FireproofAmulet(),
            new OsirisEye(),
            new OsirisSabre(),
            new OsirisStaff(),
            new IronAxe(),
            new SilverAxe(),
            new DiamondAxe(),
            new FlameStaff(),
            new SafetyRod(),
            new WindStaff(),
            new AirStone(),
            new WaterStone(),
            new EarthStone(),
            new FireStone(),
            new GoldStone(),
            new AntiMagicHealthStone(),
            new GoldenShield(),
            new MirrorShield(),
            new TurtleShield(),
            new Narya(),
            new Vilya(),
            new Nenya(),
            new MagiciansCan(),
            new MagnificentCape(),
            new SingleUseArmor(),
            new StylisedFlatIron(),
            // quest items start here
            new Flute(),
            new Kithara(),
            new Lyre(),
            new Lute(),
        };

        private static List<ItemFactory> itemFactories = new List<ItemFactory>()
        {
            new BasicArmorFactory(),
            new AxeFactory(),
            new SwordFactory(),
            new StaffFactory(),
            new BasicRingFactory(),
            new AmuletFactory(),
            new StonesFactory(),
            new OsirisFactory(),  
            new ShieldFactory(),
            new ElvenRingFactory(),
            new MildlyFunnyItemFactory(),
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
            /*
            new Monsters.MonsterFactories.ButterflyFactory(),
            new Monsters.MonsterFactories.ButterflyFactory(),
            new Monsters.MonsterFactories.HogFactory(),
            new Monsters.MonsterFactories.HogFactory(),
            new Monsters.MonsterFactories.ElementalBatFactory(),
            new Monsters.MonsterFactories.ElementalBatFactory(),
            new Monsters.MonsterFactories.ThugFactory(),
            new Monsters.MonsterFactories.ThugFactory(),
            // x1
            new Monsters.MonsterFactories.EgyptMonstersFactory(),
            new Monsters.MonsterFactories.GolemFactory(),
            new Monsters.MonsterFactories.MimicFactory(),
            new Monsters.MonsterFactories.PhoenixFactory(),
            new Monsters.MonsterFactories.UnicornFactory(),
            new Monsters.MonsterFactories.GermFactory(),
            new Monsters.MonsterFactories.DragonFactory(),
            new Monsters.MonsterFactories.IceDragonFactory(),
            new Monsters.MonsterFactories.HydraFactory(),
            new Monsters.MonsterFactories.UnseenHorrorFactory(),
            new Monsters.MonsterFactories.UndeadBishopFactory(),
            new Monsters.MonsterFactories.ElementalistFactory(),
            new Monsters.MonsterFactories.JesterFactory(),
            new Monsters.MonsterFactories.NumiFactory(),
            new Monsters.MonsterFactories.FleyonFactory(),
            */
        };

        private static List<InteractionFactory> interactionFactories = new List<InteractionFactory>()
        {
            new SkillForgetFactory(),
            new GymirHymirFactory(),
            new BloodFountainFactory(),
            new AltairOfOldGodFactory(),
            new BymirDymirFymirFactory(),
            new CymirCaveFactory(),
            new EgyptianInteractionFactory(),
            new MusesFactory(),
            new MageQuestFactory(),
            new OldManMysticQuestFactory(),
            new EchionNoicheFactory(),
            new GuitarQuestFactory(),
            new PrincessQuestFactory(),
            new LootingLuteFactory(),
            new TroubadourFactory(),
        };

    }
}
