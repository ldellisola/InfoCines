using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoCines.CinemarkHoyts.Models
{
    public partial class MoviePresentation
    {

        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Format")]
        public string Format { get; set; } // 2D, 3D

        [JsonProperty("Version")]
        public Version Version { get; set; } // Castellano, subtitulado

        [JsonProperty("CinemaList")]
        public List<CinemaList> CinemaList { get; set; }
    }
}
