using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

			if(Physics.Raycast(ray, out hit)) {
				Transform objectHit = hit.transform;

				//Debug.Log(objectHit.name);
				Switch s = objectHit.GetComponent<Switch>();
				if(s != null) {
					s.Toggle();
				}
				// Do something with the object that was hit by the raycast.
			}
		}
	}
}
