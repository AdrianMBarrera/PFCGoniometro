import System.Collections.Generic;
import System.Xml.Serialization;

@XmlRoot("EXERCISE")
public class EXERCISE {

	@XmlAttribute("time")
	public var time = "5000";

	@XmlAttribute("art")
	public var Art : String = "";
	
	@XmlAttribute("art1")
	public var Art1 : String = "";
	
	@XmlElement("ANGLE")
	public var ang : Angle;
	
	@XmlElement("EJE")
	public var eje : Eje;
	
	@XmlElement("INI")
	public var ini : Ini;
	
	@XmlElement("POSITION")
	public var positions : List.<Position> = new List.<Position>();

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
	@XmlAttribute("MIN")
	public var Min : String = "";
	
	@XmlAttribute("MAX")
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

public class Position {

	@XmlElement("ID")
	public var id : int;
	@XmlElement("ID1")
	public var id1 : int;
	
	@XmlElement("X")
	public var x : int;
	@XmlElement("Y")
	public var y : int;
	@XmlElement("Z")
	public var z : int;

	@XmlElement("GRADO")
	public var grado : int;
}
