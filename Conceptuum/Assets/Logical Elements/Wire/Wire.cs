using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Wire : BoolOutputElement {
	public List<WireNode> nodes;
	public BoolOutputElement inputBool;
	Color c;

	void Start() {
		c = Color.blue;

		if(inputBool) {
			inputBool.onStateChanged += UpdateState;
		}
	}


	void UpdateState() {
		outputBool = inputBool.outputBool;
		if (inputBool.outputBool == null) {
			c = Color.gray;
		} else if ((bool)inputBool.outputBool) {
			c = Color.green;
		} else {
			c = Color.red;
		}
		foreach(WireNode n in nodes) {
			if(n.wire != null) {
				n.wire.GetComponent<MeshRenderer>().materials[0].color = c;
			}
		}
	}
}
#if UNITY_EDITOR
[CustomEditor(typeof(Wire))]
public class WireEditor : Editor {
	public override void OnInspectorGUI() {
		base.OnInspectorGUI();
		Wire el = (Wire)target;

		if(GUILayout.Button("Add Node")) {

			List<WireNode> nodes = el.nodes;
			GameObject node = new GameObject("Node " + nodes.Count, typeof(WireNode));
			node.transform.parent = el.transform;
			if(el.nodes.Count > 0) {
				node.transform.position = el.nodes[el.nodes.Count - 1].transform.position;
			} else {
				node.transform.localPosition = Vector3.zero;
			}
			

			WireNode wn = node.GetComponent<WireNode>();
			if(el.nodes.Count > 0) {
				wn.from = el.nodes[el.nodes.Count - 1];
			}

			wn.parent = el;
			el.nodes.Add(wn);
		}

			if(GUILayout.Button("Remove Node")) {
				if(el.nodes.Count > 0) {
				WireNode wn = el.nodes[el.nodes.Count - 1];
				el.nodes.Remove(wn);
				DestroyImmediate(wn.gameObject);
			}
		}

		if(GUILayout.Button("Update Wires")) {
			foreach(WireNode n in el.nodes) {
				n.UpdateWires();
			}
		}
	}
}
#endif