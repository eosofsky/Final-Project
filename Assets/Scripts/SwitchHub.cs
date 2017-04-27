using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHub : MonoBehaviour {

	public static bool ignite = false;

	void Awake () {
		if (ignite) {
			AliceDialogue.Advance ();
		}
	}

}
