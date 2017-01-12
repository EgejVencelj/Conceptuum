using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Node : MonoBehaviour {
	public List<Node> from;
	public List<GameObject> wires;
	
	// Update is called once per frame
	public void UpdateWires () {
		if(wires.Count > 0) {
			foreach(GameObject wire in wires) {
				DestroyImmediate(wire);
			}
		}
		if(from.Count > 0) {
			foreach(Node source in from) {
				GameObject wire = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
				wire.transform.parent = transform;
				wire.transform.position = (transform.position + source.transform.position) / 2.0f;
				wire.transform.rotation = Quaternion.FromToRotation(Vector3.up, transform.position - source.transform.position);

				var v3T = wire.transform.localScale;      // Scale it
				v3T.y = (transform.position - source.transform.position).magnitude / 2;
				v3T.x = 0.1f;
				v3T.z = 0.1f;
				wire.transform.localScale = v3T;

				wires.Add(wire);
			}
		}		
	}
}


