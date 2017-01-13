using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LED : MonoBehaviour {

    public GameObject inputBool;

    void Start() {
        if (inputBool) {
            bool b = inputBool.GetComponent<BoolOutputElement>().outputBool;
            transform.GetComponentInChildren<Light>().enabled = b;
        }
    }

    void Update() {
        Start();
    }
}
