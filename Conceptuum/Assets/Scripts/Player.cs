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
                Debug.Log(hit.transform.tag);                
				Transform objectHit = hit.transform;

          
				Switch s = objectHit.GetComponent<Switch>();
				if(s != null) {
					s.Toggle();
				}
				
			}
		}
	}
}
