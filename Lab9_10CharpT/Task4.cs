using System;
using System.Collections;

namespace Lab9
{
    public class Task4
    {
        public static void Execute()
        {
            MusicCatalog catalog = new MusicCatalog();

            MusicDisk disk1 = new MusicDisk("Rock Hits 2000s");
            disk1.AddSong(new Song("In the End", "Linkin Park"));
            disk1.AddSong(new Song("Numb", "Linkin Park"));
            disk1.AddSong(new Song("Boulevard of Broken Dreams", "Linkin Park"));

            MusicDisk disk2 = new MusicDisk("Pop Classics");
            disk2.AddSong(new Song("Toxic", "Britney Spears"));
            disk2.AddSong(new Song("Baby One More Time", "Britney Spears"));

            catalog.AddDisk(disk1);
            catalog.AddDisk(disk2);

            catalog.PrintCatalog();

            Console.WriteLine("\n--- Search by Artist: Linkin Park ---");
            catalog.SearchByArtist("Linkin Park");

            Console.WriteLine("\n--- Removing Disk: Pop Classics ---");
            catalog.RemoveDisk("Pop Classics");
            catalog.PrintCatalog();
        }
    }

    public class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }

        public Song(string title, string artist)
        {
            Title = title;
            Artist = artist;
        }

        public override string ToString() => $"'{Title}' by {Artist}";
    }

    public class MusicDisk
    {
        public string Title { get; set; }
        public ArrayList Songs { get; set; }

        public MusicDisk(string title)
        {
            Title = title;
            Songs = new ArrayList();
        }

        public void AddSong(Song song) => Songs.Add(song);
        
        public void RemoveSong(Song song) => Songs.Remove(song);

        public void PrintDisk()
        {
            Console.WriteLine($"Disk: {Title}");
            foreach (Song song in Songs)
            {
                Console.WriteLine($"  - {song}");
            }
        }
    }

    public class MusicCatalog
    {
        private Hashtable disks;

        public MusicCatalog()
        {
            disks = new Hashtable(StringComparer.OrdinalIgnoreCase);
        }

        public void AddDisk(MusicDisk disk)
        {
            if (!disks.ContainsKey(disk.Title))
            {
                disks.Add(disk.Title, disk);
            }
        }

        public void RemoveDisk(string diskTitle)
        {
            if (disks.ContainsKey(diskTitle))
            {
                disks.Remove(diskTitle);
            }
        }

        public void PrintCatalog()
        {
            Console.WriteLine("\n=== Music Catalog ===");
            foreach (DictionaryEntry entry in disks)
            {
                MusicDisk disk = (MusicDisk)entry.Value!;
                disk.PrintDisk();
            }
            Console.WriteLine("=====================\n");
        }

        public void SearchByArtist(string artistName)
        {
            bool found = false;
            foreach (DictionaryEntry entry in disks)
            {
                MusicDisk disk = (MusicDisk)entry.Value!;
                foreach (Song song in disk.Songs)
                {
                    if (song.Artist.Equals(artistName, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Found {song} on disk '{disk.Title}'");
                        found = true;
                    }
                }
            }
            if (!found) Console.WriteLine($"No songs found for artist: {artistName}");
        }
    }
}