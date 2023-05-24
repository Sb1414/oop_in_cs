using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Track
    {
        private string Name { get; set; }//название трека
        private int filesize { get; set; }//размер файла
        public Track(string TrackName, int FileSize)//конструктор
        {
            this.Name = TrackName;
            this.filesize = FileSize;
        }
        public string GetTrack () { return Name; }

        public int GetFileSize () { return filesize; }

        public string ShowInfo()
        {
            string Info = "Название: " + Name + "\nРазмер: " + filesize;
            return Info;
        }
    }
}
