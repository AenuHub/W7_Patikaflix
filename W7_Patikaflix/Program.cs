using W7_Patikaflix;

public class Program
{
    public static void Main(string[] args)
    {   
        // create a list to store all series from the user
        List<Series> tvSeries = new List<Series>();
        GetAllSeriesFromUser(tvSeries);
        
        // create another list from user input to store only comedy series
        List<Series> comedySeries = tvSeries.Where(x => x.Genres.Contains("Comedy")).ToList();
        
        // print all comedy series with title, genres, director ordered by title, then director name
        if (comedySeries.Count == 0)
        {
            Console.WriteLine("No comedy series found.");
        }
        else
        {
            Console.WriteLine("Printing all comedy series:");
            foreach (var series in comedySeries.OrderBy(x => x.Title).ThenBy(x => x.Director))
            {
                Console.WriteLine(series);
                Console.WriteLine(new string('-', 50));
            }
        }
        
        Console.ReadKey();
    }
    
    // create a method to get all series from the user
    public static void GetAllSeriesFromUser(List<Series> tvSeries)
    {
        bool shouldContinue = true;
        while (shouldContinue)
        {
            Console.Write("Do you want to add a new series? (y/n): ");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "y")
            {
                // create a new series
                Console.Write("Enter the title of the series: ");
                string title = Console.ReadLine();
                Console.Write("Enter the production year of the series: ");
                int productionYear = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the genres of the series (separated by commas if more than one): ");
                string genres = Console.ReadLine();
                Console.Write("Enter the release year of the series: ");
                int releaseYear = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the director of the series: ");
                string director = Console.ReadLine();
                Console.Write("Enter the platform of the series: ");
                string platform = Console.ReadLine();
                
                // validate user input
                if (title == null || productionYear < 1800 || genres == null || releaseYear < 1800 ||
                    director == null || platform == null || title == String.Empty || genres == String.Empty ||
                    director == String.Empty || platform == String.Empty)
                {
                    Console.WriteLine("Cannot add series. Please try again.");
                    continue;
                }
                
                // add new series to the list
                tvSeries.Add(new Series(title, productionYear, ToUpperCaseAndList(genres), 
                    releaseYear, director, platform));
                Console.WriteLine("Series added successfully.");
                Console.WriteLine(new string('-', 50));
            }
            else
            {
                shouldContinue = false;
            }
        }
    }

    // create a method to convert string to uppercase first letter and return a list
    public static List<string> ToUpperCaseAndList(string input)
    {
        string[] words = input.Split(',');
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = words[i].Trim();
            words[i] = words[i].Substring(0, 1).ToUpper() + words[i].Substring(1);
        }
        return words.ToList();
    }
}