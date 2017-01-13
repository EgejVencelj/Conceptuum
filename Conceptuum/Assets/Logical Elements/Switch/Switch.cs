using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Switch : BoolOutputElement {
	public void Toggle() {
        if (outputBool == null) outputBool = false;
		outputBool = !outputBool;
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

