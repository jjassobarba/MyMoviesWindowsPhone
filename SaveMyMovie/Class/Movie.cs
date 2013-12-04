using System.Runtime.Serialization;

namespace SaveMyMovie.Class.Tables
{
    [DataContract]
    public class Movie
    {
        /// <summary>
        /// Gets or sets the rating count.
        /// </summary>
        /// <value>
        /// The rating count.
        /// </value>
        [DataMember(Name = "rating_count")]
        public int  RatingCount { get; set; }

        /// <summary>
        /// Gets or sets the genres.
        /// </summary>
        /// <value>
        /// The genres.
        /// </value>
        [DataMember(Name = "genres")]
        public string[] Genres { get; set; }

        /// <summary>
        /// Gets or sets the rated.
        /// </summary>
        /// <value>
        /// The rated.
        /// </value>
        [DataMember(Name = "rated")]
        public string Rated { get; set; }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        [DataMember(Name = "language")]
        public string[] Language { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>
        /// The rating.
        /// </value>
        [DataMember(Name = "rating")]
        public string Rating { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        [DataMember(Name = "country")]
        public string[] Country { get; set; }

        /// <summary>
        /// Gets or sets the release date.
        /// </summary>
        /// <value>
        /// The release date.
        /// </value>
        [DataMember(Name = "release_date")]
        public string ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        [DataMember(Name = "year")]
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the directors.
        /// </summary>
        /// <value>
        /// The directors.
        /// </value>
        [DataMember(Name = "directors")]
        public string[] Directors { get; set; }

        /// <summary>
        /// Gets or sets the actors.
        /// </summary>
        /// <value>
        /// The actors.
        /// </value>
        [DataMember(Name = "actors")]
        public string[] Actors { get; set; }

        /// <summary>
        /// Gets or sets the plot.
        /// </summary>
        /// <value>
        /// The plot.
        /// </value>
        [DataMember(Name = "plot_simple")]
        public string Plot { get; set; }

        /// <summary>
        /// Gets or sets the cover.
        /// </summary>
        /// <value>
        /// The cover.
        /// </value>
        [DataMember(Name = "poster")]
        public Poster Cover { get; set; }

        /// <summary>
        /// Gets or sets the runtime.
        /// </summary>
        /// <value>
        /// The runtime.
        /// </value>
        [DataMember(Name = "runtime")]
        public string[] Runtime { get; set; }

        /// <summary>
        /// Gets or sets the alt title.
        /// </summary>
        /// <value>
        /// The alt title.
        /// </value>
        [DataMember(Name = "also_known_as")]
        public string[] AltTitle { get; set; }
    }
}
