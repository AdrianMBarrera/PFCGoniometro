#pragma strict

var camf : Camera;
var camt : Camera;
var camd : Camera;
var cami : Camera;
var camc : Camera;

function Start () {
	camf.enabled = true;
	camt.enabled = false;
	camd.enabled = false;
	cami.enabled = false;
	camc.enabled = false;
}

function Update () {
	if (Input.GetKeyDown("1")) {
		camf.enabled = true;
		camt.enabled = false;
		camd.enabled = false;
		cami.enabled = false;
		camc.enabled = false;
	}

	if (Input.GetKeyDown("2")) {
		camf.enabled = false;
		camt.enabled = true;
		camd.enabled = false;
		cami.enabled = false;
	    camc.enabled = false;
	}

	if (Input.GetKeyDown("3")) {
		camf.enabled = false;
		camt.enabled = false;
		camd.enabled = true;
		cami.enabled = false;
		camc.enabled = false;
	}

	if (Input.GetKeyDown("4")) {
		camf.enabled = false;
		camt.enabled = false;
		camd.enabled = false;
		cami.enabled = true;
		camc.enabled = false;
	}
	
	if (Input.GetKeyDown("5")) {
		camf.enabled = false;
		camt.enabled = false;
		camd.enabled = false;
		cami.enabled = false;
		camc.enabled = true;
	}
}