using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour {
	
	private Text t; //texto loading
	private Canvas LS; //LoadingScreen
	private float delay = 0f;
	// Use this for initialization
	void Start () {
		t = GetComponent<Text>();
		t.text = "Loading";
		LS = GameObject.Find("LoadingScreen").GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
		delay += 0.35f;
		StartCoroutine(LoadingCoroutine(delay));
		StartCoroutine("EndLoadingCoroutine");

	

	}

	IEnumerator LoadingCoroutine (float delay){
		yield return new WaitForSeconds(delay);
		if (t.text == "Loading...")
			t.text ="Loading";
		else
			t.text += ".";
	}

	IEnumerator EndLoadingCoroutine(){
		yield return new WaitForSeconds(3f);
		LS.enabled = false;
	}

}
