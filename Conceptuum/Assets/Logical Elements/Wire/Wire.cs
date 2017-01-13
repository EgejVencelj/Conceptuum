using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour {

    public GameObject inputBool;	

	void Update () {
        if (inputBool) {
            GetComponent<BoolOutputElement>().outputBool = inputBool.GetComponent<BoolOutputElement>().outputBool;
            GetComponent<MeshRenderer>().materials[0].color = Color.red;
        }
    }
}
