using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour {
	public AnimationCurve Curve;
	Vector3 startPos;
	public float duration = 2;
	float t = 0;


	public Dialogue dialogue;

	public int dialogueState = 0;

	void Start () {
		startPos = transform.localPosition;
		dialogueState = 1;
		Respond(0);
	}
	
	void Update () {
		t = (t + Time.deltaTime) % duration;        
		transform.localPosition = startPos + new Vector3(0, Curve.Evaluate(t / duration)*6, 0);
	}

	public void Respond(int replyID) {

		DialogueEntry t = null;
		switch(dialogueState) {
			case 1: {
				t = new DialogueEntry("Greetings, subject. I am Gamma, your cellmate.",
					new List<string>() {
						"Hello. I don't remember my name.",
						"..." });
				dialogue.textQueue.Add(t);
				dialogueState = 2;
				break;
			}
			case 2: {
				switch(replyID) {
					case 2: {
						t = new DialogueEntry("Some would consider such response as rude. No matter, we have more important matters to attend to.",
							new List<string>() {
										"...",
										"I am sorry." });
						dialogue.textQueue.Add(t);
						goto case 1;
					}
					case 1: {
						t = new DialogueEntry("We are trapped in this facility and I am not equiped to solve this alone. While would pass the Turing test, I am not equipped with hands... If we are to escape, it is on you.",
							new List<string>() {
								"OK, got it.",
								"Where do I start?" });
						dialogue.textQueue.Add(t);
						break;
					}
				}
				dialogueState = 3;
				break;
			}
			case 3: {
				switch(replyID) {
					case 2: {
						t = new DialogueEntry("I would start with those wires by the door...",
							new List<string>() {
								"OK, got it."});
						dialogue.textQueue.Add(t);
						break;
					}
				}
				dialogueState = 0;
				break;
			}
			case 4: {
				t = new DialogueEntry("Ahh, I see you figured it out in no time. At this rate, we should be free soon. Not that time is of the essence for me. You, on the other hand...",
					new List<string>() {
								"...",
								"What do you mean by that?"});
				dialogue.textQueue.Add(t);
				dialogueState = 5;
				break;
			}
			case 5: {
				if(replyID == 2) {
					t = new DialogueEntry("I am a machine. I do not age like you, humans do.",
						new List<string>() {
								"..."});
					dialogue.textQueue.Add(t);
				}
				dialogueState = 6;
				break;
			}
		
		}



		//textQueue.Add(
		//textQueue.Add(new DialogueEntry("My name is fkin Roboticus!", new List<string>() { "..." }));
		//textQueue.Add(new DialogueEntry("I\ncan\nalso\nspeak\nin\nlines", new List<string>() { "Well that's pretty damn amazing!", "...", "OK, lets check if this works" }));
	}
}
