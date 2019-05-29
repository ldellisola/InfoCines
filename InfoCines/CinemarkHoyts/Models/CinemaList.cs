using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoCines.CinemarkHoyts.Models
{
    public partial class CinemaList
    {
        [JsonProperty("Id")]
        public long CinemaID { get; set; }

        [JsonProperty("SessionList")]
        public List<CinemaRoom> Rooms { get; set; }
    }
}
