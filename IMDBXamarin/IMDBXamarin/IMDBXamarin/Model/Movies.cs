using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBXamarin.Model
{
   public class Movies
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
            }
        }

     
    }
}
