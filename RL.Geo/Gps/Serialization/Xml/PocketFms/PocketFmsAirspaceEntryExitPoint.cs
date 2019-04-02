using System.Xml.Schema;
using System.Xml.Serialization;

namespace RL.Geo.Gps.Serialization.Xml.PocketFms
{
    [XmlType(AnonymousType=true)]
    public class PocketFmsAirspaceEntryExitPoint {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal Latitude { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal Longitude { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public PocketFMSFlightplanTimeMeasure ETECUMMULATIVE { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "time")]
        public System.DateTime ETAUTC { get; set; }
    }
}