using System.Runtime.Serialization;

namespace SaveMyMovie.Class
{
    [DataContract]
    public class Poster
    {
        /// <summary>
        /// Gets or sets the IMDB.
        /// </summary>
        /// <value>
        /// The IMDB.
        /// </value>
        [DataMember(Name = "imdb")]
        public string IMDB { get; set; }

        /// <summary>
        /// Gets or sets the cover.
        /// </summary>
        /// <value>
        /// The cover.
        /// </value>
        [DataMember(Name = "cover")]
        public string Cover { get; set; }

    }
}
