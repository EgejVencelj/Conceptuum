using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LED : BoolOutputElement {

	public BoolOutputElement inputBool;

	void Start() {
		if(inputBool) {
			inputBool.onStateChanged += UpdateState;
		}
	}

	void UpdateState() {
		transform.GetComponentInChildren<Light>().enabled = inputBool.outputBool;
		outputBool = inputBool.outputBool;
	}
}
