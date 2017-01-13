using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Chip : MonoBehaviour {   

    public enum ChipType {
        AND=0,
        OR=1,
        XOR=2
    }
    

    public GameObject attachedSocket;
    public ChipType chipType = ChipType.AND;

    void Start() {
        //nalep teksturo na podlagi chipTypa
    }


    void Update () {
        if (attachedSocket) {
            var r = false; 
            var a = false;
            var b = false;
            var s = attachedSocket.GetComponent<Socket>();
            if (s.inputBools.Length >= 2) {
                a = s.inputBools[0].GetComponent<BoolOutputElement>().outputBool;
                b = s.inputBools[1].GetComponent<BoolOutputElement>().outputBool;
            }

            switch (chipType) {
                case ChipType.AND:
                    r = a && b;
                    break;
                case ChipType.OR:
                    r = a || b;
                    break;
                case ChipType.XOR:
                    r = a ^ b;
                    break;
            }
            attachedSocket.GetComponent<BoolOutputElement>().outputBool = r;
        }
    }
}
