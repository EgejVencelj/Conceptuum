using System.Collections;
using System.Collections.Generic;

using UnityEngine;



public class BoolOutputElement : MonoBehaviour {
	bool b = false;

	public delegate void OnStateChange();

	public OnStateChange onStateChanged;

	
	public bool outputBool {
		get {
			return b;
		}
		set {
			if(value != b) {
				b = value;
				if(onStateChanged != null) {
					onStateChanged();   //Automatic delegate call to update hierarchy
				}
			}
		}
	}
	

}



