using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

using System.Linq;


public class Chip : BoolOutputElement {

    public Material andMaterial;
    public Material orMaterial;
    public Material xorMaterial;


    public enum ChipType {
		AND=0,
		OR=1,
		XOR=2
	}
	

	public Socket attachedSocket;
    public GameObject hand;



	public ChipType chipType = ChipType.AND;

	public List<BoolOutputElement> inputBools;


	void Start() {
        var mr = transform.FindChild("ChipModel").GetComponent<Renderer>();
        switch (chipType) {
            case ChipType.AND:               
                mr.material = andMaterial;
                break;
            case ChipType.OR:
                mr.material = orMaterial;
                break;
            case ChipType.XOR:
                mr.material = xorMaterial;
                break;
        }

        GetComponentInChildren<MeshFilter>().mesh.uv = new[] {  
            new Vector2(-1, -1),new Vector2(-1, -1),new Vector2(-1, -1),new Vector2(-1, -1),
            new Vector2(1, 0),new Vector2(0, 0),new Vector2(-1, -1), new Vector2(-1, -1),
            new Vector2(1, 1),new Vector2(0, 1),new Vector2(-1, -1), new Vector2(-1, -1),
            new Vector2(-1, -1),new Vector2(-1, -1),new Vector2(-1, -1), new Vector2(-1, -1),
            new Vector2(-1, -1),new Vector2(-1, -1),new Vector2(-1, -1), new Vector2(-1, -1),
            new Vector2(-1, -1),new Vector2(-1, -1),new Vector2(-1, -1), new Vector2(-1, -1)
        };


        if (attachedSocket != null) {
			Attach(attachedSocket);
		}
	}


	void UpdateState () {
		if (attachedSocket) {
			bool? r = null;

			int n = attachedSocket.inputBools.Count;

			if (n >= 2) {
				r = Logic(
						inputBools[0].outputBool,
						inputBools[1].outputBool
					);
				for(int i = 2; i<n; i++) {
					r = Logic(r, inputBools[i].outputBool);
				}
			}

			attachedSocket.GetComponent<BoolOutputElement>().outputBool = r;	
		}
	}

	private bool? Logic(bool? a, bool? b) {
        if (a == null || b == null) return null;

        var aa = (bool)a;
        var bb = (bool)b;


		switch(chipType) {
			case ChipType.AND: {
				return aa && bb;
			}
			case ChipType.OR: {
				return aa || bb;
			}
			case ChipType.XOR: {
				return aa ^ bb;
			}
            default:
                return null;                
		}

     		
	}

	public void Attach(Socket s) {
        GetComponent<Rigidbody>().isKinematic = true;
		attachedSocket = s;
		s.attachedChip = gameObject;
		inputBools = s.inputBools;

		//Se prijavimo na state change parentov
		foreach(BoolOutputElement p in inputBools) {
			if(p.transform == this.transform) {
#if UNITY_EDITOR
				Debug.LogError("Detected infinite loop on selected chip.");
				Selection.activeGameObject = this.gameObject;
#endif
				continue;
				//We dont want loops
			}
            if(p) {
                p.onStateChanged += UpdateState;
            }
		}
		UpdateState();
	}

	public void Unattach() {
		//Se odjavimo
		foreach(BoolOutputElement p in inputBools) {
            if (p) {
                if (p.transform == this.transform) {
#if UNITY_EDITOR
                    Debug.LogError("Detected infinite loop on selected chip.");
                    Selection.activeGameObject = this.gameObject;
#endif
                    continue;
                    //We dont want loops
                }
                p.onStateChanged -= UpdateState;
            }
			
		}
		if(attachedSocket != null) {
			attachedSocket.GetComponent<BoolOutputElement>().outputBool = null;
			attachedSocket.attachedChip = null;
			attachedSocket = null;
		}

		inputBools = null;
	}
}
