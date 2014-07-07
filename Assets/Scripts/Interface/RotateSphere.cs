using UnityEngine;
using System.Collections;

public class RotateSphere : MonoBehaviour {

	public float Speed = 5f;
	public string Art = "";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!Art.Equals("")) {
			transform.position = GameObject.Find(Art).transform.position;
			
			if (Input.GetMouseButton(0)) {
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				
				if ((Physics.Raycast(ray, out hit)) && (hit.collider.gameObject.name.Equals("blueCircle"))) {
					transform.Rotate(Vector3.right * Input.GetAxis("Mouse Y") * Speed);
					GameObject.Find(Art).transform.rotation = transform.rotation;
				}
				else if ((Physics.Raycast(ray, out hit)) && (hit.collider.gameObject.name.Equals("greenCircle"))) {
					transform.Rotate(Vector3.back * Input.GetAxis("Mouse Y") * Speed);
					GameObject.Find(Art).transform.rotation = transform.rotation;
				}
				else if ((Physics.Raycast(ray, out hit)) && (hit.collider.gameObject.name.Equals("redCircle"))) {
					transform.Rotate(Vector3.down * Input.GetAxis("Mouse X") * Speed);
					GameObject.Find(Art).transform.rotation = transform.rotation;
				}
			}
		}
	}
}
