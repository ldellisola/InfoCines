using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace InfoCines.Village.Models
{
    public partial class MoviesResponse
    {
        [JsonProperty("errors")]
        public bool Errors { get; set; }

        [JsonProperty("data")]
        public List<MovieData> Data { get; set; }

        [JsonProperty("meta")]
        public MovieMetadata Meta { get; set; }
    }

    public partial class MovieData
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title_original")]
        public string TitleOriginal { get; set; }

        [JsonProperty("title_translated")]
        public string TitleTranslated { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("release_date")]
        public DateTime ReleaseDate { get; set; }

        [JsonProperty("presell_from")]
        public DateTime? PresellFrom { get; set; }

        [JsonProperty("next_showtime")]
        public DateTime NextShowtime { get; set; }

        [JsonProperty("grouping")]
        public SellingStatus SellingStatus { get; set; }

        [JsonProperty("is_pre_sell")]
        public bool IsPreSell { get; set; }

        [JsonProperty("is_new")]
        public bool IsNew { get; set; }
    }

    public partial class MovieMetadata
    {
        [JsonProperty("aggregations")]
        public Aggregations Aggregations { get; set; }
    }

    public partial class Aggregations
    {
        [JsonProperty("complex")]
        public Dictionary<string, long> Cinema { get; set; }

        [JsonProperty("screen_type")]
        public ScreenType ScreenType { get; set; }

        [JsonProperty("attribute")]
        public Attribute Attribute { get; set; }

        [JsonProperty("date")]
        public Dictionary<string, long> Date { get; set; }
    }

    public partial class Attribute
    {
        [JsonProperty("2D")]
        public long _2D { get; set; }

        [JsonProperty("3D")]
        public long _3D { get; set; }

        [JsonProperty("CAST")]
        public long Cast { get; set; }

        [JsonProperty("SUBT")]
        public long Subt { get; set; }
    }

    public partial class ScreenType
    {
        [JsonProperty("standard")]
        public long Standard { get; set; }

        [JsonProperty("monster")]
        public long Monster { get; set; }

        [JsonProperty("gold-class")]
        public long GoldClass { get; set; }

        [JsonProperty("4d")]
        public long The4D { get; set; }
    }

    public enum SellingStatus { Premier, Presell, Regular };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {

                GroupingConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

   

    internal class GroupingConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(SellingStatus) || t == typeof(SellingStatus?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "premier":
                    return SellingStatus.Premier;
                case "presell":
                    return SellingStatus.Presell;
                case "regular":
                    return SellingStatus.Regular;
            }
            throw new Exception("Cannot unmarshal type Grouping");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (SellingStatus)untypedValue;
            switch (value)
            {
                case SellingStatus.Premier:
                    serializer.Serialize(writer, "premier");
                    return;
                case SellingStatus.Presell:
                    serializer.Serialize(writer, "presell");
                    return;
                case SellingStatus.Regular:
                    serializer.Serialize(writer, "regular");
                    return;
            }
            throw new Exception("Cannot marshal type Grouping");
        }

        public static readonly GroupingConverter Singleton = new GroupingConverter();
    }
}

