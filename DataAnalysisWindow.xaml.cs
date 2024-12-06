using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace MoviesApp
{
    public partial class DataAnalysisWindow : Window
    {
        private readonly List<Movie> _movies;

        public ObservableCollection<Movie> Movies { get; set; }

        public DataAnalysisWindow(List<Movie> movies)
        {
            InitializeComponent();
            _movies = movies ?? new List<Movie>();
            Movies = new ObservableCollection<Movie>(_movies); // Populate the ObservableCollection with passed movies
        }

        // Show average box office by genre
        // Show average box office by genre
        private void ShowAverageBoxOfficeByGenre_Click(object sender, RoutedEventArgs e)
        {
            var genreGroups = _movies.GroupBy(m => m.Genre);
            AnalysisResultsListBox.Items.Clear();

            foreach (var group in genreGroups)
            {
                double average = group.Average(m => ParseBoxOffice(m.BoxOffice)); // Ensure this is parsing correctly
                AnalysisResultsListBox.Items.Add($"{group.Key}: Avg Box Office = {FormatBoxOffice(average)} USD");
            }
        }


        // Show average box office by actor
        private void ShowAverageBoxOfficeByActor_Click(object sender, RoutedEventArgs e)
        {
            var actorGroups = _movies.GroupBy(m => m.LeadActor);
            AnalysisResultsListBox.Items.Clear();

            foreach (var group in actorGroups)
            {
                double average = group.Average(m => ParseBoxOffice(m.BoxOffice));
                AnalysisResultsListBox.Items.Add($"{group.Key}: Avg Box Office = {FormatBoxOffice(average)} USD");
            }
        }

        // Predict box office for movies
        private void PredictBoxOffice_Click(object sender, RoutedEventArgs e)
        {
            // Placeholder for real prediction logic
            var predictions = _movies.Select(movie =>
                $"Predicted Box Office for {movie.Title}: {PredictBoxOffice(movie)} USD").ToList();

            // Update the results
            AnalysisResultsListBox.Items.Clear();
            foreach (var prediction in predictions)
            {
                AnalysisResultsListBox.Items.Add(prediction);
            }
        }

        // Parse box office from string to numeric value (in millions)
        // Method to parse box office value from string
        private double ParseBoxOffice(string boxOffice)
        {
            if (string.IsNullOrWhiteSpace(boxOffice)) return 0;

            // Remove dollar sign and trim spaces
            boxOffice = boxOffice.Replace("$", "").Trim();

            // Check for "million" and process accordingly
            if (boxOffice.Contains("million", StringComparison.OrdinalIgnoreCase))
            {
                boxOffice = boxOffice.Replace("million", "").Trim();
                if (double.TryParse(boxOffice, out double result))
                {
                    return result; // Return value as it is in millions
                }
            }

            // If it's not "million" or fails to parse, return 0
            return 0;
        }


        // Format the box office value to string (in millions)
        private string FormatBoxOffice(double value)
        {
            return $"{value:0.##} Million"; // Format value as million with up to 2 decimal places
        }

        // Placeholder for predicting the box office (this would later be improved)
        private double PredictBoxOffice(Movie movie)
        {
            // For now, we'll just return the same value as a placeholder
            return ParseBoxOffice(movie.BoxOffice); // Actual prediction logic will go here
        }
    }
}
