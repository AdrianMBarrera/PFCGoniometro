#pragma strict

import System.Xml;
import System.IO;
import System.Text;

var nombre : String;
var eje;
var rotx : int;
var roty : int;
var rotz : int;

var estado : boolean = false;

function Start () {


}

function Update () {

}

function OnGUI () {
	GUI.Box(Rect(Screen.width-Screen.width/4, 0, Screen.width/4, Screen.height), "Edicion de movimiento:");
	GUI.Label(Rect(Screen.width-Screen.width/4+20, 30, 200, 30), "Articulacion: ");
	estado = GUI.Toggle(Rect(Screen.width-Screen.width/4+200, 30, 200, 30), estado, " Fijar");
	GUI.Label(Rect(Screen.width-Screen.width/4+20, 60, 200, 30), "Eje: ");
	GUI.Label(Rect(Screen.width-Screen.width/4+20, 90, 200, 30), "Rotacion: ");
	GUI.Label(Rect(Screen.width-Screen.width/4+100, 90, 200, 30), "X: ");
	GUI.Label(Rect(Screen.width-Screen.width/4+100, 120, 200, 30), "Y: ");
	GUI.Label(Rect(Screen.width-Screen.width/4+100, 150, 200, 30), "Z: ");
//	GUI.Label(Rect(Screen.width-Screen.width/4+20, 180, 200, 30), "Campo huesos en plano: ");
//	GUI.Label(Rect(Screen.width-Screen.width/4+20, 210, 200, 30), "Angulo inicial: ");
//	GUI.Label(Rect(Screen.width-Screen.width/4+20, 240, 200, 30), "Angulo final: ");

	if (GUI.Button(Rect(Screen.width-265, Screen.height-50, 200, 30), "Guardar")) {
		guardarXML();
	}
		
	
	if (((Input.GetMouseButton(0)) || (Input.GetMouseButton(1))) && !(estado)) {
		var ray : Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		var hit : RaycastHit;
		
		if (Physics.Raycast(ray,hit)) {
			nombre = hit.collider.gameObject.name;
			rotx = hit.collider.gameObject.transform.rotation.eulerAngles.x;
			roty = hit.collider.gameObject.transform.rotation.eulerAngles.y;
			rotz = hit.collider.gameObject.transform.rotation.eulerAngles.z;
		}
	}

	GUI.Label(Rect(Screen.width-Screen.width/4+100, 30, 200, 30), nombre);
//	GUI.Label(Rect(Screen.width-Screen.width/4+100, 60, 200, 30), nombre);
	GUI.Label(Rect(Screen.width-Screen.width/4+120, 90, 200, 30), rotx.ToString());
	GUI.Label(Rect(Screen.width-Screen.width/4+120, 120, 200, 30), roty.ToString());
	GUI.Label(Rect(Screen.width-Screen.width/4+120, 150, 200, 30), rotz.ToString());
	
	

}


function guardarXML() {

	var xmlDoc  : XmlDocument = new XmlDocument();      // xmlDoc es el nuevo documento XML

	// Creamos el nodo principal Player (De este colgaran los demas nodos)
	var nodoExercise : XmlElement = xmlDoc.CreateElement("EXERCISE");

	// Creamos sus hijos (ChildNodes)
	var nodoAngle    : XmlElement = xmlDoc.CreateElement("ANGLE");
	var nodoEje      : XmlElement = xmlDoc.CreateElement("EJE");
	var nodoIni      : XmlElement = xmlDoc.CreateElement("INI");
	var nodoPosition : XmlElement = xmlDoc.CreateElement("POSITION");

	// Creamos los hijos de posicion (X,Y,Z)
	var nodoId    : XmlElement = xmlDoc.CreateElement("ID");
	var nodoId1   : XmlElement = xmlDoc.CreateElement("ID1");
	var nodoX     : XmlElement = xmlDoc.CreateElement("X");
	var nodoY     : XmlElement = xmlDoc.CreateElement("Y");
	var nodoZ     : XmlElement = xmlDoc.CreateElement("Z");
	var nodoGrado : XmlElement = xmlDoc.CreateElement("GRADO");

//	nodoNombre.InnerText = "Jugador 2";
//	nodoVida.InnerText   = "80";
//	nodoArma.InnerText   = "Uzi";
//	nodoPuntuacion.InnerText = "2000";
//
//	nodoX.InnerText = "100";
//	nodoY.InnerText = "200";
//	nodoZ.InnerText = "300";

	nodoPosition.AppendChild(nodoId);
	nodoPosition.AppendChild(nodoId1);
	nodoPosition.AppendChild(nodoX);
	nodoPosition.AppendChild(nodoY);
	nodoPosition.AppendChild(nodoZ);
	nodoPosition.AppendChild(nodoGrado);

	// Ahora que tenemos los nodos creados y con sus valores los añadimos al nodoPlayer como hijos

	nodoExercise.AppendChild(nodoAngle);
	nodoExercise.AppendChild(nodoEje);
	nodoExercise.AppendChild(nodoIni);
	nodoExercise.AppendChild(nodoPosition);

	// Por ultimo anyadimos al xmlDoc el nodoPlayer que es el nodo que contiene todo lo demas.
	xmlDoc.AppendChild(nodoExercise);


	var xmlPath : String = ("C:/Users/User/Documents/PFCGoniometro/salvado.xml");
	xmlDoc.Save(xmlPath); //AssetDatabase.GetAssetPath(XMLFilePlayer));

}