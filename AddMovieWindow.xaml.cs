using System;
using System.Windows;

namespace MoviesApp
{
    public partial class AddMovieWindow : Window
    {
        public Movie NewMovie { get; set; }

        public AddMovieWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(YearTextBox.Text, out int year) &&
                !string.IsNullOrWhiteSpace(TitleTextBox.Text) &&
                !string.IsNullOrWhiteSpace(GenreTextBox.Text) &&
                !string.IsNullOrWhiteSpace(ActorTextBox.Text))
            {
                NewMovie = new Movie
                {
                    Title = TitleTextBox.Text,
                    Genre = GenreTextBox.Text,
                    BoxOffice = BoxOfficeTextBox.Text,
                    ReleaseYear = year,
                    LeadActor = ActorTextBox.Text
                };
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Please enter valid data.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
