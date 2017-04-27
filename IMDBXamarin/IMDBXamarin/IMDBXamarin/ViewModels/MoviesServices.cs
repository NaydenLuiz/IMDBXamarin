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
        private int id;
        private string title;
        private string year;
        private string poster;
        private string cor;
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

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

        public string Year
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

        public string Cor
        {
            get
            {
                return cor;
            }

            set
            {
                cor = value;
            }
        }

        public static async Task<List<Movies>>GetMovies(string query)
        {
            List<Movies> lstMovies = new List<Movies>();
            var client = new HttpClient();
            //Monto link com o parametro da busca.
            var url = new Uri("http://www.omdbapi.com/?s="+ query.ToLower() +"&r=json");
          
            var result = await client.GetAsync(url).ConfigureAwait(false);


            if (result.IsSuccessStatusCode)
            {
                var contentUser = await result.Content.ReadAsStringAsync();
                try
                {
                    var json = JObject.Parse(contentUser);
                    if(!json.ToString().Contains("Movie not found!")) { 
                    var arrayData = json["Search"];
                        int contador = 0;
                        foreach (var item in arrayData)
                        {
                            Movies m = new Movies();
                            contador++;
                            m.Id = contador;
                            m.Year = item["Year"].ToString();
                            int year = int.Parse(m.Year);
                            if (year ==2017)
                            {
                                m.Cor = "#FF0000";
                            }
                            else
                            {
                                m.Cor = "#000000";
                            }
                            m.Title = item["Title"].ToString();
                            m.Poster = item["Poster"].ToString();
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
