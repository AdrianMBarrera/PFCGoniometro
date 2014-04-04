import System.Collections.Generic;
import System.Xml.Serialization;

@XmlRoot("EXERCISE")
public class EXERCISE {

	@XmlAttribute("time")
	public var time = "5000";

	@XmlAttribute("initialArt")
	public var initialArt : String = "";
	
	@XmlAttribute("finalArt")
	public var finalArt : String = "";
	
	@XmlElement("ANGLE")
	public var ang : Angle;
	
	@XmlElement("EJE")
	public var eje : Eje;
	
	@XmlElement("INI")
	public var ini : Ini;
	
	@XmlElement("Restriction")
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

	@XmlAttribute("x")
	public var x : String = "";
	
	@XmlAttribute("y")
	public var y : String = "";
	
	@XmlAttribute("z")
	public var z : String = "";
}

public class Restriction {

	@XmlElement("initialArt")
	public var initialArt = "";
	@XmlElement("finalArt")
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




