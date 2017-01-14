using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LED : BoolOutputElement {

	public Material onMaterial;
	public Material offMaterial;

	public BoolOutputElement inputBool;

	void Start() {
		if(inputBool) {
			inputBool.onStateChanged += UpdateState;
		}
		UpdateState();
	}

	void UpdateState() {
		var shining = inputBool.outputBool is bool && (bool)inputBool.outputBool;
		transform.GetComponentInChildren<Light>().enabled = shining;
		transform.FindChild("Bulb").GetComponent<MeshRenderer>().material = shining ? onMaterial : offMaterial;

		outputBool = inputBool.outputBool;
	}
}
