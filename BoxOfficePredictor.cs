using MoviesApp;

public class BoxOfficePredictor
{
    private readonly List<Movie> _movies;

    public BoxOfficePredictor(List<Movie> movies)
    {
        _movies = movies;
    }

    // Predict future box office by lead actor
    public string PredictFutureBoxOfficeByActor(string leadActor, int releaseYear)
    {
        var filteredMovies = _movies.Where(m => m.LeadActor == leadActor).ToList();
        return PredictForActor(filteredMovies, releaseYear);
    }

    // Predict future box office for an actor based on their average growth rate
    private string PredictForActor(List<Movie> movies, int releaseYear)
    {
        if (!movies.Any())
            return "No Data Available"; // No movies available for prediction

        // Group movies by year and calculate the average box office collection for each year
        var yearData = movies.GroupBy(m => m.ReleaseYear)
                             .Select(g => new { Year = g.Key, AvgBoxOffice = g.Average(m => ParseBoxOffice(m.BoxOffice)) })
                             .OrderBy(g => g.Year)
                             .ToList();

        if (yearData.Count < 2)
            return "Not enough data for prediction"; // At least two years of data required

        // Calculate the growth rate from the average box office collections of the first and last years
        double avgGrowthRate = (yearData.Last().AvgBoxOffice - yearData.First().AvgBoxOffice) /
                               (yearData.Last().Year - yearData.First().Year);

        if (avgGrowthRate == 0)
            return FormatBoxOffice(yearData.Last().AvgBoxOffice); // No growth, return last known box office

        // Predict future box office for the given release year
        double predictedBoxOffice = yearData.Last().AvgBoxOffice + avgGrowthRate * (releaseYear - yearData.Last().Year);

        // Ensure the prediction is valid
        if (double.IsNaN(predictedBoxOffice) || double.IsInfinity(predictedBoxOffice))
            return "Prediction Error";

        return FormatBoxOffice(predictedBoxOffice);
    }

    // Method to parse box office string to numeric value
    private double ParseBoxOffice(string boxOffice)
    {
        if (string.IsNullOrWhiteSpace(boxOffice)) return 0;

        boxOffice = boxOffice.Replace("$", "").Trim();

        if (boxOffice.Contains("million", StringComparison.OrdinalIgnoreCase))
        {
            boxOffice = boxOffice.Replace("million", "").Trim();
            if (double.TryParse(boxOffice, out double result))
            {
                return result; // Return value as it is in millions
            }
        }

        return 0; // Return 0 for invalid or unrecognized values
    }

    // Method to format box office values for display
    private string FormatBoxOffice(double value)
    {
        return $"${value:F2}M"; // Format the value in millions
    }
}
