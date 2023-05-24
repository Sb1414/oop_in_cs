using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class GenreList
    {
        private class GenreNode
        {
            public Genre genre;
            public GenreNode next;
            public GenreNode prev;

            public GenreNode(Genre genre)
            {
                this.genre = genre;
                this.next = null;
                this.prev = null;
            }
        }

        private GenreNode head; // заголовочный узел

        public GenreList()
        {
            head = null;
        }

        public void AddGenre(Genre genre)
        {
            GenreNode newNode = new GenreNode(genre);

            if (head == null)
            {
                newNode.next = newNode;
                newNode.prev = newNode;
                head = newNode;
            }
            else
            {
                newNode.next = head;
                newNode.prev = head.prev;
                head.prev.next = newNode;
                head.prev = newNode;
            }
        }

        public int GetTrackCount(string genreName)
        {
            if (head == null)
            {
                return 0;
            }

            int trackCount = 0;
            GenreNode current = head;

            do
            {
                if (current.genre.GetName() == genreName)
                {
                    trackCount += current.genre.GetCurrentTrackCount();
                }

                current = current.next;
            } while (current != head);

            return trackCount;
        }


        public void RemoveGenre(Genre genre)
        {
            if (head == null)
            {
                Console.WriteLine("Жанр не найден.");
                return;
            }

            GenreNode current = head;

            do
            {
                if (current.genre == genre)
                {
                    if (head == current)
                    {
                        head = head.next;
                    }

                    current.prev.next = current.next;
                    current.next.prev = current.prev;
                    current.next = null;
                    current.prev = null;
                    return;
                }

                current = current.next;
            } while (current != head);

            Console.WriteLine("Жанр не найден.");
        }

        public Genre[] GetGenres()
        {
            if (head == null)
            {
                return new Genre[0];
            }

            List<Genre> genreList = new List<Genre>();

            GenreNode current = head;

            do
            {
                genreList.Add(current.genre);
                current = current.next;
            } while (current != head);

            return genreList.ToArray();
        }

        public void AddTrack(string genreName, Track track)
        {
            if (head == null)
            {
                Console.WriteLine("Жанр не найден.");
                return;
            }

            GenreNode current = head;

            do
            {
                if (current.genre.GetName() == genreName)
                {
                    current.genre.AddTrack(track);
                    return;
                }

                current = current.next;
            } while (current != head);

            Console.WriteLine("Жанр не найден.");
        }

        public Track[] GetTracksByGenre(string genreName)
        {
            if (head == null)
            {
                return new Track[0];
            }

            int totalCount = 0;
            GenreNode current = head;

            do
            {
                if (current.genre.GetName() == genreName)
                {
                    totalCount += current.genre.GetCurrentTrackCount();
                }
                current = current.next;
            } while (current != head);

            Track[] tracks = new Track[totalCount];
            current = head;
            int index = 0;

            do
            {
                if (current.genre.GetName() == genreName)
                {
                    Track[] genreTracks = current.genre.GetTracks();
                    for (int i = 0; i < genreTracks.Length - 1; i++)
                    {
                        tracks[index] = genreTracks[i];
                        index++;
                        if (index >= tracks.Length)
                            break; // Прерываем цикл, если все треки уже скопированы
                    }

                }
                current = current.next;
            } while (current != head);

            return tracks;
        }

        public Track[] GetAllTracksByGenre(string genreName)
        {
            if (head == null)
            {
                return new Track[0];
            }

            List<Track> tracksList = new List<Track>();
            GenreNode current = head;

            do
            {
                if (current.genre.GetName() == genreName)
                {
                    Track[] genreTracks = current.genre.GetTracks();
                    if (genreTracks != null)
                    {
                        foreach (Track track in genreTracks)
                        {
                            if (track != null)
                            {
                                tracksList.Add(track);
                            }
                        }
                    }
                }

                current = current.next;
            } while (current != head);

            return tracksList.ToArray();
        }




        public bool GenreExists(string genreName)
        {
            if (head == null)
            {
                return false;
            }

            GenreNode current = head;

            do
            {
                if (current.genre.GetName() == genreName)
                {
                    return true;
                }

                current = current.next;
            } while (current != head);

            return false;
        }

        public int GetMaxTrackSizeByGenre(string genreName)
        {
            if (head == null)
            {
                return 0;
            }

            int maxTrackSize = 0;
            GenreNode current = head;

            do
            {
                if (current.genre.GetName() == genreName)
                {
                    int currentMaxSize = current.genre.GetMaxTrackCount();
                    if (currentMaxSize > maxTrackSize)
                    {
                        maxTrackSize = currentMaxSize;
                    }
                }

                current = current.next;
            } while (current != head);

            return maxTrackSize;
        }


        public bool TrackExists(string trackName)
        {
            if (head == null)
            {
                return false;
            }

            GenreNode current = head;

            do
            {
                Track[] genreTracks = current.genre.GetTracks();

                for (int i = 0; i < genreTracks.Length; i++)
                {
                    if (genreTracks[i] != null && (genreTracks[i].GetTrack() == trackName))
                    {
                        return true;
                    }
                }

                current = current.next;
            } while (current != head);

            return false;
        }

    }

}
