#pragma strict

var camf : Camera;
var camt : Camera;
var camd : Camera;
var cami : Camera;
var camc : Camera;
//var planoX : GameObject;
//var planoY : GameObject;
//var planoZ : GameObject;

function Start () {
	camf.enabled = true;
	camt.enabled = false;
	camd.enabled = false;
	cami.enabled = false;
	camc.enabled = false;
	
//	planoX = GameObject.CreatePrimitive(PrimitiveType.Cube);
//	planoX.name = "PlanoX";
//	planoX.transform.localScale.x = 0;
//	planoX.transform.localScale.y = 8;
//	planoX.transform.localScale.z = 6;
//	planoX.transform.position.x = 0.5;
//	planoX.transform.position.y = 0;
//	planoX.transform.position.z = -0.1;
//	planoX.renderer.material.shader = Shader.Find("Transparent/Diffuse");
//	planoX.renderer.material.color = Color(0,1,0,0.2);
//	planoX.renderer.enabled=false;
//	
//	planoY = GameObject.CreatePrimitive(PrimitiveType.Cube);
//	planoY.name = "PlanoY";
//	planoY.transform.localScale.x = 6;
//	planoY.transform.localScale.y = 0;
//	planoY.transform.localScale.z = 6;
//	planoY.transform.position.x = 0.5;
//	planoY.transform.position.y = 0;
//	planoY.transform.position.z = -0.1;
//	planoY.renderer.material.shader = Shader.Find("Transparent/Diffuse");
//	planoY.renderer.material.color = Color(0,1,0,0.2);
//	planoY.renderer.enabled=false;
	
//	planoZ = GameObject.CreatePrimitive(PrimitiveType.Cube);
//	planoZ.name = "PlanoZ";
//	planoZ.transform.localScale.x = 6;
//	planoZ.transform.localScale.y = 8;
//	planoZ.transform.localScale.z = 0;
//	planoZ.transform.position.x = 0.5;
//	planoZ.transform.position.y = 0;
//	planoZ.transform.position.z = -0.1;
//	planoZ.renderer.material.shader = Shader.Find("Transparent/Diffuse");
//	planoZ.renderer.material.color = Color(0,1,0,0.2);
//	planoZ.renderer.enabled=true;
	
}

function Update () {
	if (Input.GetKeyDown("1")) {
		camf.enabled = true;
		camt.enabled = false;
		camd.enabled = false;
		cami.enabled = false;
		camc.enabled = false;
//		planoX.renderer.enabled=false;
//		planoY.renderer.enabled=false;
//		planoZ.renderer.enabled=true;
	}

	if (Input.GetKeyDown("2")) {
		camf.enabled = false;
		camt.enabled = true;
		camd.enabled = false;
		cami.enabled = false;
	    camc.enabled = false;
//	   	planoX.renderer.enabled=false;
//		planoY.renderer.enabled=false;
//		planoZ.renderer.enabled=true;
	}

	if (Input.GetKeyDown("3")) {
		camf.enabled = false;
		camt.enabled = false;
		camd.enabled = true;
		cami.enabled = false;
		camc.enabled = false;
//		planoX.renderer.enabled=true;
//		planoY.renderer.enabled=false;
//		planoZ.renderer.enabled=false;
	}

	if (Input.GetKeyDown("4")) {
		camf.enabled = false;
		camt.enabled = false;
		camd.enabled = false;
		cami.enabled = true;
		camc.enabled = false;
//		planoX.renderer.enabled=true;
//		planoY.renderer.enabled=false;
//		planoZ.renderer.enabled=false;
	}
	
	if (Input.GetKeyDown("5")) {
		camf.enabled = false;
		camt.enabled = false;
		camd.enabled = false;
		cami.enabled = false;
		camc.enabled = true;
//		planoX.renderer.enabled=false;
//		planoY.renderer.enabled=true;
//		planoZ.renderer.enabled=false;
	}
}