using System;
using System.Collections.Generic;
using System.Text;

namespace InfoCines.CommonModels
{
    public class Movie
    {

        public List<Showtime> showtimes { get; set; }
        public List<Cinema> cinemas { get; set; }
        public string name { get; set; }
        public string originalName { get; set; }
        public int duration { get; set; }

        public Uri poster { get; set; }
        public Uri TrailerYoutube { get; set; }


    }
}
