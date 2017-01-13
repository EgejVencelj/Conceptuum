using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;

public class NodeSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

/*
[CustomEditor(typeof(NodeSystem))]
public class MySystemEditor : Editor {
	public override void OnInspectorGUI() {
		base.OnInspectorGUI();
		NodeSystem s = (NodeSystem)target;

		Component[] nodes = s.GetComponentsInChildren(typeof(Node));

		if(GUILayout.Button("Update Wires")) {
			foreach(Component n in nodes) {
				(n as Node).UpdateWires();
			}
		}
	}
}
*/