using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace InfoCines.Village.Models.Showtime

{
    public partial class ShowtimeResponse
    {
        [JsonProperty("errors")]
        public bool Errors { get; set; }

        [JsonProperty("data")]
        public List<ShowtimeData> Data { get; set; }
    }

    public partial class ShowtimeData
    {
        [JsonProperty("id")]
        public long CinemaID { get; set; }

        [JsonProperty("name")]
        public string CinemaName { get; set; }

        [JsonProperty("external_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long CinemaExternalID { get; set; }

        [JsonProperty("types")]
        public List<TypeElement> ShowTimes { get; set; }
    }

    public partial class TypeElement
    {
        [JsonProperty("type")]
        public string ScreenType { get; set; }

        [JsonProperty("options")]
        public List<Screening> Screenings { get; set; }
    }

    public partial class Screening
    {
        [JsonProperty("showtimes")]
        public List<Showtime> Showtimes { get; set; }

        [JsonProperty("version")]
        public Version Version { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; } 
    }

    public partial class Showtime
    {
        [JsonProperty("showtime_id")]
        public long ShowtimeId { get; set; }

        [JsonProperty("starts_at")]
        public DateTime StartsAt { get; set; }

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("is_pre_sell")]
        public bool IsPreSell { get; set; }

        [JsonProperty("is_new")]
        public bool IsNew { get; set; }

    }







    public enum Format { The2D, The3D };

    public enum Version { Cast, Subt };

    public enum TypeEnum { Standard, Monster, _4D, GoldClass};


    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                FormatConverter.Singleton,
                VersionConverter.Singleton,
                TypeEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class FormatConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Format) || t == typeof(Format?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "2D":
                    return Format.The2D;
                case "3D":
                    return Format.The3D;
            }
            throw new Exception("Cannot unmarshal type Format");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Format)untypedValue;
            switch (value)
            {
                case Format.The2D:
                    serializer.Serialize(writer, "2D");
                    return;
                case Format.The3D:
                    serializer.Serialize(writer, "3D");
                    return;
            }
            throw new Exception("Cannot marshal type Format");
        }

        public static readonly FormatConverter Singleton = new FormatConverter();
    }

    internal class VersionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Version) || t == typeof(Version?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "CAST":
                    return Version.Cast;
                case "SUBT":
                    return Version.Subt;
            }
            throw new Exception("Cannot unmarshal type Version");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Version)untypedValue;
            switch (value)
            {
                case Version.Cast:
                    serializer.Serialize(writer, "CAST");
                    return;
                case Version.Subt:
                    serializer.Serialize(writer, "SUBT");
                    return;
            }
            throw new Exception("Cannot marshal type Version");
        }

        public static readonly VersionConverter Singleton = new VersionConverter();
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);

            switch (value)
            {
                case "monster":
                    return TypeEnum.Monster;
                case "standard":
                    return TypeEnum.Standard;
                case "4d":
                    return TypeEnum._4D;
                case "gold-class":
                    return TypeEnum.GoldClass;
            }

            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;

            switch (value)
            {
                case TypeEnum.GoldClass:
                    serializer.Serialize(writer, "gold-class");
                    break;
                case TypeEnum.Monster:
                    serializer.Serialize(writer, "monster");
                    break;
                case TypeEnum.Standard:
                    serializer.Serialize(writer, "standard");
                    break;
                case TypeEnum._4D:
                    serializer.Serialize(writer, "4d");
                    break;
                default:
                    throw new Exception("Cannot marshal type TypeEnum");
            }

            return;
            
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }
}
