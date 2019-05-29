using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoCines.CinemarkHoyts.Models
{
    public partial class Film
    {


        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Rating")]
        public string Rating { get; set; }

        [JsonProperty("FilmCode")]
        public string FilmCode { get; set; }

        [JsonProperty("Distributor")]
        public string Distributor { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Duration")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Duration { get; set; }

        [JsonProperty("Category")]
        public string Category { get; set; }

        [JsonProperty("OpeningDate")]
        public DateTime OpeningDate { get; set; }

        [JsonProperty("URLPoster")]
        public Uri UrlPoster { get; set; }

        [JsonProperty("URLTrailerAmazon")]
        public string UrlTrailerAmazon { get; set; }

        [JsonProperty("URLTrailerYoutube")]
        public Uri UrlTrailerYoutube { get; set; }

        [JsonProperty("TWHashTag")]
        public string TwHashTag { get; set; }

        [JsonProperty("PersonList")]
        public List<Featured> FeaturedActors { get; set; }

        [JsonProperty("AttributeList")]
        public List<long> Attributes { get; set; }

        [JsonProperty("FormatList")]
        public List<string> Formats { get; set; }

        [JsonProperty("CinemaList")]
        public List<long> Cinemas { get; set; }

        [JsonProperty("MovieList")]
        public List<MoviePresentation> Presentation { get; set; }

    }
}
