using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SaveMyMovie.Class.Tables;

namespace SaveMyMovie.Pages
{
    public partial class Menu : PhoneApplicationPage
    {
        private Methods methods;

        private MovieTable selectedMovie = new MovieTable();

        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        /// </summary>
        public Menu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the OnClick event of the BtnAddMovie control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnAddMovie_OnClick(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/AddMovie.xaml", UriKind.Relative));
        }

        /// <summary>
        /// Handles the OnLoaded event of the Menu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Menu_OnLoaded(object sender, RoutedEventArgs e)
        {
            methods = new Methods();
            var movies = methods.GetMovies();
            LsbCatalog.ItemsSource = movies.Where(p => !p.WantSee && !p.Wish);
            LsbWish.ItemsSource = movies.Where(p => p.Wish).ToList();
            LsbWantTo.ItemsSource = movies.Where(p => p.WantSee).ToList();
            
        }

        /// <summary>
        /// Handles the Click event of the BtnEditMovie control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnEditMovieClick(object sender, EventArgs e)
        {
            if (selectedMovie != null)
            {
                NavigationService.Navigate(new Uri("/Pages/EditMovie.xaml?id=" + selectedMovie.ID, UriKind.Relative));
            }
        }

        /// <summary>
        /// Handles the Click event of the BtnDeleteMovie control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnDeleteMovieClick(object sender, EventArgs e)
        {
            methods = new Methods();
            methods.DeleteMovie(selectedMovie);
            Menu_OnLoaded(null, null);
        }

        /// <summary>
        /// Enables the buttons.
        /// </summary>
        /// <param name="isEnable">if set to <c>true</c> [is enable].</param>
        private void EnableButtons(bool isEnable)
        {
            var buttonEdit = (ApplicationBarIconButton) ApplicationBar.Buttons[1];
            var buttonDelete = (ApplicationBarIconButton) ApplicationBar.Buttons[2];
            var buttonDetails = (ApplicationBarIconButton) ApplicationBar.Buttons[3];
            buttonEdit.IsEnabled = isEnable;
            buttonDelete.IsEnabled = isEnable;
            buttonDetails.IsEnabled = isEnable;
        }

        /// <summary>
        /// Handles the OnTap event of the LsbWish control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GestureEventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void LsbWish_OnTap(object sender, GestureEventArgs e)
        {
            selectedMovie = (MovieTable) LsbWish.SelectedItem;
            LsbWantTo.SelectedItem = null;
            LsbCatalog.SelectedItem = null;
            EnableButtons(true);
        }

        /// <summary>
        /// Handles the OnTap event of the LsbWantTo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GestureEventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void LsbWantTo_OnTap(object sender, GestureEventArgs e)
        {
            selectedMovie = (MovieTable)LsbWantTo.SelectedItem;
            LsbWish.SelectedItem = null;
            LsbCatalog.SelectedItem = null;
            EnableButtons(true);
        }

        /// <summary>
        /// Handles the OnClick event of the BtnDetailsMovie control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void BtnDetailsMovie_OnClick(object sender, EventArgs e)
        {
            if (selectedMovie != null)
            {
                NavigationService.Navigate(new Uri("/Pages/AddMovie.xaml?id=" + selectedMovie.ID, UriKind.Relative));
            }
        }

        /// <summary>
        /// Handles the OnTap event of the LsbCatalog control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GestureEventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void LsbCatalog_OnTap(object sender, GestureEventArgs e)
        {
            selectedMovie = (MovieTable)LsbCatalog.SelectedItem;
            LsbWish.SelectedItem = null;
            LsbWantTo.SelectedItem = null;
            EnableButtons(true);
        }
    }
}