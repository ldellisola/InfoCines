using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;


namespace InfoCines.CinemarkHoyts.Models
{
    public partial class CinemaRoom
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Feature")]
        public long Feature { get; set; }

        [JsonProperty("Seats")]
        public long Seats { get; set; }

        [JsonProperty("Dtm")]
        public DateTime Dtm { get; set; }
    }
}
