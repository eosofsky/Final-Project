using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWorlds : MonoBehaviour {

	public static bool physical = true;

	private static int physicalWorldMask;
	private static int digitalWorldMask;
	//private static bool hasLoaded = false;

	void Awake () {
		physicalWorldMask = Camera.main.cullingMask & ~(1 << LayerMask.NameToLayer("Digital World"));
		digitalWorldMask = Camera.main.cullingMask & ~(1 << LayerMask.NameToLayer("Physical World"));
		//if (!hasLoaded) {
			/* Start in physical world */
		//	showingPhysicalWorld = false;
		//}
		//hasLoaded = true;
		Switch (physical);
	}

	/*void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			Switch ();
		}
	}*/

	/* Pass in world to switch to */
	public void Switch (bool physical) {
		/* Disable old world's colliders */
		string tag = physical ? "DigitalWorld" : "PhysicalWorld";
		GameObject[] objs = GameObject.FindGameObjectsWithTag (tag);
		for (int i = 0; i < objs.Length; i++) {
			Collider collider = objs [i].GetComponent <Collider> ();
			if (collider) {
				collider.enabled = false;
			}
		}

		/* Enable new world's colliders */
		tag = physical ? "PhysicalWorld" : "DigitalWorld";
		objs = GameObject.FindGameObjectsWithTag (tag);
		for (int i = 0; i < objs.Length; i++) {
			Collider collider = objs [i].GetComponent <Collider> ();
			if (collider) {
				collider.enabled = true;
			}
		}
			
		/* Switch permissions on Alice.exe */
		if (physical) {
			Filesystem.canRun [0] = true;
		} else {	
			Filesystem.canRun [0] = false; 
		}

		/* Make other world invisible */
		Camera.main.cullingMask = physical ? physicalWorldMask : digitalWorldMask;
		//showingPhysicalWorld = !showingPhysicalWorld;
	}
}
