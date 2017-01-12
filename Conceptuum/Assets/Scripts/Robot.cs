using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour {
	public AnimationCurve Curve;
	Vector3 startPos;
	public float duration = 2;
	float t = 0;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		t = (t + Time.deltaTime) % duration;
		transform.position = startPos + new Vector3(0, Curve.Evaluate(t / duration), 0);
	}
}
