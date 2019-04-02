using System.Xml.Serialization;

namespace RL.Geo.Gps.Serialization.Xml.SkyDemon
{
    [XmlType(AnonymousType=true)]
    public class SkyDemonRoute {
        [XmlElement("RhumbLineRoute", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public SkyDemonRhumbLine[] RhumbLineRoute { get; set; }

        //[XmlElement("Alternate", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        //public SkyDemonRhumbLine[] Alternate { get; set; }

        //[XmlArray(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        //[XmlArrayItem("LoadingPoint", typeof (SkyDemonLoadingPoint[]), IsNullable = false)]
        //public SkyDemonLoadingPoint[][] WeightBalance { get; set; }

        [XmlAttribute]
        public string Start { get; set; }

        [XmlAttribute]
        public string Level { get; set; }

        //[XmlAttribute]
        //public string CruiseProfile { get; set; }

        //[XmlAttribute]
        //public string Time { get; set; }

        //[XmlAttribute]
        //public string PlannedFuel { get; set; }
    }
}