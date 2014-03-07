#pragma strict

function Start () {

}

function Update () {

}

function OnGUI () {
	GUI.Box(Rect(Screen.width-Screen.width/4, 0, Screen.width/4, Screen.height), "menu de prueba jose");
	GUI.Label(Rect(Screen.width-Screen.width/4+100, 15, 200, 30), "pruebita");
//	if (GUI.Button(Rect(Screen.width/2-50, Screen.height/2-15, 100, 30), "Mi boton")) {
//		salud -= 10;
//	}
//	GUI.Label(Rect(Screen.width/2-100, Screen.height/2+20, 200, 30), "SALUD: " + salud);
}