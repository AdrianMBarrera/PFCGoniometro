using UnityEngine;
using System.Collections;

public class InterfaceGUI : MonoBehaviour {

	int toolbarInt = 0;
	string[] toolbarStrings = new string[] {"Restrictions", "Start position", "Final position", "Save"};

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUI.Box(new Rect(Screen.width-Screen.width/3, 0, Screen.width/3, Screen.height),"\nMOVEMENTS INTERFACE");

		toolbarInt = GUI.Toolbar (new Rect (Screen.width - Screen.width/3 + 30, 50, 400, 25), toolbarInt, toolbarStrings);
		
//		switch (toolbarInt) {			
//			case 0: //condRest = true;
//					//step1();
//					break;
//				
//			case 1: //condRest = false;
//					//step2();
//					break;
//				
//			case 2: //condRest = false;
//					//step3();
//					break;
//				
//			case 3: //condRest = false;
//					//saveExercise();
//					break;
//				
//			default: Debug.Log("Ninguna opcion valida.");
//		}
	}
}
