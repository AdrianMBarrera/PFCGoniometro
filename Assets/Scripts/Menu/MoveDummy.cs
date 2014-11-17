using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;



public class MoveDummy : MonoBehaviour {

	public Transform Head;
	public Transform Neck;
	public Transform Torso;
	public Transform Waist;
	
	public Transform LeftCollar;
	public Transform LeftShoulder;
	public Transform LeftElbow;
	public Transform LeftWrist;
	public Transform LeftHand;
	public Transform LeftFingertip;
	
	public Transform RightCollar;
	public Transform RightShoulder;
	public Transform RightElbow;
	public Transform RightWrist;
	public Transform RightHand;
	public Transform RightFingertip;
	
	public Transform LeftHip;
	public Transform LeftKnee;
	public Transform LeftAnkle;
	public Transform LeftFoot;
	
	public Transform RightHip;
	public Transform RightKnee;
	public Transform RightAnkle;
	public Transform RightFoot;

	private int arti, arti1, refId, inicio, eje = 0;
	private float minimo, maximo;
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
			
			XmlDocument xDoc = new XmlDocument();
			Debug.Log (Application.dataPath);
			xDoc.Load("./Exercises/"+name);
		Debug.Log(name);
			
			XmlNodeList exer = xDoc.GetElementsByTagName("EXERCISE");	  
			arti = Convert.ToInt16(exer[0].Attributes["initialId"].InnerText);
			arti1 = Convert.ToInt16(exer[0].Attributes["finalId"].InnerText);
			
			XmlNodeList angles = xDoc.GetElementsByTagName("ang");
			XmlNodeList vector = xDoc.GetElementsByTagName("axis");
			XmlNodeList pos0 = xDoc.GetElementsByTagName("ini");
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

			
			refId = Convert.ToInt16(reference[0].Attributes["id"].InnerText);
			referenceArt.SetX(Convert.ToInt16(reference[0].Attributes["x"].InnerText));
			referenceArt.SetY(Convert.ToInt16(reference[0].Attributes["y"].InnerText));
			referenceArt.SetZ(Convert.ToInt16(reference[0].Attributes["z"].InnerText));
			
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

	}

	//Traductor entre los joints del fichero de definicion y el skeleton de kinect
	public Transform art(int op) {
		switch (op) {
			case 1:	return Head;
			case 2: return Neck;
			case 3: return Torso;
			case 4: return Waist;
			case 5: return LeftCollar;
			case 6: return LeftShoulder;
			case 7: return LeftElbow;
			case 8: return LeftWrist;
			case 9: return LeftHand;
			case 10: return LeftFingertip;
			case 11: return RightCollar;
			case 12: return RightShoulder;
			case 13: return RightElbow;
			case 14: return RightWrist;
			case 15: return RightHand;
			case 16: return RightFingertip;
			case 17: return LeftHip;
			case 18: return LeftKnee;
			case 19: return LeftAnkle;
			case 20: return LeftFoot;
			case 21: return RightHip;
			case 22: return RightKnee;
			case 23: return RightAnkle;
			case 24: return RightFoot;
			default: return RightKnee;
		}
	}

}
