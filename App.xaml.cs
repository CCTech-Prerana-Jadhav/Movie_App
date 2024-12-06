using System;

namespace MoviesApp
{
    public class Movie
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string BoxOffice { get; set; }
        public string LeadActor { get; set; }

        public override string ToString()
        {
            return $"{Title} ({ReleaseYear}) - {LeadActor}";
        }
    }
}
