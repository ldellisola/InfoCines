using Newtonsoft.Json;
using System;

namespace InfoCines.CinemarkHoyts.Models
{
    public partial class Cinema
    {

        public static explicit operator CommonModels.Cinema(Cinema obj)
        {

            CommonModels.Cinema output = new CommonModels.Cinema(obj.Name.Contains("Hoyts") ? CommonModels.CinemaChain.Hoyts : CommonModels.CinemaChain.Cinemark);

            output.Address = obj.Address;
            output.Description = obj.Description;
            output.GoogleMaps = obj.UrlGoogleMaps;
            output.Lat = obj.DecLatitude;
            output.Long = obj.DecLongitude;
            output.Name = obj.Name;
            output.NearbyPublicTransit = obj.NearbyBuses + " | " + obj.NearbyMetroStation;

            return output;
        }



        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Features")]
        public string Features { get; set; }

        [JsonProperty("decLatitude")]
        public string DecLatitude { get; set; }

        [JsonProperty("decLongitude")]
        public string DecLongitude { get; set; }

        [JsonProperty("Metro")]
        public string NearbyMetroStation { get; set; }

        [JsonProperty("Buses")]
        public string NearbyBuses { get; set; }

        [JsonProperty("Manager")]
        public string Manager { get; set; }

        [JsonProperty("URLThumb")]
        public Uri UrlThumb { get; set; }

        [JsonProperty("URLGoogleMaps")]
        public Uri UrlGoogleMaps { get; set; }


    }
}
