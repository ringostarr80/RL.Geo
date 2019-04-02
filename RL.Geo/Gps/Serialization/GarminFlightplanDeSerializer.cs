﻿using System.Linq;
using RL.Geo.Geometries;
using RL.Geo.Gps.Serialization.Xml;
using RL.Geo.Gps.Serialization.Xml.Garmin;
using RL.Geo.Gps.Serialization.Xml.Garmin.Flightplan;
using System.Xml;

namespace RL.Geo.Gps.Serialization
{
    public class GarminFlightplanDeSerializer : GpsXmlDeSerializer<GarminFlightplan>
    {
        public override GpsFileFormat[] FileFormats
        {
            get
            {
                return new[]
                           {
                               new GpsFileFormat("fpl", "Garmin Flightplan"),
                           };
            }
        }

        public override GpsFeatures SupportedFeatures
        {
            get { return GpsFeatures.Routes; }
        }

        protected override bool CanDeSerialize(XmlReader xml) {
            return xml.NamespaceURI == "http://www8.garmin.com/xmlschemas/FlightPlan/v1";
        }

        protected override GpsData DeSerialize(GarminFlightplan xml)
        {
            var data = new GpsData();
            foreach (var route in xml.route)
            {
                var rte = new Route();
                rte.Metadata.Attribute(x => x.Name, route.routename);
                foreach (var point in route.routepoint)
                {
                    var wp = xml.waypointtable.Single(x => x.identifier == point.waypointidentifier);
                    rte.Coordinates.Add(new Coordinate(wp.lat, wp.lon));
                }
                data.Routes.Add(rte);
            }
            return data;
        }
    }
}
