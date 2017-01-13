using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireNode : MonoBehaviour {
	public Wire parent;
	public WireNode from;
	public GameObject wire;

	public void UpdateWires() {
		if(wire != null) {
			DestroyImmediate(wire);
		}
		if(from != null) {

			wire = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
			wire.transform.parent = parent.transform;
			wire.transform.position = (transform.position + from.transform.position) / 2.0f;
			wire.transform.rotation = Quaternion.FromToRotation(Vector3.up, transform.position - from.transform.position);

			var v3T = wire.transform.localScale;      // Scale it
			v3T.y = (transform.position - from.transform.position).magnitude / 2;
			v3T.x = 0.05f;
			v3T.z = 0.05f;
			wire.transform.localScale = v3T;
		}
	}
}
