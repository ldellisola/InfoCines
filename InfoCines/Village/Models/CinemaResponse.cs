using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace InfoCines.Village.Models
{
    public partial class CinemasResponse
    {
        [JsonProperty("errors")]
        public bool Errors { get; set; }

        [JsonProperty("data")]
        public List<CinemaData> Data { get; set; }
    }

    public partial class CinemaData
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("external_id")]
        public long ExternalId { get; set; }

        [JsonProperty("zone_id")]
        public long ZoneId { get; set; }

        [JsonProperty("enabled")]
        public long Enabled { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address1")]
        public string Address1 { get; set; }

        [JsonProperty("address2")]
        public string Address2 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("parking_info")]
        public string ParkingInfo { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("public_transport")]
        public string PublicTransport { get; set; }
    }
}
