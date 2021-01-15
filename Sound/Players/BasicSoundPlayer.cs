using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Media;
using System.IO;

namespace Game.Sound.Players
{
    class BasicSoundPlayer
    {
        protected MediaPlayer mediaPlayer;
        protected bool playLooped;
        protected bool waiting;
        protected Sound tempSoud;

        public double Volume
        {
            get { return mediaPlayer.Volume; }
            set { mediaPlayer.Volume = value; }
        }
        public BasicSoundPlayer()
        {
            mediaPlayer = new MediaPlayer();
            playLooped = false;
            waiting = false;
            tempSoud = null;

            // allow to loop audio
            mediaPlayer.MediaEnded += new EventHandler(Player_Ended);
        }

        public void Open(Sound sound)
        {
            if(sound != null && File.Exists(sound.FilePath.AbsolutePath))
            {
                mediaPlayer.Open(sound.FilePath);
            }
        }

        public void Play()
        {
            if(mediaPlayer.Source != null)
            {
                mediaPlayer.IsMuted = false;
                mediaPlayer.Play();
            }
        }

        public void Pause()
        {
            mediaPlayer.Pause();
        }

        public void Stop()
        {
            double tempVolume = mediaPlayer.Volume;
            int msTime = 10;
            double sleepFactor = (double)msTime / 1000;

            while (mediaPlayer.Volume > 0)
            {
                mediaPlayer.Volume -= sleepFactor;
                // wait to decrease volume sound slowly
                System.Threading.Thread.Sleep(msTime);
            }

            mediaPlayer.IsMuted = true;
            mediaPlayer.Stop();
            mediaPlayer.Volume = tempVolume;
        }

        public void PlayLooped()
        {
            playLooped = true;
            Play();
        }

        public void WaitAndPlay(Sound sound)
        {
            if(mediaPlayer.Source != null && mediaPlayer.NaturalDuration.HasTimeSpan && mediaPlayer.NaturalDuration.TimeSpan > mediaPlayer.Position)
            {
                waiting = true;
                tempSoud = sound;
            }
            else
            {
                Open(sound);
                Play();
            }
        }

        private void Player_Ended(object sender, EventArgs e)
        {
            if (playLooped)
            {
                //Set the music back to the beginning
                mediaPlayer.Position = TimeSpan.Zero;
                //Play the music
                mediaPlayer.Play();
            }
            if (waiting && tempSoud != null)
            {
                Open(tempSoud);
                Play();
                waiting = false;
                tempSoud = null;
            }
        }

    }
}
