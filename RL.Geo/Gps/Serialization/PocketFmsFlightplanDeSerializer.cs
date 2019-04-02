﻿using System;
using RL.Geo.Geometries;
using RL.Geo.Gps.Serialization.Xml;
using RL.Geo.Gps.Serialization.Xml.PocketFms;
using System.Xml;

namespace RL.Geo.Gps.Serialization
{
    public class PocketFmsFlightplanDeSerializer : GpsXmlDeSerializer<PocketFmsFlightplan>
    {
        public override GpsFileFormat[] FileFormats
        {
            get
            {
                return new[]
                    {
                        new GpsFileFormat("xml", "PocketFMS Flightplan", "http://www.PocketFMS.com/XMLSchema/PocketFMSNavlog-1.2.0.xsd"),
                    };
            }
        }

        public override GpsFeatures SupportedFeatures
        {
            get { return GpsFeatures.Routes; }
        }

        protected override bool CanDeSerialize(XmlReader xml) {
            return xml.Name == "PocketFMSFlightplan";
        }

        protected override GpsData DeSerialize(PocketFmsFlightplan xml)
        {
            var route = new Route();
            route.Coordinates.Add(new Coordinate((double)xml.LIB[0].FromPoint.Latitude, (double)xml.LIB[0].FromPoint.Longitude));
            foreach (var lib in xml.LIB)
            {
                route.Coordinates.Add(new Coordinate((double)lib.ToPoint.Latitude, (double)lib.ToPoint.Longitude));
            }

            var data = new GpsData();
            data.Routes.Add(route);

            data.Metadata.Attribute(x => x.Vehicle.Crew1, xml.META.PilotInCommand);
            data.Metadata.Attribute(x => x.Vehicle.Identifier, xml.META.AircraftIdentification);
            data.Metadata.Attribute(x => x.Vehicle.Model, xml.META.AircraftType);

            return data;
        }
    }
}
