using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;



public class MoveDummy : MonoBehaviour {

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


	public void AddMoveToDummy(){


	}



	public void LoadXml(){
			
		deleteSphere(IniSphere);
		deleteSphere (EndSphere);
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
		rotIni.y = Convert.ToInt16(rotI[0].Attributes["y"].InnerText) - 180;
		rotIni.z = Convert.ToInt16(rotI[0].Attributes["z"].InnerText) + 90;

		//Rotacion final de la articulacion principal
		rotEnd.x = Convert.ToInt16(rotE[0].Attributes["x"].InnerText);
		rotEnd.y = Convert.ToInt16(rotE[0].Attributes["y"].InnerText) - 180;
		rotEnd.z = Convert.ToInt16(rotE[0].Attributes["z"].InnerText) + 90;

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

		ShowMovement();

		loadSphere(IniSphere, artIni,"IniSphere");
//		IniSphere.transform.localRotation = translateArt(artIni).rotation;
		loadSphere (EndSphere, artEnd, "EndSphere");
//		EndSphere.transform.localRotation = translateArt(artEnd).rotation;

//		int val;

		/*Vector3 v = new Vector3(distance(translateArt(artEnd).position.x, translateArt(artIni).position.x),
		                        distance(translateArt(artEnd).position.y, translateArt(artIni).position.y),
		                        distance(translateArt(artEnd).position.z, translateArt(artIni).position.z));*/

//		Vector3 v = new Vector3(distance(initBone.GetX(), translateArt(artIni).position.x),
//		                        distance(initBone.GetY(), translateArt(artIni).position.y),
//		                        distance(initBone.GetZ(), translateArt(artIni).position.z));

//		Vector3 v = new Vector3(translateArt(artIni).position.x + initBone.GetX(),
//		                        translateArt(artIni).position.y + initBone.GetY(),
//		                        translateArt(artIni).position.z + initBone.GetZ());

//		translateArt(artEnd).position = v;
//		translateArt(artIni).LookAt(translateArt(artEnd));



//		Vector3 relativePos = v - translateArt(artIni).position;
//		Quaternion rotation = Quaternion.LookRotation(relativePos);
//		translateArt(artIni).rotation = rotation;

//		Vector3 r = new Vector3();

		//val= CalcAngle( , Ini);

	}



	public void loadSphere(GameObject prefabSphere, int art, string name){
		prefabSphere = Instantiate(prefabSphere, translateArt(art).position, Quaternion.identity) as GameObject;
		prefabSphere.name = name;

		prefabSphere.transform.parent = translateArt(art);
	}


//	public float distance(float right, float left) {
//		if ((right < 0 && left < 0) || (right > 0 && left > 0)) return (right - left);
//		else return (right + left);
//	}
//
//
//	public double CalcAngle (Vector bone, Vector initBone) {
//		double scalarProduct = bone.GetX() * initBone.GetX() + 
//							   bone.GetY() * initBone.GetY() + 
//							   bone.GetZ() * initBone.GetZ();
//		
//		double ModuleBone = System.Math.Sqrt(bone.GetX() * bone.GetX() + 
//		                                     bone.GetY() * bone.GetY() + 
//		                                     bone.GetZ() * bone.GetZ());
//		
//		double ModuleInitBone = System.Math.Sqrt(initBone.GetX() * initBone.GetX() + 
//		                                         initBone.GetY() * initBone.GetY() + 
//		                                         initBone.GetZ() * initBone.GetZ());
//		
//		double cos = scalarProduct / (ModuleBone * ModuleInitBone);
//		
//		double ang = System.Math.Acos(cos) * 180 / System.Math.PI; //se pasa de radianes a grados
//		
//		return ang;	
//	}



	public void ShowMovement() {
		translateArt(artIni).eulerAngles = new Vector3(rotIni.x, rotIni.y, rotIni.z);
		StartCoroutine (RotateArt());
	}

	IEnumerator RotateArt() {
		Vector3 actualRot = translateArt(artIni).transform.eulerAngles;
		while ((Mathf.Round(actualRot.x) != Mathf.Round(rotEnd.x)) ||
		       (Mathf.Round(actualRot.z) != Mathf.Round(rotEnd.z))) {
			translateArt(artIni).transform.Rotate(Vector3.up * 1f);
			actualRot = translateArt(artIni).transform.eulerAngles;
			yield return null;
		}
		translateArt(artIni).transform.eulerAngles = rotEnd;
	}


	public void deleteSphere(GameObject sphere){
		if (sphere != null)
			Destroy(sphere);
	}

	//Traductor entre los joints del fichero de definicion y el skeleton de kinect
	public Transform translateArt(int op) {
		switch (op) {
			case 1:	return GameObject.Find ("Head").transform;
			case 2: return GameObject.Find ("Neck").transform;
			case 3: return GameObject.Find ("Spine1").transform;
			case 6: return GameObject.Find ("LeftArm").transform;
			case 7: return GameObject.Find ("LeftForeArm").transform;
			case 8: return GameObject.Find ("LeftHand").transform;
			case 12: return GameObject.Find ("RightArm").transform;
			case 13: return GameObject.Find ("RightForeArm").transform;
			case 14: return GameObject.Find ("RightHand").transform;
			case 17: return GameObject.Find ("LeftUpLeg").transform;
			case 18: return GameObject.Find ("LeftLeg").transform;
			case 19: return GameObject.Find ("LeftFoot").transform;
			case 21: return GameObject.Find ("RightUpLeg").transform;
			case 22: return GameObject.Find ("RightLeg").transform;
			case 23: return GameObject.Find ("RightFoot").transform;
			default: return GameObject.Find ("Head").transform;
		}
	}

}
