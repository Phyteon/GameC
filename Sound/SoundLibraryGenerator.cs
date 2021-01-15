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

    }
    internal static class SoundLibraryGenerator
    {
        internal static List<Sound> CreateLibrary()
        {
            List<Sound> soundLibrary = new List<Sound>();
            string monster = string.Empty;
            string item = string.Empty;

            item = Engine.RequiredItem.Axe.ToString();
            soundLibrary.Add(new Sound(null, item, string.Concat(item, "_item.mp3"), SoundContext.Battle, SoundType.BattleRequiredItem, Resource1.item_axe));

            item = Engine.RequiredItem.Spear.ToString();
            soundLibrary.Add(new Sound(null, item, string.Concat(item, "_item.mp3"), SoundContext.Battle, SoundType.BattleRequiredItem, Resource1.item_spear));

            item = Engine.RequiredItem.Staff.ToString();
            soundLibrary.Add(new Sound(null, item, string.Concat(item, "_item.mp3"), SoundContext.Battle, SoundType.BattleRequiredItem, Resource1.item_staff));

            item = Engine.RequiredItem.Sword.ToString();
            soundLibrary.Add(new Sound(null, item, string.Concat(item, "_item.mp3"), SoundContext.Battle, SoundType.BattleRequiredItem, Resource1.item_sword));

            soundLibrary.Add(new Sound(null, SoundNames.PLAYER_DEATH, "PlayerDeath.mp3", SoundContext.Battle, SoundType.Player, Resource1.player_death));


            return soundLibrary;
        }
    }
}
