using System.Collections;
using System.Collections.Generic;

using UnityEngine;



public class BoolOutputElement : MonoBehaviour {

    public override string ToString() {
        string s = " = N";
        if (b != null) s = (bool)b ? " = 1" : " = 0";
        return "--" + this.GetType().Name + s;
    }

    public bool? b = null;

	public delegate void OnStateChange();

	public OnStateChange onStateChanged;

	
	public bool? outputBool {
		get {
			return b;
		}
		set {
			if((value == null ^ b == null) || (value != null && b != null && (bool)value != (bool)b)) { 
				b = value;
				if(onStateChanged != null) {
					onStateChanged();   //Automatic delegate call to update hierarchy
				}
			}
		}
	}
	

}



