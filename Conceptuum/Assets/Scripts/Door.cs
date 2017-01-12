using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
	public Animator anim;

	void OnTriggerEnter(Collider col) {
		if(col.gameObject.tag == "Player") {
			anim.SetTrigger("Open");
		}
	}


	void OnTriggerExit(Collider col) {
		if(col.gameObject.tag == "Player") {
			anim.ResetTrigger("Open");
		}
	}

}
