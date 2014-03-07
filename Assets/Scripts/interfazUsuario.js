#pragma strict

function Start () {


}

function Update () {

}

function OnGUI () {
	GUI.Box(Rect(Screen.width-Screen.width/4, 0, Screen.width/4, Screen.height), "Edicion de movimiento:");
	GUI.Label(Rect(Screen.width-Screen.width/4+20, 30, 200, 30), "Articulacion: ");
	GUI.Label(Rect(Screen.width-Screen.width/4+20, 60, 200, 30), "Eje: ");
	GUI.Label(Rect(Screen.width-Screen.width/4+20, 90, 200, 30), "Campo huesos en plano: ");
	GUI.Label(Rect(Screen.width-Screen.width/4+20, 120, 200, 30), "Angulo inicial: ");
	GUI.Label(Rect(Screen.width-Screen.width/4+20, 150, 200, 30), "Angulo final: ");
	
	if (Input.GetMouseButton(0)) {
		var ray : Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		var hit : RaycastHit;
//		var objeto : GameObject;
		
		if (Physics.Raycast(ray,hit)) {
//			objeto = hit.collider.gameObject;
			GUI.Label(Rect(Screen.width-Screen.width/4+100, 30, 200, 30), hit.collider.gameObject.name);
//			var x = hit.collider.gameObject.transform.localRotation.x;
			GUI.Label(Rect(Screen.width-Screen.width/4+100, 60, 200, 30), hit.collider.gameObject.transform.rotation.x.ToString());
			GUI.Label(Rect(Screen.width-Screen.width/4+100, 90, 200, 30), hit.collider.gameObject.transform.rotation.y.ToString());
			GUI.Label(Rect(Screen.width-Screen.width/4+100, 120, 200, 30), hit.collider.gameObject.transform.rotation.z.ToString());
		}
	}
//	if (Input.anyKey)
//		GUI.Label(Rect(Screen.width-Screen.width/4+100, 15, 200, 30), "pulsar");

//	GUI.Box(Rect(Screen.width-Screen.width/4, 0, Screen.width/4, Screen.height), "menu de prueba jose");
//	GUI.Label(Rect(Screen.width-Screen.width/4+100, 15, 200, 30), "pruebita");
////	if (GUI.Button(Rect(Screen.width/2-50, Screen.height/2-15, 100, 30), "Mi boton")) {
////		salud -= 10;
////	}
////	GUI.Label(Rect(Screen.width/2-100, Screen.height/2+20, 200, 30), "SALUD: " + salud);
}