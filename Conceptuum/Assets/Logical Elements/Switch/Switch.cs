using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Switch : BoolOutputElement {
	public void Toggle() {
		if(outputBool == null) {
			outputBool = false;
		} else {
			outputBool = !outputBool;
		}
		var b = outputBool is bool && (bool)outputBool;
		transform.FindChild("Button").transform.localPosition = b ? new Vector3(0, 0.035f, 0) : new Vector3(0, 0.065f, 0); //fck gc
	}    
}

#if UNITY_EDITOR
[CustomEditor(typeof(Switch))]

public class SwitchEditor : Editor {
	public override void OnInspectorGUI() {
		base.OnInspectorGUI();
		Switch el = (Switch)target;

		//el.outputBool = EditorGUILayout.Toggle("Enabled", el.outputBool);

	}
}
#endif

