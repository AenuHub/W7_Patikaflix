namespace W7_Patikaflix;

public class Series
{
    public string Title { get; set; }
    public int ProductionYear { get; set; }
    public List<string> Genres { get; set; }
    public int ReleaseYear { get; set; }
    public string Director { get; set; }
    public string Platform { get; set; }
    
    public Series(string title, int productionYear, List<string> genres, int releaseYear, string director, 
        string platform)
    {
        Title = title;
        ProductionYear = productionYear;
        Genres = genres;
        ReleaseYear = releaseYear;
        Director = director;
        Platform = platform;
    }
    
    // overriding ToString method to print series title, genres, director only
    public override string ToString()
    {
        return $"Title: {Title}\nGenres: {string.Join(", ", Genres)}\nDirector: {Director}";
    }
}