using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHub : MonoBehaviour {

	public static bool ignite = false;
	public static bool hasIgnited = false;

	void Awake () {
		if (ignite && !hasIgnited) {
			AliceDialogue.Advance ();
			hasIgnited = true;
		}
	}

}
