using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1 : MonoBehaviour {

	public static bool hasLoaded = false;

	void Awake () {
		if (!hasLoaded) {
			AliceDialogue.Advance ();
		}
		hasLoaded = true;
	}
}
