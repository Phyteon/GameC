using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Sound.Players;

namespace Game.Sound
{
    public class SoundEngine
    {
        private BasicSoundPlayer backgroundPlayer;
        private BasicSoundPlayer soundPlayer;
        private SoundContext soundContext;

        public SoundEngine(SoundContext soundContext)
        {
            this.soundContext = soundContext;
            this.backgroundPlayer = new BasicSoundPlayer();
            this.soundPlayer = new BasicSoundPlayer();
        }

        public void PlayBackgroundMusic()
        {
            backgroundPlayer.Open(GetBackgroundMusic());
            backgroundPlayer.PlayLooped();
        }

        public void StopBackgroundMusic()
        {
            backgroundPlayer.Stop();
        }

        public void PauseBackgroundMusic()
        {
            backgroundPlayer.Pause();
        }

        public void ResumeBackgroundMusic()
        {
            backgroundPlayer.Play();
        }

        private Sound GetBackgroundMusic()
        {
            return SoundLibrary.Sounds.Find(t => t.SoundType == SoundType.Background && t.SoundContext == soundContext);
        }

        public void PlaySound(string soundName)
        {
            PlaySound(SoundLibrary.Sounds.Find(t => t.SoundName == soundName));
        }

        public void PlaySound(string soundName, SoundType soundType)
        {
            PlaySound(SoundLibrary.Sounds.Find(t => t.SoundName == soundName && t.SoundType == soundType));
        }

        public void WaitAndPlay(string soundName, SoundType soundType)
        {
            soundPlayer.WaitAndPlay(SoundLibrary.Sounds.Find(t => t.SoundName == soundName && t.SoundType == soundType));
        }


        private void PlaySound(Sound s)
        {
            if (s != null)
            {
                soundPlayer.Open(s);
                soundPlayer.Play();
            }
        }

        public void StopAllPlayers()
        {
            backgroundPlayer.Stop();
            soundPlayer.Stop();
        }
    }

    
    
}
