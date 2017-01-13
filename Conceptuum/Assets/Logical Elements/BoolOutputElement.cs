using System.Collections;
using System.Collections.Generic;

using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class BoolOutputElement : MonoBehaviour {
	bool b = false;

	public delegate void OnStateChange();

	public OnStateChange onStateChanged;

	
	public bool outputBool {
		get {
			return b;
		}
		set {
			if(value != b) {
				b = value;
				onStateChanged();   //Automatic delegate call to update hierarchy
			}
		}
	}
	
	public void Toggle() {
		outputBool = !outputBool;
	}

	void Start() {
		onStateChanged += Demo;
	}

	void Demo() {
		Debug.Log("Mogoce pa vseeno dela?");
	}
}


#if UNITY_EDITOR
[CustomEditor(typeof(BoolOutputElement))]

public class MyBoolOutputElement : Editor {
	public override void OnInspectorGUI() {
		base.OnInspectorGUI();
		BoolOutputElement el = (BoolOutputElement)target;
		if(GUILayout.Button("Toggle")) {
			el.Toggle();
		}

	}
}
#endif
