using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour {
	public AnimationCurve Curve;
	Vector3 startPos;
	public float duration = 2;
	float t = 0;


	void Start () {
		startPos = transform.localPosition;
	}
	
	void Update () {
		t = (t + Time.deltaTime) % duration;        
		transform.localPosition = startPos + new Vector3(0, Curve.Evaluate(t / duration)*6, 0);
	}
}
