using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoCines.CinemarkHoyts.Models
{
    public partial class FutureFilm
    {



        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("OpeningDate")]
        public DateTime OpeningDate { get; set; }

        [JsonProperty("URLTrailerYoutube")]
        public Uri UrlTrailerYoutube { get; set; }

        [JsonProperty("Duration")]
        public long Duration { get; set; }

        [JsonProperty("Category")]
        public string Category { get; set; }

        [JsonProperty("Rating")]
        public string Rating { get; set; }

        [JsonProperty("URLPoster")]
        public Uri UrlPoster { get; set; }

        [JsonProperty("TWHashTag")]
        public object TwHashTag { get; set; }
    }
}
