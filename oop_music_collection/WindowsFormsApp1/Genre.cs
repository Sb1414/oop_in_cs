using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Genre
    {
        private string name; // название жанра
        private int maxTrackCount; // максимальное количество треков
        private int currentTrackCount; // текущее количество треков
        private Track[] tracks; // массив треков

        public Genre(string name, int maxTrackCount)
        {
            this.name = name;
            this.maxTrackCount = maxTrackCount;
            this.currentTrackCount = 0;
            this.tracks = new Track[maxTrackCount];
        }

        public string GetName()
        {
            return name;
        }

        public int GetMaxTrackCount()
        {
            return maxTrackCount;
        }

        public int GetCurrentTrackCount()
        {
            return currentTrackCount;
        }

        public void AddTrack(Track track)
        {
            if (currentTrackCount < maxTrackCount)
            {
                tracks[currentTrackCount] = track;
                currentTrackCount++;
            }
            else
            {
                Console.WriteLine("Достигнуто максимальное количество треков для жанра.");
            }
        }

        public void RemoveTrack(Track track)
        {
            for (int i = 0; i < currentTrackCount; i++)
            {
                if (tracks[i] == track)
                {
                    for (int j = i; j < currentTrackCount - 1; j++)
                    {
                        tracks[j] = tracks[j + 1];
                    }
                    tracks[currentTrackCount - 1] = null;
                    currentTrackCount--;
                    break;
                }
            }
        }

        public Track[] GetTracks()
        {
            return tracks;
        }

    }

}
