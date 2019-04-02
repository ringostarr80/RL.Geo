﻿using System.IO;
using RL.Geo.Abstractions.Interfaces;

namespace RL.Geo.IO.GeoJson
{
    public static class GeoJson
    {
        private static readonly GeoJsonReader Reader = new GeoJsonReader();
        private static readonly GeoJsonWriter Writer = new GeoJsonWriter();

        public static string Serialize(object obj)
        {
            return Writer.Write(obj);
        }

        public static IGeoJsonObject DeSerialize(string json)
        {
            return Reader.Read(json);
        }

        public static IGeoJsonObject DeSerialize(Stream stream)
        {
            return Reader.Read(stream);
        }
    }
}
