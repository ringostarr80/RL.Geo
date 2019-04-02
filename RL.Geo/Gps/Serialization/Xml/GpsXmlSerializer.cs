﻿using System;
using System.IO;
using RL.Geo.Gps.Metadata;

namespace RL.Geo.Gps.Serialization.Xml
{
    public abstract class GpsXmlSerializer<T> : GpsXmlDeSerializer<T>, IGpsFileSerializer
    {
        public void Serialize(GpsData data, Stream stream)
        {
            _xmlSerializer.Serialize(stream, SerializeInternal(data));
        }

        public string Serialize(GpsData data)
        {
            var textWriter = new StringWriter();
            _xmlSerializer.Serialize(textWriter, SerializeInternal(data));
            return textWriter.ToString();
        }

        protected abstract T SerializeInternal(GpsData data);

        protected void SerializeMetadata(GpsData data, T xml, Func<GpsMetadata.MetadataKeys, string> attribute, Action<T, string> action)
        {
            var value = data.Metadata.Attribute(attribute);
            if (!string.IsNullOrWhiteSpace(value))
                action(xml, value);
        }

        protected void SerializeTrackMetadata<TTrack>(Track data, TTrack xml, Func<TrackMetadata.MetadataKeys, string> attribute, Action<TTrack, string> action)
        {
            var value = data.Metadata.Attribute(attribute);
            if (!string.IsNullOrWhiteSpace(value))
                action(xml, value);
        }

        protected void SerializeRouteMetadata<TRoute>(Route data, TRoute xml, Func<RouteMetadata.MetadataKeys, string> attribute, Action<TRoute, string> action)
        {
            var value = data.Metadata.Attribute(attribute);
            if (!string.IsNullOrWhiteSpace(value))
                action(xml, value);
        }
    }
}
