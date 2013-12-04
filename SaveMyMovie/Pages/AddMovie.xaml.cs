using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SaveMyMovie.Class.Tables;


namespace SaveMyMovie.Pages
{
    public partial class AddMovie : PhoneApplicationPage
    {
        private const string URLBase = "http://mymovieapi.com/?";
        private const string RequestConstants = "&type=json&plot=simple&episode=1&limit=1&yg=0&mt=none&lang=en-US&offset=&aka=simple&release=simple&business=0&tech=0";
        private Movie movie;
        private Methods methods;
        private string urlImage;

        public AddMovie()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Called when a page becomes the active page in a frame.
        /// </summary>
        /// <param name="e">An object that contains the event data.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            methods = new Methods();
            base.OnNavigatedTo(e);
            string id;
            if (NavigationContext.QueryString.TryGetValue("id", out id))
            {
                var currentMovie = methods.GetMovie(Convert.ToInt32(id));
                TxtMovieTitle.Text = currentMovie.Title;
                BtnSearch_OnClick(null, null);
                BtnSearch.IsEnabled = false;
                DisableAppBar();
            }
        }

        /// <summary>
        /// Handles the OnClick event of the BtnSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void BtnSearch_OnClick(object sender, RoutedEventArgs e)
        {
            ClearControls();
            var movieTitle = TxtMovieTitle.Text;
            try
            {
                var httpReq =(HttpWebRequest)HttpWebRequest.Create(new Uri(string.Format("{0}title={1}{2}", URLBase, movieTitle, RequestConstants)));
                httpReq.BeginGetResponse(HTTPWebRequestCallBack, httpReq);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error contacting provider: " + ex.Message);
            }
        }

        /// <summary>
        /// HTTPs the web request call back.
        /// </summary>
        /// <param name="ar">The ar.</param>
        private void HTTPWebRequestCallBack(IAsyncResult ar)
        {
            try
            {
                Dispatcher.BeginInvoke(() =>
                                       {
                                           try
                                           {
                                               var httpRequest = (HttpWebRequest) ar.AsyncState;
                                               var response = httpRequest.EndGetResponse(ar);
                                               var stream = response.GetResponseStream();
                                               var reader = new StreamReader(stream);
                                               var stringResponse = reader.ReadToEnd();
                                               ParseResponseData(stringResponse);
                                           }
                                           catch (Exception ex)
                                           {
                                               MessageBox.Show("Error in web request: " + ex.Message);
                                           }
                                       });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating dispatcher: " + ex.Message);
            }
        }

        /// <summary>
        /// Parses the response data.
        /// </summary>
        /// <param name="stringResponse">The string response.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void ParseResponseData(string stringResponse)
        {
            //TODO: The response comes into an array I need to create a task to do that
            movie = new Movie();
            stringResponse = stringResponse.Remove(0, 1);
            stringResponse = stringResponse.Remove(stringResponse.Length - 1, 1);
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(stringResponse));
            var serialization = new DataContractJsonSerializer(movie.GetType());
            movie = serialization.ReadObject(ms) as Movie;
            ms.Close();
            if (movie != null)
            {
                ShowResults(movie);
            }
        }

        /// <summary>
        /// Shows the results.
        /// </summary>
        /// <param name="movie1">The movie1.</param>
        private void ShowResults(Movie movie1)
        {
            if (movie1.Title != null) TxtMovieTitle.Text = movie1.Title;
            var uri = new Uri(movie1.Cover.Cover, uriKind: UriKind.Absolute);
            ImgCover.Source = new BitmapImage(uri);
            if (movie1.Plot != null) BlockDescription.Text = movie1.Plot;
            if (movie1.Cover.Cover != null) urlImage = movie1.Cover.Cover;
            if (!string.IsNullOrWhiteSpace(movie1.RatingCount.ToString(CultureInfo.InvariantCulture)))
            {
                BlockRatingCounter.Text = movie1.RatingCount.ToString(CultureInfo.InvariantCulture);
            }
            if (movie1.Genres != null)
            {
                foreach (var genre in movie1.Genres)
                {
                    BlockGenres.Text += genre + " ,";
                }
            }
            if (!string.IsNullOrWhiteSpace(movie1.Rated))
            {
                BlockRated.Text = movie1.Rated;
            }
            if (movie1.Language != null)
            {
                foreach (var language in movie1.Language)
                {
                    BlockLanguage.Text += language + " ,";
                }
            }
            if (!string.IsNullOrWhiteSpace(movie1.Rating))
            {
                BlockRating.Text = movie1.Rating;
            }
            if (movie1.Country != null)
            {
                foreach (var country in movie1.Country)
                {
                    BlockCountry.Text += country + " ,";
                }
            }
            if (!string.IsNullOrWhiteSpace(movie1.ReleaseDate))
            {
                var dateString = movie1.ReleaseDate.ToString(CultureInfo.InvariantCulture);
                var date = new DateTime(Convert.ToInt32(dateString.Substring(0, 4)),
                    Convert.ToInt32(dateString.Substring(4, 2)), Convert.ToInt32(dateString.Substring(6, 2)));
                BlockReleaseDate.Text = date.Date.ToShortDateString();
            }
            if (!string.IsNullOrWhiteSpace(movie1.Year.ToString(CultureInfo.InvariantCulture)))
            {
                BlockYear.Text = movie1.Year.ToString(CultureInfo.InvariantCulture);
            }
            if (movie1.Directors != null)
            {
                foreach (var director in movie1.Directors)
                {
                    BlockDirectors.Text += director + " ,";
                }
            }
            if (movie1.Actors != null)
            {
                foreach (var actor in movie1.Actors)
                {
                    BlockActors.Text += actor + " ,";
                }
            }
            if (movie1.Runtime != null)
            {
                foreach (var runtime in movie1.Runtime)
                {
                    BlockRuntime.Text += runtime + " ,";
                }
            }
            if (movie1.AltTitle != null)
            {
                foreach (var title in movie1.AltTitle)
                {
                    BlockAltTitle.Text += title + " ,";
                }
            }
        }

        /// <summary>
        /// Clears the controls.
        /// </summary>
        private void ClearControls()
        {
            BlockDescription.Text = "";
            BlockRatingCounter.Text = "";
            BlockGenres.Text = "";
            BlockRated.Text = "";
            BlockLanguage.Text = "";
            BlockRating.Text = "";
            BlockCountry.Text = "";
            BlockReleaseDate.Text = "";
            BlockYear.Text = "";
            BlockDirectors.Text = "";
            BlockActors.Text = "";
            BlockRuntime.Text = "";
            BlockAltTitle.Text = "";
        }

        /// <summary>
        /// Disables the app bar.
        /// </summary>
        private void DisableAppBar()
        {
            foreach (var button in ApplicationBar.Buttons)
            {
                ((ApplicationBarIconButton)button).IsEnabled = false;
            }
        }

        /// <summary>
        /// Handles the OnClick event of the BtnAddCollection control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnAddCollection_OnClick(object sender, EventArgs e)
        {
            methods = new Methods();
            var movie = new MovieTable
                        {
                            Director = BlockDirectors.Text,
                            Title = TxtMovieTitle.Text,
                            Year = Convert.ToInt32(BlockYear.Text),
                            WantSee = false,
                            Wish = false,
                            UrlImage = urlImage
                        };
            methods.InsertMovie(movie);
            MessageBox.Show("The movie has been added to the collection");
            NavigationService.Navigate(new Uri("/Pages/Menu.xaml", UriKind.Relative));
        }

        /// <summary>
        /// BTNs the add to wish list click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnAddToWishListClick(object sender, EventArgs e)
        {
            methods = new Methods();
            var movie = new MovieTable
            {
                Director = BlockDirectors.Text,
                Title = TxtMovieTitle.Text,
                Year = Convert.ToInt32(BlockYear.Text),
                WantSee = false,
                Wish = true,
                UrlImage = urlImage
            };
            methods.InsertMovie(movie);
            MessageBox.Show("Added to your wish list");
            NavigationService.Navigate(new Uri("/Pages/Menu.xaml", UriKind.Relative));
        }

        /// <summary>
        /// BTNs the add to want to see click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnAddToWantToSeeClick(object sender, EventArgs e)
        {
            methods = new Methods();
            var movie = new MovieTable
            {
                Director = BlockDirectors.Text,
                Title = TxtMovieTitle.Text,
                Year = Convert.ToInt32(BlockYear.Text),
                WantSee = true,
                Wish = false,
                UrlImage = urlImage
            };
            methods.InsertMovie(movie);
            MessageBox.Show("Added to your want to see list");
            NavigationService.Navigate(new Uri("/Pages/Menu.xaml", UriKind.Relative));
        }
    }
}