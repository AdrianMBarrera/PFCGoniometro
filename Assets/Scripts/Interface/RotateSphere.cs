using UnityEngine;
using System.Collections;

public class RotateSphere : MonoBehaviour {

	public float Speed = 5f;
	public string Art = "";
	public int Step = 0;

	bool selectBlue	 = true;
	bool selectGreen = true;
	bool selectRed	 = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update() {
		if ((!Art.Equals("")) && (Step < 2)) {
			transform.position = GameObject.Find(Art).transform.position;
			transform.rotation = GameObject.Find(Art).transform.rotation;

			if (Input.GetMouseButtonUp(0)) {
				selectBlue 	= true;
				selectGreen = true;
				selectRed 	= true;
			}

			if (Input.GetMouseButton(0)) {
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;

				if ((selectBlue) && (Physics.Raycast(ray, out hit)) && (hit.collider.gameObject.name.Equals("blueCircle"))) {
					selectGreen = false;
					selectRed = false;
					transform.Rotate(Vector3.right * Input.GetAxis("Mouse Y") * Speed);
					GameObject.Find(Art).transform.rotation = transform.rotation;
				}
				else if ((selectGreen) && (Physics.Raycast(ray, out hit)) && (hit.collider.gameObject.name.Equals("greenCircle"))) {
					selectBlue = false;
					selectRed = false;
					transform.Rotate(Vector3.back * Input.GetAxis("Mouse Y") * Speed);
					GameObject.Find(Art).transform.rotation = transform.rotation;
				}
				else if ((selectRed) && (Physics.Raycast(ray, out hit)) && (hit.collider.gameObject.name.Equals("redCircle"))) {
					selectBlue = false;
					selectGreen	= false;
					transform.Rotate(Vector3.down * Input.GetAxis("Mouse X") * Speed);
					GameObject.Find(Art).transform.rotation = transform.rotation;
				}
			}
		}
	}
}
