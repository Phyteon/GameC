using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Sound
{
    /// <summary>
    /// Contains constant strings of prepared music and sound names. 
    /// </summary>
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
    /// <summary>
    /// Generates list (library) of game sounds. 
    /// </summary>
    internal static class SoundLibraryGenerator
    {
        /// <summary>
        /// Contains list of all sounds linked to monsters, items, payer, background music etc.
        /// </summary>
        /// <returns>List of sounds used by game app.</returns>
        internal static List<Sound> CreateLibrary()
        {
            List<Sound> soundLibrary = new List<Sound>();
            string monster = string.Empty;
            string item = string.Empty;

            // Add here list of sounds by pattern
            // soundLibrary.Add(new Sound(null, NAME, "FILE_NAME.mp3", SoundContext.Battle, SoundType.MonsterInit, Resource1.RESOURCE_NAME));

            return soundLibrary;
        }
    }
}
