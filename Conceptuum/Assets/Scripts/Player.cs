using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject chipInHand = null;
    GameObject hand;

    private void Start() {
        hand = GameObject.FindGameObjectWithTag("Hand");      
    }

    
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            if (Physics.Raycast(ray, out hit)) {                
                Transform objectHit = hit.transform;

                Debug.Log(objectHit.tag);

                switch (objectHit.tag) {
                    case "Switch":
                        objectHit.GetComponent<Switch>().Toggle();
                        break;
                    case "Chip":
                    case "Socket":
                        everythingButDrop(objectHit);
                        break;
                    default:
                        dropChip();
                        break;
                }

            }
        }
    }






    void pickChipInHand(Transform chipTransform) {
        if (chipInHand) return; //can't carry more than one

        this.chipInHand = chipTransform.gameObject;        

        chipTransform.parent = hand.transform;
        chipTransform.localScale = Vector3.one;
        chipTransform.localRotation = Quaternion.Euler(Vector3.zero);
        chipTransform.localPosition = Vector3.zero;

        chipTransform.GetComponent<Rigidbody>().isKinematic = true;
    }


    void everythingButDrop(Transform t) {
        Transform chipTransform = null;
        Transform socketTransform = null;
        Chip chip = null;
        Socket socket = null;

        if ((t.tag.Equals("Chip") && t.GetComponent<Chip>().attachedSocket) || //selecting chip attached to socket
            (t.tag.Equals("Socket") && t.GetComponent<Socket>().attachedChip)) { //selecting socket attached to chip (both times detaching is in order)  
            if (t.tag.Equals("Chip")){
                chipTransform = t;
                chip = chipTransform.GetComponent<Chip>();
                socketTransform = chip.attachedSocket.transform;
                socket = socketTransform.GetComponent<Socket>();
            } else {
                socketTransform = t;
                socket = socketTransform.GetComponent<Socket>();
                chipTransform = socket.attachedChip.transform;
                chip = chipTransform.GetComponent<Chip>();
            }
            if (!chipInHand && !socket.epoxied) {
				chip.Unattach();
                pickChipInHand(chip.transform);
            } 
        } else if (t.tag.Equals("Chip")) { //picking chip in hand
            pickChipInHand(t);
        } else { //attaching chip to socket
            socketTransform = t;
            socket = socketTransform.GetComponent<Socket>();           

            if (chipInHand && !socket.attachedChip) {
                chipInHand.transform.parent = socketTransform;
                chipInHand.transform.localScale = Vector3.one;
                chipInHand.transform.localRotation = Quaternion.Euler(Vector3.zero);
                chipInHand.transform.localPosition = Vector3.zero;

                chip = chipInHand.GetComponent<Chip>();
                chip.Attach(socket);
                chipInHand = null;
            }
        }      
    }

    void dropChip() {
        if (chipInHand) {            
            hand.transform.DetachChildren();
            chipInHand.GetComponent<Rigidbody>().isKinematic = false;
            chipInHand = null;
        }
    }

   



}
