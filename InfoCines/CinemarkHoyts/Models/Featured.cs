using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace InfoCines.CinemarkHoyts.Models
{
    public partial class Featured
    {
        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }
    }
}
