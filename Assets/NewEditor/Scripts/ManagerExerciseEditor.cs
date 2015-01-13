using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Xml;
using System.IO;
using System.Text;


public class ManagerExerciseEditor : MonoBehaviour {
	
	public LineRenderer line;
	public Exercise exercise = new Exercise();
	public GameObject plano;

	private RestrictionStep firstStep;

	private GameObject restrictionI;
	private GameObject startPositionI;
	private GameObject finalPositionI;
	private GameObject saveI;




	
	// Use this for initialization
	void Start () {

		restrictionI = GameObject.Find("RestrictionsInterface");
		startPositionI = GameObject.Find("StartPositionInterface");
		finalPositionI = GameObject.Find("FinalPositionInterface");
		saveI = GameObject.Find("SaveInterface");

		plano = GameObject.CreatePrimitive(PrimitiveType.Cube);
		plano.name = "Plano";
		plano.transform.localScale = new Vector3(0.05f, 7f, 7f);
		plano.collider.enabled = false;
		plano.renderer.enabled = false;
		firstStep = GameObject.Find("RestrictionsInterface").GetComponent<RestrictionStep>();
		
	//	sphereScript = GameObject.Find ("Esfera_Movimiento").GetComponent<RotateSphere>();
		
//		line = gameObject.AddComponent<LineRenderer>();
//		line.SetWidth(0.05f, 0.05f);
//		line.SetVertexCount(2);
//		line.material = new Material (Shader.Find("Particles/Additive"));
//		line.SetColors(Color.red, Color.red);
//		line.renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (restrictionI.GetComponent<Canvas>().enabled){
			restrictionI.GetComponent<RestrictionStep>().enabled = true;

		}
		if (startPositionI.GetComponent<Canvas>().enabled){
			restrictionI.GetComponent<RestrictionStep>().enabled = false;
			
		}

		if (finalPositionI.GetComponent<Canvas>().enabled){
			restrictionI.GetComponent<RestrictionStep>().enabled = false;
			
		}

		if (saveI.GetComponent<Canvas>().enabled){
			restrictionI.GetComponent<RestrictionStep>().enabled = false;
			
		}
	}

}
