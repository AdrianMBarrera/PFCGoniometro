﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class CreateButtonScript : MonoBehaviour {
	public GameObject prefabButton;
	private RectTransform rectTransform;
	// Use this for initialization
	void Start () {
		ReadXml();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("fdafdasfasdf" + rectTransform.rect);
	}

	public void CreateButton(float y, string name){

		prefabButton = Instantiate(prefabButton,prefabButton.transform.position, Quaternion.identity) as GameObject;
//		prefabButton.transform.parent = this.transform;
		prefabButton.transform.SetParent(this.transform, false);

		rectTransform = prefabButton.GetComponent<RectTransform>();
		rectTransform.anchoredPosition = new Vector2 (1f, y);
		rectTransform.sizeDelta = new Vector2 (-45,40);
		prefabButton.name = name;
		Text t = prefabButton.GetComponentInChildren<Text>();


		t.text = name.Substring(0,name.Length-4);

	}

	public void ReadXml(){
		float y = -20f;
		DirectoryInfo di = new DirectoryInfo("./Exercises");
		FileInfo[] files = di.GetFiles();

		foreach (FileInfo fi in files)
		{
			if (fi.Extension.Contains("xml")) {
				CreateButton(y, fi.Name);
				y -=40;
			}
		}

	}
}
