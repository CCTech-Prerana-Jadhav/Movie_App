using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace MoviesApp
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Movie> Movies { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Movies = new ObservableCollection<Movie>();
            MoviesListBox.ItemsSource = Movies;
            SeedMovies();
        }

        private void SeedMovies()
        {
            Movies.Add(new Movie { Title = "Inception", Genre = "Science Fiction", BoxOffice = "$ 837 million", ReleaseYear = 2010, LeadActor = "Leonardo DiCaprio" });
            Movies.Add(new Movie { Title = "The Dark Knight", Genre = "Action", BoxOffice = "$ 536 million", ReleaseYear = 2008, LeadActor = "Christian Bale" });
            Movies.Add(new Movie { Title = "Interstellar", Genre = "Science Fiction", BoxOffice = "$ 730.8 million", ReleaseYear = 2014, LeadActor = "Matthew McConaughey" });
            Movies.Add(new Movie { Title = "Arjun Reddy", Genre = "Romantic", BoxOffice = "$ 5.1 million", ReleaseYear = 2017, LeadActor = "Vijay Deverakonda" });
            Movies.Add(new Movie { Title = "Kabir Singh", Genre = "Romantic", BoxOffice = "$ 37.92 million", ReleaseYear = 2019, LeadActor = "Shahid Kapoor" });
            Movies.Add(new Movie { Title = "Animal", Genre = "Action", BoxOffice = "$ 91.782 million", ReleaseYear = 2024, LeadActor = "Ranbir Kapoor" });
            Movies.Add(new Movie { Title = "Inception", Genre = "Science Fiction", BoxOffice = "$ 837 million", ReleaseYear = 2010, LeadActor = "Leonardo DiCaprio" });
            Movies.Add(new Movie { Title = "Titanic", Genre = "Romantic", BoxOffice = "$ 2200 million", ReleaseYear = 1997, LeadActor = "Leonardo DiCaprio" });
            Movies.Add(new Movie { Title = "Shutter Island", Genre = "Thriller", BoxOffice = "$ 294 million", ReleaseYear = 2010, LeadActor = "Leonardo DiCaprio" });
            Movies.Add(new Movie { Title = "The Revenant", Genre = "Adventure", BoxOffice = "$ 533 million", ReleaseYear = 2015, LeadActor = "Leonardo DiCaprio" });
            Movies.Add(new Movie { Title = "Jersey", Genre = "Drama", BoxOffice = "$ 9.985 million", ReleaseYear = 2022, LeadActor = "Shahid Kapoor" });
            Movies.Add(new Movie { Title = "Kesari", Genre = "Action", BoxOffice = "$ 20.709 million", ReleaseYear = 2019, LeadActor = "Akshay Kumar" });
            Movies.Add(new Movie { Title = "Good Newwz", Genre = "Comedy", BoxOffice = "$ 31.857 million", ReleaseYear = 2019, LeadActor = "Akshay Kumar" });
            Movies.Add(new Movie { Title = "Mission Mangal", Genre = "Drama", BoxOffice = "$ 29.016 million", ReleaseYear = 2019, LeadActor = "Akshay Kumar" });

        }

        private void AddMovieButton_Click(object sender, RoutedEventArgs e)
        {
            var newMovieWindow = new AddMovieWindow();
            if (newMovieWindow.ShowDialog() == true)
            {
                Movies.Add(newMovieWindow.NewMovie);
            }
        }

        private void ViewDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            if (MoviesListBox.SelectedItem is Movie selectedMovie)
            {
                MessageBox.Show($"Title: {selectedMovie.Title}\nGenre: {selectedMovie.Genre}\nYear: {selectedMovie.ReleaseYear}\nYear: {selectedMovie.BoxOffice}",
                                "Movie Details",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please select a movie.", "No Movie Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DataAnalysisButton_Click(object sender, RoutedEventArgs e)
        {
            var analysisWindow = new DataAnalysisWindow(Movies.ToList());
            analysisWindow.ShowDialog();
        }

    }
}
