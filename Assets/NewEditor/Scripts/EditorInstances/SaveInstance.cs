using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Xml;
using System.IO;

public class SaveInstance : MonoBehaviour {

	private Instance instance;

	private Text nameExercise;
	private InputField repExercise;
	private InputField timeExercise;
	private InputField nameFile;
	private Text helpText;

	// Use this for initialization
	void Start () {

		nameExercise = GameObject.Find("ExerciseText").GetComponent<Text>();
		helpText = GameObject.Find("HelpText").GetComponent<Text>();
		nameFile = GameObject.Find("InstanceInputField").GetComponent<InputField>();
		repExercise = GameObject.Find("RepeatInputField").GetComponent<InputField>();
		timeExercise = GameObject.Find("TimeInputField").GetComponent<InputField>();
		instance = new Instance();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Save(){

		if ((nameFile.text != null) && (nameFile.text.CompareTo("")!= 0) &&
		    (nameExercise.text != null) && (nameExercise.text.CompareTo("")!= 0) &&
		    (repExercise.text != null) && (repExercise.text.CompareTo("")!= 0) &&
		    (timeExercise.text != null) && (timeExercise.text.CompareTo("")!= 0)
		    ){
			string xmlPath =  "./Instances";
			if (!Directory.Exists(xmlPath))
				Directory.CreateDirectory(xmlPath);
			instance.name = nameExercise.text;
			instance.time = int.Parse(timeExercise.text);
			instance.repetitions = int.Parse(repExercise.text);
			instance.Save(Path.Combine(xmlPath, nameFile.text + ".xml"));
			StartCoroutine(ShowMessage(4));
		}
	}

	IEnumerator ShowMessage(float delay) {
		helpText.enabled = true;
		yield return new WaitForSeconds(delay);
		helpText.enabled = false;
	}


}
