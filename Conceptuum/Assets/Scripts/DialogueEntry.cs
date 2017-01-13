using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEntry {
	public string txt;
	public List<string> responses;

	public DialogueEntry(string txt, List<string> responses) {
		this.txt = txt;
		this.responses = responses;
	}
}
