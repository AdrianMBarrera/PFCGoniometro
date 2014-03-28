#pragma strict

import System.Xml;
import System.IO;
import System.Text;

var nombreArt : String = "";
var nombreArt1 : String = "";
var eje;
var rotx : int;
var roty : int;
var rotz : int;
var tiempo : String = "5000";

var estado : boolean = false;

var lastClick : float = 0;
var catchTime : float = .25;

var contador : int = 0;

function Start () {


}

function Update () {

}

function OnGUI () {
	GUI.Box(Rect(Screen.width-Screen.width/4, 0, Screen.width/4, Screen.height), "Edicion de movimiento: Paso 1");
	
	primerPaso();
	
	if (GUI.Button(Rect(Screen.width-125, Screen.height-50, 100, 30), "Siguiente")) {

	}
}

function primerPaso() {

	GUI.Label(Rect(Screen.width-Screen.width/4+20, 60, 200, 30), "Articulacion inicial: ");
	GUI.Label(Rect(Screen.width-Screen.width/4+20, 90, 200, 30), "Articulacion final: ");
	
	if (contador <= 2) {
		if(contador == 0)
			nombreArt = seleccionArt(nombreArt, Color.green);
		else
			nombreArt1 = seleccionArt(nombreArt1, Color.blue);
	}
	Debug.Log(contador);
	GUI.Label(Rect(Screen.width-Screen.width/4+200, 60, 200, 30), nombreArt);
	GUI.Label(Rect(Screen.width-Screen.width/4+200, 90, 200, 30), nombreArt1);

}

function seleccionArt(art,color) {

	if ((Input.GetKey(KeyCode.LeftShift)) && (Input.GetMouseButtonUp(0))) {
		var ray : Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		var hit : RaycastHit;
		var nombre : String;
		nombre = art;

		if ((Physics.Raycast(ray,hit)) && (Time.time-lastClick>catchTime)) {
			if (!nombre.Equals(hit.collider.gameObject.name)) {
				nombre = hit.collider.gameObject.name;
				hit.collider.gameObject.renderer.material.color = color;
				contador++;
			}
			else {
				nombre = "";
				hit.collider.gameObject.renderer.material.color = Color.white;
				contador--;
			}
		}
		
		lastClick = Time.time;
		return nombre;
	}
	
//	if (nombreArt.Equals("")) {
//		nombreArt = nombre;
//		color = Color.blue;
//	}
//	else if (nombreArt1.Equals("")) {
//	
//	}

}

function moverArtInicial() {



}

//	GUI.Label(Rect(Screen.width-Screen.width/4+20, 30, 200, 30), "Articulacion: ");
//	estado = GUI.Toggle(Rect(Screen.width-Screen.width/4+200, 30, 200, 30), estado, " Fijar");
//	
//	GUI.Label(Rect(Screen.width-Screen.width/4+20, 60, 200, 30), "Rotacion: ");
//	GUI.Label(Rect(Screen.width-Screen.width/4+100, 60, 200, 30), "X: ");
//	GUI.Label(Rect(Screen.width-Screen.width/4+100, 90, 200, 30), "Y: ");
//	GUI.Label(Rect(Screen.width-Screen.width/4+100, 120, 200, 30), "Z: ");
//
//	GUI.Label(Rect(Screen.width-Screen.width/4+20, 150, 200, 30), "Angulo: ");
//	GUI.Label(Rect(Screen.width-Screen.width/4+100, 150, 200, 30), "Minimo: ");
//	GUI.Label(Rect(Screen.width-Screen.width/4+100, 180, 200, 30), "Maximo: ");
//	
//	GUI.Label(Rect(Screen.width-Screen.width/4+20, 210, 200, 30), "Eje: ");
//	GUI.Label(Rect(Screen.width-Screen.width/4+100, 210, 200, 30), "X: ");
//	GUI.Label(Rect(Screen.width-Screen.width/4+100, 240, 200, 30), "Y: ");
//	GUI.Label(Rect(Screen.width-Screen.width/4+100, 270, 200, 30), "Z: ");
//	
//	GUI.Label(Rect(Screen.width-Screen.width/4+20, 300, 200, 30), "Tiempo: ");
////	estado = GUI.Toggle(Rect(Screen.width-Screen.width/4+200, 60, 200, 30), estado, " Fijar");
//	
//	if (((Input.GetMouseButton(0)) || (Input.GetMouseButton(1))) && !(estado)) {
//		var ray : Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//		var hit : RaycastHit;
//		
//		if (Physics.Raycast(ray,hit)) {
//			nombre = hit.collider.gameObject.name;
//			rotx = hit.collider.gameObject.transform.rotation.eulerAngles.x;
//			roty = hit.collider.gameObject.transform.rotation.eulerAngles.y;
//			rotz = hit.collider.gameObject.transform.rotation.eulerAngles.z;
//		}
//	}
//
//	GUI.Label(Rect(Screen.width-Screen.width/4+100, 30, 200, 30), nombre);
//	GUI.Label(Rect(Screen.width-Screen.width/4+120, 60, 200, 30), rotx.ToString());
//	GUI.Label(Rect(Screen.width-Screen.width/4+120, 90, 200, 30), roty.ToString());
//	GUI.Label(Rect(Screen.width-Screen.width/4+120, 120, 200, 30), rotz.ToString());
//	tiempo = GUI.TextField(Rect(Screen.width-Screen.width/4+100, 300, 50, 20), tiempo, 5);
//	
//	if (GUI.Button(Rect(Screen.width-265, Screen.height-50, 200, 30), "Guardar")) {
//		guardarXML();
//	}
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