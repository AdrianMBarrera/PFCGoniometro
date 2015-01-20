using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Xml;
using System.IO;

public class SaveScript : MonoBehaviour {

	private Text nameFile;
	private Exercise exercise; //Ejercicio que estamos editando sacado del manager exercise
	private Material wood;

	void Start(){
		wood = GameObject.Find("ManagerInterface").GetComponent<ManagerExerciseEditor>().wood;
		nameFile = GameObject.Find("FileInputField").GetComponentInChildren<Text>();
		exercise = GameObject.Find("ManagerInterface").GetComponent<ManagerExerciseEditor>().exercise;
	}


	public void SaveExercise(){
		if ((nameFile.text != null) && (nameFile.text.CompareTo("")!= 0)){
			string xmlPath =  "./Exercises";
			if (!Directory.Exists(xmlPath))
				Directory.CreateDirectory(xmlPath);

			exercise.initialId = searchIdArt(exercise.initialArt);
			exercise.finalId = searchIdArt(exercise.finalArt);
			for (var i = 0; i < exercise.Restrictions.Count; i++) {
				exercise.Restrictions[i].initialId = searchIdArt(exercise.Restrictions[i].initialArt);
				exercise.Restrictions[i].finalId = searchIdArt(exercise.Restrictions[i].finalArt);
			}
			
			exercise.Save(Path.Combine(xmlPath, nameFile.text + ".xml"));
			
			StartCoroutine(ShowMessage(5));
	
		}

	}

	public void ShowMovement() {
		if (GameObject.Find(exercise.finalArt).GetComponent<TrailRenderer>() == null) {
			GameObject.Find(exercise.initialArt).transform.eulerAngles = new Vector3(float.Parse (exercise.rotIni.x),
			                                                                         float.Parse (exercise.rotIni.y),
			                                                                         float.Parse (exercise.rotIni.z));
			
			TrailRenderer trail = GameObject.Find(exercise.finalArt).AddComponent<TrailRenderer>();
			
			//			trail.material = new Material (Shader.Find("Particles/Additive"));
			
//			trail.startWidth = 0.1f;
//			trail.endWidth = 0.01f;
//			trail.time = Mathf.Infinity;
			
			StartCoroutine (RotateMe(trail));
		}
		
	}
	IEnumerator RotateMe(TrailRenderer t) {
		Vector3 actualRot = GameObject.Find(exercise.initialArt).transform.eulerAngles;
		while ((Mathf.Round(actualRot.x) != Mathf.Round(float.Parse (exercise.rotEnd.x))) ||
		       (Mathf.Round(actualRot.z) != Mathf.Round(float.Parse (exercise.rotEnd.z)))) {
			GameObject.Find(exercise.initialArt).transform.Rotate(Vector3.left * 1f);
			actualRot = GameObject.Find(exercise.initialArt).transform.eulerAngles;
			yield return null;
		}
		GameObject.Find(exercise.initialArt).transform.eulerAngles = new Vector3(float.Parse (exercise.rotEnd.x),
		                                                                         float.Parse (exercise.rotEnd.y),
		                                                                         float.Parse (exercise.rotEnd.z));
		Destroy(t);
	}


	IEnumerator ShowMessage(float delay) {

		yield return new WaitForSeconds(delay);
		GUI.Label(new Rect(10, 10, 200, 30), "File saved!");
		ResetExercise();
	}

	int searchIdArt (string name) {
		switch (name) {
		case "Head":			return 1;
		case "Neck":			return 2;
		case "Chest":			return 3;
		case "Spine": 			return 4;
		case "LeftCollar": 		return 5;
		case "LeftShoulder":	return 6;
		case "LeftElbow":		return 7;
		case "LeftWrist":		return 8;
		case "LeftHand":		return 9;
		case "LeftFingertip": 	return 10;
		case "RightCollar": 	return 11;
		case "RightShoulder": 	return 12;
		case "RightElbow": 		return 13;
		case "RightWrist": 		return 14;
		case "RightHand": 		return 15;
		case "RightFingertip": 	return 16;
		case "LeftHip": 		return 17;
		case "LeftKnee": 		return 18;
		case "LeftAnkle": 		return 19;
		case "LeftFoot": 		return 20;
		case "RightHip": 		return 21;
		case "RightKnee": 		return 22;
		case "RightAnkle": 		return 23;
		case "RightFoot": 		return 24;
		default: return 0;
		}
	}



	public void ResetExercise() {
//		
//		if (!exercise.finalArt.Equals(""))
//			GameObject.Find(exercise.finalArt).renderer.material = wood;
//		
//		if (!exercise.initialArt.Equals("")) {
//			GameObject.Find(exercise.initialArt).renderer.material = wood;
//			GameObject.Find(exercise.initialArt).transform.eulerAngles = new Vector3(0,180,0);
//		}
//		
//		if (!restriction.finalArt.Equals(""))
//			GameObject.Find(restriction.finalArt).renderer.material = wood;
//		
//		if (!restriction.initialArt.Equals("")) {
//			GameObject.Find(restriction.initialArt).renderer.material = wood;
//			GameObject.Find(restriction.initialArt).transform.eulerAngles = new Vector3(0,180,0);
//		}
//		
//		foreach (Restriction r in exercise.Restrictions) {
//			GameObject.Find(r.initialArt).renderer.material = wood;
//			GameObject.Find(r.finalArt).renderer.material = wood;
//			GameObject.Find(r.initialArt).transform.eulerAngles = new Vector3(0,180,0);
//		}
//
//		exercise = new Exercise();
////		restriction = new Restriction();
//
		Destroy(GameObject.Find("RestrictionsInterface").GetComponent<RestrictionScript>());
		GameObject.Find("RestrictionsInterface").AddComponent<RestrictionScript>();
//		
//		selectInitial = false;
//		selectFinal = false;
//		
////		plano.renderer.enabled = false;
////		line.renderer.enabled = false;
//		
//		nameFile.text = "";
//
////		move = false;
////		condRef = false;
////		condRest = false;
//		//		condMessage = false;
	}









}


