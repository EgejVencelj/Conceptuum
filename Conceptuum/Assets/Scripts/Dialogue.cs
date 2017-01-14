using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Dialogue : MonoBehaviour {
	public Text robotDialogue;
	public CanvasGroup holder;
	public RectTransform optionsHolder;
	public RectTransform optionPrefab;
	public Robot robot;

	public List<DialogueEntry> textQueue = new List<DialogueEntry>();

	bool busy = false;



	void Update() {
		if(textQueue.Count > 0 && !busy) {
			DialogueEntry str = textQueue[0];
			textQueue.RemoveAt(0);
			StartCoroutine(TypeText(str));
			
		}

		if(robotDialogue.text.Length > 0 && holder.alpha < 1) {
			holder.alpha += 0.05f;
		}
		if(robotDialogue.text.Length == 0 && holder.alpha > 0) {
			holder.alpha -= 0.05f;
		}
	}


	IEnumerator TypeText(DialogueEntry dialogue) {
		busy = true;
		robotDialogue.text = "";

		foreach(Transform o in optionsHolder.transform) {
			Destroy(o.gameObject);
		}

		foreach(char letter in dialogue.txt.ToCharArray()) {
			robotDialogue.text += letter;
			yield return new WaitForSeconds(0.01f);
		}
		

		int n = dialogue.responses.Count;
		for(int i = 0; i < n; i++) {
			yield return new WaitForSeconds(0.1f);
			string str = dialogue.responses[i];
			RectTransform response = Instantiate(optionPrefab, optionsHolder);
			response.transform.SetSiblingIndex(optionsHolder.childCount-1);
			Text opTxt = response.GetComponent<Text>();

			opTxt.text = string.Format("[{0}]: {1}", (i+1), str);
		}
		
		while(true) {
			if(n >= 1 && Input.GetKeyDown(KeyCode.Alpha1)) {
				robot.Respond(1);
				break;
			}
			if(n >= 2 && Input.GetKeyDown(KeyCode.Alpha2)) {
				robot.Respond(2);
				break;
			}
			if(n >= 3 && Input.GetKeyDown(KeyCode.Alpha3)) {
				robot.Respond(3);
				break;
			}
			if(n >= 4 && Input.GetKeyDown(KeyCode.Alpha4)) {
				robot.Respond(4);
				break;
			}
			yield return null;
		}
		busy = false;
		robotDialogue.text = "";
	}
}
