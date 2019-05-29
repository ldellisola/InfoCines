using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoCines.CinemarkHoyts.Models
{
    public partial class CinemarkHoytsResponse
    {
        [JsonProperty("TimeStamp")]
        public double TimeStamp { get; set; }

        [JsonProperty("Cinemas")]
        public List<Cinema> Cinemas { get; set; }

        [JsonProperty("Films")]
        public List<Film> Films { get; set; }

        [JsonProperty("ComingSoonFilms")]
        public List<FutureFilm> FutureFilms { get; set; }

    }
}
