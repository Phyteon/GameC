using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Sound
{
    class SoundLibrary
    {
        public static List<Sound> Sounds { get; private set; }
        public static string TempFolderName = "GameJPiA2021_temp_music";
        public static Uri TempPath { get; private set; }

        public static void InitializeLibrary(bool tempFiles)
        {
            if(Sounds == null)
            {
                Sounds = SoundLibraryGenerator.CreateLibrary();
                if (tempFiles)
                {
                    InitilizeTempraryFiles();
                }
            }
        }

        public static void InitilizeTempraryFiles() 
        {
            BuildTempPath();

            try
            {
                Directory.CreateDirectory(TempPath.AbsolutePath);
            }
            catch (Exception ex)
            {
                return;
            }

            foreach (Sound s in Sounds)
            {
                s.FilePath = new Uri(Path.Combine(TempPath.AbsolutePath, s.FileName), UriKind.Absolute);
                if (!File.Exists(s.FilePath.AbsolutePath))
                {
                    using (FileStream bytetoimage = File.Create(s.FilePath.AbsolutePath))
                    {
                        bytetoimage.Write(s.Resource, 0, s.Resource.Length);
                    }
                }
            }

            Resource1.ResourceManager.ReleaseAllResources();
        }

        public static void DiscardTemporaryFiles() 
        {
            if(TempPath == null) { BuildTempPath(); }
            DirectoryInfo directory = new DirectoryInfo(TempPath.AbsolutePath);

            foreach (FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }
        }

        private static void BuildTempPath()
        {
            TempPath = new Uri(Path.Combine(Path.GetTempPath(), TempFolderName));
        }
        
    }

    class Sound
    {
        public Uri FilePath { get; set; }
        public string SoundName { get; set; }
        public string FileName { get; set; }
        public SoundContext SoundContext { get; set; }
        public SoundType SoundType { get; set; }
        public byte[] Resource { get; set; }

        public Sound(Uri filePath, string soundName, string fileName, SoundContext soundContext, SoundType soundType, byte[] resource)
        {
            FilePath = filePath;
            SoundName = soundName;
            FileName = fileName;
            SoundContext = soundContext;
            SoundType = soundType;
            Resource = resource;
        }
    }

    public enum SoundContext
    {
        MenuPage,
        GamePage,
        Battle
    }

    public enum SoundType
    {
        Background,
        MouseSound,
        Player,
        MonsterInit,
        MonsterBite,
        MonsterDeath,
        MonsterWin, 
        BattleRequiredItem
    }
}
