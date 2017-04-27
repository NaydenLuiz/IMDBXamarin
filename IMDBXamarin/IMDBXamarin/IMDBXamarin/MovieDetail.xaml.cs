using IMDBXamarin.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IMDBXamarin
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDetail : ContentPage
    {
        public MovieDetail(Movies movie)
        {
            InitializeComponent();

           
            imgFilme.Source = movie.Poster;
            lblTitulo.Text = movie.Title;

            lblAnoLancamento.Text =string.Format("{0:dd/MM/yyyy}", movie.Year);
          
           
            
        }
    }

   

    
}
