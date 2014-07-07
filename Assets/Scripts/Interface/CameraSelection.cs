using UnityEngine;
using System.Collections;

public class CameraSelection : MonoBehaviour {

	public Camera FrontCam;
	public Camera BackCam;
	public Camera RightCam;
	public Camera LeftCam;
	public Camera AerialCam;

	// Use this for initialization
	void Start () {
		FrontCam.enabled = true;
		BackCam.enabled	= false;
		RightCam.enabled = false;
		LeftCam.enabled = false;
		AerialCam.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("1")) {
			FrontCam.enabled = true;
			BackCam.enabled	= false;
			RightCam.enabled = false;
			LeftCam.enabled = false;
			AerialCam.enabled = false;
		}
		
		if (Input.GetKeyDown("2")) {
			FrontCam.enabled = false;
			BackCam.enabled	= true;
			RightCam.enabled = false;
			LeftCam.enabled = false;
			AerialCam.enabled = false;
		}
		
		if (Input.GetKeyDown("3")) {
			FrontCam.enabled = false;
			BackCam.enabled	= false;
			RightCam.enabled = true;
			LeftCam.enabled = false;
			AerialCam.enabled = false;
		}
		
		if (Input.GetKeyDown("4")) {
			FrontCam.enabled = false;
			BackCam.enabled	= false;
			RightCam.enabled = false;
			LeftCam.enabled = true;
			AerialCam.enabled = false;
		}
		
		if (Input.GetKeyDown("5")) {
			FrontCam.enabled = false;
			BackCam.enabled	= false;
			RightCam.enabled = false;
			LeftCam.enabled = false;
			AerialCam.enabled = true;
		}
	}
}
