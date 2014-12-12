using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;



public class MoveDummyScript : MonoBehaviour {

	public GameObject IniSphere; //prefabs
	public GameObject EndSphere;
	public GameObject ReferenceSphere;
	public GameObject RestrictSpehere;

	//public GameObject DummyPrefab;


	private int artIni, artEnd, refId, inicio, eje = 0;
	private float minimo, maximo;
	private Vector3 rotIni;
	private Vector3 rotEnd;
	Vector plane = new Vector(); // plano de medicion->definido en el fichero de definiciones
	Vector initBone = new Vector(); //posicion inicial del brazo, con respecto a esta posicion se medira
	Vector referenceArt = new Vector();
	// Use this for initialization
	List<Pose> poseList = new List<Pose>();  //Lista de articulaciones a tener en cuenta durante el ejercicio 

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	public void LoadXml(){
			
		deleteSphere("IniSphere");
		deleteSphere ("EndSphere");

		XmlDocument xDoc = new XmlDocument();
		Debug.Log (Application.dataPath);
		xDoc.Load("./Exercises/" + name);
		Debug.Log(name);
			
		XmlNodeList exer = xDoc.GetElementsByTagName("EXERCISE");	  
		artIni = Convert.ToInt16(exer[0].Attributes["initialId"].InnerText);
		artEnd = Convert.ToInt16(exer[0].Attributes["finalId"].InnerText);
			
		XmlNodeList angles = xDoc.GetElementsByTagName("ang");
		XmlNodeList vector = xDoc.GetElementsByTagName("axis");
		XmlNodeList pos0 = xDoc.GetElementsByTagName("ini");
		XmlNodeList rotI = xDoc.GetElementsByTagName("rotIni");
		XmlNodeList rotE = xDoc.GetElementsByTagName("rotEnd");
		XmlNodeList reference = xDoc.GetElementsByTagName ("reference");
		XmlNodeList frames = ((XmlElement)exer[0]).GetElementsByTagName("Restrictions");
		
		//Angulos maximo y minimo de ejercicio
		minimo = Convert.ToInt16(angles[0].Attributes["min"].InnerText);
		maximo = Convert.ToInt16(angles[0].Attributes["max"].InnerText);
		
		//plano sobre el que se va a realizar la medicion
		plane.SetX(Convert.ToInt16(vector[0].Attributes["x"].InnerText));
		plane.SetY(Convert.ToInt16(vector[0].Attributes["y"].InnerText));
		plane.SetZ(Convert.ToInt16(vector[0].Attributes["z"].InnerText));
		
		//posicion de inicio del ejercicio
		initBone.SetX(Convert.ToInt16(pos0[0].Attributes["x"].InnerText));
		initBone.SetY(Convert.ToInt16(pos0[0].Attributes["y"].InnerText));
		initBone.SetZ(Convert.ToInt16(pos0[0].Attributes["z"].InnerText));

		//Rotacion inicial de la articulacion principal
		rotIni.x = Convert.ToInt16(rotI[0].Attributes["x"].InnerText);
		rotIni.y = Convert.ToInt16(rotI[0].Attributes["y"].InnerText);
		rotIni.z = Convert.ToInt16(rotI[0].Attributes["z"].InnerText);

		//Rotacion final de la articulacion principal
		rotEnd.x = Convert.ToInt16(rotE[0].Attributes["x"].InnerText);
		rotEnd.y = Convert.ToInt16(rotE[0].Attributes["y"].InnerText);
		rotEnd.z = Convert.ToInt16(rotE[0].Attributes["z"].InnerText);

	/*	
		refId = Convert.ToInt16(reference[0].Attributes["id"].InnerText);
		referenceArt.SetX(Convert.ToInt16(reference[0].Attributes["x"].InnerText));
		referenceArt.SetY(Convert.ToInt16(reference[0].Attributes["y"].InnerText));
		referenceArt.SetZ(Convert.ToInt16(reference[0].Attributes["z"].InnerText));
	*/		

		/*XmlNodeList ID;
			XmlNodeList ID1;		
			XmlNodeList FX;
			XmlNodeList FY;
			XmlNodeList FZ;
			XmlNodeList G;
			
			foreach (XmlElement frame in frames) {
				
				int i = 0;
				Pose pose = new Pose();	
				ID = frame.GetElementsByTagName("initialId");
				ID1 = frame.GetElementsByTagName("finalId");
				FX = frame.GetElementsByTagName("x");
				FY = frame.GetElementsByTagName("y");
				FZ = frame.GetElementsByTagName("z");
				G = frame.GetElementsByTagName("grade");
				
				//define el hueso que vamos a tener en cuenta
				pose.SetArt(Convert.ToInt16(ID[i].InnerText));
				pose.SetArt1(Convert.ToInt16(ID1[i].InnerText));
				
				//define la posicion correcta para el ejercicio
				Vector aux = new Vector();
				aux.SetX(Convert.ToInt16(FX[i].InnerText));
				aux.SetY(Convert.ToInt16(FY[i].InnerText));
				aux.SetZ(Convert.ToInt16(FZ[i].InnerText));
				pose.SetBone(aux);
				
				//define las restricciones en angulos con respecto a la posicion correcta
				pose.SetGrado(Convert.ToInt16(G[i].InnerText));
				
				//Lista de restricciones del ejercicio
				poseList.Add (pose);
				i++; 
			}*/

		loadSphere(IniSphere, artIni, "IniSphere");
		loadSphere(EndSphere, artEnd, "EndSphere");

		ShowMovement();
	}



	public void loadSphere(GameObject prefabSphere, int art, string name){
		prefabSphere = Instantiate(prefabSphere, translateArt(art).position, Quaternion.identity) as GameObject;
		prefabSphere.name = name;

		prefabSphere.transform.parent = translateArt(art);
	}


	public void ShowMovement() {
		Vector3 reposePos = translateArt(artIni).eulerAngles;
		translateArt(artIni).eulerAngles = new Vector3(rotIni.x, rotIni.y, rotIni.z);
		StartCoroutine (RotateArt(reposePos));
	}

	IEnumerator RotateArt(Vector3 repPos) {
		Vector3 actualRot = translateArt(artIni).transform.eulerAngles;
		while ((Mathf.Round(actualRot.x) != Mathf.Round(rotEnd.x)) ||
		       (Mathf.Round(actualRot.z) != Mathf.Round(rotEnd.z))) {
			translateArt(artIni).transform.Rotate(Vector3.left * 1f);
			actualRot = translateArt(artIni).transform.eulerAngles;
			yield return null;
		}
		translateArt(artIni).transform.eulerAngles = rotEnd;

		while ((Mathf.Round(actualRot.x) != Mathf.Round(rotIni.x)) ||
		       (Mathf.Round(actualRot.z) != Mathf.Round(rotIni.z))) {
			translateArt(artIni).transform.Rotate(Vector3.left * -1f);
			actualRot = translateArt(artIni).transform.eulerAngles;
			yield return null;
		}
		translateArt(artIni).transform.eulerAngles = rotIni;
		
		yield return new WaitForSeconds(1);
		translateArt(artIni).eulerAngles = repPos;
	}


	public void deleteSphere(string name) {
		GameObject go = GameObject.Find(name);

		if (go != null)
			Destroy(go);
	}

	//Traductor entre los joints del fichero de definicion y el skeleton de kinect
	public Transform translateArt(int op) {
		switch (op) {
			case 1:	return GameObject.Find ("Head").transform;
			case 2: return GameObject.Find ("Neck").transform;
			case 3: return GameObject.Find ("Spine1").transform;
			case 6: return GameObject.Find ("JointLeftArm").transform;
			case 7: return GameObject.Find ("LeftForeArm").transform;
			case 8: return GameObject.Find ("LeftHand").transform;
			case 12: return GameObject.Find ("JointRightArm").transform;
			case 13: return GameObject.Find ("RightForeArm").transform;
			case 14: return GameObject.Find ("RightHand").transform;
			case 17: return GameObject.Find ("LeftUpLeg").transform;
			case 18: return GameObject.Find ("JointLeftLeg").transform;
			case 19: return GameObject.Find ("LeftFoot").transform;
			case 21: return GameObject.Find ("RightUpLeg").transform;
			case 22: return GameObject.Find ("JointRightLeg").transform;
			case 23: return GameObject.Find ("RightFoot").transform;
			default: return GameObject.Find ("Head").transform;
		}
	}

}
