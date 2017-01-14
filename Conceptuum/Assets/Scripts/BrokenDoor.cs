using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenDoor : BoolOutputElement {
	public Animator anim;

	public BoolOutputElement inputBool;
	public DialogueTrigger dt;

	void Start() {
		if(inputBool) {
			inputBool.onStateChanged += UpdateState;
		}
	}

	void UpdateState() {

		if(inputBool.outputBool is bool && (bool)inputBool.outputBool) {
			anim.SetTrigger("Open");
			GetComponent<BoxCollider>().enabled = false;
			StartCoroutine(EndDialogue());
		} else {
			anim.ResetTrigger("Open");
			GetComponent<BoxCollider>().enabled = true;
		}
	}

	IEnumerator EndDialogue() {
		yield return new WaitForSeconds(6f);
		outputBool = true;
	}

}
