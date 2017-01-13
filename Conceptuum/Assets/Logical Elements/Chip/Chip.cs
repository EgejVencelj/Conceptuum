using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class Chip : BoolOutputElement {   

	public enum ChipType {
		AND=0,
		OR=1,
		XOR=2
	}
	

	public Socket attachedSocket;
	public ChipType chipType = ChipType.AND;

	public List<BoolOutputElement> inputBools;


	void Start() {
		//nalep teksturo na podlagi chipTypa
		if(attachedSocket != null) {
			Attach(attachedSocket);
		}
	}


	void UpdateState () {
		if (attachedSocket) {
			bool r = false;

			int n = attachedSocket.inputBools.Count;

			if (n >= 2) {
				r = Logic(
						inputBools[0].outputBool,
						inputBools[1].outputBool
					);
				for(int i = 2; i<n; i++) {
					r = Logic(r, inputBools[i].outputBool);
				}
			}

			attachedSocket.GetComponent<BoolOutputElement>().outputBool = r;	
		}
	}

	private bool Logic(bool a, bool b) {
		switch(chipType) {
			case ChipType.AND: {
				return a && b;
			}
			case ChipType.OR: {
				return a || b;
			}
			case ChipType.XOR: {
				return a ^ b;
			}
		}
		return false;
	}

	public void Attach(Socket s) {
		inputBools = s.inputBools;

		//Se prijavimo na state change parentov
		foreach(BoolOutputElement p in inputBools) {
			/*if(p.transform == this.transform) {
				Debug.LogError("Detected infinite loop on selected chip.");
				Selection.activeGameObject = this.gameObject;
				continue;
				//We dont want loops
			}*/
			p.onStateChanged += UpdateState;
		}
	}

	public void Unattach() {
		//Se odjavimo
		foreach(BoolOutputElement p in inputBools) {
			if(p.transform == this.transform) {
				Debug.LogError("Detected infinite loop on selected chip.");
				Selection.activeGameObject = this.gameObject;
				continue;
				//We dont want loops
			}
			p.onStateChanged -= UpdateState;
		}

		inputBools = null;
	}
}
