using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Sound
{
    public static class SoundNames
    {
        public const string BACKGROUND_MUSIC = "BackgroundMusic";
        public const string BACKGROUND_MUSIC_MENU = "BackgroundMusicMenu";
        public const string BACKGROUND_MUSIC_GAME = "BackgroundMusicGame";
        public const string BACKGROUND_MUSIC_BATTLE = "BackgroundMusicBattle";

        public const string MOUSE_HOVER_MENU = "MouseHoverMenu";
        public const string MOUSE_CLICK_MENU = "MouseClickMenu";

        public const string MOUSE_HOVER_GAME = "MouseHoverGame";
        public const string MOUSE_CLICK_GAME_1 = "MouseClickGame_1";
        public const string MOUSE_CLICK_GAME_2 = "MouseClickGame_2";

        public const string PLAYER_DEATH = "PlayerDeath";
        public const string PLAYER_WIN = "PlayerWin";

    }
    internal static class SoundLibraryGenerator
    {
        internal static List<Sound> CreateLibrary()
        {
            List<Sound> soundLibrary = new List<Sound>();
            string monster = string.Empty;
            List<string> monsters = new List<string>();
            string item = string.Empty;

            // MOUSE
            soundLibrary.Add(new Sound(null, SoundNames.MOUSE_CLICK_MENU, string.Concat(SoundNames.MOUSE_CLICK_MENU, ".mp3"), SoundContext.MenuPage, SoundType.MouseSound, Resource1.mouse_click));
            soundLibrary.Add(new Sound(null, SoundNames.MOUSE_HOVER_MENU, string.Concat(SoundNames.MOUSE_HOVER_MENU, ".mp3"), SoundContext.MenuPage, SoundType.MouseSound, Resource1.mouse_hover));

            soundLibrary.Add(new Sound(null, SoundNames.MOUSE_CLICK_GAME_1, string.Concat(SoundNames.MOUSE_CLICK_GAME_1, ".mp3"), SoundContext.MenuPage, SoundType.MouseSound, Resource1.mouse_drop));
            soundLibrary.Add(new Sound(null, SoundNames.MOUSE_CLICK_GAME_2, string.Concat(SoundNames.MOUSE_CLICK_GAME_2, ".mp3"), SoundContext.GamePage, SoundType.MouseSound, Resource1.mouse_click));

            // MONSTERS

            // Cats / Black Cat
            monsters.Add("monster1163");
            // Cats / Cat Wizard
            monsters.Add("monster1164");
            foreach(var m in monsters)
            {
                soundLibrary.Add(new Sound(null, m, "cat_init.mp3", SoundContext.Battle, SoundType.MonsterInit, Resource1.cat_init));
                soundLibrary.Add(new Sound(null, m, "cat_bite.mp3", SoundContext.Battle, SoundType.MonsterBite, Resource1.cat_bite));
                soundLibrary.Add(new Sound(null, m, "cat_win.mp3", SoundContext.Battle, SoundType.MonsterWin, Resource1.cat_win));
                soundLibrary.Add(new Sound(null, m, "cat_death.mp3", SoundContext.Battle, SoundType.MonsterDeath, Resource1.cat_death));
            }
            monsters.Clear();

            // Dragons / AncientDragon
            monsters.Add("monster1380");
            // Dragons / IceDragon
            monsters.Add("monster1125");
            // Dragons / RainbowDragon
            monsters.Add("monster1426");
            // Dragons / ShadowDragon
            monsters.Add("monster1420");
            // Dragons / SkeletalDragon
            monsters.Add("monster1421"); 
            foreach (var m in monsters)
            {
                soundLibrary.Add(new Sound(null, m, "dragon_init.mp3", SoundContext.Battle, SoundType.MonsterInit, Resource1.dragon_init));
                soundLibrary.Add(new Sound(null, m, "dragon_bite.mp3", SoundContext.Battle, SoundType.MonsterBite, Resource1.dragon_bite));
                soundLibrary.Add(new Sound(null, m, "dragon_death.mp3", SoundContext.Battle, SoundType.MonsterDeath, Resource1.dragon_death));
            }
            monsters.Clear();

            // Misc / Tyrannosaurus
            monster = "monster1120";
            soundLibrary.Add(new Sound(null, monster, "misc_tyrannosaurus_init.mp3", SoundContext.Battle, SoundType.MonsterInit, Resource1.misc_tyrannosaurus_init));
            soundLibrary.Add(new Sound(null, monster, "misc_tyrannosaurus_bite.mp3", SoundContext.Battle, SoundType.MonsterBite, Resource1.misc_tyrannosaurus_bite));
            soundLibrary.Add(new Sound(null, monster, "misc_tyrannosaurus_death.mp3", SoundContext.Battle, SoundType.MonsterDeath, Resource1.misc_tyrannosaurus_death));

            // Wolves / YoungWolf
            monsters.Add("monster1152");
            // Wolves / OLdWolf
            monsters.Add("monster1153");
            foreach (var m in monsters)
            {
                soundLibrary.Add(new Sound(null, m, "wolf_init.mp3", SoundContext.Battle, SoundType.MonsterInit, Resource1.wolf_init));
                soundLibrary.Add(new Sound(null, m, "wolf_bite.mp3", SoundContext.Battle, SoundType.MonsterBite, Resource1.wolf_bite));
                soundLibrary.Add(new Sound(null, m, "wolf_death.mp3", SoundContext.Battle, SoundType.MonsterDeath, Resource1.wolf_death));
            }
            monsters.Clear();

            // ITEMS

            item = Engine.RequiredItem.Axe.ToString();
            soundLibrary.Add(new Sound(null, item, string.Concat(item, "_item.mp3"), SoundContext.Battle, SoundType.BattleRequiredItem, Resource1.item_axe));

            item = Engine.RequiredItem.Spear.ToString();
            soundLibrary.Add(new Sound(null, item, string.Concat(item, "_item.mp3"), SoundContext.Battle, SoundType.BattleRequiredItem, Resource1.item_spear));

            item = Engine.RequiredItem.Staff.ToString();
            soundLibrary.Add(new Sound(null, item, string.Concat(item, "_item.mp3"), SoundContext.Battle, SoundType.BattleRequiredItem, Resource1.item_staff));

            item = Engine.RequiredItem.Sword.ToString();
            soundLibrary.Add(new Sound(null, item, string.Concat(item, "_item.mp3"), SoundContext.Battle, SoundType.BattleRequiredItem, Resource1.item_sword));

            // PLAYER

            soundLibrary.Add(new Sound(null, SoundNames.PLAYER_DEATH, "PlayerDeath.mp3", SoundContext.Battle, SoundType.Player, Resource1.player_death));
            soundLibrary.Add(new Sound(null, SoundNames.PLAYER_WIN, "PlayerWin.mp3", SoundContext.Battle, SoundType.Player, Resource1.player_win));


            return soundLibrary;
        }
    }
}
