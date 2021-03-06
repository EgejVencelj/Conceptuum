﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {
	public Robot robot;
	public int dialogueState;
	public BoolOutputElement boolElement;

	void Start() {
		boolElement.onStateChanged += Trigger;
	}
	
	public void Trigger() {
		StartCoroutine(checkDelay());
	}

	IEnumerator checkDelay() {
		yield return new WaitForSeconds(0.1f);
		if(boolElement.outputBool == true) {
			boolElement.onStateChanged -= Trigger;
			robot.dialogueState = dialogueState;
			robot.Respond(0);
		}
	}
}
