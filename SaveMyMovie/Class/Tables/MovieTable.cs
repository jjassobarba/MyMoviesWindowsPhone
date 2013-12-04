using System.ComponentModel;
using System.Data.Linq.Mapping;

namespace SaveMyMovie.Class.Tables
{
    [Table]
    public class MovieTable: INotifyPropertyChanged, INotifyPropertyChanging
    {
        private int id;

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        /// <value>
        /// The ID.
        /// </value>
        [Column(IsPrimaryKey = true,IsDbGenerated = true, DbType = "INT NOT NULL IDENTITY", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int ID
        {
            get { return id; }
            set
            {
                NotifyPropertyChanging("ID");
                id = value;
                NotifyPropertyChanged("ID");
            }
        }

        private string title;

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [Column]
        public string Title
        {
            get { return title; }
            set
            {
                NotifyPropertyChanging("Title");
                title = value;
                NotifyPropertyChanged("Title");
            }
        }

        private string director;

        /// <summary>
        /// Gets or sets the director.
        /// </summary>
        /// <value>
        /// The director.
        /// </value>
        [Column]
        public string Director
        {
            get { return director; }
            set
            {
                NotifyPropertyChanging("Director");
                director = value;
                NotifyPropertyChanged("Director");
            }
        }


        private int year;

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        [Column]
        public int Year
        {
            get { return year; }
            set
            {
                NotifyPropertyChanging("Year");
                year = value;
                NotifyPropertyChanging("Year");
            }
        }

        private bool wish;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MovieTable" /> is wish.
        /// </summary>
        /// <value>
        ///   <c>true</c> if wish; otherwise, <c>false</c>.
        /// </value>
        [Column]
        public bool Wish
        {
            get { return wish; }
            set
            {
                NotifyPropertyChanging("Wish");
                wish = value;
                NotifyPropertyChanged("Wish");
            }
        }

        private bool tosee;

        /// <summary>
        /// Gets or sets a value indicating whether [want see].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [want see]; otherwise, <c>false</c>.
        /// </value>
        [Column]
        public bool WantSee
        {
            get { return tosee; }
            set
            {
                NotifyPropertyChanging("WantSee");
                tosee = value;
                NotifyPropertyChanged("WantSee");
            }
        }

        private string urlImage;

        /// <summary>
        /// Gets or sets the URL image.
        /// </summary>
        /// <value>
        /// The URL image.
        /// </value>
        [Column]
        public string UrlImage
        {
            get { return urlImage; }
            set
            {
                NotifyPropertyChanging("UrlImage");
                urlImage = value;
                NotifyPropertyChanged("UrlImage");
            }
        }

        

        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        /// <summary>
        /// Notifies the property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        /// <summary>
        /// Notifies the property changing.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }
    }
}
