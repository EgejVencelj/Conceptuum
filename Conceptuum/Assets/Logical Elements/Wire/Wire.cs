using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : BoolOutputElement {
	public BoolOutputElement inputBool;
	Color c;

	void Start() {
		c = GetComponent<MeshRenderer>().materials[0].color;
		c = Color.blue;
		if(inputBool) {
			inputBool.onStateChanged += UpdateState;
		}
	}


	void UpdateState() {
		outputBool = inputBool;
		if(inputBool) {
			c = Color.green;
		}else {
			c = Color.red;
		}
	}
}
