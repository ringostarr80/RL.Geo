using System.Xml.Serialization;

namespace RL.Geo.Gps.Serialization.Xml.SkyDemon
{
    [XmlType(AnonymousType=true)]
    public class SkyDemonLoadingPoints {
        [XmlElement("FuelLoadingPoint", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public SkyDemonFuelLoadingPoint[] FuelLoadingPoint { get; set; }

        [XmlElement("LoadingPoint")]
        public SkyDemonLoadingPoint[] LoadingPoint { get; set; }
    }
}