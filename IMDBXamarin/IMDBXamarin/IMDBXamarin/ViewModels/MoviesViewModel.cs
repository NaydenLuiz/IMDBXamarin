using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IMDBXamarin.Model;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace IMDBXamarin.ViewModels
{
    public class MoviesViewModel:BaseViewModel
    {
      
        private string title;
        private DateTime year;
        private string poster;
        
      

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        public DateTime Year
        {
            get
            {
                return year;
            }

            set
            {
                year = value;
                OnPropertyChanged();
            }
        }

        public string Poster
        {
            get
            {
                return poster;
            }

            set
            {
                poster = value;
                OnPropertyChanged();
            }
        }

       

        public static async Task<List<Movies>>GetMovies(string query)
        {
            List<Movies> lstMovies = new List<Movies>();
            var client = new HttpClient();
            //Monto link com o parametro da busca.
            var url = new Uri("https://api.themoviedb.org/3/search/movie?api_key=1f54bd990f1cdfb230adb312546d765d&query=" + query.ToLower());
          
            var result = await client.GetAsync(url).ConfigureAwait(false);


            if (result.IsSuccessStatusCode)
            {
                var contentUser = await result.Content.ReadAsStringAsync();
                try
                {
                    var json = JObject.Parse(contentUser);
                    int total_result = int.Parse(json["total_results"].ToString());
                    if(total_result>0) { 
                    var arrayData = json["results"];
                        
                        foreach (var item in arrayData)
                        {
                            Movies m = new Movies();
                           
                            m.Title = item["title"].ToString();
                            m.Poster = "http://image.tmdb.org/t/p/w780/" + item["poster_path"].ToString();
                            m.Year =DateTime.Parse(item["release_date"].ToString());
                            lstMovies.Add(m);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Erro ao Processar Request GetMovies:" + ex.Message);
                    
                }
               
                
            }


            return lstMovies;
        }
    }
}
