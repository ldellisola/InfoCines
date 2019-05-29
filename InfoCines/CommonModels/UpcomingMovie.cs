using System;
using System.Collections.Generic;
using System.Text;

namespace InfoCines.CommonModels
{
    public class UpcomingMovie
    {
        public DateTime releaseDate { get; set; }
        public string name { get; set; }
        public Uri TrailerYoutube { get; set; }
        public string description { get; set; }
        public Uri Poster { get; set; }
        
    }
}
