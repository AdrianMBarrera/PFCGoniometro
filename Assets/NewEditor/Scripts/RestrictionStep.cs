using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RestrictionStep : MonoBehaviour {

	private Exercise exercise;
	private Text initArt;
	private Text finalArt;
	private Text restX;
	private Text restY;
	private Text restZ;
	private Text grades;
	private Restriction restriction = new Restriction();

	private bool selectInitial = false; // variable para controlar la seleccion de la articulacion inicial
	private bool selectFinal = false; // variable para controlar la seleccion de la articulacion final
	private float lastClick = 0.0f;
	private float catchTime = 1.0f;
	private RotateSphere sphereScript; //Script de la esfera
	public Material wood;
	private int cont = 0;
	
	// Use this for initialization
	void Start () {
		sphereScript = GameObject.Find ("Esfera_Movimiento").GetComponent<RotateSphere>();
		exercise = GameObject.Find("ManagerInterface").GetComponent<ManagerExerciseEditor>().exercise;
		initArt = GameObject.Find("RestInitialArticulation").GetComponent<Text>();
		finalArt = GameObject.Find("RestFinalArticulation").GetComponent<Text>();
		restX = GameObject.Find("RestX").GetComponent<Text>();
		restY = GameObject.Find("RestY").GetComponent<Text>();
		restZ = GameObject.Find("RestZ").GetComponent<Text>();
		grades = GameObject.Find("GradesInputField").GetComponentInChildren<Text>();
	}


	// Update is called once per frame
	void Update () {

//		if (Input.GetMouseButtonUp(0)){
//			artSelection();
//
//
//		}
//		ShowRestRotation();

	}


	void ShowRestRotation(){

		if (!restriction.finalArt.Equals("")) {
			
			restriction.x = (int) Mathf.Round(GameObject.Find(restriction.finalArt).transform.position.x)
				- (int) Mathf.Round(GameObject.Find(restriction.initialArt).transform.position.x);
			
			restriction.y = (int) Mathf.Round(GameObject.Find(restriction.finalArt).transform.position.y)
				- (int) Mathf.Round(GameObject.Find(restriction.initialArt).transform.position.y);
			
			restriction.z = (int) Mathf.Round(GameObject.Find(restriction.finalArt).transform.position.z)
				- (int) Mathf.Round(GameObject.Find(restriction.initialArt).transform.position.z);
			
			restriction.rotX = (int) Mathf.Round(GameObject.Find(restriction.initialArt).transform.eulerAngles.x);
			restriction.rotY = (int) Mathf.Round(GameObject.Find(restriction.initialArt).transform.eulerAngles.y);
			restriction.rotZ = (int) Mathf.Round(GameObject.Find(restriction.initialArt).transform.eulerAngles.z);

			restX.text = "X: "+ restriction.rotX.ToString();
			restY.text = "Y: "+ restriction.rotY.ToString();
			restZ.text = "Z: "+ restriction.rotZ.ToString();

		}
		else{
			restX.text = "X: ";
			restY.text = "Y: ";
			restZ.text = "Z: ";
			
		}
	}



	public void AddRestriction(){

		if ((grades.text != null) && (grades.text.CompareTo("")!= 0))
		restriction.grade =  int.Parse(grades.text);
		exercise.Restrictions.Add(restriction);
		restriction = new Restriction();
		selectInitial = false;
		selectFinal = false;

	}


	public void PassToManager(){
		GameObject.Find("ManagerInterface").GetComponent<ManagerExerciseEditor>().exercise = exercise;

	}




//
//	public void Step1restriction() {
//
//		//	if (GUI.Button(Rect(Screen.width-275, Screen.height-30, 125, 30), "View restrictions")) {
////		int i = 0;
////		foreach (Restriction r in exercise.Restrictions) {
////			GUI.Label(new Rect(Screen.width-Screen.width/4+20, 400+(i*30), 300, 30), "restriction " + i + ": " + 
////			          r.initialArt + ", " + r.finalArt);
////			i++;
////		}
//
//	}


	public void artSelection() {
		 
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			string nameInitialArt = restriction.initialArt;
			string nameFinalArt = restriction.finalArt;

			Color iniColor = Color.black;
			Color finalColor = Color.black;
			
			if ((Physics.Raycast(ray, out hit)) && ((Time.time-lastClick) > catchTime)) {
				
				if ((!selectInitial) && (!selectFinal)) {
					nameInitialArt = hit.collider.gameObject.name;
					hit.collider.gameObject.renderer.material.color = iniColor;
					selectInitial = true;
					initArt.text += nameInitialArt; // poner en la gui art inicial
				}
				else if ((selectInitial) && (!selectFinal) && (hit.collider.gameObject.name.Equals(nameInitialArt))) {
					nameInitialArt = "";
					hit.collider.gameObject.renderer.material = wood;
					selectInitial = false;
					initArt.text = "Initial articulation: ";
				}
				else if ((selectInitial) && (!selectFinal) && (!hit.collider.gameObject.name.Equals(nameInitialArt))) {
					nameFinalArt = hit.collider.gameObject.name;
					hit.collider.gameObject.renderer.material.color = finalColor;
					selectFinal = true;
					finalArt.text += nameFinalArt; // poner en la gui art inicial
					sphereScript.Art = nameInitialArt; // Articulacion que tiene que rotar la esfera 
				}
				else if ((selectInitial) && (selectFinal) && (hit.collider.gameObject.name.Equals(nameFinalArt))) {
					nameFinalArt = "";
					hit.collider.gameObject.renderer.material = wood;
					selectFinal = false;
					finalArt.text = "Final articulation: ";
				}
			}

			restriction.initialArt = nameInitialArt;
			restriction.finalArt = nameFinalArt;


			
			lastClick = Time.time;

	}

	public void Hello (){


		Debug.Log("Felicidades hijo de puta rumenabo");
	}



}
