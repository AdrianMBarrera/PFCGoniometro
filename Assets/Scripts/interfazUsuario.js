#pragma strict

import System.Xml;
import System.IO;
import System.Text;

var exercise : EXERCISE;

var step : int;
var grado : String = "0";
var file : String = "";

var artselect = false;
var art1select = false;

var cond = true;

var move = false;

var ejex = false;
var ejey = false;
var ejez = false;

var lastClick : float = 0;
var catchTime : float = .25;
var restriction : Restriction;


function Start () {
	step = 1;
}

function Update () {

}

function OnGUI () {

	if (step == 1)
		primerPaso();
			
	if (step == 2)
		segundoPaso();
	
	if (step == 3)
		tercerPaso();
	
	if (step < 3) {
		if (GUI.Button(Rect(Screen.width-125, Screen.height-50, 100, 30), "Siguiente")){
		   if ((step==2) && (!exercise.finalArt.Equals("")))
	   		step++;
	   	   else
	   	      if (step==1)
	   	         step++;
	   	move = false;
		}      
	}
	   		
	if ((step > 1) && (step <= 3)) {
		if (GUI.Button(Rect(Screen.width-275, Screen.height-50, 100, 30), "Anterior")) {
	   		step--;
	   		cond = true; //
	   		move = false;
	   	}
	}
	
	if (step >= 3) {
		if (GUI.Button(Rect(Screen.width-125, Screen.height-50, 100, 30), "Guardar")) {
			var xmlPath : String = ("C:/Users/User/Documents/PFCGoniometro/" + file);
			exercise.Save(xmlPath);
		}
	}
}


function primerPaso() {

	GUI.Box(Rect(Screen.width-Screen.width/4, 0, Screen.width/4, Screen.height),"Edicion de ejercicio: Paso 1/3\n\nRESTRICCIONES");
	GUI.Label(Rect(Screen.width-Screen.width/4+20, 60, 200, 30), "Articulacion inicial: ");
	GUI.Label(Rect(Screen.width-Screen.width/4+20, 90, 200, 30), "Articulacion final: ");
	
	GUI.Label(Rect(Screen.width-Screen.width/4+20, 300, 200, 30), "Grados: ");
	GUI.Label(Rect(Screen.width-Screen.width/4+200, 60, 200, 30), restriction.initialArt);
	GUI.Label(Rect(Screen.width-Screen.width/4+200, 90, 200, 30), restriction.finalArt);
    GUI.Label(Rect(Screen.width-Screen.width/4+20 , 130, 200, 30), "Rotacion: ");
	GUI.Label(Rect(Screen.width-Screen.width/4+120, 130, 200, 30), "X: ");
	GUI.Label(Rect(Screen.width-Screen.width/4+120, 160, 200, 30), "Y: ");
	GUI.Label(Rect(Screen.width-Screen.width/4+120, 190, 200, 30), "Z: ");
	restriction.grade = parseInt(GUI.TextField(Rect(Screen.width-Screen.width/4+100, 300, 50, 20), restriction.grade.ToString(), 3));
	if (!restriction.finalArt.Equals("")) {
		restriction.x = GameObject.Find(restriction.initialArt).transform.position.x;
		restriction.y = GameObject.Find(restriction.initialArt).transform.position.y;
		restriction.z = GameObject.Find(restriction.initialArt).transform.position.z;
		
		GUI.Label(Rect(Screen.width-Screen.width/4+150, 130, 200, 30), GameObject.Find(restriction.initialArt).transform.rotation.x.ToString());
	    GUI.Label(Rect(Screen.width-Screen.width/4+150, 160, 200, 30), GameObject.Find(restriction.initialArt).transform.rotation.y.ToString());
	    GUI.Label(Rect(Screen.width-Screen.width/4+150, 190, 200, 30), GameObject.Find(restriction.initialArt).transform.rotation.z.ToString());
		

	}
	else {
		restriction.x = 0;
		restriction.y = 0;
		restriction.z = 0;
		GUI.Label(Rect(Screen.width-Screen.width/4+150, 130, 200, 30), "0");
	    GUI.Label(Rect(Screen.width-Screen.width/4+150, 160, 200, 30), "0");
	    GUI.Label(Rect(Screen.width-Screen.width/4+150, 190, 200, 30), "0");
		
	}
	seleccionArt();
	
    if (move)
	   moveArt();
	
	if (GUI.Button(Rect(Screen.width-275, Screen.height-50, 125, 30), "Añadir restriccion")) {
	   	move = false;
	}
}

function segundoPaso() {

	GUI.Box(Rect(Screen.width-Screen.width/4, 0, Screen.width/4, Screen.height), "Edicion de ejercicio: Paso 2/3\n\nMOVIMIENTO: Posicion inicial");

	GUI.Label(Rect(Screen.width-Screen.width/4+20, 70, 200, 30), "Articulacion inicial: ");
	GUI.Label(Rect(Screen.width-Screen.width/4+20, 100, 200, 30), "Articulacion final: ");
	GUI.Label(Rect(Screen.width-Screen.width/4+200, 70, 200, 30), exercise.initialArt);
	GUI.Label(Rect(Screen.width-Screen.width/4+200, 100, 200, 30), exercise.finalArt);
	seleccionArt();
	
	if (move)
		moveArt();
	
	GUI.Label(Rect(Screen.width-Screen.width/4+20 , 130, 200, 30), "Posicion inicial: ");
	GUI.Label(Rect(Screen.width-Screen.width/4+120, 130, 200, 30), "X: ");
	GUI.Label(Rect(Screen.width-Screen.width/4+120, 160, 200, 30), "Y: ");
	GUI.Label(Rect(Screen.width-Screen.width/4+120, 190, 200, 30), "Z: ");
	
	if (!exercise.finalArt.Equals("")) {
		exercise.ini.x = GameObject.Find(exercise.finalArt).transform.position.x.ToString();
		exercise.ini.y = GameObject.Find(exercise.finalArt).transform.position.y.ToString();
		exercise.ini.z = GameObject.Find(exercise.finalArt).transform.position.z.ToString();
	}
	else {
		exercise.ini.x = "0";
		exercise.ini.y = "0";
		exercise.ini.z = "0";
	}
	
	GUI.Label(Rect(Screen.width-Screen.width/4+150, 130, 200, 30), exercise.ini.x);
	GUI.Label(Rect(Screen.width-Screen.width/4+150, 160, 200, 30), exercise.ini.y);
	GUI.Label(Rect(Screen.width-Screen.width/4+150, 190, 200, 30), exercise.ini.z);
}

function tercerPaso() {

	GUI.Box(Rect(Screen.width-Screen.width/4, 0, Screen.width/4, Screen.height),"Edicion de ejercicio: Paso 3/3\n\nMOVIMIENTO: Posicion final");
		
	GUI.Label(Rect(Screen.width-Screen.width/4+20, 70, 200, 30), "Eje: ");
	ejex = GUI.Toggle(Rect(Screen.width-Screen.width/4+70, 70, 200, 30), ejex, " X");
	ejey = GUI.Toggle(Rect(Screen.width-Screen.width/4+110, 70, 200, 30), ejey, " Y");
	ejez = GUI.Toggle(Rect(Screen.width-Screen.width/4+150, 70, 200, 30), ejez, " Z");
	seleccionEje();
	
	GUI.Label(Rect(Screen.width-Screen.width/4+20, 100, 200, 30), "Rotacion: ");
	GUI.Label(Rect(Screen.width-Screen.width/4+100, 100, 200, 30), "Minimo: ");
	GUI.Label(Rect(Screen.width-Screen.width/4+100, 130, 200, 30), "Maximo: ");
	moveArt();
	
	if (cond) {
		cond = false;
		if (ejex)
			exercise.ang.Min = GameObject.Find(exercise.initialArt).transform.rotation.eulerAngles.x.ToString();
		else if (ejey)
			exercise.ang.Min = GameObject.Find(exercise.initialArt).transform.rotation.eulerAngles.y.ToString();
		else if (ejez)
			exercise.ang.Min = GameObject.Find(exercise.initialArt).transform.rotation.eulerAngles.z.ToString();
	}
	
	if (ejex)
		exercise.ang.Max = GameObject.Find(exercise.initialArt).transform.rotation.eulerAngles.x.ToString();
	else if (ejey)
		exercise.ang.Max = GameObject.Find(exercise.initialArt).transform.rotation.eulerAngles.y.ToString();
	else if (ejez)
		exercise.ang.Max = GameObject.Find(exercise.initialArt).transform.rotation.eulerAngles.z.ToString();
	
	GUI.Label(Rect(Screen.width-Screen.width/4+160, 100, 200, 30), exercise.ang.Min);
	GUI.Label(Rect(Screen.width-Screen.width/4+160, 130, 200, 30), exercise.ang.Max);

	GUI.Label(Rect(Screen.width-Screen.width/4+20, 270, 200, 30), "Tiempo: ");
	exercise.time = GUI.TextField(Rect(Screen.width-Screen.width/4+150, 270, 150, 20), exercise.time, 6);

	GUI.Label(Rect(Screen.width-Screen.width/4+20, 300, 200, 30), "Nombre de fichero: ");
	file = GUI.TextField(Rect(Screen.width-Screen.width/4+150, 300, 150, 20), file);
	
}

function seleccionArt() {
	if ((Input.GetKey(KeyCode.LeftShift)) && (Input.GetMouseButtonUp(0))) {
		var ray : Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		var hit : RaycastHit;
		var nameInitialArt = exercise.initialArt;
		var nameFinalArt = exercise.finalArt;
        var iniColor : Color;
        var finalColor : Color;

		if (step ==1)
		{
			iniColor = Color.black;
		    finalColor = Color.black;
		    nameInitialArt = restriction.initialArt;
			nameFinalArt = restriction.finalArt;
		}
		else
		{
			iniColor = Color.green;
		    finalColor = Color.blue;
			nameInitialArt = exercise.initialArt;
			nameFinalArt = exercise.finalArt;
		}


		if ((Physics.Raycast(ray,hit)) && (Time.time-lastClick>catchTime)) {
			if ((!artselect) && (!art1select)) {
				nameInitialArt = hit.collider.gameObject.name;
				hit.collider.gameObject.renderer.material.color = iniColor;
				artselect = true;
			}
			else if ((artselect) && (!art1select) && (hit.collider.gameObject.name.Equals(nameInitialArt))) {
				nameInitialArt = "";
				hit.collider.gameObject.renderer.material.color = Color.white;
				artselect = false;
			}
			else if ((artselect) && (!art1select) && (!hit.collider.gameObject.name.Equals(nameInitialArt))) {
				nameFinalArt = hit.collider.gameObject.name;
				hit.collider.gameObject.renderer.material.color = finalColor;
				art1select = true;
				move = true;  //variable para poder mover solo la articulacion cuando selecciones la art final
			}
			else if ((artselect) && (art1select) && (hit.collider.gameObject.name.Equals(nameFinalArt))) {
				nameFinalArt = "";
				hit.collider.gameObject.renderer.material.color = Color.white;
				art1select = false;
				move = false;
			}
		}
		
		
		if (step == 1){
			 restriction.initialArt = nameInitialArt;
			 restriction.finalArt = nameFinalArt;
		}
		else
		{
			exercise.initialArt = nameInitialArt;
			exercise.finalArt = nameFinalArt;
		}
		
		
		lastClick = Time.time;
	}
}


function moveArt() {
	var ray : Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	var hit : RaycastHit;
	var nameInitialArt;

	if (step ==1)
	    nameInitialArt = restriction.initialArt;
	else
		nameInitialArt = exercise.initialArt;
	
	
	if (Input.GetMouseButton(0)) {		
		if ((Physics.Raycast(ray, hit)) && (hit.collider.gameObject.name.Equals(nameInitialArt))) {
			hit.collider.gameObject.renderer.material.color = Color.red;
			hit.collider.gameObject.transform.rotation = rotarArt(hit.collider.gameObject, 0);
		}
	}
	else if (Input.GetMouseButton(1)) {
		if ((Physics.Raycast(ray, hit)) && (hit.collider.gameObject.name.Equals(nameInitialArt))) {
			hit.collider.gameObject.renderer.material.color = Color.red;
			hit.collider.gameObject.transform.rotation = rotarArt(hit.collider.gameObject, 1);
		}
	}

}


function rotarArt(articulacion, tecla) {
	var newRotation : Quaternion;
	var target : Quaternion;
	var rot : GameObject = articulacion;

	newRotation = Quaternion.Euler(0.0,0.0,0.0);
	
	if (tecla == 0) {
		if (Camera.main.name.Equals("CamaraFrontal"))
			newRotation = Quaternion.Euler(0.0,0.0,0.5)*rot.transform.rotation;
		else if (Camera.main.name.Equals("CamaraDerecha"))
			newRotation = Quaternion.Euler(0.5,0.0,0.0)*rot.transform.rotation;
		else if (Camera.main.name.Equals("CamaraIzquierda"))
			newRotation = Quaternion.Euler(-0.5,0.0,0.0)*rot.transform.rotation;
		else if (Camera.main.name.Equals("CamaraCenital"))
			newRotation = Quaternion.Euler(0.0,0.5,0.0)*rot.transform.rotation;
	}
	else if (tecla == 1) {
		if (Camera.main.name.Equals("CamaraFrontal"))
			newRotation = Quaternion.Euler(0.0,0.0,-0.5)*rot.transform.rotation;
		else if (Camera.main.name.Equals("CamaraDerecha"))
			newRotation = Quaternion.Euler(-0.5,0.0,0.0)*rot.transform.rotation;
		else if (Camera.main.name.Equals("CamaraIzquierda"))
			newRotation = Quaternion.Euler(0.5,0.0,0.0)*rot.transform.rotation;
		else if (Camera.main.name.Equals("CamaraCenital"))
			newRotation = Quaternion.Euler(0.0,-0.5,0.0)*rot.transform.rotation;
	}
		
	return newRotation;
}


function seleccionEje() {
	if (Camera.allCameras[0].name.Equals("CamaraFrontal")) {
		ejex = false;
		ejey = false;
		ejez = true;	
		exercise.eje.X = "0";
		exercise.eje.Y = "0";
		exercise.eje.Z = "1";
	}
	else if (Camera.allCameras[0].name.Equals("CamaraCenital")) {
		ejex = false;
		ejey = true;
		ejez = false;
		exercise.eje.X = "0";
		exercise.eje.Y = "1";
		exercise.eje.Z = "0";
	}
	else if ((Camera.allCameras[0].name.Equals("CamaraDerecha")) || (Camera.allCameras[0].name.Equals("CamaraIzquierda"))) {
		ejex = true;
		ejey = false;
		ejez = false;
		exercise.eje.X = "1";
		exercise.eje.Y = "0";
		exercise.eje.Z = "0";
	}
}