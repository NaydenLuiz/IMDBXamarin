using IMDBXamarin.Model;
using IMDBXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IMDBXamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

           
            busca.SearchButtonPressed += buscar;
            lista.ItemSelected += itemSelected;
        }

        private void itemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Movies m = e.SelectedItem as Movies;
            Navigation.PushAsync(new MovieDetail(m));
        }

        private async void buscar(object sender, EventArgs e)
        {
            OnIndicator();

            string q = busca.Text;
            List<Movies> lstMovies = await MoviesViewModel.GetMovies(q);
            if (lstMovies.Count > 0)
            {
                lista.ItemsSource = lstMovies;
                lista.IsVisible = true;
            }
            else
            {
                await DisplayAlert("Alerta!", "Não foram encontrados dados na sua busca." + Environment.NewLine + " Tente realizar a busca novamente", "OK");
                lista.IsVisible = false;
            }
            OffIndicator();
        }
        public void OnIndicator()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                busca.IsEnabled = false;
                stkAguarde.IsVisible = true;
                indicator.IsVisible = true;
                indicator.IsRunning = true;
            });
        }
        public void OffIndicator()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                busca.IsEnabled = true;
                stkAguarde.IsVisible = false;
                indicator.IsVisible = false;
                indicator.IsRunning = false;
            });
        }
    }
}
