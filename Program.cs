var track = new SayaMusicTrack("lagu lama");
var track2 = new SayaMusicTrack("lagu baru");
var user = new SayaMusicUser("deva");
var user2 = new SayaMusicUser("deva baru");
track.IncreasePlayCount(23682);
track.PrintTrackDetails();
track2.IncreasePlayCount(12903);
track2.PrintTrackDetails();
user.AddTrack(track);
user.PrintAllTracks();
user2.AddTrack(track2);
user2.PrintAllTracks();

public class SayaMusicUser
{
    private int id;
    public string Username;
    private List<SayaMusicTrack> uploadedTracks = new();
    public SayaMusicUser(string Username)
    {
        this.id = Random.Shared.Next(10000, 100000);
        this.Username = Username;
    }
    public int GetTotalPlayCount()
    {
        int playcount = 0;
        for (int i = 0; i < uploadedTracks.Count; i++) 
        {
            playcount += uploadedTracks[i].playCount;
        }
        return playcount;
    }
    public void AddTrack(SayaMusicTrack track)
    {
        uploadedTracks.Add(track);
    }
    public void PrintAllTracks() 
    {
        for (int i = 0; i < uploadedTracks.Count; i++) 
        {
            Console.WriteLine($"Username : {Username} | Track {i + 1} Judul : {uploadedTracks[i].title}");
        }
    }
}

public class SayaMusicTrack
{
    private int id;
    public string title;
    public int playCount { get; private set; }
    public SayaMusicTrack(string title)
    {
        if(title is null)
        {
            throw new ArgumentNullException("title tidak boleh null");
        }
        if (title.Length > 200) 
        {
            throw new ArgumentException("title maks 200 karakter");
        }
        this.title = title;  
        id = Random.Shared.Next(10000, 100000);
        playCount = 0;
    }
    public void IncreasePlayCount(int count)
    {
        if(count > 25_000_000) 
        { 
            throw new ArgumentOutOfRangeException(nameof(count), "maks 25 juta playcount");
        }
        if (count < 0)
        {
            throw new Exception("tidak boleh negatif");
        }
        checked
        {
            playCount += count;
        }
    }
    public void PrintTrackDetails()
    {
        Console.WriteLine($"ID : {id} | Title : {title} | Play count {playCount}");
    }
}

