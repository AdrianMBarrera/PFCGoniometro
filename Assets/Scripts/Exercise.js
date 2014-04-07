import System.Collections.Generic;
import System.Xml.Serialization;

@XmlRoot("EXERCISE")
public class EXERCISE {

	@XmlAttribute("time")
	public var time = "5000";

	@XmlAttribute("initialId")
	public var initialId ;
	
	@XmlAttribute("finalID")
	public var finalId ;
	@XmlIgnoreAttribute
	public var initialArt = "";
	@XmlIgnoreAttribute
	public var finalArt = "";
	
	@XmlElement("ANGLE")
	public var ang : Angle;
	
	@XmlElement("EJE")
	public var eje : Eje;
	

	@XmlElement("INI")
	public var ini : Ini;
	
	@XmlElement("RESTRICTION")
	public var restrictions : List.<Restriction> = new List.<Restriction>();


	public function Save(path : String) {
		var ns : XmlSerializerNamespaces = new XmlSerializerNamespaces();
		ns.Add("","");
	
 		var serializer : XmlSerializer = new XmlSerializer(EXERCISE);
 		var stream : Stream = new FileStream(path, FileMode.Create);
 		serializer.Serialize(stream, this, ns);
 		stream.Close();
 	}

}

public class Angle {
	@XmlAttribute("min")
	public var Min : String = "";
	
	@XmlAttribute("max")
	public var Max : String = "";
}

public class Eje {
	@XmlAttribute("X")
	public var X : String = "";
	
	@XmlAttribute("Y")
	public var Y : String = "";
	
	@XmlAttribute("Z")
	public var Z : String = "";
}

public class Ini {

	@XmlAttribute("X")
	public var x : String = "";
	
	@XmlAttribute("Y")
	public var y : String = "";
	
	@XmlAttribute("Z")
	public var z : String = "";
}

public class Restriction {

	@XmlElement("initialId")
	public var initialId : int;
    @XmlElement("finalId") 
	public var finalId : int;
	@XmlIgnoreAttribute
	public var initialArt = "";	
	@XmlIgnoreAttribute	
	public var finalArt = "";
	
	
	
	@XmlElement("x")
	public var x : int;
	@XmlElement("y")
	public var y : int;
	@XmlElement("z")
	public var z : int;

	@XmlElement("grade")
	public var grade = 0;
}




