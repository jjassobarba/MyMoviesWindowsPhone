using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using SaveMyMovie.Class.Tables;

namespace SaveMyMovie.Pages
{
    public partial class EditMovie : PhoneApplicationPage
    {
        private Methods methods;
        private MovieTable currentMovie;

        public EditMovie()
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
                currentMovie = methods.GetMovie(Convert.ToInt32(id));
                BlockTitle.Text = currentMovie.Title;
                BlockYear.Text = currentMovie.Year.ToString(CultureInfo.InvariantCulture);
                BlockDirector.Text = currentMovie.Director;
                if (currentMovie.WantSee)
                    RadioButtonWant.IsChecked = true;
                if (currentMovie.Wish)
                    RadioButtonWish.IsChecked = true;
                var uri = new Uri(currentMovie.UrlImage, UriKind.Absolute);
                ImgCover.Source = new BitmapImage(uri);
            }
        }

        /// <summary>
        /// Handles the OnClick event of the ApplicationBarIconButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void ApplicationBarIconButton_OnClick(object sender, EventArgs e)
        {
            methods = new Methods();
            currentMovie.WantSee = (bool) RadioButtonWant.IsChecked;
            currentMovie.Wish = (bool) RadioButtonWish.IsChecked;
            methods.UpdateMovie(currentMovie);
            MessageBox.Show("The movie has been updated");
            NavigationService.Navigate(new Uri("/Pages/Menu.xaml", UriKind.Relative));
        }
    }
}