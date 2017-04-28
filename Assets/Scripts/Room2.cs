using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2 : MonoBehaviour {

	public static bool hasLoaded = false;

	void Awake () {
		if (!hasLoaded) {
			CatDialogue.Advance ();
		}
		hasLoaded = true;
	}
}
