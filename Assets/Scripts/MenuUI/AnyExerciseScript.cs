using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnyExerciseScript : MonoBehaviour {

	private Text helper; // texto de ayuda
	private LoadingScript loading; // llamar a pasar de nivel
	// Use this for initialization
	void Start () {
		helper = GameObject.Find("HelpText").GetComponent<Text>();
		helper.enabled = false;
		helper.text = "Please, Select any exercise";
		loading = GameObject.Find("Veil").GetComponent <LoadingScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void AnyExercise(string nameLevel){

		if (InfoPlayer.alExercise.Count < 1){
			StartCoroutine("HelpCoroutine");

		}else{
			loading.BeginLevel(nameLevel);

		}

	}



	IEnumerator HelpCoroutine(){
		helper.enabled = true;
		yield return new  WaitForSeconds (3f);
		helper.enabled = false;


	}

}
