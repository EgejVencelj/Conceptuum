using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : BoolOutputElement {
	public Animator anim;

	public BoolOutputElement inputBool;

	void Start() {
		if(inputBool) {
			inputBool.onStateChanged += UpdateState;
		}
	}

	void UpdateState() {
		outputBool = inputBool.outputBool;

		if(outputBool) {
			anim.SetTrigger("Open");
		}else {
			anim.ResetTrigger("Open");
		}
	}

}
